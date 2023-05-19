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
            var connectionString = "Server=localhost;port=3306;Database=dbExpenseManagementDesktop;User=root;Password=optimus1993;";

            // Configura as injeções de dependencias
            DependecyInjectorContainer.ConfigureServices(connectionString);

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            Application.Run(new FormLogin());

            if (SessionUser.IsLogged)
            {
                Application.Run(new FormMain());
            }
        }
    }
}