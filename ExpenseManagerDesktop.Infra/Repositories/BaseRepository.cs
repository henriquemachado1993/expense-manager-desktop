
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using ExpenseManagerDesktop.Domain.Interfaces.Data;
using ExpenseManagerDesktop.Domain.Entities;
using ExpenseManagerDesktop.Domain.ValueObjects;

namespace ExpenseManagerDesktop.Infra.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T>
        where T : BaseEntity
    {
        protected readonly Contexts.ExpenseManagerContext context;

        public BaseRepository(Contexts.ExpenseManagerContext context)
        {
            this.context = context;
        }

        public T Add(T entity)
        {
            T _entity = null;
            if (entity != null)
            {
                _entity = context.Set<T>().Add(entity).Entity;
            }
            return _entity;
        }

        public async Task<T> AddAsync(T entity)
        {
            EntityEntry<T> _entity = null;
            if (entity != null)
            {
                _entity = await context.Set<T>().AddAsync(entity);
            }
            return _entity.Entity;
        }

        public ICollection<T> AddMultiple(ICollection<T> listEntity)
        {
            ICollection<T> _lstEntity = new List<T>();
            if (listEntity != null && listEntity.Any())
            {
                foreach (var entity in listEntity)
                {
                    _lstEntity.Add(context.Set<T>().Add(entity).Entity);
                }
            }
            return _lstEntity;
        }

        public async Task<ICollection<T>> AddMultipleAsync(ICollection<T> listEntity)
        {
            ICollection<T> _lstEntity = new List<T>();
            if (listEntity != null && listEntity.Any())
            {
                foreach (var entity in listEntity)
                {
                    var ent = await context.Set<T>().AddAsync(entity);
                    _lstEntity.Add(ent.Entity);
                }
            }
            return _lstEntity;
        }

        public T Update(T entity)
        {
            if (entity != null)
            {
                var existingEntity = context.Set<T>().Find(entity.Id);
                if (existingEntity != null)
                {
                    context.Entry(existingEntity).CurrentValues.SetValues(entity); // Copia as propriedades da entidade atualizada
                }
            }
            return entity;
        }

        public void Delete(int id)
        {
            var existingEntity = context.Set<T>().Find(id);
            if (existingEntity != null)
            {
                context.Set<T>().Remove(existingEntity);
            }
        }

        public void Delete(T entity)
        {
            if (entity != null)
            {
                var existingEntity = context.Set<T>().Find(entity.Id);
                if (existingEntity != null)
                {
                    context.Set<T>().Remove(existingEntity); // Copia as propriedades da entidade atualizada
                }
            }
        }

        public void DeleteMultiple(ICollection<T> listEntity)
        {
            if (listEntity != null && listEntity.Any())
            {
                context.Set<T>().RemoveRange(listEntity);
            }
        }

        public T GetById(int id, string navigation = "")
        {
            IQueryable<T> result = context.Set<T>().Where(x => x.Id == id).AsNoTracking();
            if (!string.IsNullOrEmpty(navigation))
            {
                var lstNavigation = navigation.Split(',');
                foreach (var nav in lstNavigation)
                {
                    result = result.Include(nav);
                }
                return result.FirstOrDefault();
            }
            return result.FirstOrDefault();
        }

        public IQueryable<T> GetFiltered(QueryCriteria<T> query)
        {
            IQueryable<T> result = null;
            if (query == null)
                return result;

            if (query.Expression == null)
                query.Expression = x => x.Id != 0;

            if (query.OrderBy == null)
                query.OrderBy = x => x.Id;

            int skip = ((query.Offset) - 1) * query.Limit;

            if (query.Ascending) // Ascending
            {
                result = context.Set<T>()
                        .Where(query.Expression)
                        .OrderBy(query.OrderBy)
                        .AsNoTracking();
            }
            else if (!query.Ascending) // Descending
            {
                result = context.Set<T>()
                        .Where(query.Expression)
                        .OrderByDescending(query.OrderBy)
                        .AsNoTracking();
            }

            if (query.Navigation != null && query.Navigation.Any())
            {
                foreach (var nav in query.Navigation)
                {
                    result = result.Include(nav);
                }
            }

            return result;
        }

        public int GetCount(QueryCriteria<T> query = null)
        {
            if (query == null)
                query = new QueryCriteria<T>();

            if (query.Expression == null)
                query.Expression = x => x.Id != 0;

            return context.Set<T>().Where(query.Expression).AsNoTracking().Count();
        }

        public IQueryable<T> GetPaged(QueryCriteria<T> query)
        {
            IQueryable<T> result = null;
            if (query == null)
                return result;

            if (query.Expression == null)
                query.Expression = x => x.Id != 0;

            if (query.OrderBy == null)
                query.OrderBy = x => x.Id;

            int skip = ((query.Offset) - 1) * query.Limit;

            if (query.Ascending) // Ascending
            {
                result = context.Set<T>()
                        .Where(query.Expression)
                        .OrderBy(query.OrderBy)
                        .Skip(skip)
                        .Take(query.Limit)
                        .AsNoTracking();
            }
            else if (!query.Ascending) // Descending
            {
                result = context.Set<T>()
                        .Where(query.Expression)
                        .OrderByDescending(query.OrderBy)
                        .Skip(skip)
                        .Take(query.Limit)
                        .AsNoTracking();
            }

            if (query.Navigation != null && query.Navigation.Any())
            {
                foreach (var nav in query.Navigation)
                    result = result.Include(nav);
            }

            return result;
        }
    }
}
