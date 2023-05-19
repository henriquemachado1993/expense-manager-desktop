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

namespace ExpenseManagerDesktop.Expense
{
    public partial class FormListExpenses : Form
    {
        public FormListExpenses()
        {
            InitializeComponent();
            LoadExpenses();
        }

        private void btnNewExpense_Click(object sender, EventArgs e)
        {
            FormManager manager = new FormManager();
            manager.OpenNewForm(new FormRegisterUpdateExpense());
        }

        /// <summary>
        /// Faz o carregamento dos registros para o datagridview
        /// </summary>
        private void LoadExpenses()
        {
            var service = DependecyInjectorContainer.GetService<IExpenseService>();

            dataGridViewExpenses.AutoGenerateColumns = false;

            dataGridViewExpenses.Columns.Add("ID", "ID");
            dataGridViewExpenses.Columns["ID"].DataPropertyName = "Id";

            dataGridViewExpenses.Columns.Add("Description", "Descrição");
            dataGridViewExpenses.Columns["Description"].DataPropertyName = "Description";

            dataGridViewExpenses.Columns.Add("ExpenseDate", "Vencimento");
            dataGridViewExpenses.Columns["ExpenseDate"].DataPropertyName = "ExpenseDate";

            dataGridViewExpenses.Columns.Add("Amount", "Valor R$");
            dataGridViewExpenses.Columns["Amount"].DataPropertyName = "Amount";

            dataGridViewExpenses.Columns.Add("CategoryTitle", "Categoria");
            dataGridViewExpenses.Columns["CategoryTitle"].DataPropertyName = "Category.Title";

            this.dataGridViewExpenses.DataSource = service.GetFiltered().Data;

            DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn();
            editButtonColumn.HeaderText = "Alterar";
            editButtonColumn.Text = "Alterar";
            editButtonColumn.UseColumnTextForButtonValue = true;
            dataGridViewExpenses.Columns.Add(editButtonColumn);

            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
            deleteButtonColumn.HeaderText = "Excluir";
            deleteButtonColumn.Text = "Excluir";
            deleteButtonColumn.UseColumnTextForButtonValue = true;
            dataGridViewExpenses.Columns.Add(deleteButtonColumn);

            dataGridViewExpenses.CellContentClick += dataGridView1_CellContentClick;
        }

        /// <summary>
        /// Método responsável por realizar alteração e exclusão dos registros
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (dataGridViewExpenses.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                {
                    string columnName = dataGridViewExpenses.Columns[e.ColumnIndex].HeaderText;
                    int rowId = (int)dataGridViewExpenses.Rows[e.RowIndex].Cells["ID"].Value;

                    FormManager formManager = new FormManager();

                    if (columnName == "Alterar")
                    {
                        var formUpdate = new FormRegisterUpdateExpense(rowId);
                        formUpdate.FormClosed += FormRegisterUpdateExpense_FormClosed;
                        formManager.OpenNewForm(formUpdate);
                    }
                    else if (columnName == "Excluir")
                    {
                        var resultDialog = MessageBox.Show("Tem certeza que deseja excluir o registro?", "Confirmação", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                        if (resultDialog == DialogResult.Yes)
                        {
                            var serviceCategory = DependecyInjectorContainer.GetService<IExpenseService>();
                            var result = serviceCategory.Delete(rowId);

                            if (result.IsValid)
                            {
                                MessageBox.Show("Registro deletado com sucesso!", "Desculpe", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Remover a linha excluída
                                dataGridViewExpenses.Rows.RemoveAt(e.RowIndex);
                            }
                            else
                            {
                                MessageBox.Show(string.Join(" | ", result.Messages.Select(x => x.Message)), "Desculpe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Método para atualizar as células do datagridview com os dados atualizados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormRegisterUpdateExpense_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormRegisterUpdateExpense formExpense = (FormRegisterUpdateExpense)sender;

            if (formExpense.ChangedData != null)
            {
                int rowIndex = dataGridViewExpenses.SelectedCells[0].RowIndex;

                dataGridViewExpenses.Rows[rowIndex].Cells["Description"].Value = formExpense.ChangedData.Description;
                dataGridViewExpenses.Rows[rowIndex].Cells["ExpenseDate"].Value = formExpense.ChangedData.ExpenseDate;
                dataGridViewExpenses.Rows[rowIndex].Cells["Amount"].Value = formExpense.ChangedData.Amount;
                dataGridViewExpenses.Rows[rowIndex].Cells["CategoryTitle"].Value = formExpense.ChangedData.Category?.Title;

                dataGridViewExpenses.Refresh();
            }
        }
    }
}
