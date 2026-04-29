using Projet_C;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Projet_C
{
    public partial class EmployeesForm : Form
    {
        private string connString = @"Data Source=LAPTOP-VHCQUHIA;Initial Catalog=uni_gestion;Integrated Security=True";
        private Form parentForm; // reference to InterfaceAdmin

        public EmployeesForm(Form parent)
        {
            InitializeComponent();
            parentForm = parent;
            LoadEmployees();
        }

        public EmployeesForm()
        {
            InitializeComponent();
            LoadEmployees();
        }

        private void LoadEmployees()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM dbo.personnels", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridEmployees.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur de chargement: " + ex.Message);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string cin = txtCIN.Text.Trim();
            string nom = txtNom.Text.Trim();
            string prenom = txtPrenom.Text.Trim();
            string phone = txtNumero.Text.Trim();
            string email = txtEmail.Text.Trim();
            string poste = txtPoste.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Validation
            if (!System.Text.RegularExpressions.Regex.IsMatch(cin, @"^\d{8}$"))
            {
                MessageBox.Show("CIN doit contenir exactement 8 chiffres.");
                return;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(phone, @"^\d{8}$"))
            {
                MessageBox.Show("Numéro doit contenir exactement 8 chiffres.");
                return;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(email, @"^[^@\s]+@gmail\.com$"))
            {
                MessageBox.Show("Email doit être au format something@gmail.com.");
                return;
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Veuillez entrer un mot de passe.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO dbo.personnels (CIN, Nom, Prenom, Phone, Email, Poste, Password) " +
                    "VALUES (@cin, @nom, @prenom, @phone, @email, @poste, @password)", conn);

                cmd.Parameters.AddWithValue("@cin", cin);
                cmd.Parameters.AddWithValue("@nom", nom);
                cmd.Parameters.AddWithValue("@prenom", prenom);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@poste", poste);
                cmd.Parameters.AddWithValue("@password", password);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Employé ajouté avec succès !");
            LoadEmployees();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridEmployees.SelectedRows.Count > 0)
            {
                string cin = dataGridEmployees.SelectedRows[0].Cells["CIN"].Value.ToString();

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM dbo.personnels WHERE CIN=@cin", conn);
                    cmd.Parameters.AddWithValue("@cin", cin);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Employé supprimé !");
                LoadEmployees();
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un employé à supprimer.");
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            string cin = txtCIN.Text.Trim();
            string nom = txtNom.Text.Trim();
            string prenom = txtPrenom.Text.Trim();
            string phone = txtNumero.Text.Trim();
            string email = txtEmail.Text.Trim();
            string poste = txtPoste.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Validation
            if (!System.Text.RegularExpressions.Regex.IsMatch(cin, @"^\d{8}$"))
            {
                MessageBox.Show("CIN doit contenir exactement 8 chiffres.");
                return;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(phone, @"^\d{8}$"))
            {
                MessageBox.Show("Numéro doit contenir exactement 8 chiffres.");
                return;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(email, @"^[^@\s]+@gmail\.com$"))
            {
                MessageBox.Show("Email doit être au format something@gmail.com.");
                return;
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Veuillez entrer un mot de passe.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "UPDATE dbo.personnels SET Nom=@nom, Prenom=@prenom, Phone=@phone, Email=@email, Poste=@poste, Password=@password WHERE CIN=@cin", conn);

                cmd.Parameters.AddWithValue("@cin", cin);
                cmd.Parameters.AddWithValue("@nom", nom);
                cmd.Parameters.AddWithValue("@prenom", prenom);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@poste", poste);
                cmd.Parameters.AddWithValue("@password", password);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Employé modifié avec succès !");
            LoadEmployees();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (parentForm != null)
            {
                parentForm.Show();
            }
            else
            {
                InterfaceAdmin admin = new InterfaceAdmin();
                admin.Show();
            }
        }

        private void dataGridEmployees_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridEmployees.Rows[e.RowIndex];

                txtCIN.Text = row.Cells["CIN"].Value.ToString();
                txtNom.Text = row.Cells["Nom"].Value.ToString();
                txtPrenom.Text = row.Cells["Prenom"].Value.ToString();
                txtNumero.Text = row.Cells["Phone"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtPoste.Text = row.Cells["Poste"].Value.ToString();
                txtPassword.Text = row.Cells["Password"].Value.ToString();
            }
        }
        private void dataGridEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // ignore header row
            {
                DataGridViewRow row = dataGridEmployees.Rows[e.RowIndex];

                txtCIN.Text = row.Cells["CIN"].Value.ToString();
                txtNom.Text = row.Cells["Nom"].Value.ToString();
                txtPrenom.Text = row.Cells["Prenom"].Value.ToString();
                txtNumero.Text = row.Cells["Phone"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtPoste.Text = row.Cells["Poste"].Value.ToString();
                txtPassword.Text = row.Cells["Password"].Value.ToString();
            }
        }

    }
}
