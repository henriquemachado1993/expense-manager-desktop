using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpenseManagerDesktop.User
{
    public partial class FormForgotPassword : Form
    {
        public FormForgotPassword()
        {
            InitializeComponent();
        }

        private void btnConfirmNewPassword_Click(object sender, EventArgs e)
        {
            if(this.textBoxNewPassword == this.textBoxConfirmNewPassword)
            {

            }
            else
            {
                MessageBox.Show("A senhas não conferem!", "Desculpe", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
