namespace ExpenseManagerDesktop.User
{
    partial class FormForgotPassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormForgotPassword));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxLoginName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnConfirmNewPassword = new System.Windows.Forms.Button();
            this.textBoxConfirmNewPassword = new System.Windows.Forms.TextBox();
            this.textBoxNewPassword = new System.Windows.Forms.TextBox();
            this.textBoxKeyworld = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxLoginName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnConfirmNewPassword);
            this.groupBox1.Controls.Add(this.textBoxConfirmNewPassword);
            this.groupBox1.Controls.Add(this.textBoxNewPassword);
            this.groupBox1.Controls.Add(this.textBoxKeyworld);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(357, 188);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Recuperar senha";
            // 
            // textBoxLoginName
            // 
            this.textBoxLoginName.Location = new System.Drawing.Point(135, 22);
            this.textBoxLoginName.Name = "textBoxLoginName";
            this.textBoxLoginName.Size = new System.Drawing.Size(204, 23);
            this.textBoxLoginName.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "*Nome de login";
            // 
            // btnConfirmNewPassword
            // 
            this.btnConfirmNewPassword.Location = new System.Drawing.Point(264, 147);
            this.btnConfirmNewPassword.Name = "btnConfirmNewPassword";
            this.btnConfirmNewPassword.Size = new System.Drawing.Size(75, 23);
            this.btnConfirmNewPassword.TabIndex = 8;
            this.btnConfirmNewPassword.Text = "Confirmar";
            this.btnConfirmNewPassword.UseVisualStyleBackColor = true;
            this.btnConfirmNewPassword.Click += new System.EventHandler(this.btnConfirmNewPassword_Click);
            // 
            // textBoxConfirmNewPassword
            // 
            this.textBoxConfirmNewPassword.Location = new System.Drawing.Point(135, 118);
            this.textBoxConfirmNewPassword.Name = "textBoxConfirmNewPassword";
            this.textBoxConfirmNewPassword.Size = new System.Drawing.Size(204, 23);
            this.textBoxConfirmNewPassword.TabIndex = 4;
            this.textBoxConfirmNewPassword.UseSystemPasswordChar = true;
            // 
            // textBoxNewPassword
            // 
            this.textBoxNewPassword.Location = new System.Drawing.Point(135, 89);
            this.textBoxNewPassword.Name = "textBoxNewPassword";
            this.textBoxNewPassword.Size = new System.Drawing.Size(204, 23);
            this.textBoxNewPassword.TabIndex = 3;
            this.textBoxNewPassword.UseSystemPasswordChar = true;
            // 
            // textBoxKeyworld
            // 
            this.textBoxKeyworld.Location = new System.Drawing.Point(135, 55);
            this.textBoxKeyworld.Name = "textBoxKeyworld";
            this.textBoxKeyworld.Size = new System.Drawing.Size(204, 23);
            this.textBoxKeyworld.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "*Palavra chave";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "*Confirmar nova senha";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "*Nova senha";
            // 
            // FormForgotPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 214);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormForgotPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Resetar senha";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox1;
        private Button btnConfirmNewPassword;
        private TextBox textBoxConfirmNewPassword;
        private TextBox textBoxNewPassword;
        private TextBox textBoxKeyworld;
        private Label label1;
        private Label label3;
        private Label label2;
        private TextBox textBoxLoginName;
        private Label label4;
    }
}