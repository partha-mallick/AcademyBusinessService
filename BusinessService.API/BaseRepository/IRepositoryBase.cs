using System;
using System.Linq;
using System.Linq.Expressions;

namespace BusinessService.API.BaseRepository
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression);
        bool Create(T entity);
        bool Update(T entity);
        bool Delete(T entity);
    }
}
