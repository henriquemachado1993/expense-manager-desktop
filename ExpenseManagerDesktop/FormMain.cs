using ExpenseManagerDesktop.Domain.Helpers;
using ExpenseManagerDesktop.Expense;

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
    }
}