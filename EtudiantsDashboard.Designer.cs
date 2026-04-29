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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Res
            // 
            this.btn_Res.Location = new System.Drawing.Point(68, 108);
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
            this.label1.Location = new System.Drawing.Point(56, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bienvenue chèr(e) étudiant(e)!";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(68, 174);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(173, 60);
            this.btn_Cancel.TabIndex = 2;
            this.btn_Cancel.Text = "Annuler une réservation";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_Cons
            // 
            this.btn_Cons.Location = new System.Drawing.Point(68, 240);
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
            this.dataGridMenu.Location = new System.Drawing.Point(457, 18);
            this.dataGridMenu.Name = "dataGridMenu";
            this.dataGridMenu.RowHeadersWidth = 51;
            this.dataGridMenu.RowTemplate.Height = 24;
            this.dataGridMenu.Size = new System.Drawing.Size(730, 373);
            this.dataGridMenu.TabIndex = 4;
            // 
            // EtudiantsDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1221, 550);
            this.Controls.Add(this.dataGridMenu);
            this.Controls.Add(this.btn_Cons);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Res);
            this.Name = "EtudiantsDashboard";
            this.Text = "EtudiantsDashboard";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMenu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Res;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_Cons;
        private System.Windows.Forms.DataGridView dataGridMenu;
    }
}