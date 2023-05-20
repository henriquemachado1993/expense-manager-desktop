using ExpenseManagerDesktop.Contexts;
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

namespace ExpenseManagerDesktop.Expense
{
    public partial class FormRegisterUpdateExpense : Form
    {
        /// <summary>
        /// Armazena as alterações feitas no registro, para um uso em outro form
        /// </summary>
        public Domain.Entities.Expense ChangedData { get; private set; }


        public FormRegisterUpdateExpense(int idExpense = 0)
        {
            InitializeComponent();
            LoadCategories();
            LoadExpense(idExpense);
            // Altera o título da janela
            if (idExpense > 0 || !string.IsNullOrEmpty(this.textBoxExpenseId.Text))
                this.Text = "Alterar";
        }

        private void LoadCategories()
        {
            var serviceCategory = DependecyInjectorContainer.GetService<ICategoryService>();
            var resultCategories = serviceCategory.GetFiltered();

            if (!resultCategories.IsValid)
            {
                MessageBox.Show("Houve um problema ao carregar as categorias", "Desculpe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var items = resultCategories.Data.Select(x => new DataItem<int> { Key = x.Id, Value = x.Title }).ToList();
            
            this.listBoxCategories.Items.Clear();
            this.listBoxCategories.DataSource = items;
            this.listBoxCategories.DisplayMember = "Value";
            this.listBoxCategories.ValueMember = "Key";
        }

        private void LoadExpense(int expenseId = 0)
        {
            if (expenseId > 0)
            {
                var serviceCategory = DependecyInjectorContainer.GetService<IExpenseService>();
                var result = serviceCategory.GetById(expenseId);

                if (result.IsValid)
                {
                    this.textBoxExpenseId.Text = result.Data.Id.ToString();
                    this.textBoxDescription.Text = result.Data.Description;
                    this.textBoxAmount.Text = result.Data.Amount.ToString();
                    this.dateTimePickerDue.Value = result.Data.ExpenseDate;

                    if (result.Data.IsPaid == 1)
                        this.radioButtonPaid.Checked = true;
                    else
                        this.radioButtonUnpaid.Checked = true;

                    int selectedIndex = -1;
                    for (int i = 0; i < this.listBoxCategories.Items.Count; i++)
                    {
                        if (((DataItem<int>)listBoxCategories.Items[i]).Key == result.Data.CategoryId)
                        {
                            selectedIndex = i;
                            break;
                        }
                    }
                    this.listBoxCategories.SelectedIndex = selectedIndex;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var service = DependecyInjectorContainer.GetService<IExpenseService>();

            var selectedCategory = (DataItem<int>)this.listBoxCategories.SelectedItem;

            var listValidations = ValidateForm();
            if (listValidations.Any())
            {
                MessageBox.Show(string.Join(" | ", listValidations.Select(x => x)), "Desculpe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(this.textBoxExpenseId.Text))
            {
                var resultAdd = service.Add(new Domain.Entities.Expense()
                {
                    UserId = SessionUser.UserId,
                    Description = this.textBoxDescription.Text,
                    Amount = decimal.Parse(this.textBoxAmount.Text),
                    CategoryId = selectedCategory.Key,
                    IsPaid = this.radioButtonPaid.Checked ? 1 : 0,
                    ExpenseDate = this.dateTimePickerDue.Value
                });

                if (resultAdd.IsValid)
                {
                    this.textBoxExpenseId.Text = resultAdd.Data.Id.ToString();
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
                int.TryParse(this.textBoxExpenseId.Text, out int id);
                var resultUpdate = service.Update(new Domain.Entities.Expense()
                {
                    Id = id,
                    UserId = SessionUser.UserId,
                    Description = this.textBoxDescription.Text,
                    Amount = decimal.Parse(this.textBoxAmount.Text),
                    CategoryId = selectedCategory.Key,
                    IsPaid = this.radioButtonPaid.Checked ? 1 : 0,
                    ExpenseDate = this.dateTimePickerDue.Value
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
            if (string.IsNullOrWhiteSpace(this.textBoxDescription.Text))
                listErrors.Add("Campo 'Descrição' é obrigatório!");

            if (string.IsNullOrWhiteSpace(this.textBoxAmount.Text))
                listErrors.Add("Campo 'Valor' é obrigatório!");

            if (this.dateTimePickerDue.Value == DateTime.MinValue)
                listErrors.Add("Campo 'Vencimento' é obrigatório!");

            if (!this.radioButtonPaid.Checked && !this.radioButtonUnpaid.Checked)
                listErrors.Add("É necessário especificar se a despesa foi paga ou não!");

            if (this.listBoxCategories.SelectedItem == null)
                listErrors.Add("Você precisa especificar uma categoria para a despesa!");

            return listErrors;
        }
    }
}
