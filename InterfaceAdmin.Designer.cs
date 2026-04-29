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
            this.btn_AddEmp = new System.Windows.Forms.Button();
            this.btn_ConsEtu = new System.Windows.Forms.Button();
            this.btn_DelEmp = new System.Windows.Forms.Button();
            this.btn_ConsEmp = new System.Windows.Forms.Button();
            this.btn_ModRoles = new System.Windows.Forms.Button();
            this.btn_DeleteUser = new System.Windows.Forms.Button();
            this.btn_ModUser = new System.Windows.Forms.Button();
            this.btn_AddUser = new System.Windows.Forms.Button();
            this.btn_addMenu = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(251, 49);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 68);
            this.label1.TabIndex = 0;
            this.label1.Text = "Admin";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btn_AddEmp
            // 
            this.btn_AddEmp.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AddEmp.Location = new System.Drawing.Point(500, 69);
            this.btn_AddEmp.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_AddEmp.Name = "btn_AddEmp";
            this.btn_AddEmp.Size = new System.Drawing.Size(154, 29);
            this.btn_AddEmp.TabIndex = 1;
            this.btn_AddEmp.Text = "Ajouter un employé";
            this.btn_AddEmp.UseVisualStyleBackColor = true;
            this.btn_AddEmp.Click += new System.EventHandler(this.btn_AddEmp_Click);
            // 
            // btn_ConsEtu
            // 
            this.btn_ConsEtu.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ConsEtu.Location = new System.Drawing.Point(226, 162);
            this.btn_ConsEtu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_ConsEtu.Name = "btn_ConsEtu";
            this.btn_ConsEtu.Size = new System.Drawing.Size(210, 29);
            this.btn_ConsEtu.TabIndex = 2;
            this.btn_ConsEtu.Text = "Consulter la liste des étudiants";
            this.btn_ConsEtu.UseVisualStyleBackColor = true;
            this.btn_ConsEtu.Click += new System.EventHandler(this.btn_ConsEtu_Click);
            // 
            // btn_DelEmp
            // 
            this.btn_DelEmp.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DelEmp.Location = new System.Drawing.Point(500, 102);
            this.btn_DelEmp.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_DelEmp.Name = "btn_DelEmp";
            this.btn_DelEmp.Size = new System.Drawing.Size(154, 29);
            this.btn_DelEmp.TabIndex = 3;
            this.btn_DelEmp.Text = "Supprimer un employé";
            this.btn_DelEmp.UseVisualStyleBackColor = true;
            // 
            // btn_ConsEmp
            // 
            this.btn_ConsEmp.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ConsEmp.Location = new System.Drawing.Point(226, 119);
            this.btn_ConsEmp.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_ConsEmp.Name = "btn_ConsEmp";
            this.btn_ConsEmp.Size = new System.Drawing.Size(210, 37);
            this.btn_ConsEmp.TabIndex = 4;
            this.btn_ConsEmp.Text = "Consulter la liste du personnel";
            this.btn_ConsEmp.UseVisualStyleBackColor = true;
            this.btn_ConsEmp.Click += new System.EventHandler(this.btn_ConsEmp_Click);
            // 
            // btn_ModRoles
            // 
            this.btn_ModRoles.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ModRoles.Location = new System.Drawing.Point(366, 318);
            this.btn_ModRoles.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_ModRoles.Name = "btn_ModRoles";
            this.btn_ModRoles.Size = new System.Drawing.Size(154, 29);
            this.btn_ModRoles.TabIndex = 8;
            this.btn_ModRoles.Text = "Gestion des roles";
            this.btn_ModRoles.UseVisualStyleBackColor = true;
            this.btn_ModRoles.Click += new System.EventHandler(this.btn_ModRoles_Click);
            // 
            // btn_DeleteUser
            // 
            this.btn_DeleteUser.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DeleteUser.Location = new System.Drawing.Point(500, 205);
            this.btn_DeleteUser.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_DeleteUser.Name = "btn_DeleteUser";
            this.btn_DeleteUser.Size = new System.Drawing.Size(154, 29);
            this.btn_DeleteUser.TabIndex = 7;
            this.btn_DeleteUser.Text = "Supprimer un utilisateur";
            this.btn_DeleteUser.UseVisualStyleBackColor = true;
            this.btn_DeleteUser.Click += new System.EventHandler(this.btn_DeleteUser_Click);
            // 
            // btn_ModUser
            // 
            this.btn_ModUser.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ModUser.Location = new System.Drawing.Point(500, 171);
            this.btn_ModUser.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_ModUser.Name = "btn_ModUser";
            this.btn_ModUser.Size = new System.Drawing.Size(154, 29);
            this.btn_ModUser.TabIndex = 6;
            this.btn_ModUser.Text = "Modifier un utilisateur";
            this.btn_ModUser.UseVisualStyleBackColor = true;
            this.btn_ModUser.Click += new System.EventHandler(this.btn_ModUser_Click);
            // 
            // btn_AddUser
            // 
            this.btn_AddUser.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AddUser.Location = new System.Drawing.Point(500, 136);
            this.btn_AddUser.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_AddUser.Name = "btn_AddUser";
            this.btn_AddUser.Size = new System.Drawing.Size(154, 29);
            this.btn_AddUser.TabIndex = 5;
            this.btn_AddUser.Text = "Ajouter un utilisateur";
            this.btn_AddUser.UseVisualStyleBackColor = true;
            this.btn_AddUser.Click += new System.EventHandler(this.btn_AddUser_Click);
            // 
            // btn_addMenu
            // 
            this.btn_addMenu.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_addMenu.Location = new System.Drawing.Point(226, 196);
            this.btn_addMenu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_addMenu.Name = "btn_addMenu";
            this.btn_addMenu.Size = new System.Drawing.Size(210, 29);
            this.btn_addMenu.TabIndex = 9;
            this.btn_addMenu.Text = "Gestion des menus";
            this.btn_addMenu.UseVisualStyleBackColor = true;
            this.btn_addMenu.Click += new System.EventHandler(this.btn_addMenu_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Projet_C_.Properties.Resources.Screenshot_2026_04_26_213309;
            this.pictureBox2.Location = new System.Drawing.Point(11, 11);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(96, 48);
            this.pictureBox2.TabIndex = 18;
            this.pictureBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label2.Location = new System.Drawing.Point(111, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(221, 39);
            this.label2.TabIndex = 19;
            this.label2.Text = "Restaurant IHEC";
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::Projet_C_.Properties.Resources.Screenshot_2026_04_26_215304;
            this.button1.Location = new System.Drawing.Point(547, 11);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 41);
            this.button1.TabIndex = 20;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(11, 391);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(111, 37);
            this.button2.TabIndex = 21;
            this.button2.Text = "Se Déconnecter";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // InterfaceAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(688, 429);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btn_addMenu);
            this.Controls.Add(this.btn_ModRoles);
            this.Controls.Add(this.btn_DeleteUser);
            this.Controls.Add(this.btn_ModUser);
            this.Controls.Add(this.btn_AddUser);
            this.Controls.Add(this.btn_ConsEmp);
            this.Controls.Add(this.btn_DelEmp);
            this.Controls.Add(this.btn_ConsEtu);
            this.Controls.Add(this.btn_AddEmp);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "InterfaceAdmin";
            this.Text = "InterfaceAdmin";
            this.Load += new System.EventHandler(this.InterfaceAdmin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_AddEmp;
        private System.Windows.Forms.Button btn_ConsEtu;
        private System.Windows.Forms.Button btn_DelEmp;
        private System.Windows.Forms.Button btn_ConsEmp;
        private System.Windows.Forms.Button btn_ModRoles;
        private System.Windows.Forms.Button btn_DeleteUser;
        private System.Windows.Forms.Button btn_ModUser;
        private System.Windows.Forms.Button btn_AddUser;
        private System.Windows.Forms.Button btn_addMenu;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}