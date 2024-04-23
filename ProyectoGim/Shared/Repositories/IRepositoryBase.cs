using Shared.Domain;
using System.Linq.Expressions;

namespace Shared.Repositories
{
    public interface IRepositoryBase<T>
        where T : Entity
    {
        List<T> GetAll(params Expression<Func<T, object>>[] includes);

        T Get(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);

        void Insert(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Save();
    }
}
