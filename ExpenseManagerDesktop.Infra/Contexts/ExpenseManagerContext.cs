using ExpenseManagerDesktop.Domain.Entities;
using ExpenseManagerDesktop.Infra.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagerDesktop.Infra.Contexts
{
    public class ExpenseManagerContext : DbContext
    {
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BankAccounts> BankAccounts { get; set; }
        public DbSet<User> Users { get; set; }

        public ExpenseManagerContext()
        {
        }

        public ExpenseManagerContext(DbContextOptions<ExpenseManagerContext> options)
        : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var serverVersion = new MySqlServerVersion(new Version(5, 7, 37));
                optionsBuilder.UseMySql("Server=localhost;port=3306;Database=dbExpenseManagementDesktop;User=root;Password=optimus1993;", serverVersion); 
                // TODO: buscar a string de conexao de um arquivo de configuração
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new UserMap());
            builder.ApplyConfiguration(new BankAccountsMap());
            builder.ApplyConfiguration(new CategoryMap());
            builder.ApplyConfiguration(new ExpenseMap());
        }
    }
}
