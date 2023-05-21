using ExpenseManagerDesktop.Domain.Interfaces.Services;
using ExpenseManagerDesktop.Infra;
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
            if (string.IsNullOrWhiteSpace(this.textBoxLoginName.Text))
            {
                MessageBox.Show("Você precisa informar o seu nome de login", "Desculpe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(this.textBoxKeyworld.Text))
            {
                MessageBox.Show("Você precisa informar a palavra chave", "Desculpe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(this.textBoxNewPassword.Text == this.textBoxConfirmNewPassword.Text)
            {
                var service = DependecyInjectorContainer.GetService<IUserService>();
                var resultUser = service.GetFiltered(new Domain.ValueObjects.QueryCriteria<Domain.Entities.User>()
                {
                    Expression = x => x.LoginName.ToLower() == this.textBoxLoginName.Text.ToLower() && x.Keyword.ToLower() == this.textBoxKeyworld.Text.ToLower(),
                });

                if (resultUser.IsValid && resultUser.Data != null && resultUser.Data.Any())
                {
                    var user = resultUser.Data.FirstOrDefault();
                    user.Password = this.textBoxNewPassword.Text;
                    service.UpdatePassword(user);
                    MessageBox.Show("Sua senha foi alterada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Nenhum usuário foi encontrado!", "Desculpe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("A senhas não conferem!", "Desculpe", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
