namespace ExpenseManagerDesktop.BankAccount
{
    partial class FormRegisterUpdateBankAccount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRegisterUpdateBankAccount));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxBankAccountId = new System.Windows.Forms.TextBox();
            this.listBoxTypeBankAccount = new System.Windows.Forms.ListBox();
            this.textBoxTotalBalance = new System.Windows.Forms.TextBox();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.btnSaveBankAccount = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxBankAccountId);
            this.groupBox1.Controls.Add(this.listBoxTypeBankAccount);
            this.groupBox1.Controls.Add(this.textBoxTotalBalance);
            this.groupBox1.Controls.Add(this.textBoxTitle);
            this.groupBox1.Controls.Add(this.btnSaveBankAccount);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(255, 318);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Contas de banco";
            // 
            // textBoxBankAccountId
            // 
            this.textBoxBankAccountId.Location = new System.Drawing.Point(6, 285);
            this.textBoxBankAccountId.Name = "textBoxBankAccountId";
            this.textBoxBankAccountId.Size = new System.Drawing.Size(100, 23);
            this.textBoxBankAccountId.TabIndex = 7;
            this.textBoxBankAccountId.Visible = false;
            // 
            // listBoxTypeBankAccount
            // 
            this.listBoxTypeBankAccount.FormattingEnabled = true;
            this.listBoxTypeBankAccount.ItemHeight = 15;
            this.listBoxTypeBankAccount.Location = new System.Drawing.Point(6, 125);
            this.listBoxTypeBankAccount.Name = "listBoxTypeBankAccount";
            this.listBoxTypeBankAccount.Size = new System.Drawing.Size(241, 154);
            this.listBoxTypeBankAccount.TabIndex = 6;
            // 
            // textBoxTotalBalance
            // 
            this.textBoxTotalBalance.Location = new System.Drawing.Point(6, 81);
            this.textBoxTotalBalance.Name = "textBoxTotalBalance";
            this.textBoxTotalBalance.Size = new System.Drawing.Size(240, 23);
            this.textBoxTotalBalance.TabIndex = 5;
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Location = new System.Drawing.Point(6, 37);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(240, 23);
            this.textBoxTitle.TabIndex = 4;
            // 
            // btnSaveBankAccount
            // 
            this.btnSaveBankAccount.Location = new System.Drawing.Point(171, 285);
            this.btnSaveBankAccount.Name = "btnSaveBankAccount";
            this.btnSaveBankAccount.Size = new System.Drawing.Size(75, 23);
            this.btnSaveBankAccount.TabIndex = 3;
            this.btnSaveBankAccount.Text = "Salvar";
            this.btnSaveBankAccount.UseVisualStyleBackColor = true;
            this.btnSaveBankAccount.Click += new System.EventHandler(this.btnSaveBankAccount_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "*Total na conta R$";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "*Tipo de conta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "*Título";
            // 
            // FormRegisterUpdateBankAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 343);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormRegisterUpdateBankAccount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrar";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox1;
        private ListBox listBoxTypeBankAccount;
        private TextBox textBoxTotalBalance;
        private TextBox textBoxTitle;
        private Button btnSaveBankAccount;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox textBoxBankAccountId;
    }
}