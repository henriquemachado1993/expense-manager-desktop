using ExpenseManagerDesktop.Infra;
using ExpenseManagerDesktop.Infra.Contexts;
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
        public static ServiceProvider ServiceProvider { get; private set; }

        public static void ConfigureServices()
        {
            var services = new ServiceCollection();

            // Configurar a conexão com o banco de dados
            var connectionString = "Server=localhost;port=3306;Database=dbExpenseManagementDesktop;User=root;Password=optimus1993;";
            var serverVersion = new MySqlServerVersion(new Version(5, 7, 37));
            services.AddDbContext<ExpenseManagerContext>(options =>
                options.UseMySql(connectionString, serverVersion, b => b.MigrationsAssembly("ExpenseManagerDesktop.Infra")));

            DependenciesInjector.Register(services);

            ServiceProvider = services.BuildServiceProvider();
        }

        //var service = DependecyInjectorContainer.ServiceProvider.GetRequiredService<Interfacedesejada>();
    }
}
