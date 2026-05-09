using Projet_C;
using Projet_C_.Resources;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace Projet_C_
{
    public partial class EtudiantsDashboard : Form
    {
        private string connString = @"Data Source=LAPTOP-VHCQUHIA;Initial Catalog=uni_gestion;Integrated Security=True";
        private string etudiantCIN; // student identifier passed at login
        public EtudiantsDashboard()
        {
            InitializeComponent();
            LoadTodayMenus();
        }
        public EtudiantsDashboard(string cin)
        {
            InitializeComponent();
            etudiantCIN = cin;
            LoadTodayMenus();
            UpdateStudentStats(); // Load their stats immediately
            GetStudentName();   // <--- Add this call
        }

        // Load today's menus into dataGridMenu
        private void LoadTodayMenus()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                // Show all menus (no filter)
                string query = @"
            SELECT Id, DateMenu, PlatPrincipal, Dessert, Boisson, Prix
            FROM dbo.Menu
            ORDER BY DateMenu DESC";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridMenu.DataSource = dt;
            }
        }

        private void LoadReservations()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT R.DateReservation, M.PlatPrincipal, M.Dessert, M.Boisson, M.Prix " +
                    "FROM dbo.Reservations R " +
                    "JOIN dbo.Menu M ON R.MenuId = M.Id " +
                    "WHERE R.EtudiantCIN=@cin ORDER BY R.DateReservation DESC", conn);

                da.SelectCommand.Parameters.AddWithValue("@cin", etudiantCIN);

                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridReservations.DataSource = dt;
            }
        }


        //  Make a reservation
        private void btn_Res_Click(object sender, EventArgs e)
        {
            if (dataGridMenu.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner un menu.");
                return;
            }

            int menuId = Convert.ToInt32(dataGridMenu.SelectedRows[0].Cells["Id"].Value);
            // Get the date of the menu selected, not just "Today"
            DateTime menuDate = Convert.ToDateTime(dataGridMenu.SelectedRows[0].Cells["DateMenu"].Value);

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    // --- CHECK IF RESERVATION EXISTS FOR THIS DATE ---
                    string checkQuery = "SELECT COUNT(*) FROM dbo.Reservations WHERE EtudiantCIN = @cin AND DateReservation = @date";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@cin", etudiantCIN);
                    checkCmd.Parameters.AddWithValue("@date", menuDate);

                    int count = (int)checkCmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Vous avez déjà une réservation pour cette date (" + menuDate.ToShortDateString() + ").");
                        return;
                    }

                    // --- PROCEED WITH INSERT ---
                    SqlCommand cmd = new SqlCommand(
                        "INSERT INTO dbo.Reservations (EtudiantCIN, MenuId, DateReservation) VALUES (@cin, @menuId, @date)", conn);

                    cmd.Parameters.AddWithValue("@cin", etudiantCIN);
                    cmd.Parameters.AddWithValue("@menuId", menuId);
                    cmd.Parameters.AddWithValue("@date", menuDate);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Réservation effectuée avec succès !");
                    LoadReservations();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Erreur: " + ex.Message);
                }
            }
        }


        //  Cancel a reservation
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            if (dataGridReservations.SelectedRows.Count == 0)
            {
                MessageBox.Show("Sélectionnez une réservation dans votre historique pour l'annuler.");
                return;
            }

            // Get the date from the selected reservation row
            DateTime resDate = Convert.ToDateTime(dataGridReservations.SelectedRows[0].Cells["DateReservation"].Value);

            // Optional: Prevent canceling past meals
            if (resDate < DateTime.Today)
            {
                MessageBox.Show("Vous ne pouvez pas annuler une réservation passée.");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Voulez-vous vraiment annuler cette réservation ?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    // Delete based on student and the specific date
                    string deleteQuery = "DELETE FROM dbo.Reservations WHERE EtudiantCIN = @cin AND DateReservation = @date";
                    SqlCommand cmd = new SqlCommand(deleteQuery, conn);
                    cmd.Parameters.AddWithValue("@cin", etudiantCIN);
                    cmd.Parameters.AddWithValue("@date", resDate);

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("Réservation annulée !");
                        LoadReservations(); // Refresh the list
                    }
                }
            }
        }

        //  Consult reservation history
        private void btn_Cons_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT R.DateReservation, M.PlatPrincipal, M.Dessert, M.Boisson, M.Prix " +
                    "FROM dbo.Reservations R " +
                    "JOIN dbo.Menu M ON R.MenuId = M.Id " +
                    "WHERE R.EtudiantCIN=@cin ORDER BY R.DateReservation DESC", conn);

                da.SelectCommand.Parameters.AddWithValue("@cin", etudiantCIN);

                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridReservations.DataSource = dt; // add a DataGridView named dataGridReservations
            }

            MessageBox.Show("Historique des réservations chargé !");
        }
        private void UpdateStudentStats()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    // SQL logic: COUNT rows for the count, SUM prices for the total
                    string query = @"SELECT COUNT(*) as TotalCount, SUM(M.Prix) as TotalPrice 
                             FROM dbo.Reservations R 
                             JOIN dbo.Menu M ON R.MenuId = M.Id 
                             WHERE R.EtudiantCIN = @cin";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@cin", etudiantCIN);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Handle cases where the student has 0 reservations (NULL)
                            int count = reader["TotalCount"] != DBNull.Value ? Convert.ToInt32(reader["TotalCount"]) : 0;
                            decimal total = reader["TotalPrice"] != DBNull.Value ? Convert.ToDecimal(reader["TotalPrice"]) : 0;

                            // Update the text on your Form
                            label_4.Text = $"Total réservations : {count}";
                            label_5.Text = $"Total dépensé : {total:f2} DT";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur stats: " + ex.Message);
                }
            }
        }

        private void btn_SignOut_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide(); //hiding login page in order for the new page to show up
        }

        private void btnExportHistory_Click(object sender, EventArgs e)
        {
            if (dataGridReservations.Rows.Count == 0)
            {
                MessageBox.Show("Aucun historique à exporter.");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Fichier CSV (*.csv)|*.csv";
            sfd.FileName = $"Historique_{etudiantCIN}.csv";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(sfd.FileName, false, System.Text.Encoding.UTF8))
                    {
                        // CSV Header
                        sw.WriteLine("Date;Plat Principal;Dessert;Boisson;Prix");

                        // Loop through the DataGridView rows
                        foreach (DataGridViewRow row in dataGridReservations.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                string date = Convert.ToDateTime(row.Cells["DateReservation"].Value).ToString("dd/MM/yyyy");
                                string plat = row.Cells["PlatPrincipal"].Value.ToString();
                                string dessert = row.Cells["Dessert"].Value.ToString();
                                string boisson = row.Cells["Boisson"].Value.ToString();
                                string prix = row.Cells["Prix"].Value.ToString();

                                sw.WriteLine($"{date};{plat};{dessert};{boisson};{prix}");
                            }
                        }
                    }
                    MessageBox.Show("Historique exporté avec succès !");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors de l'export : " + ex.Message);
                }
            }
        }
        private void GetStudentName()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT Nom, Prenom FROM dbo.etudiants WHERE CIN = @cin";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@cin", etudiantCIN);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        string nom = reader["Nom"].ToString();
                        string prenom = reader["Prenom"].ToString();

                        // Assuming your welcome label is named label_Welcome
                        // If it's the one in your screenshot, it says "Bienvenue chèr(e) étudiant(e)!"
                        label_Welcome.Text = $"Bienvenue, {prenom} {nom} !";
                    }
                }
                catch (Exception ex)
                {
                    // If it fails, we just keep the default text
                    Console.WriteLine("Erreur lors de la récupération du nom: " + ex.Message);
                }
            }
        }
    }
}
