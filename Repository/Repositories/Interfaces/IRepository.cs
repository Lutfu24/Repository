using Repository.Models.Common;
using System.Linq.Expressions;

namespace Repository.Repositories.Interfaces;

public interface IRepository<T> where T : BaseEntity
{
    IQueryable<T> GetAll();
    IQueryable<T> GetFiltered(Expression<Func<T, bool>> expression);
    Task<T> GetByIdAsync(int id);
    Task<T> GetSingleAsync(Expression<Func<T, bool>> expression);
    Task CreateAsync(T entity);
    Task<bool> IsExistAsync(Expression<Func<T, bool>> expression);
    void Delete(T entity);
    void SoftDelete(T entity);
    void Update(T entity);

    Task<int> SaveAsync();
}
