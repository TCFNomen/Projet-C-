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
        private int selectedMenuId = -1;

        public MenuForm(Form parent)
        {
            InitializeComponent();
            parentForm = parent;
            LoadMenus();
          
        }

        // Default constructor for standalone testing
        public MenuForm()
        {
            InitializeComponent();
            LoadMenus();
           
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
            if (!decimal.TryParse(txtPrix.Text.Replace(',', '.'), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out _))
            {
                MessageBox.Show("Prix invalide. Entrez un format numérique correct.");
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
            // Safety check: Did they actually select a row?
            if (selectedMenuId == -1)
            {
                MessageBox.Show("Veuillez d'abord sélectionner un menu dans la liste à modifier.");
                return;
            }

            if (!IsInputValid()) return;

            // Parse the price safely
            decimal prix;
            string cleanPrix = txtPrix.Text.Trim().Replace(',', '.');
            if (!decimal.TryParse(cleanPrix, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out prix))
            {
                MessageBox.Show("Prix invalide.");
                return;
            }

            DateTime dateMenu = DateTime.ParseExact(txtJour.Text.Trim(), "dd-MM-yyyy", null);

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    // THE FIX: We use WHERE Id = @id instead of DateMenu
                    string query = @"UPDATE dbo.menu 
                             SET DateMenu=@jour, 
                                 PlatPrincipal=@plat, 
                                 Dessert=@dessert, 
                                 Boisson=@boisson, 
                                 Prix=@prix 
                             WHERE Id=@id";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@id", selectedMenuId); // The specific row ID
                    cmd.Parameters.AddWithValue("@jour", dateMenu);
                    cmd.Parameters.AddWithValue("@plat", txtPlat.Text.Trim());
                    cmd.Parameters.AddWithValue("@dessert", txtDessert.Text.Trim());
                    cmd.Parameters.AddWithValue("@boisson", txtBoisson.Text.Trim());
                    cmd.Parameters.AddWithValue("@prix", prix);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Menu mis à jour avec succès !");
                        selectedMenuId = -1; // Reset selection
                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("Erreur : Le menu n'a pas pu être trouvé.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur SQL : " + ex.Message);
                }
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
            // 1. Check if the index is valid (not a header)
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridMenu.Rows[e.RowIndex];

                // 2. IMPORTANT: Check if the "Id" cell is null or empty
                // This prevents the error when clicking the empty/new row
                if (row.Cells["Id"].Value == null || row.Cells["Id"].Value == DBNull.Value)
                {
                    selectedMenuId = -1;
                    ClearFields();
                    return; // Stop here if the row is empty
                }

                // 3. Now it is safe to convert
                selectedMenuId = Convert.ToInt32(row.Cells["Id"].Value);

                // Fill textboxes
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