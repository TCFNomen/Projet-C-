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
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_Cons = new System.Windows.Forms.Button();
            this.dataGridMenu = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridReservations = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btn_SignOut = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridReservations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Res
            // 
            this.btn_Res.Location = new System.Drawing.Point(63, 153);
            this.btn_Res.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Res.Name = "btn_Res";
            this.btn_Res.Size = new System.Drawing.Size(173, 60);
            this.btn_Res.TabIndex = 0;
            this.btn_Res.Text = "Réserver un repas";
            this.btn_Res.UseVisualStyleBackColor = true;
            this.btn_Res.Click += new System.EventHandler(this.btn_Res_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bienvenue chèr(e) étudiant(e)!";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(63, 218);
            this.btn_Cancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(173, 60);
            this.btn_Cancel.TabIndex = 2;
            this.btn_Cancel.Text = "Annuler une réservation";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_Cons
            // 
            this.btn_Cons.Location = new System.Drawing.Point(63, 282);
            this.btn_Cons.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Cons.Name = "btn_Cons";
            this.btn_Cons.Size = new System.Drawing.Size(173, 60);
            this.btn_Cons.TabIndex = 3;
            this.btn_Cons.Text = "Consulter mes réservations";
            this.btn_Cons.UseVisualStyleBackColor = true;
            this.btn_Cons.Click += new System.EventHandler(this.btn_Cons_Click);
            // 
            // dataGridMenu
            // 
            this.dataGridMenu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridMenu.Location = new System.Drawing.Point(463, 53);
            this.dataGridMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridMenu.Name = "dataGridMenu";
            this.dataGridMenu.RowHeadersWidth = 51;
            this.dataGridMenu.RowTemplate.Height = 24;
            this.dataGridMenu.Size = new System.Drawing.Size(732, 190);
            this.dataGridMenu.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(460, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Menu de la semaine:";
            // 
            // dataGridReservations
            // 
            this.dataGridReservations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridReservations.Location = new System.Drawing.Point(463, 273);
            this.dataGridReservations.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridReservations.Name = "dataGridReservations";
            this.dataGridReservations.RowHeadersWidth = 51;
            this.dataGridReservations.RowTemplate.Height = 24;
            this.dataGridReservations.Size = new System.Drawing.Size(732, 159);
            this.dataGridReservations.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(460, 254);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Mes réservations";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Projet_C_.Properties.Resources.Screenshot_2026_04_26_213309;
            this.pictureBox2.Location = new System.Drawing.Point(15, 14);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(128, 59);
            this.pictureBox2.TabIndex = 18;
            this.pictureBox2.TabStop = false;
            // 
            // btn_SignOut
            // 
            this.btn_SignOut.Location = new System.Drawing.Point(12, 391);
            this.btn_SignOut.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_SignOut.Name = "btn_SignOut";
            this.btn_SignOut.Size = new System.Drawing.Size(173, 60);
            this.btn_SignOut.TabIndex = 19;
            this.btn_SignOut.Text = "Déconnecter";
            this.btn_SignOut.UseVisualStyleBackColor = true;
            this.btn_SignOut.Click += new System.EventHandler(this.btn_SignOut_Click);
            // 
            // EtudiantsDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1221, 550);
            this.Controls.Add(this.btn_SignOut);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridReservations);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridMenu);
            this.Controls.Add(this.btn_Cons);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Res);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "EtudiantsDashboard";
            this.Text = "EtudiantsDashboard";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridReservations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Res;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_Cons;
        private System.Windows.Forms.DataGridView dataGridMenu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridReservations;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btn_SignOut;
    }
}