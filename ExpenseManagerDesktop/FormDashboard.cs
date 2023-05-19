using ExpenseManagerDesktop.ContextsInfo;
using ExpenseManagerDesktop.Domain.Entities;
using ExpenseManagerDesktop.Domain.Helpers;
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

namespace ExpenseManagerDesktop
{
    public partial class FormDashBoard : Form
    {

        private TabControlManager tabControlManager;

        public FormDashBoard()
        {
            InitializeComponent();

            if (SessionUser.IsLogged)
            {
                this.labelNameUserLogged.Text = SessionUser.UserName;
            }

            LoadExpensesToBePaid();
            LoadTotalOnBankAccount();

            // Controle de tabs
            tabControlManager = new TabControlManager(this.tabControlMain);
            tabControlManager.LoadData(this.tabControlMain.TabPages["tabPageExpenses"]); // inicia o tab de despesas ao carregar a páginas
        }

        private void linkLabelLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SessionUser.Logout();

            FormManager manager = new FormManager(this);
            manager.OpenNewForm(new FormLogin());
        }

        #region Dados de despesas a pagar e total nas contas bancárias

        /// <summary>
        /// Carrega as despesas a pagar
        /// </summary>
        private void LoadExpensesToBePaid()
        {
            var service = DependecyInjectorContainer.GetService<IExpenseService>();
            var result = service.GetFiltered();

            if (result.IsValid)
            {
                var expenses = result.Data;
                if (expenses.Any())
                {
                    var totalTobePaid = expenses.Select(x => x.Amount).Sum();
                    ExpenseDataContext.ExpensesToBePaid = totalTobePaid;
                    ExpenseDataContext.TotalAccountsPayable = expenses.Count;

                    this.labelTextExpensesToBePaid.Text = $"Você tem {expenses.Count} cotas a pagar no total de { CurrencyHelper.FormatCurrency(totalTobePaid) }";
                }
                else
                    this.labelTextExpensesToBePaid.Text = $"Você não possui contas a pagar.";
            }
            else
            {
                this.labelTextExpensesToBePaid.Text = $"Você não possui contas a pagar.";
            }
        }

        /// <summary>
        /// Carrega as informações de saldo bancário
        /// </summary>
        private void LoadTotalOnBankAccount()
        {
            var service = DependecyInjectorContainer.GetService<IBankAccountsService>();
            var result = service.GetFiltered();

            // informaçoes de saldo da conta
            if (result.IsValid)
            {
                decimal total = result.Data?.Select(x => x.AccountValue)?.Sum() ?? 0;
                ExpenseDataContext.TotalBalanceAccount = total;

                this.labelTotalBalance.Text = CurrencyHelper.FormatCurrency(total);
            }
            else
            {
                this.labelTotalBalance.Text = CurrencyHelper.FormatCurrency(0);
            }

            // Informaçoes do saldo descontando despesas
            this.labelBalanceMinusExpenses.BackColor = ExpenseDataContext.BalanceMinusExpenses < 0 ? Color.Red : Color.Green;
            this.labelBalanceMinusExpenses.Text = $"{ CurrencyHelper.FormatCurrency(ExpenseDataContext.BalanceMinusExpenses) }";
        }

        #endregion


    }
}
