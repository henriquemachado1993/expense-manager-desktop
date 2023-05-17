using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagerDesktop.Domain.Helpers
{
    public static class SessionUser
    {
        public static string? UserId { get; private set; }
        public static string? UserName { get; private set; }
        public static bool IsLogged { get; private set; }

        public static void SetUserLogged(string userId, string userName, bool isLogged = true)
        {
            UserId = userId;
            UserName = userName;
            IsLogged = isLogged;
        }

        public static void Logout()
        {
            UserId = "";
            UserName = "";
            IsLogged = false;
        }
    }
}
