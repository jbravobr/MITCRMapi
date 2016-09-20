using CRMApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CRMApi.ApplicationService
{
    /// <summary>
    /// Classe intermediária para consumo da exposição do Repositório Base
    /// </summary>
    public class BaseApplicationService<T> : IBaseApplicationService<T> where T : class
    {
        readonly IBaseRepository<T> _baseRepo;

        public BaseApplicationService(IBaseRepository<T> baseRepo)
        {
            _baseRepo = baseRepo;
        }

        public async Task<int> Insert(T entity)
        {
            return await _baseRepo.Insert(entity);
        }

        public async Task<int> Delete(T entity)
        {
            return await _baseRepo.Delete(entity);
        }

        public async Task<int> Update(T entity)
        {
            return await _baseRepo.Update(entity);
        }

        public async Task<T> GetById(int id)
        {
            return await _baseRepo.GetById(id);
        }

        public async Task<T> GetByPredicate(Expression<Func<T,bool>> predicate)
        {
            return await _baseRepo.GetByPredicate(predicate);
        }

        public async Task<ICollection<T>> GetAll()
        {
            return await _baseRepo.GetAll();
        }

        public async Task<ICollection<T>> GetAllWithPredicate(Expression<Func<T,bool>> predicate)
        {
            return await _baseRepo.GetAllWithPredicate(predicate);
        }
    }
}
