using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OnelityAssigment.Repository
{
    public class EfRepository<T> : IRepository<T> where T : class
    {
        protected OnelityAssigmentDbContext DbContext { get; set; }

        public EfRepository(OnelityAssigmentDbContext repositoryContext)
        {
            this.DbContext = repositoryContext;
        }
        public async Task<List<T>> FindAll()
        {
            return await this.DbContext.Set<T>().AsNoTracking().ToListAsync();
        }
        public async Task<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return await this.DbContext.Set<T>().Where(expression).AsNoTracking().FirstOrDefaultAsync();
        }
        public async Task<List<T>> FindManyByCondition(Expression<Func<T, bool>> expression)
        {
            return await this.DbContext.Set<T>().Where(expression).AsNoTracking().ToListAsync();
        }
        public async Task CreateAsync(T entity)
        {
            this.DbContext.Set<T>().Add(entity);
            await DbContext.SaveChangesAsync();
        }
        public async Task Update(T entity)
        {
            this.DbContext.Set<T>().Update(entity);
            await DbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            T element = this.DbContext.Set<T>().Find(id);
            this.DbContext.Remove(element);
            await DbContext.SaveChangesAsync();
        }
        public async Task DeleteRangeAsync(List<T> entity)
        {
            this.DbContext.Set<T>().RemoveRange(entity);
            await DbContext.SaveChangesAsync();
        }

        public async Task<T> FindById(int id)
        {
            return await DbContext.Set<T>().FindAsync(id);
        }

    }
}
