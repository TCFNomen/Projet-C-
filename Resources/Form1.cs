using Projet_C;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projet_C_.Resources
{
    
    public partial class SettingsForm : Form
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ThemeManager.ApplyTheme(this);
        }
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login settings = new Login();
            settings.Show();
            this.Hide(); // hides login form
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Paramètres sauvegardés avec succès",
                  "Succès",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Information);
        }

        private void chkoui_CheckedChanged(object sender, EventArgs e)
        {
            ThemeManager.DarkMode = chkoui.Checked;

            foreach (Form form in Application.OpenForms)
            {
                ThemeManager.ApplyTheme(form);
            }
        }
    }
    public static class ThemeManager
    {

        public static bool DarkMode = true;

        public static Color BackColor => DarkMode ? Color.FromArgb(30, 30, 30) : Color.White;
        public static Color ForeColor => DarkMode ? Color.White : Color.Black;

        public static void ApplyTheme(Control control)
        {
            control.BackColor = BackColor;
            control.ForeColor = ForeColor;

            foreach (Control c in control.Controls)
            {
                ApplyTheme(c);
            }
        }
    }
}
