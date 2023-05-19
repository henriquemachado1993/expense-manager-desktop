using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagerDesktop.Domain.Helpers
{
    public static class SessionUser
    {
        public static int UserId { get; private set; }
        public static string? UserName { get; private set; }
        public static bool IsLogged { get; private set; }

        public static void SetUserLogged(int userId, string userName, bool isLogged = true)
        {
            UserId = userId;
            UserName = userName;
            IsLogged = isLogged;
        }

        public static void Logout()
        {
            UserId = 0;
            UserName = "";
            IsLogged = false;
        }
    }
}
