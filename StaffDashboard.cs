using Projet_C;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Projet_C_
{
    public partial class StaffDashboard : Form
    {
        private string connString = @"Data Source=LAPTOP-VHCQUHIA;Initial Catalog=uni_gestion;Integrated Security=True";
        private string personnelCIN;
        private int currentSolde = 0; // Local variable to track remaining days

        public StaffDashboard(string cin)
        {
            InitializeComponent();
            personnelCIN = cin;
            LoadProfile();
            LoadVacationHistory();
        }

        private void LoadProfile()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT Nom, Prenom, Phone, Email, Poste, Salary, SoldeConge FROM dbo.personnels WHERE CIN=@cin";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@cin", personnelCIN);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        lblWelcome.Text = $"Bienvenue, {reader["Prenom"]} {reader["Nom"]}";
                        lblEmail.Text = $"Email: {reader["Email"]}";
                        lblPhone.Text = $"Téléphone: {reader["Phone"]}";
                        lblPoste.Text = $"Poste: {reader["Poste"]}";

                        // --- SAFE NULL CHECKING ---
                        decimal salary = reader["Salary"] != DBNull.Value ? Convert.ToDecimal(reader["Salary"]) : 0;
                        lblSalary.Text = $"Salaire: {salary} DT";

                        // This is where your error was happening
                        currentSolde = reader["SoldeConge"] != DBNull.Value ? Convert.ToInt32(reader["SoldeConge"]) : 21;
                        lblSolde.Text = $"Solde restant: {currentSolde} jours";

                        lblSolde.ForeColor = currentSolde < 5 ? Color.Red : Color.DarkGreen;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur profil: " + ex.Message);
                }
            }
        }

        private void btnRequestVacation_Click(object sender, EventArgs e)
        {
            DateTime start = dtpStart.Value.Date;
            DateTime end = dtpEnd.Value.Date;

            // 1. Basic Date Validation
            if (start < DateTime.Today)
            {
                MessageBox.Show("La date de début ne peut pas être dans le passé.");
                return;
            }

            if (end < start)
            {
                MessageBox.Show("La date de fin doit être après la date de début.");
                return;
            }

            // Calculate total days requested
            int requestedDays = (end - start).Days + 1;

            // 2. Maximum Days Validation (21 days total)
            if (requestedDays > currentSolde)
            {
                MessageBox.Show($"Solde insuffisant ! Il ne vous reste que {currentSolde} jours, mais vous en demandez {requestedDays}.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    // 3. Conflict Check: Ensure dates do not overlap with existing vacations
                    string conflictQuery = @"
                SELECT COUNT(*) 
                FROM dbo.vacations 
                WHERE PersonnelCIN = @cin 
                AND Status <> 'Refusé'
                AND (
                    (@start BETWEEN DateDebut AND DateFin) OR 
                    (@end BETWEEN DateDebut AND DateFin) OR 
                    (DateDebut BETWEEN @start AND @end)
                )";

                    SqlCommand checkCmd = new SqlCommand(conflictQuery, conn);
                    checkCmd.Parameters.AddWithValue("@cin", personnelCIN);
                    checkCmd.Parameters.AddWithValue("@start", start);
                    checkCmd.Parameters.AddWithValue("@end", end);

                    int conflictCount = (int)checkCmd.ExecuteScalar();

                    if (conflictCount > 0)
                    {
                        MessageBox.Show("Erreur : Vous avez déjà un congé prévu ou en attente qui chevauche ces dates.");
                        return;
                    }

                    // 4. Execution with Transaction
                    SqlTransaction transaction = conn.BeginTransaction();
                    try
                    {
                        // Insert the new vacation request
                        string queryVac = "INSERT INTO dbo.vacations (PersonnelCIN, DateDebut, DateFin, NombreJours, Status) VALUES (@cin, @s, @e, @n, 'En attente')";
                        SqlCommand cmdVac = new SqlCommand(queryVac, conn, transaction);
                        cmdVac.Parameters.AddWithValue("@cin", personnelCIN);
                        cmdVac.Parameters.AddWithValue("@s", start);
                        cmdVac.Parameters.AddWithValue("@e", end);
                        cmdVac.Parameters.AddWithValue("@n", requestedDays);
                        cmdVac.ExecuteNonQuery();

                        // Deduct from the personnel balance
                        string queryUpd = "UPDATE dbo.personnels SET SoldeConge = SoldeConge - @n WHERE CIN=@cin";
                        SqlCommand cmdUpd = new SqlCommand(queryUpd, conn, transaction);
                        cmdUpd.Parameters.AddWithValue("@n", requestedDays);
                        cmdUpd.Parameters.AddWithValue("@cin", personnelCIN);
                        cmdUpd.ExecuteNonQuery();

                        transaction.Commit();

                        // Update local memory balance
                        currentSolde -= requestedDays;

                        MessageBox.Show($"Succès ! Demande de {requestedDays} jours enregistrée.");

                        // Refresh UI
                        lblSolde.Text = $"Solde restant: {currentSolde} jours";
                        lblSolde.ForeColor = currentSolde < 5 ? Color.Red : Color.DarkGreen;
                        LoadVacationHistory();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Erreur lors de la transaction : " + ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur de connexion : " + ex.Message);
                }
            }
        }

        private void LoadVacationHistory()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "SELECT DateDebut, DateFin, NombreJours, Status FROM dbo.vacations WHERE PersonnelCIN=@cin ORDER BY DateDebut DESC";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@cin", personnelCIN);

                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvVacationHistory.DataSource = dt;
            }
        }

        private void btn_SignOut_Click(object sender, EventArgs e)
        {
            new Login().Show();
            this.Hide();
        }
    }
}