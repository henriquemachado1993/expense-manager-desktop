using ExpenseManagerDesktop.Domain.Interfaces.Data;
using ExpenseManagerDesktop.Domain.Interfaces.Services;
using ExpenseManagerDesktop.Infra;
using ExpenseManagerDesktop.Infra.Contexts;
using ExpenseManagerDesktop.Infra.Repositories;
using ExpenseManagerDesktop.Services.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagerDesktop.Infra
{
    public static class DependecyInjectorContainer
    {
        private static ServiceProvider ServiceProvider { get; set; }

        public static void ConfigureServices(IServiceCollection services, string connectionString)
        {
            // Database
            var serverVersion = new MySqlServerVersion(new Version(5, 7, 37));
            services.AddDbContext<ExpenseManagerContext>(options =>
                //options.UseMySql(connectionString, serverVersion, b => b.MigrationsAssembly("ExpenseManagerDesktop.Infra")));
                options.UseMySql(connectionString, serverVersion));

            // Services
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IBankAccountsService, BankAccountsService>();
            services.AddScoped<IExpenseService, ExpenseService>();
            services.AddScoped<IUserService, UserService>();

            // Repositories
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            ServiceProvider = services.BuildServiceProvider();
        }

        public static T GetService<T>()
        {
            if (ServiceProvider == null)
                throw new InvalidOperationException("You failed to configure the service provider.");
                
            return ServiceProvider.GetRequiredService<T>();
        }
    }
}
