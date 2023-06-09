﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagerDesktop.Domain.Enuns
{
    public enum TypeBankAccount
    {
        [Display(Name = "Conta corrente")]
        CurrentAccount = 1,
        [Display(Name = "Conta salário")]
        SalaryAccount = 2,
        [Display(Name = "Conta poupança")]
        SavingsAccount = 3, 
        [Display(Name = "Conta de Investimentos")]
        InvestimentsAccount = 4,
    }
}
