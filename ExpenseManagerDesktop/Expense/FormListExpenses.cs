using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpenseManagerDesktop.Expense
{
    public partial class FormListExpenses : Form
    {
        public FormListExpenses()
        {
            InitializeComponent();
        }

        private void btnNewExpense_Click(object sender, EventArgs e)
        {
            FormManager manager = new FormManager();
            manager.OpenNewForm(new FormRegisterExpense());
        }
    }
}
