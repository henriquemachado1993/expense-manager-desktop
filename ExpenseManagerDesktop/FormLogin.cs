using ExpenseManagerDesktop.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpenseManagerDesktop
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (this.textBoxNameUser.Text == "hmgod" && this.textBoxPassword.Text == "123")
            {
                SessionUser.SetUserLogged(Guid.NewGuid().ToString(), this.textBoxNameUser.Text);

                FormManager manager = new FormManager(this);
                manager.OpenNewForm(new FormMain());
            }
            else
            {
                MessageBox.Show("Usuário ou senha incorretos!", "Desculpe", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabelRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormManager manager = new FormManager();
            manager.OpenNewForm(new FormRegisterUser());
        }
    }
}
