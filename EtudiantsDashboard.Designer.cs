namespace Projet_C_
{
    partial class EtudiantsDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_Res = new System.Windows.Forms.Button();
            this.label_Welcome = new System.Windows.Forms.Label();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_Cons = new System.Windows.Forms.Button();
            this.dataGridMenu = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridReservations = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btn_SignOut = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExportHistory = new System.Windows.Forms.Button();
            this.label_4 = new System.Windows.Forms.Label();
            this.label_5 = new System.Windows.Forms.Label();
            this.lblTotalReservations = new System.Windows.Forms.Label();
            this.lblTotalSpent = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridReservations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Res
            // 
            this.btn_Res.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Res.Location = new System.Drawing.Point(10, 23);
            this.btn_Res.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Res.Name = "btn_Res";
            this.btn_Res.Padding = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.btn_Res.Size = new System.Drawing.Size(195, 60);
            this.btn_Res.TabIndex = 0;
            this.btn_Res.Text = "Réserver un repas";
            this.btn_Res.UseVisualStyleBackColor = true;
            this.btn_Res.Click += new System.EventHandler(this.btn_Res_Click);
            // 
            // label_Welcome
            // 
            this.label_Welcome.AutoSize = true;
            this.label_Welcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Welcome.Location = new System.Drawing.Point(62, 95);
            this.label_Welcome.Name = "label_Welcome";
            this.label_Welcome.Size = new System.Drawing.Size(215, 16);
            this.label_Welcome.TabIndex = 1;
            this.label_Welcome.Text = "Bienvenue chèr(e) étudiant(e)!";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cancel.Location = new System.Drawing.Point(10, 87);
            this.btn_Cancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Padding = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.btn_Cancel.Size = new System.Drawing.Size(195, 60);
            this.btn_Cancel.TabIndex = 2;
            this.btn_Cancel.Text = "Annuler une réservation";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_Cons
            // 
            this.btn_Cons.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cons.Location = new System.Drawing.Point(10, 151);
            this.btn_Cons.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Cons.Name = "btn_Cons";
            this.btn_Cons.Padding = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.btn_Cons.Size = new System.Drawing.Size(195, 60);
            this.btn_Cons.TabIndex = 3;
            this.btn_Cons.Text = "Consulter mes réservations";
            this.btn_Cons.UseVisualStyleBackColor = true;
            this.btn_Cons.Click += new System.EventHandler(this.btn_Cons_Click);
            // 
            // dataGridMenu
            // 
            this.dataGridMenu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridMenu.Location = new System.Drawing.Point(407, 76);
            this.dataGridMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridMenu.Name = "dataGridMenu";
            this.dataGridMenu.RowHeadersWidth = 51;
            this.dataGridMenu.RowTemplate.Height = 24;
            this.dataGridMenu.Size = new System.Drawing.Size(951, 190);
            this.dataGridMenu.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(404, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Menu de la semaine:";
            // 
            // dataGridReservations
            // 
            this.dataGridReservations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridReservations.Location = new System.Drawing.Point(407, 339);
            this.dataGridReservations.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridReservations.Name = "dataGridReservations";
            this.dataGridReservations.RowHeadersWidth = 51;
            this.dataGridReservations.RowTemplate.Height = 24;
            this.dataGridReservations.Size = new System.Drawing.Size(951, 218);
            this.dataGridReservations.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(404, 304);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Mes réservations:";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Projet_C_.Properties.Resources.Screenshot_2026_04_26_213309;
            this.pictureBox2.Location = new System.Drawing.Point(129, 11);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(175, 59);
            this.pictureBox2.TabIndex = 18;
            this.pictureBox2.TabStop = false;
            // 
            // btn_SignOut
            // 
            this.btn_SignOut.BackColor = System.Drawing.Color.Firebrick;
            this.btn_SignOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SignOut.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_SignOut.Location = new System.Drawing.Point(10, 215);
            this.btn_SignOut.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_SignOut.Name = "btn_SignOut";
            this.btn_SignOut.Padding = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.btn_SignOut.Size = new System.Drawing.Size(195, 60);
            this.btn_SignOut.TabIndex = 19;
            this.btn_SignOut.Text = "Déconnecter";
            this.btn_SignOut.UseVisualStyleBackColor = false;
            this.btn_SignOut.Click += new System.EventHandler(this.btn_SignOut_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnExportHistory);
            this.panel1.Controls.Add(this.btn_Res);
            this.panel1.Controls.Add(this.btn_SignOut);
            this.panel1.Controls.Add(this.btn_Cancel);
            this.panel1.Controls.Add(this.btn_Cons);
            this.panel1.Location = new System.Drawing.Point(61, 135);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(216, 355);
            this.panel1.TabIndex = 20;
            // 
            // btnExportHistory
            // 
            this.btnExportHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportHistory.Location = new System.Drawing.Point(10, 279);
            this.btnExportHistory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExportHistory.Name = "btnExportHistory";
            this.btnExportHistory.Padding = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.btnExportHistory.Size = new System.Drawing.Size(195, 60);
            this.btnExportHistory.TabIndex = 20;
            this.btnExportHistory.Text = "Exporter les réservations";
            this.btnExportHistory.UseVisualStyleBackColor = true;
            this.btnExportHistory.Click += new System.EventHandler(this.btnExportHistory_Click);
            // 
            // label_4
            // 
            this.label_4.AutoSize = true;
            this.label_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_4.Location = new System.Drawing.Point(68, 514);
            this.label_4.Name = "label_4";
            this.label_4.Size = new System.Drawing.Size(143, 16);
            this.label_4.TabIndex = 21;
            this.label_4.Text = "Réservations Total:";
            // 
            // label_5
            // 
            this.label_5.AutoSize = true;
            this.label_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_5.Location = new System.Drawing.Point(68, 541);
            this.label_5.Name = "label_5";
            this.label_5.Size = new System.Drawing.Size(120, 16);
            this.label_5.TabIndex = 22;
            this.label_5.Text = "Total dépenses:";
            // 
            // lblTotalReservations
            // 
            this.lblTotalReservations.AutoSize = true;
            this.lblTotalReservations.Location = new System.Drawing.Point(214, 514);
            this.lblTotalReservations.Name = "lblTotalReservations";
            this.lblTotalReservations.Size = new System.Drawing.Size(0, 16);
            this.lblTotalReservations.TabIndex = 23;
            // 
            // lblTotalSpent
            // 
            this.lblTotalSpent.AutoSize = true;
            this.lblTotalSpent.Location = new System.Drawing.Point(207, 541);
            this.lblTotalSpent.Name = "lblTotalSpent";
            this.lblTotalSpent.Size = new System.Drawing.Size(0, 16);
            this.lblTotalSpent.TabIndex = 24;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Projet_C_.Properties.Resources.Screenshot_2026_04_26_213122;
            this.pictureBox1.Location = new System.Drawing.Point(14, 11);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(109, 26);
            this.pictureBox1.TabIndex = 25;
            this.pictureBox1.TabStop = false;
            // 
            // EtudiantsDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1446, 593);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblTotalSpent);
            this.Controls.Add(this.lblTotalReservations);
            this.Controls.Add(this.label_5);
            this.Controls.Add(this.label_4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridReservations);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridMenu);
            this.Controls.Add(this.label_Welcome);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "EtudiantsDashboard";
            this.Text = "EtudiantsDashboard";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridReservations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Res;
        private System.Windows.Forms.Label label_Welcome;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_Cons;
        private System.Windows.Forms.DataGridView dataGridMenu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridReservations;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btn_SignOut;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnExportHistory;
        private System.Windows.Forms.Label label_4;
        private System.Windows.Forms.Label label_5;
        private System.Windows.Forms.Label lblTotalReservations;
        private System.Windows.Forms.Label lblTotalSpent;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}