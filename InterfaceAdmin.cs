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
        private void btn_addMenu_Click(object sender, EventArgs e)
        {
            MenuForm menuForms = new MenuForm(this);
            menuForms.Show();
            this.Hide();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide(); //hiding login page in order for the new page to show up
        }

        private void InterfaceAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {   
            Application.Exit(); // Ensure the entire application exits when admin dashboard is closed
        }
    }
}
