using ExpenseManagerDesktop.Domain.Entities;
using ExpenseManagerDesktop.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagerDesktop.Domain.Interfaces.Services
{
    public interface IUserService
    {
        BusinessResult<User> Add(User user);
        BusinessResult<User> Update(User user);
        BusinessResult<User> UpdatePassword(User user);
        BusinessResult<User> ValidateLogin(string userName, string password);
    }
}
