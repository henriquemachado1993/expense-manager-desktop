using ExpenseManagerDesktop.Domain.Helpers;
using ExpenseManagerDesktop.Domain.Interfaces.Services;
using ExpenseManagerDesktop.Infra;
using ExpenseManagerDesktop.User;
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
            Application.Exit();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            var userService = DependecyInjectorContainer.GetService<IUserService>();
            var result = userService.ValidateLogin(this.textBoxNameUser.Text, this.textBoxPassword.Text);

            if (!result.IsValid)
            {
                MessageBox.Show(string.Join(" | ", result.Messages.Select(x => x.Message)), "Desculpe", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var userData = result.Data;
                SessionUser.SetUserLogged(userData.Id, userData.LoginName);

                FormManager manager = new FormManager(this);
                manager.OpenNewForm(new FormDashBoard());
            }
        }

        private void linkLabelRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormManager manager = new FormManager();
            manager.OpenNewForm(new FormRegisterUser());
        }

        private void linkLabelForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormManager manager = new FormManager();
            manager.OpenNewForm(new FormForgotPassword());
        }
    }
}
