using ExpenseManagerDesktop.BankAccount;
using ExpenseManagerDesktop.Category;
using ExpenseManagerDesktop.Contexts;
using ExpenseManagerDesktop.Domain.Interfaces.Services;
using ExpenseManagerDesktop.Expense;
using ExpenseManagerDesktop.Infra;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
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

        public delegate void DataGridViewActionDelegate(int rowId, DataGridView dataGrid, ActionType actionType);
        public event DataGridViewActionDelegate ExpenseAction;
        public event DataGridViewActionDelegate CategoryAction;
        public event DataGridViewActionDelegate BankAccountAction;

        private BindingList<Domain.Entities.Expense> expensesBindingList;
        private BindingList<Domain.Entities.Category> categoriesBindingList;
        private BindingList<Domain.Entities.BankAccounts> bankAccountsBindingList;

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

            GridViewActionDelegates();
        }

        #region Configuração para abrir páginas de novo registro

        private void BtnNewExpense_Click(object sender, EventArgs e)
        {
            FormManager manager = new FormManager();
            var form = new FormRegisterUpdateExpense();
            manager.OpenNewForm(form);
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

        #endregion

        private void TabControl_Selected(object sender, TabControlEventArgs e)
        {
            TabPage? selectedTabPage = e.TabPage;
            if (selectedTabPage != null && !DataLoaded[selectedTabPage])
            {
                LoadData(selectedTabPage);
                DataLoaded[selectedTabPage] = true;
            }
        }

        public void RefreshDataGridViewControl(TabPage selectedPage)
        {
            if (selectedPage != null)
            {
                DataGridView dataGridView = DataGridViews[selectedPage];
                dataGridView.Rows.Clear();
                dataGridView.Columns.Clear();

                LoadData(selectedPage);
            }
        }

        public void LoadData(TabPage tabPage)
        {
            // Lógica para carregar os dados no DataGridView correspondente à guia
            DataGridView dataGridView = DataGridViews[tabPage];

            // Se a aba já tiver sido carregada em algum outro momento, coloco ela como já carregada
            if (!DataLoaded[tabPage])
                DataLoaded[tabPage] = true;

            if (tabPage.Name == "tabPageExpenses")
            {
                ConfigureDataGridViewColumnsExpenses(dataGridView);
                dataGridView.DataSource = expensesBindingList = new BindingList<Domain.Entities.Expense>(GetExpenses());
            }
            else if (tabPage.Name == "tabPageCategories")
            {
                ConfigureDataGridViewColumnsCategories(dataGridView);
                dataGridView.DataSource = categoriesBindingList = new BindingList<Domain.Entities.Category>(GetCategories());

                //dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            }
            else if (tabPage.Name == "tabPageBankAccounts")
            {
                ConfigureDataGridViewColumnsBankAccounts(dataGridView);
                dataGridView.DataSource = bankAccountsBindingList = new BindingList<Domain.Entities.BankAccounts>(GetBankAccounts());
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

            dataGridView.CellContentClick += dataGridView_CellContentClick;

            dataGridView.AllowUserToAddRows = false;

            //ConfigurarColunasDataGridView(dataGridView);
        }

        #region Busca as informações para preenchimento do DataGrid

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

        #endregion

        #region Configuração das colunas do dataGrid

        private void ConfigureDataGridViewColumnsExpenses(DataGridView dataGridView)
        {
            dataGridView.AutoGenerateColumns = false;
            dataGridView.Columns.Add("ID", "ID");
            dataGridView.Columns["ID"].DataPropertyName = "Id";
            dataGridView.Columns.Add("Description", "Descrição");
            dataGridView.Columns["Description"].DataPropertyName = "Description";
            dataGridView.Columns.Add("ExpenseDate", "Vencimento");
            dataGridView.Columns["ExpenseDate"].DataPropertyName = "ExpenseDate";

            dataGridView.Columns.Add("Amount", "Valor");
            dataGridView.Columns["Amount"].DataPropertyName = "Amount";
            dataGridView.Columns["Amount"].DefaultCellStyle.Format = "C2";
            dataGridView.Columns["Amount"].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("pt-BR");

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

            dataGridView.Columns.Add("AccountValue", "Total");
            dataGridView.Columns["AccountValue"].DataPropertyName = "AccountValue";
            dataGridView.Columns["AccountValue"].DefaultCellStyle.Format = "C2";
            dataGridView.Columns["AccountValue"].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("pt-BR");

            dataGridView.Columns.Add("LastModifiedAt", "Atualizado em");
            dataGridView.Columns["LastModifiedAt"].DataPropertyName = "LastModifiedAt";
        }

        #endregion

        // <summary>
        // Método responsável por realizar alteração e exclusão dos registros
        // </summary>
        // <param name="sender"></param>
        // <param name="e"></param>
        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridView dataGridView = (DataGridView)sender;

                if (dataGridView.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                {
                    string columnName = dataGridView.Columns[e.ColumnIndex].HeaderText;
                    int rowId = (int)dataGridView.Rows[e.RowIndex].Cells["ID"].Value;

                    FormManager formManager = new FormManager();

                    ActionType actionType = columnName == "Alterar" ? ActionType.Update : ActionType.Delete;

                    bool canProceed = true;
                    if (actionType == ActionType.Delete)
                    {
                        var resultDialog = MessageBox.Show("Tem certeza que deseja excluir o registro?", "Confirmação", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                        canProceed = resultDialog == DialogResult.Yes;
                    }

                    if (canProceed && ExpenseAction != null && dataGridView.Name == "dataGridViewExpenses")
                    {
                        ExpenseAction.Invoke(rowId, dataGridView, actionType);
                    }
                    else if (canProceed && CategoryAction != null && dataGridView.Name == "dataGridViewCategories")
                    {
                        CategoryAction.Invoke(rowId, dataGridView, actionType);
                    }
                    else if (canProceed && BankAccountAction != null && dataGridView.Name == "dataGridViewBankAccounts")
                    {
                        BankAccountAction.Invoke(rowId, dataGridView, actionType);
                    }
                }
            }
        }

        public void GridViewActionDelegates()
        {
            FormManager formManager = new FormManager();

            // Ação no DataGridView de Expenses
            ExpenseAction += (rowId, dataGridView, actionType) =>
            {
                if (actionType == ActionType.Update)
                {
                    var formUpdate = new FormRegisterUpdateExpense(rowId);
                    formUpdate.FormClosed += (sender, e) =>
                    {
                        if (sender != null)
                        {
                            FormRegisterUpdateExpense form = (FormRegisterUpdateExpense)sender;
                            if (form.ChangedData != null)
                            {
                                int rowIndex = dataGridView.SelectedCells[0].RowIndex;
                                dataGridView.Rows[rowIndex].Cells["Description"].Value = form.ChangedData.Description;
                                dataGridView.Rows[rowIndex].Cells["ExpenseDate"].Value = form.ChangedData.ExpenseDate;
                                dataGridView.Rows[rowIndex].Cells["Amount"].Value = form.ChangedData.Amount;
                                dataGridView.Rows[rowIndex].Cells["CategoryTitle"].Value = form.ChangedData.Category?.Title;

                                dataGridView.Refresh();
                                ExpenseDataContext.RefreshExpenseData();
                            }
                        }
                    };
                    formManager.OpenNewForm(formUpdate);
                }
                else if (actionType == ActionType.Delete)
                {
                    var service = DependecyInjectorContainer.GetService<IExpenseService>();
                    var result = service.Delete(rowId);

                    if (result.IsValid)
                    {
                        MessageBox.Show("Registro deletado com sucesso!", "Desculpe", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Remover a linha excluída
                        expensesBindingList.RemoveAt(dataGridView.SelectedCells[0].RowIndex);
                        ExpenseDataContext.RefreshExpenseData();
                    }
                    else
                    {
                        MessageBox.Show(string.Join(" | ", result.Messages.Select(x => x.Message)), "Desculpe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            };

            // Ação no DataGridView de Categories
            CategoryAction += (rowId, dataGridView, actionType) =>
            {
                if (actionType == ActionType.Update)
                {
                    var formUpdate = new FormRegisterUpdateCategory(rowId);
                    formUpdate.FormClosed += (sender, e) =>
                    {
                        if (sender != null)
                        {
                            FormRegisterUpdateCategory form = (FormRegisterUpdateCategory)sender;
                            if (form.ChangedData != null)
                            {
                                int rowIndex = dataGridView.SelectedCells[0].RowIndex;
                                dataGridView.Rows[rowIndex].Cells["Title"].Value = form.ChangedData.Title;
                                dataGridView.Rows[rowIndex].Cells["Description"].Value = form.ChangedData.Description;

                                dataGridView.Refresh();
                            }
                        }
                    };
                    formManager.OpenNewForm(formUpdate);
                }
                else if (actionType == ActionType.Delete)
                {
                    var service = DependecyInjectorContainer.GetService<ICategoryService>();
                    var result = service.Delete(rowId);

                    if (result.IsValid)
                    {
                        MessageBox.Show("Registro deletado com sucesso!", "Desculpe", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Remover a linha excluída
                        categoriesBindingList.RemoveAt(dataGridView.SelectedCells[0].RowIndex);
                    }
                    else
                    {
                        MessageBox.Show(string.Join(" | ", result.Messages.Select(x => x.Message)), "Desculpe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            };

            // Ação no DataGridView de BankAccounts
            BankAccountAction += (rowId, dataGridView, actionType) =>
            {
                if (actionType == ActionType.Update)
                {
                    var formUpdate = new FormRegisterUpdateBankAccount(rowId);
                    formUpdate.FormClosed += (sender, e) =>
                    {
                        if (sender != null)
                        {
                            FormRegisterUpdateBankAccount form = (FormRegisterUpdateBankAccount)sender;
                            if (form.ChangedData != null)
                            {
                                int rowIndex = dataGridView.SelectedCells[0].RowIndex;
                                dataGridView.Rows[rowIndex].Cells["Title"].Value = form.ChangedData.Title;
                                dataGridView.Rows[rowIndex].Cells["AccountValue"].Value = form.ChangedData.AccountValue;
                                dataGridView.Rows[rowIndex].Cells["LastModifiedAt"].Value = form.ChangedData.LastModifiedAt;

                                dataGridView.Refresh();
                                ExpenseDataContext.RefreshExpenseData();
                            }
                        }
                    };
                    formManager.OpenNewForm(formUpdate);
                }
                else if (actionType == ActionType.Delete)
                {
                    var service = DependecyInjectorContainer.GetService<IBankAccountsService>();
                    var result = service.Delete(rowId);

                    if (result.IsValid)
                    {
                        MessageBox.Show("Registro deletado com sucesso!", "Desculpe", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Remover a linha excluída
                        bankAccountsBindingList.RemoveAt(dataGridView.SelectedCells[0].RowIndex);
                        ExpenseDataContext.RefreshExpenseData();
                    }
                    else
                    {
                        MessageBox.Show(string.Join(" | ", result.Messages.Select(x => x.Message)), "Desculpe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            };
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

    public enum ActionType
    {
        Update,
        Delete
    }
}
