namespace ExpenseManagerDesktop.Expense
{
    partial class FormListExpenses
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
            this.btnNewExpense = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnNewExpense
            // 
            this.btnNewExpense.Location = new System.Drawing.Point(39, 18);
            this.btnNewExpense.Name = "btnNewExpense";
            this.btnNewExpense.Size = new System.Drawing.Size(75, 23);
            this.btnNewExpense.TabIndex = 0;
            this.btnNewExpense.Text = "Novo";
            this.btnNewExpense.UseVisualStyleBackColor = true;
            this.btnNewExpense.Click += new System.EventHandler(this.btnNewExpense_Click);
            // 
            // ListExpenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnNewExpense);
            this.Name = "ListExpenses";
            this.Text = "Despesas";
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnNewExpense;
    }
}