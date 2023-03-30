using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace CleanArchMVC.Domain.Interfaces.Handler
{
    public interface IRepositoryHandler<T>
    {
        public Task<IEnumerable<T>> GetAll();
        public Task<T> GetById(int id);
        public Task<T> Update(T model);
        public Task<T> Create(T model);
        public Task<T> Remove(T model);

        protected Task<IEnumerable<T>> GetAll<Context>(Context ctx);
        protected Task<T> GetById<Context>(Context ctx, int id);
        protected Task<T> Update<Context>(Context ctx, T model);
        protected Task<T> Create<Context>(Context ctx, T model);
        protected Task<T> Remove<Context>(Context ctx, T model);
    }
}
