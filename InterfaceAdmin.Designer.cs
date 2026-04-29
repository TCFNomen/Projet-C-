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
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(348, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 85);
            this.label1.TabIndex = 0;
            this.label1.Text = "Admin";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btn_AddEmp
            // 
            this.btn_AddEmp.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AddEmp.Location = new System.Drawing.Point(667, 42);
            this.btn_AddEmp.Name = "btn_AddEmp";
            this.btn_AddEmp.Size = new System.Drawing.Size(206, 36);
            this.btn_AddEmp.TabIndex = 1;
            this.btn_AddEmp.Text = "Ajouter un employé";
            this.btn_AddEmp.UseVisualStyleBackColor = true;
            this.btn_AddEmp.Click += new System.EventHandler(this.btn_AddEmp_Click);
            // 
            // btn_ConsEtu
            // 
            this.btn_ConsEtu.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ConsEtu.Location = new System.Drawing.Point(302, 199);
            this.btn_ConsEtu.Name = "btn_ConsEtu";
            this.btn_ConsEtu.Size = new System.Drawing.Size(280, 36);
            this.btn_ConsEtu.TabIndex = 2;
            this.btn_ConsEtu.Text = "Consulter la liste des étudiants";
            this.btn_ConsEtu.UseVisualStyleBackColor = true;
            this.btn_ConsEtu.Click += new System.EventHandler(this.btn_ConsEtu_Click);
            // 
            // btn_DelEmp
            // 
            this.btn_DelEmp.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DelEmp.Location = new System.Drawing.Point(667, 126);
            this.btn_DelEmp.Name = "btn_DelEmp";
            this.btn_DelEmp.Size = new System.Drawing.Size(206, 36);
            this.btn_DelEmp.TabIndex = 3;
            this.btn_DelEmp.Text = "Supprimer un employé";
            this.btn_DelEmp.UseVisualStyleBackColor = true;
            // 
            // btn_ConsEmp
            // 
            this.btn_ConsEmp.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ConsEmp.Location = new System.Drawing.Point(302, 147);
            this.btn_ConsEmp.Name = "btn_ConsEmp";
            this.btn_ConsEmp.Size = new System.Drawing.Size(280, 46);
            this.btn_ConsEmp.TabIndex = 4;
            this.btn_ConsEmp.Text = "Consulter la liste du personnel";
            this.btn_ConsEmp.UseVisualStyleBackColor = true;
            this.btn_ConsEmp.Click += new System.EventHandler(this.btn_ConsEmp_Click);
            // 
            // btn_ModRoles
            // 
            this.btn_ModRoles.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ModRoles.Location = new System.Drawing.Point(488, 391);
            this.btn_ModRoles.Name = "btn_ModRoles";
            this.btn_ModRoles.Size = new System.Drawing.Size(206, 36);
            this.btn_ModRoles.TabIndex = 8;
            this.btn_ModRoles.Text = "Gestion des roles";
            this.btn_ModRoles.UseVisualStyleBackColor = true;
            this.btn_ModRoles.Click += new System.EventHandler(this.btn_ModRoles_Click);
            // 
            // btn_DeleteUser
            // 
            this.btn_DeleteUser.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DeleteUser.Location = new System.Drawing.Point(667, 252);
            this.btn_DeleteUser.Name = "btn_DeleteUser";
            this.btn_DeleteUser.Size = new System.Drawing.Size(206, 36);
            this.btn_DeleteUser.TabIndex = 7;
            this.btn_DeleteUser.Text = "Supprimer un utilisateur";
            this.btn_DeleteUser.UseVisualStyleBackColor = true;
            this.btn_DeleteUser.Click += new System.EventHandler(this.btn_DeleteUser_Click);
            // 
            // btn_ModUser
            // 
            this.btn_ModUser.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ModUser.Location = new System.Drawing.Point(667, 210);
            this.btn_ModUser.Name = "btn_ModUser";
            this.btn_ModUser.Size = new System.Drawing.Size(206, 36);
            this.btn_ModUser.TabIndex = 6;
            this.btn_ModUser.Text = "Modifier un utilisateur";
            this.btn_ModUser.UseVisualStyleBackColor = true;
            this.btn_ModUser.Click += new System.EventHandler(this.btn_ModUser_Click);
            // 
            // btn_AddUser
            // 
            this.btn_AddUser.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AddUser.Location = new System.Drawing.Point(667, 168);
            this.btn_AddUser.Name = "btn_AddUser";
            this.btn_AddUser.Size = new System.Drawing.Size(206, 36);
            this.btn_AddUser.TabIndex = 5;
            this.btn_AddUser.Text = "Ajouter un utilisateur";
            this.btn_AddUser.UseVisualStyleBackColor = true;
            this.btn_AddUser.Click += new System.EventHandler(this.btn_AddUser_Click);
            // 
            // btn_addMenu
            // 
            this.btn_addMenu.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_addMenu.Location = new System.Drawing.Point(302, 241);
            this.btn_addMenu.Name = "btn_addMenu";
            this.btn_addMenu.Size = new System.Drawing.Size(280, 36);
            this.btn_addMenu.TabIndex = 9;
            this.btn_addMenu.Text = "Gestion des menus";
            this.btn_addMenu.UseVisualStyleBackColor = true;
            this.btn_addMenu.Click += new System.EventHandler(this.btn_addMenu_Click);
            // 
            // InterfaceAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(918, 528);
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
            this.Name = "InterfaceAdmin";
            this.Text = "InterfaceAdmin";
            this.Load += new System.EventHandler(this.InterfaceAdmin_Load);
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
    }
}