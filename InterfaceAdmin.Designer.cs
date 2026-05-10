namespace Projet_C
{
    partial class InterfaceAdmin
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
            this.label1 = new System.Windows.Forms.Label();
            this.btn_ConsEtu = new System.Windows.Forms.Button();
            this.btn_ConsEmp = new System.Windows.Forms.Button();
            this.btn_addMenu = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(361, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 85);
            this.label1.TabIndex = 0;
            this.label1.Text = "Admin";
            // 
            // btn_ConsEtu
            // 
            this.btn_ConsEtu.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ConsEtu.Location = new System.Drawing.Point(311, 259);
            this.btn_ConsEtu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_ConsEtu.Name = "btn_ConsEtu";
            this.btn_ConsEtu.Padding = new System.Windows.Forms.Padding(10);
            this.btn_ConsEtu.Size = new System.Drawing.Size(280, 66);
            this.btn_ConsEtu.TabIndex = 2;
            this.btn_ConsEtu.Text = "Consulter la liste des étudiants";
            this.btn_ConsEtu.UseVisualStyleBackColor = true;
            this.btn_ConsEtu.Click += new System.EventHandler(this.btn_ConsEtu_Click);
            // 
            // btn_ConsEmp
            // 
            this.btn_ConsEmp.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ConsEmp.Location = new System.Drawing.Point(311, 206);
            this.btn_ConsEmp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_ConsEmp.Name = "btn_ConsEmp";
            this.btn_ConsEmp.Padding = new System.Windows.Forms.Padding(10);
            this.btn_ConsEmp.Size = new System.Drawing.Size(280, 46);
            this.btn_ConsEmp.TabIndex = 4;
            this.btn_ConsEmp.Text = "Consulter la liste du personnel";
            this.btn_ConsEmp.UseVisualStyleBackColor = true;
            this.btn_ConsEmp.Click += new System.EventHandler(this.btn_ConsEmp_Click);
            // 
            // btn_addMenu
            // 
            this.btn_addMenu.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_addMenu.Location = new System.Drawing.Point(311, 329);
            this.btn_addMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_addMenu.Name = "btn_addMenu";
            this.btn_addMenu.Padding = new System.Windows.Forms.Padding(10);
            this.btn_addMenu.Size = new System.Drawing.Size(280, 69);
            this.btn_addMenu.TabIndex = 9;
            this.btn_addMenu.Text = "Gestion des menus";
            this.btn_addMenu.UseVisualStyleBackColor = true;
            this.btn_addMenu.Click += new System.EventHandler(this.btn_addMenu_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Projet_C_.Properties.Resources.Screenshot_2026_04_26_213309;
            this.pictureBox2.Location = new System.Drawing.Point(119, 11);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(167, 59);
            this.pictureBox2.TabIndex = 18;
            this.pictureBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label2.Location = new System.Drawing.Point(321, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(270, 49);
            this.label2.TabIndex = 19;
            this.label2.Text = "Restaurant IHEC";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(311, 402);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Padding = new System.Windows.Forms.Padding(10);
            this.button2.Size = new System.Drawing.Size(280, 68);
            this.button2.TabIndex = 21;
            this.button2.Text = "Se Déconnecter";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Projet_C_.Properties.Resources.Screenshot_2026_04_26_213122;
            this.pictureBox1.Location = new System.Drawing.Point(15, 11);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(83, 26);
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // InterfaceAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(917, 528);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btn_addMenu);
            this.Controls.Add(this.btn_ConsEmp);
            this.Controls.Add(this.btn_ConsEtu);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "InterfaceAdmin";
            this.Text = "InterfaceAdmin";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InterfaceAdmin_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_ConsEtu;
        private System.Windows.Forms.Button btn_ConsEmp;
        private System.Windows.Forms.Button btn_addMenu;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}