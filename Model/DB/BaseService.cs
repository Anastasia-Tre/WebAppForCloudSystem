using System.Linq.Expressions;
using Model.Models;

namespace Model.DB;

public interface IBaseService<TEntity> where TEntity : DbEntity
{
    IEnumerable<TEntity> GetAll();
    IEnumerable<TEntity> GetByCondition(Expression<Func<TEntity, bool>> condition);
    TEntity GetById(object id);
    bool Insert(TEntity entity);
    bool Update(TEntity entity);
    bool Delete(object id);
    bool Delete(TEntity entity);
}

public class BaseService<TEntity> : IBaseService<TEntity>
    where TEntity : DbEntity
{
    protected readonly BaseRepository<TEntity> Repository;

    public BaseService(ChinookContext context)
    {
        Repository = new BaseRepository<TEntity>(context) ??
                      throw new ArgumentNullException(nameof(context));
    }

    public virtual IEnumerable<TEntity> GetAll()
    {
        return Repository.GetAll();
    }

    public virtual IEnumerable<TEntity> GetByCondition(Expression<Func<TEntity, bool>> condition)
    {
        return Repository.GetByCondition(condition);
    }

    public virtual TEntity GetById(object id)
    {
        return Repository.GetById(id);
    }

    public virtual bool Insert(TEntity entity)
    {
        Repository.Insert(entity);
        return Repository.SaveChanges();
    }

    public virtual bool Update(TEntity entity)
    {
        Repository.Update(entity);
        return Repository.SaveChanges();
    }

    public virtual bool Delete(object id)
    {
        Repository.Delete(id);
        return Repository.SaveChanges();
    }

    public virtual bool Delete(TEntity entity)
    {
        Repository.Delete(entity);
        return Repository.SaveChanges();
    }
}