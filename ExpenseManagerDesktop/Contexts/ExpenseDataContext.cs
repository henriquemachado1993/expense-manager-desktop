using ExpenseManagerDesktop.Domain.Entities;
using ExpenseManagerDesktop.Domain.Interfaces.Services;
using ExpenseManagerDesktop.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagerDesktop.Contexts
{
    public static class ExpenseDataContext
    {
        public static Form FormDashBoard { get; set; }
        public static EventHandler EventHandler { get; set; }

        /// <summary>
        /// Total de contas a pagar
        /// </summary>
        public static decimal TotalAccountsPayable { get; private set; }
        /// <summary>
        /// Total a ser pago
        /// </summary>
        public static decimal ExpensesToBePaid { get; private set; }
        /// <summary>
        /// Total em todas as contas
        /// </summary>
        public static decimal TotalBalanceAccount { get; private set; }
        /// <summary>
        /// Total nas contas descontando as despesas
        /// </summary>
        public static decimal BalanceMinusExpenses
        {
            get
            {
                return TotalBalanceAccount - ExpensesToBePaid;
            }
        }

        public static void RefreshExpenseData()
        {
            LoadExpenseData();
        }

        public static void LoadExpenseData()
        {
            var resultExpense = DependecyInjectorContainer.GetService<IExpenseService>().GetTotalAmountOfExpenses();
            var serviceBankAccount = DependecyInjectorContainer.GetService<IBankAccountsService>().GetTotalAmountBankAccounts();

            if (resultExpense.IsValid)
            {
                var tuple = resultExpense.Data;
                TotalAccountsPayable = tuple.Item1;
                ExpensesToBePaid = tuple.Item2;
            }

            if (serviceBankAccount.IsValid)
                TotalBalanceAccount = serviceBankAccount.Data;

            if (FormDashBoard != null && EventHandler != null)
            {
                EventHandler.Invoke(FormDashBoard, new EventArgs());
            }
        }
    }
}
