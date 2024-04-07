using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Model.Models;

namespace Model.DB;

public class BaseRepository<TEntity> where TEntity : DbEntity
{
    private readonly ChinookContext _context;
    private readonly DbSet<TEntity> _dbSet;

    public BaseRepository(ChinookContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _dbSet = _context.Set<TEntity>();
    }

    public IEnumerable<TEntity> GetAll()
    {
        return _dbSet.ToList();
    }

    public IEnumerable<TEntity> GetByCondition(Expression<Func<TEntity, bool>> condition)
    {
        return _dbSet.Where(condition).ToList();
    }

    public TEntity GetById(object id)
    {
        return _dbSet.Find(id);
    }

    public void Insert(TEntity entity)
    {
        _dbSet.Add(entity);
    }

    public void Update(TEntity entity)
    {
        _dbSet.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
    }

    public void Delete(object id)
    {
        TEntity entityToDelete = _dbSet.Find(id);
        Delete(entityToDelete);
    }

    public void Delete(TEntity entity)
    {
        if (_context.Entry(entity).State == EntityState.Detached)
        {
            _dbSet.Attach(entity);
        }
        _dbSet.Remove(entity);
    }

    public bool SaveChanges()
    {
        try
        {
            _context.SaveChanges();
            return true;
        } catch (Exception)
        {
            // Обробка помилок збереження, якщо потрібно
            return false;
        }
    }
}