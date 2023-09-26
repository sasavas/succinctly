using System.Linq.Expressions;
using Domain.BaseTypes;

namespace Application.Ports;

public interface IBaseRepository<TEntity, in TId>
     where TEntity : Entity<TId>
     where TId : notnull
{
     TEntity Add(TEntity entity);
     TEntity Update(TEntity entity);
     void Delete(TId id);
     TEntity? Get(TId id);
     IEnumerable<TEntity> GetList();
     IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> filter);
}