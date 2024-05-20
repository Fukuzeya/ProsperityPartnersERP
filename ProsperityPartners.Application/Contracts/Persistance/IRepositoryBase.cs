using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProsperityPartners.Application.Contracts.Persistance
{
    public interface IRepositoryBase<T> where T : class
    {
        IQueryable<T> FindAll(bool trackChanges);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);
        Task Create(T entity);
        void Delete(T entity);
        void Update(T entity);
        Task<T?> GetAsync(Guid Id);
        Task<bool> Exists(Guid Id);

    }
}
