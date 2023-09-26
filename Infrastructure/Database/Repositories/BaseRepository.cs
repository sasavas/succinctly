using System.Linq.Expressions;
using Application.Ports;
using Domain.BaseTypes;

namespace Infrastructure.Database.Repositories;

public class BaseRepository<TEntity, TId> : IBaseRepository<TEntity, TId>
    where TEntity : Entity<TId>
    where TId : notnull
{
    private readonly SuccinctlyContext _context;

    public BaseRepository(SuccinctlyContext context)
    {
        _context = context;
    }
    
    public TEntity Add(TEntity entity)
    {
        var inserted = _context.Set<TEntity>().Add(entity);
        _context.SaveChanges();
        return inserted.Entity;
    }

    public virtual TEntity Update(TEntity entity)
    {
        var updated = _context.Set<TEntity>().Update(entity);
        _context.SaveChanges();
        return updated.Entity;
    }

    public virtual void Delete(TId entityId)
    {
        var toDelete = _context.Set<TEntity>().FirstOrDefault(t => entityId.Equals(t.Id));
        if (toDelete is not null)
            _context.Set<TEntity>().Remove(toDelete);
    }

    public TEntity Get(TId id)
    {
        throw new NotImplementedException();
    }

    public virtual IEnumerable<TEntity> GetList()
    {
        return _context.Set<TEntity>();
    }

    public IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> filter)
    {
        return _context.Set<TEntity>()
            .Where(filter);
    }
}