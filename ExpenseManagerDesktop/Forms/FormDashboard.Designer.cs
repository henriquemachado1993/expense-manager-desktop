namespace ExpenseManagerDesktop
{
    partial class FormDashBoard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDashBoard));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelBalanceMinusExpenses = new System.Windows.Forms.Label();
            this.labelTotalBalance = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelTextExpensesToBePaid = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.linkLabelLogout = new System.Windows.Forms.LinkLabel();
            this.labelNameUserLogged = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageExpenses = new System.Windows.Forms.TabPage();
            this.btnNewExpense = new System.Windows.Forms.Button();
            this.dataGridViewExpenses = new System.Windows.Forms.DataGridView();
            this.tabPageCategories = new System.Windows.Forms.TabPage();
            this.btnNewCategory = new System.Windows.Forms.Button();
            this.dataGridViewCategories = new System.Windows.Forms.DataGridView();
            this.tabPageBankAccounts = new System.Windows.Forms.TabPage();
            this.btnNewBankAccount = new System.Windows.Forms.Button();
            this.dataGridViewBankAccounts = new System.Windows.Forms.DataGridView();
            this.btnRefreshDataGridView = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tabPageExpenses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExpenses)).BeginInit();
            this.tabPageCategories.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCategories)).BeginInit();
            this.tabPageBankAccounts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBankAccounts)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelBalanceMinusExpenses);
            this.groupBox2.Controls.Add(this.labelTotalBalance);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(557, 83);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(601, 70);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Total nas contas bancárias";
            // 
            // labelBalanceMinusExpenses
            // 
            this.labelBalanceMinusExpenses.AutoSize = true;
            this.labelBalanceMinusExpenses.Location = new System.Drawing.Point(393, 31);
            this.labelBalanceMinusExpenses.Name = "labelBalanceMinusExpenses";
            this.labelBalanceMinusExpenses.Size = new System.Drawing.Size(56, 15);
            this.labelBalanceMinusExpenses.TabIndex = 3;
            this.labelBalanceMinusExpenses.Text = "R$ 500,00";
            // 
            // labelTotalBalance
            // 
            this.labelTotalBalance.AutoSize = true;
            this.labelTotalBalance.Location = new System.Drawing.Point(109, 31);
            this.labelTotalBalance.Name = "labelTotalBalance";
            this.labelTotalBalance.Size = new System.Drawing.Size(50, 15);
            this.labelTotalBalance.TabIndex = 2;
            this.labelTotalBalance.Text = "R$ 1.000";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(223, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(164, 15);
            this.label6.TabIndex = 1;
            this.label6.Text = "Saldo descontando despesas: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Saldo total:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelTextExpensesToBePaid);
            this.groupBox1.Location = new System.Drawing.Point(12, 83);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(539, 70);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Despesas a pagar";
            // 
            // labelTextExpensesToBePaid
            // 
            this.labelTextExpensesToBePaid.AutoSize = true;
            this.labelTextExpensesToBePaid.Location = new System.Drawing.Point(21, 31);
            this.labelTextExpensesToBePaid.Name = "labelTextExpensesToBePaid";
            this.labelTextExpensesToBePaid.Size = new System.Drawing.Size(226, 15);
            this.labelTextExpensesToBePaid.TabIndex = 0;
            this.labelTextExpensesToBePaid.Text = "Você tem 3 contas no valor de R$ 1,200.00";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.linkLabelLogout);
            this.panel1.Controls.Add(this.labelNameUserLogged);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1146, 56);
            this.panel1.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(4, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(286, 30);
            this.label3.TabIndex = 4;
            this.label3.Text = "Gerenciamento de Despesas";
            // 
            // linkLabelLogout
            // 
            this.linkLabelLogout.AutoSize = true;
            this.linkLabelLogout.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.linkLabelLogout.LinkColor = System.Drawing.Color.Black;
            this.linkLabelLogout.Location = new System.Drawing.Point(1096, 17);
            this.linkLabelLogout.Name = "linkLabelLogout";
            this.linkLabelLogout.Size = new System.Drawing.Size(35, 20);
            this.linkLabelLogout.TabIndex = 3;
            this.linkLabelLogout.TabStop = true;
            this.linkLabelLogout.Text = "Sair";
            this.linkLabelLogout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelLogout_LinkClicked);
            // 
            // labelNameUserLogged
            // 
            this.labelNameUserLogged.AutoSize = true;
            this.labelNameUserLogged.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelNameUserLogged.Location = new System.Drawing.Point(997, 17);
            this.labelNameUserLogged.Name = "labelNameUserLogged";
            this.labelNameUserLogged.Size = new System.Drawing.Size(74, 21);
            this.labelNameUserLogged.TabIndex = 2;
            this.labelNameUserLogged.Text = "Henrique";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(964, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Olá,";
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageExpenses);
            this.tabControlMain.Controls.Add(this.tabPageCategories);
            this.tabControlMain.Controls.Add(this.tabPageBankAccounts);
            this.tabControlMain.Location = new System.Drawing.Point(12, 171);
            this.tabControlMain.Multiline = true;
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(1146, 521);
            this.tabControlMain.TabIndex = 4;
            // 
            // tabPageExpenses
            // 
            this.tabPageExpenses.Controls.Add(this.btnNewExpense);
            this.tabPageExpenses.Controls.Add(this.dataGridViewExpenses);
            this.tabPageExpenses.Location = new System.Drawing.Point(4, 24);
            this.tabPageExpenses.Name = "tabPageExpenses";
            this.tabPageExpenses.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageExpenses.Size = new System.Drawing.Size(1138, 493);
            this.tabPageExpenses.TabIndex = 1;
            this.tabPageExpenses.Text = "Despesas";
            this.tabPageExpenses.UseVisualStyleBackColor = true;
            // 
            // btnNewExpense
            // 
            this.btnNewExpense.Location = new System.Drawing.Point(6, 6);
            this.btnNewExpense.Name = "btnNewExpense";
            this.btnNewExpense.Size = new System.Drawing.Size(109, 23);
            this.btnNewExpense.TabIndex = 1;
            this.btnNewExpense.Text = "Nova despesa";
            this.btnNewExpense.UseVisualStyleBackColor = true;
            // 
            // dataGridViewExpenses
            // 
            this.dataGridViewExpenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewExpenses.Location = new System.Drawing.Point(6, 35);
            this.dataGridViewExpenses.Name = "dataGridViewExpenses";
            this.dataGridViewExpenses.RowTemplate.Height = 25;
            this.dataGridViewExpenses.Size = new System.Drawing.Size(1126, 452);
            this.dataGridViewExpenses.TabIndex = 0;
            // 
            // tabPageCategories
            // 
            this.tabPageCategories.Controls.Add(this.btnNewCategory);
            this.tabPageCategories.Controls.Add(this.dataGridViewCategories);
            this.tabPageCategories.Location = new System.Drawing.Point(4, 24);
            this.tabPageCategories.Name = "tabPageCategories";
            this.tabPageCategories.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCategories.Size = new System.Drawing.Size(1138, 493);
            this.tabPageCategories.TabIndex = 2;
            this.tabPageCategories.Text = "Categorias";
            this.tabPageCategories.UseVisualStyleBackColor = true;
            // 
            // btnNewCategory
            // 
            this.btnNewCategory.Location = new System.Drawing.Point(6, 6);
            this.btnNewCategory.Name = "btnNewCategory";
            this.btnNewCategory.Size = new System.Drawing.Size(109, 23);
            this.btnNewCategory.TabIndex = 2;
            this.btnNewCategory.Text = "Nova categoria";
            this.btnNewCategory.UseVisualStyleBackColor = true;
            // 
            // dataGridViewCategories
            // 
            this.dataGridViewCategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCategories.Location = new System.Drawing.Point(6, 35);
            this.dataGridViewCategories.Name = "dataGridViewCategories";
            this.dataGridViewCategories.RowTemplate.Height = 25;
            this.dataGridViewCategories.Size = new System.Drawing.Size(1121, 452);
            this.dataGridViewCategories.TabIndex = 0;
            // 
            // tabPageBankAccounts
            // 
            this.tabPageBankAccounts.Controls.Add(this.btnNewBankAccount);
            this.tabPageBankAccounts.Controls.Add(this.dataGridViewBankAccounts);
            this.tabPageBankAccounts.Location = new System.Drawing.Point(4, 24);
            this.tabPageBankAccounts.Name = "tabPageBankAccounts";
            this.tabPageBankAccounts.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBankAccounts.Size = new System.Drawing.Size(1138, 493);
            this.tabPageBankAccounts.TabIndex = 3;
            this.tabPageBankAccounts.Text = "Contas Bancárias";
            this.tabPageBankAccounts.UseVisualStyleBackColor = true;
            // 
            // btnNewBankAccount
            // 
            this.btnNewBankAccount.Location = new System.Drawing.Point(6, 6);
            this.btnNewBankAccount.Name = "btnNewBankAccount";
            this.btnNewBankAccount.Size = new System.Drawing.Size(109, 23);
            this.btnNewBankAccount.TabIndex = 3;
            this.btnNewBankAccount.Text = "Nova conta";
            this.btnNewBankAccount.UseVisualStyleBackColor = true;
            // 
            // dataGridViewBankAccounts
            // 
            this.dataGridViewBankAccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBankAccounts.Location = new System.Drawing.Point(6, 35);
            this.dataGridViewBankAccounts.Name = "dataGridViewBankAccounts";
            this.dataGridViewBankAccounts.RowTemplate.Height = 25;
            this.dataGridViewBankAccounts.Size = new System.Drawing.Size(1126, 452);
            this.dataGridViewBankAccounts.TabIndex = 0;
            // 
            // btnRefreshDataGridView
            // 
            this.btnRefreshDataGridView.Location = new System.Drawing.Point(1079, 159);
            this.btnRefreshDataGridView.Name = "btnRefreshDataGridView";
            this.btnRefreshDataGridView.Size = new System.Drawing.Size(75, 23);
            this.btnRefreshDataGridView.TabIndex = 8;
            this.btnRefreshDataGridView.Text = "Atualizar";
            this.btnRefreshDataGridView.UseVisualStyleBackColor = true;
            this.btnRefreshDataGridView.Click += new System.EventHandler(this.btnRefreshDataGridView_Click);
            // 
            // FormDashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1170, 705);
            this.Controls.Add(this.btnRefreshDataGridView);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControlMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormDashBoard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControlMain.ResumeLayout(false);
            this.tabPageExpenses.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExpenses)).EndInit();
            this.tabPageCategories.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCategories)).EndInit();
            this.tabPageBankAccounts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBankAccounts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox2;
        private Label label6;
        private Label label5;
        private GroupBox groupBox1;
        private Label labelTextExpensesToBePaid;
        private Panel panel1;
        private Label label3;
        private LinkLabel linkLabelLogout;
        private Label labelNameUserLogged;
        private Label label1;
        private TabControl tabControlMain;
        private TabPage tabPageExpenses;
        private DataGridView dataGridViewExpenses;
        private TabPage tabPageCategories;
        private TabPage tabPageBankAccounts;
        private Label labelTotalBalance;
        private Label labelBalanceMinusExpenses;
        private Button btnNewExpense;
        private Button btnNewCategory;
        private DataGridView dataGridView1;
        private Button btnNewBankAccount;
        private DataGridView dataGridView2;
        private DataGridView dataGridViewCategories;
        private DataGridView dataGridViewBankAccounts;
        private Button btnRefreshDataGridView;
    }
}