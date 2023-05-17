using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExpenseManagerDesktop.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Keyword { get; set; }
        public int Status { get; set; }

        // Relationships
        public ICollection<BankAccounts> BankAccounts { get; set; }
        public ICollection<Expense> Expenses { get; set; }
    }
}
