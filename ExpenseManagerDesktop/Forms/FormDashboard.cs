using ExpenseManagerDesktop.Contexts;
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

            ExpenseDataContext.FormDashBoard = this;
            ExpenseDataContext.EventHandler += LoadExpensesToBePaid;
            ExpenseDataContext.EventHandler += LoadTotalOnBankAccount;
            ExpenseDataContext.LoadExpenseData();

            LoadControlTabs();
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
        public void LoadExpensesToBePaid(object sender, EventArgs e)
        {
            if (ExpenseDataContext.ExpensesToBePaid > 0)
            {
                this.labelTextExpensesToBePaid.Text = $"Você tem {ExpenseDataContext.TotalAccountsPayable} cotas a pagar no total de { CurrencyHelper.FormatCurrency(ExpenseDataContext.ExpensesToBePaid) }";
            }
            else
                this.labelTextExpensesToBePaid.Text = $"Você não possui contas a pagar.";
        }

        /// <summary>
        /// Carrega as informações de saldo bancário
        /// </summary>
        public void LoadTotalOnBankAccount(object sender, EventArgs e)
        {
            // informaçoes de saldo da conta
            this.labelTotalBalance.Text = CurrencyHelper.FormatCurrency(ExpenseDataContext.TotalBalanceAccount);

            // Informaçoes do saldo descontando despesas
            this.labelBalanceMinusExpenses.ForeColor = ExpenseDataContext.BalanceMinusExpenses < 0 ? Color.Red : Color.Green;
            //this.labelBalanceMinusExpenses.BackColor = ExpenseDataContext.BalanceMinusExpenses < 0 ? Color.Red : Color.Green;
            this.labelBalanceMinusExpenses.Text = $"{ CurrencyHelper.FormatCurrency(ExpenseDataContext.BalanceMinusExpenses) }";
        }

        #endregion

        private void LoadControlTabs()
        {
            // Controle de tabs
            tabControlManager = new TabControlManager(this.tabControlMain);
            tabControlManager.LoadData(this.tabControlMain.TabPages["tabPageExpenses"]); // inicia o tab de despesas ao carregar a páginas
        }

        private void btnRefreshDataGridView_Click(object sender, EventArgs e)
        {
            tabControlManager.RefreshDataGridViewControl(this.tabControlMain.SelectedTab);
        }
    }
}
