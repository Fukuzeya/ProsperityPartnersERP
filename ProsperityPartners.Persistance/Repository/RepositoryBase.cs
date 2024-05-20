using Microsoft.EntityFrameworkCore;
using ProsperityPartners.Application.Contracts.Persistance;
using ProsperityPartners.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProsperityPartners.Persistance.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext RepositoryContext;
        protected RepositoryBase(RepositoryContext repositoryContext)
            => RepositoryContext = repositoryContext;
        public async Task Create(T entity) => await RepositoryContext.Set<T>().AddAsync(entity);
        public void Update(T entity) => RepositoryContext.Set<T>().Update(entity);
        public void Delete(T entity) => RepositoryContext.Set<T>().Remove(entity);
        public async Task<T?> GetAsync(Guid Id) => await RepositoryContext.Set<T>().FindAsync(Id);
        public async Task<bool> Exists(Guid Id)
        {
            var entity = await GetAsync(Id);
            return entity != null;
        }
        public IQueryable<T> FindAll(bool trackChanges)
            =>  !trackChanges ?RepositoryContext.Set<T>()
            .AsNoTracking() :RepositoryContext.Set<T>();
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
             =>!trackChanges ?RepositoryContext.Set<T>()
            .Where(expression).AsNoTracking() :RepositoryContext
            .Set<T>().Where(expression);

    }
}
