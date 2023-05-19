using ExpenseManagerDesktop.Category;
using ExpenseManagerDesktop.Domain.Helpers;
using ExpenseManagerDesktop.Domain.Interfaces.Services;
using ExpenseManagerDesktop.Expense;
using ExpenseManagerDesktop.Infra;

namespace ExpenseManagerDesktop
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

            if (SessionUser.IsLogged)
            {
                this.UserNameLogged.Text = SessionUser.UserName;
            }

            LoadExpensesToBePaid();
        }

        private void LoadExpensesToBePaid()
        {
            var service = DependecyInjectorContainer.GetService<IExpenseService>();
            var result = service.GetFiltered();

            if (result.IsValid)
            {
                var expenses = result.Data;
                if(expenses.Any())
                    this.labelTextExpensesToBePaid.Text = $"Você tem {expenses.Count} cotas a pagar no total de { expenses.Select(x => x.Amount).Sum() }";
                else
                    this.labelTextExpensesToBePaid.Text = $"Você não possui contas a pagar.";
            }
            else
            {
                this.labelTextExpensesToBePaid.Text = "Problema ao carregar as informações.";
            }
        }

        private void btnExpenses_Click(object sender, EventArgs e)
        {
            FormManager manager = new FormManager();
            manager.OpenNewForm(new FormListExpenses());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            SessionUser.Logout();

            FormManager manager = new FormManager(this);
            manager.OpenNewForm(new FormLogin());
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            FormManager manager = new FormManager();
            manager.OpenNewForm(new FormListCategories());
        }
    }
}