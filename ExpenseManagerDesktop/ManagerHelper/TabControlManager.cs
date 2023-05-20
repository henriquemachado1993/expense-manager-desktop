using ExpenseManagerDesktop.BankAccount;
using ExpenseManagerDesktop.Category;
using ExpenseManagerDesktop.Domain.Interfaces.Services;
using ExpenseManagerDesktop.Expense;
using ExpenseManagerDesktop.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagerDesktop
{
    public class TabControlManager
    {
        private TabControl TabControl;
        private Dictionary<TabPage, DataGridView> DataGridViews;
        private Dictionary<TabPage, bool> DataLoaded;

        public TabControlManager(TabControl tabControl)
        {
            this.TabControl = tabControl;
            this.DataGridViews = new Dictionary<TabPage, DataGridView>();
            this.DataLoaded = new Dictionary<TabPage, bool>();

            foreach (TabPage tabPage in tabControl.TabPages)
            {
                DataGridView dataGridView = tabPage.Controls.OfType<DataGridView>().FirstOrDefault();
                if (dataGridView != null)
                {
                    DataGridViews.Add(tabPage, dataGridView);
                    DataLoaded.Add(tabPage, false);
                }

                Button buttons = tabPage.Controls.OfType<Button>().FirstOrDefault();
                if (buttons != null)
                {
                    switch (buttons.Name)
                    {
                        case "btnNewExpense": buttons.Click += BtnNewExpense_Click; break;
                        case "btnNewCategory": buttons.Click += BtnNewCategory_Click; break;
                        case "btnNewBankAccount": buttons.Click += BtnNewBankAccount_Click; break;
                        default:
                            break;
                    }
                }
            }

            tabControl.Selected += TabControl_Selected;
        }

        private void BtnNewExpense_Click(object sender, EventArgs e)
        {
            FormManager manager = new FormManager();
            manager.OpenNewForm(new FormRegisterUpdateExpense());
        }

        private void BtnNewCategory_Click(object sender, EventArgs e)
        {
            FormManager manager = new FormManager();
            manager.OpenNewForm(new FormRegisterUpdateCategory());
        }

        private void BtnNewBankAccount_Click(object sender, EventArgs e)
        {
            FormManager manager = new FormManager();
            manager.OpenNewForm(new FormRegisterUpdateBankAccount());
        }

        private void TabControl_Selected(object sender, TabControlEventArgs e)
        {
            TabPage? selectedTabPage = e.TabPage;
            if (selectedTabPage != null && !DataLoaded[selectedTabPage])
            {
                LoadData(selectedTabPage);
                DataLoaded[selectedTabPage] = true;
            }
        }

        public void LoadData(TabPage tabPage)
        {
            // Se a aba já tiver sido carregada em algum outro momento, coloco ela como já carregada
            if (!DataLoaded[tabPage])
                DataLoaded[tabPage] = true;

            // Lógica para carregar os dados no DataGridView correspondente à guia
            DataGridView dataGridView = DataGridViews[tabPage];

            if (tabPage.Name == "tabPageExpenses")
            {
                ConfigureDataGridViewColumnsExpenses(dataGridView);
                dataGridView.DataSource = GetExpenses();
            }
            else if (tabPage.Name == "tabPageCategories")
            {
                ConfigureDataGridViewColumnsCategories(dataGridView);
                dataGridView.DataSource = GetCategories();

                //dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            }
            else if (tabPage.Name == "tabPageBankAccounts")
            {
                ConfigureDataGridViewColumnsBankAccounts(dataGridView);
                dataGridView.DataSource = GetBankAccounts();
            }

            DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn();
            editButtonColumn.HeaderText = "Alterar";
            editButtonColumn.Text = "Alterar";
            editButtonColumn.UseColumnTextForButtonValue = true;
            dataGridView.Columns.Add(editButtonColumn);

            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
            deleteButtonColumn.HeaderText = "Excluir";
            deleteButtonColumn.Text = "Excluir";
            deleteButtonColumn.UseColumnTextForButtonValue = true;
            dataGridView.Columns.Add(deleteButtonColumn);

            //ConfigurarColunasDataGridView(dataGridView);
        }

        private List<Domain.Entities.Expense> GetExpenses()
        {
            var serviceCategory = DependecyInjectorContainer.GetService<IExpenseService>();
            var result = serviceCategory.GetFiltered();
            return result.IsValid ? result.Data : new List<Domain.Entities.Expense>();
        }

        private List<Domain.Entities.Category> GetCategories()
        {
            var serviceCategory = DependecyInjectorContainer.GetService<ICategoryService>();
            var result = serviceCategory.GetFiltered();
            return result.IsValid ? result.Data : new List<Domain.Entities.Category>();
        }

        private List<Domain.Entities.BankAccounts> GetBankAccounts()
        {
            var serviceCategory = DependecyInjectorContainer.GetService<IBankAccountsService>();
            var result = serviceCategory.GetFiltered();
            return result.IsValid ? result.Data : new List<Domain.Entities.BankAccounts>();
        }

        private void ConfigureDataGridViewColumnsExpenses(DataGridView dataGridView)
        {
            dataGridView.AutoGenerateColumns = false;
            dataGridView.Columns.Add("ID", "ID");
            dataGridView.Columns["ID"].DataPropertyName = "Id";
            dataGridView.Columns.Add("Description", "Descrição");
            dataGridView.Columns["Description"].DataPropertyName = "Description";
            dataGridView.Columns.Add("ExpenseDate", "Vencimento");
            dataGridView.Columns["ExpenseDate"].DataPropertyName = "ExpenseDate";
            dataGridView.Columns.Add("Amount", "Valor R$");
            dataGridView.Columns["Amount"].DataPropertyName = "Amount";
            dataGridView.Columns.Add("CategoryTitle", "Categoria");
            dataGridView.Columns["CategoryTitle"].DataPropertyName = "Category.Title";
        }

        private void ConfigureDataGridViewColumnsCategories(DataGridView dataGridView)
        {
            dataGridView.AutoGenerateColumns = false;
            dataGridView.Columns.Add("ID", "ID");
            dataGridView.Columns["ID"].DataPropertyName = "Id";
            dataGridView.Columns.Add("Title", "Título");
            dataGridView.Columns["Title"].DataPropertyName = "Title";
            dataGridView.Columns.Add("Description", "Descrição");
            dataGridView.Columns["Description"].DataPropertyName = "Description";
        }

        private void ConfigureDataGridViewColumnsBankAccounts(DataGridView dataGridView)
        {
            dataGridView.AutoGenerateColumns = false;
            dataGridView.Columns.Add("ID", "ID");
            dataGridView.Columns["ID"].DataPropertyName = "Id";
            dataGridView.Columns.Add("Title", "Título");
            dataGridView.Columns["Title"].DataPropertyName = "Title";
            dataGridView.Columns.Add("AccountValue", "Total R$");
            dataGridView.Columns["AccountValue"].DataPropertyName = "AccountValue";
            dataGridView.Columns.Add("LastModifiedAt", "Atualizado em");
            dataGridView.Columns["LastModifiedAt"].DataPropertyName = "LastModifiedAt";
        }

        private void ConfigurarColunasDataGridView(DataGridView dataGridView)
        {
            // Configurar as colunas do DataGridView para ajuste automático
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }
    }
}
