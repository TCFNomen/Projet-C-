using Projet_C;
using Projet_C_.Resources;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Projet_C_
{
    public partial class MenuForm : Form
    {
        private string connString = @"Data Source=LAPTOP-VHCQUHIA;Initial Catalog=uni_gestion;Integrated Security=True";
        private Form parentForm;

        public MenuForm(Form parent)
        {
            InitializeComponent();
            parentForm = parent;
            LoadMenus();
            ThemeManager.ApplyTheme(this);
        }

        // Default constructor for standalone testing
        public MenuForm()
        {
            InitializeComponent();
            LoadMenus();
            ThemeManager.ApplyTheme(this);
        }

        private void LoadMenus()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM dbo.menu ORDER BY DateMenu DESC", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridMenu.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur de chargement: " + ex.Message);
                }
            }
        }

        // Helper method to validate inputs (prevents repeated code)
        private bool IsInputValid()
        {
            if (!Regex.IsMatch(txtJour.Text.Trim(), @"^(0[1-9]|[12][0-9]|3[01])-(0[1-9]|1[0-2])-(\d{4})$"))
            {
                MessageBox.Show("Le jour doit être au format DD-MM-YYYY.");
                return false;
            }
            if (!Regex.IsMatch(txtPrix.Text.Trim(), @"^\d+([.,]\d{1,2})?$"))
            {
                MessageBox.Show("Prix invalide. Entrez un nombre (ex: 12,50).");
                return false;
            }
            return true;
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (!IsInputValid()) return;

            decimal prix = decimal.Parse(txtPrix.Text.Trim().Replace(',', '.'));
            DateTime dateMenu = DateTime.ParseExact(txtJour.Text.Trim(), "dd-MM-yyyy", null);

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO dbo.menu (DateMenu, PlatPrincipal, Dessert, Boisson, Prix) " +
                    "VALUES (@jour, @plat, @dessert, @boisson, @prix)", conn);

                cmd.Parameters.AddWithValue("@jour", dateMenu);
                cmd.Parameters.AddWithValue("@plat", txtPlat.Text.Trim());
                cmd.Parameters.AddWithValue("@dessert", txtDessert.Text.Trim());
                cmd.Parameters.AddWithValue("@boisson", txtBoisson.Text.Trim());
                cmd.Parameters.AddWithValue("@prix", prix);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Menu ajouté avec succès !");
            LoadMenus();
        }

        private void btn_Modify_Click(object sender, EventArgs e)
        {
            if (!IsInputValid()) return;

            decimal prix = decimal.Parse(txtPrix.Text.Trim().Replace(',', '.'));
            DateTime dateMenu = DateTime.ParseExact(txtJour.Text.Trim(), "dd-MM-yyyy", null);

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "UPDATE dbo.menu SET PlatPrincipal=@plat, Dessert=@dessert, Boisson=@boisson, Prix=@prix " +
                    "WHERE DateMenu=@jour", conn);

                cmd.Parameters.AddWithValue("@jour", dateMenu);
                cmd.Parameters.AddWithValue("@plat", txtPlat.Text.Trim());
                cmd.Parameters.AddWithValue("@dessert", txtDessert.Text.Trim());
                cmd.Parameters.AddWithValue("@boisson", txtBoisson.Text.Trim());
                cmd.Parameters.AddWithValue("@prix", prix);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                    MessageBox.Show("Menu modifié avec succès !");
                else
                    MessageBox.Show("Aucun menu trouvé pour cette date à modifier.");
            }
            LoadMenus();
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtJour.Text))
            {
                MessageBox.Show("Veuillez sélectionner un menu dans la liste.");
                return;
            }

            // 1. Confirm with the Admin
            DialogResult result = MessageBox.Show("Attention : Supprimer ce menu supprimera également toutes les réservations des étudiants pour cette date. Continuer ?",
                                                "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    DateTime dateToDelete = DateTime.ParseExact(txtJour.Text.Trim(), "dd-MM-yyyy", null);

                    using (SqlConnection conn = new SqlConnection(connString))
                    {
                        conn.Open();

                        // 2. We need the Menu's ID to clear the reservations table first
                        SqlCommand getIdCmd = new SqlCommand("SELECT Id FROM dbo.menu WHERE DateMenu=@jour", conn);
                        getIdCmd.Parameters.AddWithValue("@jour", dateToDelete);
                        object resultId = getIdCmd.ExecuteScalar();

                        if (resultId != null)
                        {
                            int mId = Convert.ToInt32(resultId);

                            // 3. Delete reservations that depend on this MenuId
                            SqlCommand delRes = new SqlCommand("DELETE FROM dbo.reservations WHERE MenuId=@mid", conn);
                            delRes.Parameters.AddWithValue("@mid", mId);
                            delRes.ExecuteNonQuery();

                            // 4. Now delete the menu itself
                            SqlCommand delMenu = new SqlCommand("DELETE FROM dbo.menu WHERE Id=@mid", conn);
                            delMenu.Parameters.AddWithValue("@mid", mId);
                            delMenu.ExecuteNonQuery();

                            MessageBox.Show("Menu et réservations supprimés !");
                        }
                        else
                        {
                            MessageBox.Show("Menu introuvable dans la base de données.");
                        }
                    }

                    LoadMenus(); // Refresh grid
                    ClearFields(); // Empty textboxes
                }
                catch (Exception ex)
                {
                    // Showing the real error helps us debug (e.g., connection issues or formatting)
                    MessageBox.Show("Erreur lors de la suppression : " + ex.Message);
                }
            }
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (parentForm != null)
                parentForm.Show();
            else
                new InterfaceAdmin().Show();
        }

        private void dataGridMenu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridMenu.Rows[e.RowIndex];

                if (row.Cells["DateMenu"].Value != DBNull.Value)
                    txtJour.Text = Convert.ToDateTime(row.Cells["DateMenu"].Value).ToString("dd-MM-yyyy");

                txtPlat.Text = row.Cells["PlatPrincipal"].Value?.ToString();
                txtDessert.Text = row.Cells["Dessert"].Value?.ToString();
                txtBoisson.Text = row.Cells["Boisson"].Value?.ToString();
                txtPrix.Text = row.Cells["Prix"].Value?.ToString();
            }
        }
        private void ClearFields()
        {
            txtJour.Clear();
            txtPlat.Clear();
            txtDessert.Clear();
            txtBoisson.Clear();
            txtPrix.Clear();
        }
    }
}