using ExpenseManagerDesktop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagerDesktop.ContextsInfo
{
    public static class ExpenseDataContext
    {
        /// <summary>
        /// Total de contas a pagar
        /// </summary>
        public static decimal TotalAccountsPayable { get; set; }
        /// <summary>
        /// Total a ser pago
        /// </summary>
        public static decimal ExpensesToBePaid { get; set; }
        /// <summary>
        /// Total em todas as contas
        /// </summary>
        public static decimal TotalBalanceAccount { get; set; }
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
    }
}
