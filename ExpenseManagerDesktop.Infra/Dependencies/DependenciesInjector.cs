using Microsoft.Extensions.DependencyInjection;
using ExpenseManagerDesktop.Domain.Interfaces.Data;
using ExpenseManagerDesktop.Infra.Repositories;

namespace ExpenseManagerDesktop.Infra
{
    public class DependenciesInjector
    {
        public static void Register(IServiceCollection svcCollection)
        {
            // Services
            //svcCollection.AddScoped<ICategoryService, CategoryService>();
            //svcCollection.AddScoped<IBankAccountsService, BankAccountsService>();
            //svcCollection.AddScoped<IExpenseService, ExpenseService>();

            // Repositories
            svcCollection.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            svcCollection.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        }
    }
}
