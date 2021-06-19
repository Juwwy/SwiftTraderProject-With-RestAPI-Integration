using Microsoft.EntityFrameworkCore;
using SwiftTraders.ApplicationCore.Interfaces.Repositories;
using SwiftTraders.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SwiftTraders.Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly SwiftTraderDbContext dbContext;
        private readonly DbSet<T> dbSet;

        public Repository(SwiftTraderDbContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = dbContext.Set<T>();
        }
        public async Task Add(T entity)
        {
            await dbSet.AddAsync(entity);
        }

        public async Task<T> Find(string id)
        {
            return await dbContext.Set<T>().FindAsync(id);
        }

        public async Task<T> Get(Expression<Func<T, bool>> filter, string[] includes = null)
        {
            var query = GetQuery(includes);
            return await query.Where(filter).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetAll(string[] includes, int count = 60)
        {
            var query = GetQuery(includes);
            return await query.Take(count).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAll(System.Linq.Expressions.Expression<Func<T, bool>> filter, string[] includes = null)
        {
            var query = GetQuery(includes);
            return await query.Where(filter).Take(20).ToListAsync();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void Update(T entity)
        {
            dbSet.Update(entity);
        }

        private IQueryable<T> GetQuery(string[] includes)
        {
            IQueryable<T> query = dbContext.Set<T>();

            if(includes != null)
            {
                foreach(var child in includes)
                {
                    query = query.Include(child);
                }
            }
            return query;
        }
    }
}
