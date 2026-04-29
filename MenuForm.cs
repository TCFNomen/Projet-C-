using Projet_C;
using Projet_C_;
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
        private Form parentForm; // reference to InterfaceAdmin

        public MenuForm(Form parent)
        {
            InitializeComponent();
            parentForm = parent;
            LoadMenus();
        }

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
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM dbo.menu", conn);
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

        private void btn_Add_Click(object sender, EventArgs e)
        {
            string jour = txtJour.Text.Trim();
            string plat = txtPlat.Text.Trim();
            string dessert = txtDessert.Text.Trim();
            string boisson = txtBoisson.Text.Trim();
            string prixText = txtPrix.Text.Trim();

            // Validation
            if (!Regex.IsMatch(jour, @"^(0[1-9]|[12][0-9]|3[01])-(0[1-9]|1[0-2])-(\d{4})$"))
            {
                MessageBox.Show("Jour doit être au format DD-MM-YYYY.");
                return;
            }
            if (!Regex.IsMatch(prixText, @"^\d+([.,]\d{1,2})?$"))
            {
                MessageBox.Show("Prix invalide. Entrez un nombre (ex: 12,50).");
                return;
            }
            decimal prix = decimal.Parse(prixText.Replace(',', '.'));
            DateTime dateMenu = DateTime.ParseExact(jour, "dd-MM-yyyy", null);

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO dbo.menu (DateMenu, PlatPrincipal, Dessert, Boisson, Prix) " +
                    "VALUES (@jour, @plat, @dessert, @boisson, @prix)", conn);

                cmd.Parameters.AddWithValue("@jour", dateMenu);
                cmd.Parameters.AddWithValue("@plat", plat);
                cmd.Parameters.AddWithValue("@dessert", dessert);
                cmd.Parameters.AddWithValue("@boisson", boisson);
                cmd.Parameters.AddWithValue("@prix", prix);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Menu ajouté avec succès !");
            LoadMenus();
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (dataGridMenu.SelectedRows.Count > 0)
            {
                DateTime jour = Convert.ToDateTime(dataGridMenu.SelectedRows[0].Cells["DateMenu"].Value);

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM dbo.menu WHERE DateMenu=@jour", conn);
                    cmd.Parameters.AddWithValue("@jour", jour);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Menu supprimé !");
                LoadMenus();
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un menu à supprimer.");
            }
        }

        private void btn_Modify_Click(object sender, EventArgs e)
        {
            string jour = txtJour.Text.Trim();
            string plat = txtPlat.Text.Trim();
            string dessert = txtDessert.Text.Trim();
            string boisson = txtBoisson.Text.Trim();
            string prixText = txtPrix.Text.Trim();

            // Validation
            if (!Regex.IsMatch(jour, @"^(0[1-9]|[12][0-9]|3[01])-(0[1-9]|1[0-2])-(\d{4})$"))
            {
                MessageBox.Show("Jour doit être au format DD-MM-YYYY.");
                return;
            }
            if (!Regex.IsMatch(prixText, @"^\d+([.,]\d{1,2})?$"))
            {
                MessageBox.Show("Prix invalide. Entrez un nombre (ex: 12,50).");
                return;
            }
            decimal prix = decimal.Parse(prixText.Replace(',', '.'));
            DateTime dateMenu = DateTime.ParseExact(jour, "dd-MM-yyyy", null);

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "UPDATE dbo.menu SET PlatPrincipal=@plat, Dessert=@dessert, Boisson=@boisson, Prix=@prix WHERE DateMenu=@jour", conn);

                cmd.Parameters.AddWithValue("@jour", dateMenu);
                cmd.Parameters.AddWithValue("@plat", plat);
                cmd.Parameters.AddWithValue("@dessert", dessert);
                cmd.Parameters.AddWithValue("@boisson", boisson);
                cmd.Parameters.AddWithValue("@prix", prix);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Menu modifié avec succès !");
            LoadMenus();
        }

        private void btn_Back_Click(object sender, EventArgs e)
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

        private void dataGridMenu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // ignore header row
            {
                DataGridViewRow row = dataGridMenu.Rows[e.RowIndex];

                txtJour.Text = Convert.ToDateTime(row.Cells["DateMenu"].Value).ToString("dd-MM-yyyy");
                txtPlat.Text = row.Cells["PlatPrincipal"].Value.ToString();
                txtDessert.Text = row.Cells["Dessert"].Value.ToString();
                txtBoisson.Text = row.Cells["Boisson"].Value.ToString();
                txtPrix.Text = row.Cells["Prix"].Value.ToString();
            }
        }
    }
}
