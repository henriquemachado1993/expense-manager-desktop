using ExpenseManagerDesktop.Domain.Interfaces.Services;
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
        private TabControl tabControl;
        private Dictionary<TabPage, DataGridView> dataGridViews;
        private Dictionary<TabPage, bool> dataLoaded;

        public TabControlManager(TabControl tabControl)
        {
            this.tabControl = tabControl;
            this.dataGridViews = new Dictionary<TabPage, DataGridView>();
            this.dataLoaded = new Dictionary<TabPage, bool>();

            foreach (TabPage tabPage in tabControl.TabPages)
            {
                DataGridView dataGridView = tabPage.Controls.OfType<DataGridView>().FirstOrDefault();
                if (dataGridView != null)
                {
                    dataGridViews.Add(tabPage, dataGridView);
                    dataLoaded.Add(tabPage, false);
                }
            }

            tabControl.Selected += TabControl_Selected;
        }

        private void TabControl_Selected(object sender, TabControlEventArgs e)
        {
            TabPage? selectedTabPage = e.TabPage;
            if (selectedTabPage != null && !dataLoaded[selectedTabPage])
            {
                LoadData(selectedTabPage);
                dataLoaded[selectedTabPage] = true;
            }
        }

        public void LoadData(TabPage tabPage)
        {
            // Lógica para carregar os dados no DataGridView correspondente à guia
            DataGridView dataGridView = dataGridViews[tabPage];

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
            //dataGridView.AutoGenerateColumns = false;
            //dataGridView.Columns.Add("ID", "ID");
            //dataGridView.Columns["ID"].DataPropertyName = "Id";
            //dataGridView.Columns.Add("Title", "Título");
            //dataGridView.Columns["Title"].DataPropertyName = "Title";
            //dataGridView.Columns.Add("Description", "Descrição");
            //dataGridView.Columns["Description"].DataPropertyName = "Description";
        }
    }
}
