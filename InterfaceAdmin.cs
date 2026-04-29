using Projet_C_;
using Projet_C_.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projet_C
{
    public partial class InterfaceAdmin : Form
    {
        public InterfaceAdmin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_AddEmp_Click(object sender, EventArgs e)
        {

        }

        private void btn_AddUser_Click(object sender, EventArgs e)
        {

        }

        private void btn_ConsEtu_Click(object sender, EventArgs e)
        {
            EtudiantsForm etuForm = new EtudiantsForm(this);
            etuForm.Show();
            this.Hide();
        }
        private void btn_ConsEmp_Click(object sender, EventArgs e)
        {
            EmployeesForm empForm = new EmployeesForm(this); // pass reference
            empForm.Show();
            this.Hide(); // hide admin dashboard while employees form is open
        }

        private void btn_ModUser_Click(object sender, EventArgs e)
        {

        }

        private void btn_DeleteUser_Click(object sender, EventArgs e)
        {

        }

        private void btn_ModRoles_Click(object sender, EventArgs e)
        {

        }

        private void InterfaceAdmin_Load(object sender, EventArgs e)
        {

        }

        private void btn_addMenu_Click(object sender, EventArgs e)
        {
            MenuForm menuForms = new MenuForm(this);
            menuForms.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SettingsForm settings = new SettingsForm();
            settings.Show();
            this.Hide(); // hides login form
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide(); //hiding login page in order for the new page to show up
        }
    }
}
