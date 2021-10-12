using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OnelityAssigment.Repository
{
    public interface IRepository<T>
    {
        Task<List<T>> FindAll();
        Task<T> FindById(int id);
        Task<T> FindByCondition(Expression<Func<T, bool>> expression);
        Task<List<T>> FindManyByCondition(Expression<Func<T, bool>> expression);
        Task CreateAsync(T entity);
        Task Update(T entity);
        Task DeleteAsync(int id);
        Task DeleteRangeAsync(List<T> entity);

    }
}
