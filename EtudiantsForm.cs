using Projet_C;
using Projet_C_.Resources;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Projet_C_
{
    public partial class EtudiantsForm : Form
    {
        private string connString = @"Data Source=LAPTOP-VHCQUHIA;Initial Catalog=uni_gestion;Integrated Security=True";
        private Form parentForm; // reference to InterfaceAdmin

        public EtudiantsForm(Form parent)
        {
            InitializeComponent();
            parentForm = parent;
            LoadEtudiants();
            dataGridEtudiants.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridEtudiants.MultiSelect = false;
        }

        private void LoadEtudiants()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM dbo.etudiants", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridEtudiants.DataSource = dt;
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
                    "INSERT INTO dbo.etudiants (CIN, Nom, Prenom, Phone, Email, Password) " +
                    "VALUES (@cin, @nom, @prenom, @phone, @email, @password)", conn);

                cmd.Parameters.AddWithValue("@cin", cin);
                cmd.Parameters.AddWithValue("@nom", nom);
                cmd.Parameters.AddWithValue("@prenom", prenom);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", password);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Étudiant ajouté avec succès !");
            txtCIN.ReadOnly = false; // Make it editable again for the next entry
            ClearFields();
            LoadEtudiants();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Use the text in txtCIN as the target, or the selected row
            string cinToDelete = txtCIN.Text.Trim();

            if (string.IsNullOrEmpty(cinToDelete))
            {
                MessageBox.Show("Veuillez sélectionner un étudiant (cliquez sur une ligne ou entrez le CIN).");
                return;
            }

            DialogResult result = MessageBox.Show($"Voulez-vous vraiment supprimer l'étudiant {cinToDelete} ? Cela supprimera aussi ses réservations.",
                "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    try
                    {
                        conn.Open();
                        // 1. Delete reservations first to avoid SQL errors
                        SqlCommand cmdRes = new SqlCommand("DELETE FROM dbo.reservations WHERE EtudiantCIN=@cin", conn);
                        cmdRes.Parameters.AddWithValue("@cin", cinToDelete);
                        cmdRes.ExecuteNonQuery();

                        // 2. Delete the student
                        SqlCommand cmdEtud = new SqlCommand("DELETE FROM dbo.etudiants WHERE CIN=@cin", conn);
                        cmdEtud.Parameters.AddWithValue("@cin", cinToDelete);

                        int rows = cmdEtud.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            MessageBox.Show("Étudiant supprimé avec succès !");
                            txtCIN.ReadOnly = false; // Reset so user can type a new CIN
                            ClearFields();
                        }
                        else
                        {
                            MessageBox.Show("Aucun étudiant trouvé avec ce CIN.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erreur lors de la suppression : " + ex.Message);
                    }
                }
                LoadEtudiants();
            }
        }

        private void dataGridEtudiants_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridEtudiants.Rows[e.RowIndex];

                txtCIN.Text = row.Cells["CIN"].Value.ToString();
                txtCIN.ReadOnly = true; // Lock the CIN so it can't be changed during modification

                txtNom.Text = row.Cells["Nom"].Value.ToString();
                txtPrenom.Text = row.Cells["Prenom"].Value.ToString();
                txtNumero.Text = row.Cells["Phone"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtPassword.Text = row.Cells["Password"].Value.ToString();
            }
        }

        private void btnBack_Click_1(object sender, EventArgs e)
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

        private void EtudiantsForm_Load(object sender, EventArgs e)
        {

        }
        // Call this inside Add, Modify, and Delete to keep the form clean
        private void ClearFields()
        {
            txtCIN.Clear();
            txtNom.Clear();
            txtPrenom.Clear();
            txtNumero.Clear();
            txtEmail.Clear();
            txtPassword.Clear();
        }

        // Move your Regex logic here to reuse it for both Add and Modify
        private bool ValidateInputs()
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtCIN.Text.Trim(), @"^\d{8}$"))
            {
                MessageBox.Show("CIN doit contenir exactement 8 chiffres.");
                return false;
            }
            // Add your other regex checks here...
            return true;
        }

        private void btnModify_Click_1(object sender, EventArgs e)
        {
            // Use the CIN from the textbox as the unique ID for the update
            string cin = txtCIN.Text.Trim();

            if (string.IsNullOrEmpty(cin))
            {
                MessageBox.Show("Sélectionnez un étudiant dans la liste.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE dbo.etudiants SET Nom=@nom, Prenom=@prenom, Phone=@phone, Email=@email, Password=@password WHERE CIN=@cin";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@cin", cin);
                    cmd.Parameters.AddWithValue("@nom", txtNom.Text.Trim());
                    cmd.Parameters.AddWithValue("@prenom", txtPrenom.Text.Trim());
                    cmd.Parameters.AddWithValue("@phone", txtNumero.Text.Trim());
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@password", txtPassword.Text.Trim());

                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                        MessageBox.Show("Modification réussie !");
                    else
                        MessageBox.Show("Aucun étudiant trouvé avec ce CIN.");

                    LoadEtudiants(); // Refresh the grid
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur SQL: " + ex.Message);
                }
            }
        }
    }
}
