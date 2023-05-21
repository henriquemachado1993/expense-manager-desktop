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

namespace ExpenseManagerDesktop
{
    public partial class FormRegisterUser : Form
    {
        public FormRegisterUser()
        {
            InitializeComponent();
        }

        private void btnRegister_Click_1(object sender, EventArgs e)
        {
            var listValidations = ValidateForm();
            if (listValidations.Any())
            {
                MessageBox.Show(string.Join(" | ", listValidations.Select(x => x)), "Desculpe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var userService = DependecyInjectorContainer.GetService<IUserService>();
            var result = userService.Add(new Domain.Entities.User()
            {
                LoginName = this.textBoxUserLogin.Text,
                Name = this.textBoxName.Text,
                Keyword = this.textBoxKeyword.Text,
                Password = this.textBoxPassword.Text
            });

            if (!result.IsValid)
            {
                MessageBox.Show(string.Join(" | ", result.Messages.Select(x => x.Message)), "Desculpe", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Registrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private List<string> ValidateForm()
        {
            var listErrors = new List<string>();
            if (string.IsNullOrWhiteSpace(this.textBoxUserLogin.Text))
                listErrors.Add("Campo 'Login' é obrigatório!");

            if (string.IsNullOrWhiteSpace(this.textBoxName.Text))
                listErrors.Add("Campo 'Nome' é obrigatório!");

            if (string.IsNullOrWhiteSpace(this.textBoxPassword.Text))
                listErrors.Add("Campo 'Senha' é obrigatório!");

            if (string.IsNullOrWhiteSpace(this.textBoxKeyword.Text))
                listErrors.Add("Campo 'Palavra chave é obrigatório' é obrigatório!");

            return listErrors;
        }
    }
}
