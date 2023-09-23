using System.Linq.Expressions;

namespace Application.Ports;

public interface IBaseRepository<TEntity, TId>
{
     TEntity Add(TEntity entity);
     TEntity Update(TEntity entity);
     TId Delete(TId id);
     TEntity Get(TId id);
     IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> filter);
}