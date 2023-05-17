using ExpenseManagerDesktop.Domain.Helpers;
using ExpenseManagerDesktop.Extensions;
using ExpenseManagerDesktop.Infra;
using ExpenseManagerDesktop.Infra.Contexts;
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
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            Application.Run(new FormLogin());

            if (SessionUser.IsLogged)
            {
                Application.Run(new FormMain());
            }

            // Configurar e construir o provedor de serviços
            DependecyInjectorContainer.ConfigureServices();
        }
    }
}