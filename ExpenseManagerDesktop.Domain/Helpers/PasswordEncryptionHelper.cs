using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagerDesktop.Domain.Helpers
{
    public static class PasswordEncryptionHelper
    {
        public static bool VerifyPassword(string password, string passwordEncrypted)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                string hash = EncryptPassword(password);
                StringComparer comparer = StringComparer.OrdinalIgnoreCase;

                return comparer.Compare(hash, passwordEncrypted) == 0;
            }
        }

        public static string EncryptPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();

                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }
}
