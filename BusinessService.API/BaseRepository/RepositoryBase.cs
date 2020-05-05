using BusinessService.API.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace BusinessService.API.BaseRepository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext RepositoryContext { get; set; }

        public RepositoryBase(RepositoryContext repositoryContext)
        {
            this.RepositoryContext = repositoryContext;
        }

        public IQueryable<T> GetAll()
        {
            return this.RepositoryContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression)
        {
            return this.RepositoryContext.Set<T>().Where(expression).AsNoTracking();
        }

        public bool Create(T entity)
        {
            bool isSuccess;
            try
            {
                this.RepositoryContext.Set<T>().Add(entity);
                isSuccess = true;
            }
            catch (Exception)
            {
                isSuccess = false;
            }
            return isSuccess;
        }

        public bool Update(T entity)
        {
            bool isSuccess;
            try
            {
                this.RepositoryContext.Set<T>().Update(entity);
                isSuccess = true;
            }
            catch (Exception)
            {
                isSuccess = false;
            }
            return isSuccess;
        }

        public bool Delete(T entity)
        {
            bool isSuccess;
            try
            {
                this.RepositoryContext.Set<T>().Remove(entity);
                isSuccess = true;
            }
            catch (Exception)
            {
                isSuccess = false;
            }
            return isSuccess;
        }
    }
}
