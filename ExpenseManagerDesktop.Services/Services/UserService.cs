using ExpenseManagerDesktop.Domain.Entities;
using ExpenseManagerDesktop.Domain.Helpers;
using ExpenseManagerDesktop.Domain.Interfaces.Data;
using ExpenseManagerDesktop.Domain.Interfaces.Services;
using ExpenseManagerDesktop.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagerDesktop.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _uow;

        public UserService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public BusinessResult<User> Add(User user)
        {
            var result = BusinessResult<User>.CreateValidResult(user);

            var count = _uow.GetRepository<User>().GetCount(new QueryCriteria<User>()
            {
                Expression = x => (x.LoginName.ToLower() == user.LoginName.ToLower())
            });

            if (count > 0)
            {
                result.WithErrors($"Já existe um registro com esse nome de login ({user.LoginName}).");
                return result;
            }

            user.LoginName = user.LoginName.ToLower();
            user.Password = PasswordEncryptionHelper.EncryptPassword(user.Password);
            user.CreatedAt = DateTime.Now;
            user.Status = 1;
            result.Data = _uow.GetRepository<User>().Add(user);
            _uow.Commit();

            return result;
        }

        public BusinessResult<List<User>> GetFiltered(QueryCriteria<User>? query = null)
        {
            if (query == null)
                query = new QueryCriteria<User>() { };

            if (!query.IgnoreNavigation && (query.Navigation == null || !query.Navigation.Any()))
                query.Navigation = new List<string>() { "BankAccounts", "Expenses" };

            var boResult = BusinessResult<List<User>>.CreateValidResult();
            boResult.Data = _uow.GetRepository<User>().GetFiltered(query).ToList();
            return boResult;
        }

        public BusinessResult<User> Update(User user)
        {
            var result = BusinessResult<User>.CreateValidResult();

            var entity = _uow.GetRepository<User>().GetFiltered(new QueryCriteria<User>()
            {
                Expression = x => x.Id == user.Id
            }).FirstOrDefault();

            if (entity == null)
            {
                result.WithErrors("Registro não encontrado.");
                return result;
            }

            entity.Name = user.Name;
            entity.LastModifiedAt = DateTime.Now;

            result.Data = _uow.GetRepository<User>().Update(entity);
            _uow.Commit();

            return result;
        }

        public BusinessResult<User> UpdatePassword(User user)
        {
            var result = BusinessResult<User>.CreateValidResult();

            var entity = _uow.GetRepository<User>().GetFiltered(new QueryCriteria<User>()
            {
                Expression = x => x.Id == user.Id
            }).FirstOrDefault();

            if (entity == null)
            {
                result.WithErrors("Registro não encontrado.");
                return result;
            }

            entity.Password = PasswordEncryptionHelper.EncryptPassword(user.Password);
            entity.LastModifiedAt = DateTime.Now;

            result.Data = _uow.GetRepository<User>().Update(entity);
            _uow.Commit();

            return result;
        }

        public BusinessResult<User> ValidateLogin(string userName, string password)
        {
            var result = BusinessResult<User>.CreateValidResult();
       
            var entity = _uow.GetRepository<User>().GetFiltered(new QueryCriteria<User>()
            {
                Expression = x => x.LoginName.ToLower() == userName.ToLower() && x.Password == PasswordEncryptionHelper.EncryptPassword(password)
            }).FirstOrDefault();

            if (entity == null)
            {
                result.WithErrors("Usuário ou senha incorretos.");
                return result;
            }

            result.Data = entity;

            return result;
        }
    }
}