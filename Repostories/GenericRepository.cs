using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace App.Repositories;

public class GenericRepository<T>(AppDbContext context) : IGenericRepository<T> where T : class
{
    protected AppDbContext Context = context;

    private readonly DbSet<T> _dbSet = context.Set<T>();

    public ValueTask<EntityEntry<T>> AddAsync(T entity)
    {
        return _dbSet.AddAsync(entity);
    }
    public void Update(T entity) => _dbSet.Update(entity);
    public void Delete(T entity) => _dbSet.Remove(entity);

    public IQueryable<T> GetAll() => _dbSet.AsQueryable().AsNoTracking();

    public IQueryable<T> Where(Expression<Func<T, bool>> predicate) => _dbSet.Where(predicate).AsNoTracking();

    public ValueTask<T?> GetByIdAsync(int id) => _dbSet.FindAsync(id);

    public Task SaveChangesAsync() => Context.SaveChangesAsync();
}