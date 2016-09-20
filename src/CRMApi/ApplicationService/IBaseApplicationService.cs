using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CRMApi.ApplicationService
{
    public interface IBaseApplicationService<T> where T : class
    {
        Task<int> Insert(T TEntity);

        Task<int> Delete(T TEntity);

        Task<int> Update(T Entity);

        Task<T> GetById(int Id);

        Task<T> GetByPredicate(Expression<Func<T, bool>> predicate);

        Task<ICollection<T>> GetAll();

        Task<ICollection<T>> GetAllWithPredicate(Expression<Func<T, bool>> predicate);
    }
}
