using ExpenseManagerDesktop.Contexts;
using ExpenseManagerDesktop.Domain.Enuns;
using ExpenseManagerDesktop.Domain.Helpers;
using ExpenseManagerDesktop.Domain.Interfaces.Services;
using ExpenseManagerDesktop.Domain.ValueObjects;
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

namespace ExpenseManagerDesktop.BankAccount
{
    public partial class FormRegisterUpdateBankAccount : Form
    {
        /// <summary>
        /// Armazena as alterações feitas no registro, para um uso em outro form
        /// </summary>
        public Domain.Entities.BankAccounts ChangedData { get; private set; }

        public FormRegisterUpdateBankAccount(int idBankAccount = 0)
        {
            InitializeComponent();
            LoadTypeBankAccount();
            LoadBankAccount(idBankAccount);

            // Altera o título da janela
            if (idBankAccount > 0 || !string.IsNullOrEmpty(this.textBoxBankAccountId.Text))
                this.Text = "Alterar";
        }

        private void LoadTypeBankAccount()
        {
            List<DataItem<int>> items = EnumHelper.GetEnumList<TypeBankAccount, int>();

            this.listBoxTypeBankAccount.Items.Clear();
            this.listBoxTypeBankAccount.DataSource = items;
            this.listBoxTypeBankAccount.DisplayMember = "Value";
            this.listBoxTypeBankAccount.ValueMember = "Key";
        }

        private void LoadBankAccount(int bankAccountId = 0)
        {
            if (bankAccountId > 0)
            {
                var serviceCategory = DependecyInjectorContainer.GetService<IBankAccountsService>();
                var result = serviceCategory.GetById(bankAccountId);

                if (result.IsValid)
                {
                    this.textBoxBankAccountId.Text = result.Data.Id.ToString();
                    this.textBoxTitle.Text = result.Data.Title;
                    this.textBoxTotalBalance.Text = result.Data.AccountValue.ToString();

                    int selectedIndex = -1;
                    for (int i = 0; i < this.listBoxTypeBankAccount.Items.Count; i++)
                    {
                        if (((DataItem<int>)listBoxTypeBankAccount.Items[i]).Key == result.Data.Type)
                        {
                            selectedIndex = i;
                            break;
                        }
                    }
                    this.listBoxTypeBankAccount.SelectedIndex = selectedIndex;
                }
            }
        }

        private void btnSaveBankAccount_Click(object sender, EventArgs e)
        {
            var service = DependecyInjectorContainer.GetService<IBankAccountsService>();

            var selectedBankAccount = (DataItem<int>)this.listBoxTypeBankAccount.SelectedItem;

            var listValidations = ValidateForm();
            if (listValidations.Any())
            {
                MessageBox.Show(string.Join(" | ", listValidations.Select(x => x)), "Desculpe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(this.textBoxBankAccountId.Text))
            {
                var resultAdd = service.Add(new Domain.Entities.BankAccounts()
                {
                    UserId = SessionUser.UserId,
                    Title = this.textBoxTitle.Text,
                    AccountValue = decimal.Parse(this.textBoxTotalBalance.Text),
                    Type = selectedBankAccount.Key
                });

                if (resultAdd.IsValid)
                {
                    this.textBoxBankAccountId.Text = resultAdd.Data.Id.ToString();
                    this.Text = "Alterar";
                    MessageBox.Show("Registrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(string.Join(" | ", resultAdd.Messages.Select(x => x.Message)), "Desculpe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                int.TryParse(this.textBoxBankAccountId.Text, out int id);
                var resultUpdate = service.Update(new Domain.Entities.BankAccounts()
                {
                    Id = id,
                    UserId = SessionUser.UserId,
                    Title = this.textBoxTitle.Text,
                    AccountValue = decimal.Parse(this.textBoxTotalBalance.Text),
                    Type = selectedBankAccount.Key
                });

                if (resultUpdate.IsValid)
                {
                    MessageBox.Show("Alterado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ChangedData = resultUpdate.Data;
                }
                else
                {
                    MessageBox.Show(string.Join(" | ", resultUpdate.Messages.Select(x => x.Message)), "Desculpe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            ExpenseDataContext.RefreshExpenseData();
        }

        private List<string> ValidateForm()
        {
            var listErrors = new List<string>();
            if (string.IsNullOrWhiteSpace(this.textBoxTitle.Text))
                listErrors.Add("Campo 'Título' é obrigatório!");

            if (string.IsNullOrWhiteSpace(this.textBoxTotalBalance.Text))
                listErrors.Add("Campo 'Total na conta' é obrigatório!");

            if (this.listBoxTypeBankAccount.SelectedItem == null)
                listErrors.Add("Você precisa especificar o tipo da conta!");

            return listErrors;
        }
    }
}
