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

namespace ExpenseManagerDesktop.Category
{
    public partial class FormListCategories : Form
    {
        public FormListCategories()
        {
            InitializeComponent();
            LoadCategories();
        }

        private void btnNewRegister_Click(object sender, EventArgs e)
        {
            FormManager manager = new FormManager();
            manager.OpenNewForm(new FormRegisterOrUpdate());
        }

        /// <summary>
        /// Faz o carregamento dos registros para o datagridview
        /// </summary>
        private void LoadCategories()
        {
            var serviceCategory = DependecyInjectorContainer.GetService<ICategoryService>();

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Add("ID", "ID");
            dataGridView1.Columns["ID"].DataPropertyName = "Id";
            dataGridView1.Columns.Add("Title", "Título");
            dataGridView1.Columns["Title"].DataPropertyName = "Title";
            dataGridView1.Columns.Add("Description", "Descrição");
            dataGridView1.Columns["Description"].DataPropertyName = "Description";

            this.dataGridView1.DataSource = serviceCategory.GetFiltered().Data;

            DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn();
            editButtonColumn.HeaderText = "Alterar";
            editButtonColumn.Text = "Alterar";
            editButtonColumn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(editButtonColumn);

            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
            deleteButtonColumn.HeaderText = "Excluir";
            deleteButtonColumn.Text = "Excluir";
            deleteButtonColumn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(deleteButtonColumn);

            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
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
                if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                {
                    string columnName = dataGridView1.Columns[e.ColumnIndex].HeaderText;
                    int rowCategoryId = (int)dataGridView1.Rows[e.RowIndex].Cells["ID"].Value;

                    FormManager formManager = new FormManager();

                    if (columnName == "Alterar")
                    {
                        var formUpdate = new FormRegisterOrUpdate(rowCategoryId);
                        formUpdate.FormClosed += FormRegisterOrUpdate_FormClosed;
                        formManager.OpenNewForm(formUpdate);
                    }
                    else if (columnName == "Excluir")
                    {
                        var resultDialog = MessageBox.Show("Tem certeza que deseja excluir o registro?", "Confirmação", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                        if (resultDialog == DialogResult.Yes)
                        {
                            var serviceCategory = DependecyInjectorContainer.GetService<ICategoryService>();
                            var result = serviceCategory.Delete(rowCategoryId);

                            if (result.IsValid)
                            {
                                MessageBox.Show("Registro deletado com sucesso!", "Desculpe", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Remover a linha excluída
                                dataGridView1.Rows.RemoveAt(e.RowIndex);
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
        private void FormRegisterOrUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormRegisterOrUpdate formRegisterOrUpdate = (FormRegisterOrUpdate)sender;

            if (formRegisterOrUpdate.ChangedData != null)
            {
                int rowIndex = dataGridView1.SelectedCells[0].RowIndex;
                
                dataGridView1.Rows[rowIndex].Cells["Title"].Value = formRegisterOrUpdate.ChangedData.Title;
                dataGridView1.Rows[rowIndex].Cells["Description"].Value = formRegisterOrUpdate.ChangedData.Description;

                dataGridView1.Refresh();
            }
        }
    }
}
