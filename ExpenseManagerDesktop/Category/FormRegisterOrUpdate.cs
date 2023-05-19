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

namespace ExpenseManagerDesktop.Category
{
    public partial class FormRegisterOrUpdate : Form
    {
        /// <summary>
        /// Armazena as alterações feitas no registro, para um uso em outro form
        /// </summary>
        public Domain.Entities.Category ChangedData { get; private set; }

        public FormRegisterOrUpdate(int idCategory = 0)
        {
            InitializeComponent();
            LoadCategory(idCategory);

            // Altera o título da janela
            if (idCategory > 0 || !string.IsNullOrEmpty(this.textBoxCategoryId.Text))
                this.Text = "Alterar";
        }

        private void LoadCategory(int categoryId = 0)
        {
            if (categoryId > 0)
            {
                var serviceCategory = DependecyInjectorContainer.GetService<ICategoryService>();
                var result = serviceCategory.GetById(categoryId);

                if (result.IsValid)
                {
                    this.textBoxCategoryId.Text = result.Data.Id.ToString();
                    this.textBoxTitle.Text = result.Data.Title;
                    this.textBoxDescription.Text = result.Data.Description;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var serviceCategory = DependecyInjectorContainer.GetService<ICategoryService>();

            if (string.IsNullOrEmpty(this.textBoxCategoryId.Text))
            {
                var resultAdd = serviceCategory.Add(new Domain.Entities.Category()
                {
                    Title = this.textBoxTitle.Text,
                    Description = this.textBoxDescription.Text
                });

                if (resultAdd.IsValid)
                {
                    this.textBoxCategoryId.Text = resultAdd.Data.Id.ToString();
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
                int.TryParse(this.textBoxCategoryId.Text, out int id);
                var resultUpdate = serviceCategory.Update(new Domain.Entities.Category()
                {
                    Id = id,
                    Title = this.textBoxTitle.Text,
                    Description = this.textBoxDescription.Text
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
        }
    }
}
