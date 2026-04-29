using System;
using System.Data;
using System.Data.SqlClient;
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


        // ✅ Make a reservation
        private void btn_Res_Click(object sender, EventArgs e)
        {
            if (dataGridMenu.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner un menu.");
                return;
            }

            int menuId = Convert.ToInt32(dataGridMenu.SelectedRows[0].Cells["Id"].Value);
            DateTime today = DateTime.Today;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(
                        "INSERT INTO dbo.Reservations (EtudiantCIN, MenuId, DateReservation) VALUES (@cin, @menuId, @date)", conn);

                    cmd.Parameters.AddWithValue("@cin", etudiantCIN);
                    cmd.Parameters.AddWithValue("@menuId", menuId);
                    cmd.Parameters.AddWithValue("@date", today);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Réservation effectuée avec succès !");

                    // 🔥 Refresh reservations grid immediately
                    LoadReservations();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Erreur de réservation: " + ex.Message);
                }
            }
        }


        // ✅ Cancel a reservation
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            if (dataGridMenu.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner un menu à annuler.");
                return;
            }

            int menuId = Convert.ToInt32(dataGridMenu.SelectedRows[0].Cells["Id"].Value);
            DateTime today = DateTime.Today;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM dbo.Reservations WHERE EtudiantCIN=@cin AND MenuId=@menuId AND DateReservation=@date", conn);

                cmd.Parameters.AddWithValue("@cin", etudiantCIN);
                cmd.Parameters.AddWithValue("@menuId", menuId);
                cmd.Parameters.AddWithValue("@date", today);

                int rows = cmd.ExecuteNonQuery();
                MessageBox.Show(rows > 0 ? "Réservation annulée !" : "Aucune réservation trouvée pour ce menu aujourd'hui.");
            }
        }

        // ✅ Consult reservation history
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
    }
}
