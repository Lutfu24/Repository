using Microsoft.EntityFrameworkCore;
using Repository.Contexts;
using Repository.Models.Common;
using Repository.Repositories.Interfaces;
using System.Linq.Expressions;

namespace Repository.Repositories.Implamentations;

public class Repository<T> : IRepository<T> where T : BaseEntity
{
    private readonly AppDbContext _context;

    public Repository(AppDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
    }

    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
    }

    public void SoftDelete(T entity)
    {
        entity.IsDeleted = true;
        Update(entity);
    }

    public IQueryable<T> GetAll()
    {
        return _context.Set<T>();
    }

    public async Task<T> GetByIdAsync(int id)
    {
       return await _context.Set<T>().FindAsync(id);
    }

    public IQueryable<T> GetFiltered(Expression<Func<T, bool>> expression)
    {
       return _context.Set<T>().Where(expression);
    }

    public async Task<T> GetSingleAsync(Expression<Func<T, bool>> expression)
    {
        return await _context.Set<T>().FirstOrDefaultAsync(expression);
    }

    public async Task<bool> IsExistAsync(Expression<Func<T, bool>> expression)
    {
        return await _context.Set<T>().AnyAsync(expression);
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
    }
}
 