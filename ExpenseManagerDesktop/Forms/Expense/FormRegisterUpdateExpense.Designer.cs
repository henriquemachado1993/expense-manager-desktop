namespace ExpenseManagerDesktop.Expense
{
    partial class FormRegisterUpdateExpense
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRegisterUpdateExpense));
            this.listBoxCategories = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxAmount = new System.Windows.Forms.TextBox();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.radioButtonPaid = new System.Windows.Forms.RadioButton();
            this.radioButtonUnpaid = new System.Windows.Forms.RadioButton();
            this.btnSave = new System.Windows.Forms.Button();
            this.dateTimePickerDue = new System.Windows.Forms.DateTimePicker();
            this.textBoxExpenseId = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxCategories
            // 
            this.listBoxCategories.FormattingEnabled = true;
            this.listBoxCategories.ItemHeight = 15;
            this.listBoxCategories.Location = new System.Drawing.Point(6, 197);
            this.listBoxCategories.Name = "listBoxCategories";
            this.listBoxCategories.Size = new System.Drawing.Size(379, 139);
            this.listBoxCategories.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 179);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "*Categorias";
            // 
            // textBoxAmount
            // 
            this.textBoxAmount.Location = new System.Drawing.Point(6, 88);
            this.textBoxAmount.Name = "textBoxAmount";
            this.textBoxAmount.Size = new System.Drawing.Size(123, 23);
            this.textBoxAmount.TabIndex = 4;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(6, 37);
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(379, 23);
            this.textBoxDescription.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "*Descrição";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "*Valor";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(134, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "*Vencimento";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "*Pago?";
            // 
            // radioButtonPaid
            // 
            this.radioButtonPaid.AutoSize = true;
            this.radioButtonPaid.Location = new System.Drawing.Point(11, 148);
            this.radioButtonPaid.Name = "radioButtonPaid";
            this.radioButtonPaid.Size = new System.Drawing.Size(45, 19);
            this.radioButtonPaid.TabIndex = 10;
            this.radioButtonPaid.TabStop = true;
            this.radioButtonPaid.Text = "Sim";
            this.radioButtonPaid.UseVisualStyleBackColor = true;
            // 
            // radioButtonUnpaid
            // 
            this.radioButtonUnpaid.AutoSize = true;
            this.radioButtonUnpaid.Location = new System.Drawing.Point(62, 148);
            this.radioButtonUnpaid.Name = "radioButtonUnpaid";
            this.radioButtonUnpaid.Size = new System.Drawing.Size(47, 19);
            this.radioButtonUnpaid.TabIndex = 11;
            this.radioButtonUnpaid.TabStop = true;
            this.radioButtonUnpaid.Text = "Não";
            this.radioButtonUnpaid.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(310, 342);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Salvar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dateTimePickerDue
            // 
            this.dateTimePickerDue.Location = new System.Drawing.Point(135, 88);
            this.dateTimePickerDue.Name = "dateTimePickerDue";
            this.dateTimePickerDue.Size = new System.Drawing.Size(250, 23);
            this.dateTimePickerDue.TabIndex = 13;
            // 
            // textBoxExpenseId
            // 
            this.textBoxExpenseId.Location = new System.Drawing.Point(285, 147);
            this.textBoxExpenseId.Name = "textBoxExpenseId";
            this.textBoxExpenseId.Size = new System.Drawing.Size(100, 23);
            this.textBoxExpenseId.TabIndex = 14;
            this.textBoxExpenseId.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxExpenseId);
            this.groupBox1.Controls.Add(this.listBoxCategories);
            this.groupBox1.Controls.Add(this.dateTimePickerDue);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.textBoxAmount);
            this.groupBox1.Controls.Add(this.radioButtonUnpaid);
            this.groupBox1.Controls.Add(this.textBoxDescription);
            this.groupBox1.Controls.Add(this.radioButtonPaid);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(394, 376);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Despesa";
            // 
            // FormRegisterUpdateExpense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 400);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormRegisterUpdateExpense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrar";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ListBox listBoxCategories;
        private Label label1;
        private TextBox textBoxAmount;
        private TextBox textBoxDescription;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private RadioButton radioButtonPaid;
        private RadioButton radioButtonUnpaid;
        private Button btnSave;
        private DateTimePicker dateTimePickerDue;
        private TextBox textBoxExpenseId;
        private GroupBox groupBox1;
    }
}