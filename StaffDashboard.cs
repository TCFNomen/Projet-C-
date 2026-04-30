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
        private string personnelCIN; // passed from Login

        public StaffDashboard(string cin)
        {
            InitializeComponent();
            personnelCIN = cin;
            LoadStaffData();
        }

        private void LoadStaffData()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "SELECT CIN, Nom, Prenom, Phone, Email, Poste, Password, Salary " +
                    "FROM dbo.personnels WHERE CIN=@cin", conn);

                cmd.Parameters.AddWithValue("@cin", personnelCIN);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridStaff.DataSource = dt;
                StyleDataGrid(dataGridStaff);
            }
        }

        private void StyleDataGrid(DataGridView grid)
        {
            grid.BorderStyle = BorderStyle.None;
            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            grid.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            grid.BackgroundColor = Color.White;

            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }

        private void btn_SignOut_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide(); //hiding login page in order for the new page to show up
        }
    }
}
