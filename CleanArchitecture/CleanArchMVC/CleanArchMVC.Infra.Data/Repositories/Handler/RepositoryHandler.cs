using CleanArchMVC.Domain.Interfaces;
using CleanArchMVC.Domain.Interfaces.Handler;
using CleanArchMVC.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMVC.Infra.Data.Repositories.Handler
{
    public abstract class RepositoryHandler<T> : IRepositoryHandler<T>
    {
        private DbContextOptions<ApplicationDbContext> _options;
        public RepositoryHandler(DbContextOptions<ApplicationDbContext> options)
        {
            _options = options;
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            using (var context = GetNewContext())
            {
                return await GetAll(context);
            }
        }

        public async Task<T> GetById(int id)
        {
            using (var context = GetNewContext())
            {
                return await GetById(context, id);
            }
        }

        public async Task<T> Update(T model)
        {
            using (var context = GetNewContext())
            {
                return await Update(context, model);
            }
        }

        public async Task<T> Create(T model) 
        {
            using (var context = GetNewContext())
            {
                return await Create(context, model);
            }
        }

        public async Task<T> Remove(T model)
        {
            using (var context = GetNewContext())
            {
                return await Remove(context, model);
            }
        }

        private ApplicationDbContext GetNewContext()
        {
            return new ApplicationDbContext(_options);
        }

        public abstract Task<IEnumerable<T>> GetAll<Context>(Context ctx);
        public abstract Task<T> GetById<Context>(Context ctx, int id);
        public abstract Task<T> Update<Context>(Context ctx, T model);
        public abstract Task<T> Create<Context>(Context ctx, T model);
        public abstract Task<T> Remove<Context>(Context ctx, T model);
    }
}
