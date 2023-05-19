using ExpenseManagerDesktop.Domain.Entities;
using ExpenseManagerDesktop.Domain.ValueObjects;

namespace ExpenseManagerDesktop.Domain.Interfaces.Services
{
    public interface ICategoryService
    {
        BusinessResult<Category> Add(Category category);
        BusinessResult<Category> Update(Category category);
        BusinessResult<List<Category>> GetFiltered(QueryCriteria<Category>? query = null);
        BusinessResult<Category> GetById(int id);
        BusinessResult<bool> Delete(int id);
    }
}
