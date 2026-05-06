using Projet_C_;
using Projet_C_.Resources;
using System;
using System.Configuration;   // Needed for ConfigurationManager
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Projet_C
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Empty
         
        
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Empty
        }

        private void label2_Click(object sender, EventArgs e)
        {
            // Empty
        }

        private void label5_Click(object sender, EventArgs e)
        {
            // Empty
        }

        private void cin_TextChanged(object sender, EventArgs e)
        {
            // Empty
        }

        private void password_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            // Empty
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            string carte_id = cin.Text.Trim();   // textbox for CIN
            string mdp = password.Text.Trim();   // textbox for password

            string connString = @"Data Source=LAPTOP-VHCQUHIA;Initial Catalog=uni_gestion;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    // 1. Admin
                    if (CheckCredentials(conn, "dbo.admin", "CIN", "Password", carte_id, mdp))
                    {
                        MessageBox.Show("Login successful (Admin)");
                        InterfaceAdmin adminForm = new InterfaceAdmin(); //Opening Interface
                        adminForm.Show();
                        this.Hide();
                        return;

                    }

                    // 2. Personnel → StaffDashboard
                    if (CheckCredentials(conn, "dbo.personnels", "CIN", "Password", carte_id, mdp))
                    {
                        MessageBox.Show("Login successful (Personnel)");
                        StaffDashboard staffForm = new StaffDashboard(carte_id);
                        staffForm.Show();
                        this.Hide(); //hiding login page in order for the new page to show up
                        return;
                    }

                    // 3. Etudiant → EtudiantsDashboard
                    if (CheckCredentials(conn, "dbo.etudiants", "CIN", "Password", carte_id, mdp))
                    {
                        MessageBox.Show("Login successful (Etudiant)");
                        EtudiantsDashboard etuForm = new EtudiantsDashboard(carte_id);
                        etuForm.Show();
                        this.Hide();
                        return;
                    }

                    // If none matched
                    MessageBox.Show("Données invalides");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur de connexion: " + ex.Message);
                }
            }
        }

        private bool CheckCredentials(SqlConnection conn, string tableName, string idColumn, string pwdColumn, string id, string password)
        {
            string query = $"SELECT COUNT(*) FROM {tableName} WHERE {idColumn}=@id AND {pwdColumn}=@mdp";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@mdp", password);

                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            // Empty
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SettingsForm settings = new SettingsForm();
            settings.Show();
            this.Hide(); // hides login form
        }
        
    }
}
