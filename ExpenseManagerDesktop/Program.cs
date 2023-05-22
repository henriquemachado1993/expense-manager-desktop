using ExpenseManagerDesktop.Domain.Helpers;
using ExpenseManagerDesktop.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ExpenseManagerDesktop
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Configura as injeções de dependencias
            var connectionString = "Server=localhost;port=3306;Database=dbExpenseManagementDesktop;User=root;Password=optimus1993;";
            var services = new ServiceCollection();
            DependecyInjectorContainer.ConfigureServices(services, connectionString);

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            Application.Run(new FormLogin());

            if (SessionUser.IsLogged)
            {
                Application.Run(new FormDashBoard());
            }
        }
    }
}