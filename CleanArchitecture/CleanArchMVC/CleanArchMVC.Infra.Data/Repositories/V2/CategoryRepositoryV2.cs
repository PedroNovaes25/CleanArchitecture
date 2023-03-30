using CleanArchMVC.Domain.Entities;
using CleanArchMVC.Domain.Interfaces;
using CleanArchMVC.Domain.Interfaces.Handler;
using CleanArchMVC.Infra.Data.Context;
using CleanArchMVC.Infra.Data.Repositories.Handler;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMVC.Infra.Data.Repositories.V2
{
    public class CategoryRepositoryV2 : RepositoryHandler<Category>
    {
        public CategoryRepositoryV2(DbContextOptions<ApplicationDbContext> context) : base(context) { }
        public override async Task<IEnumerable<Category>> GetAll<Context>(Context ctx)
        {
            var context = ctx as ApplicationDbContext;
            return await context.Categories.ToListAsync();
        }

        public override async Task<Category> Create<Context>(Context ctx, Category model)
        {
            var context = ctx as ApplicationDbContext;
            context.Add(model);
            await context.SaveChangesAsync();
            return model;
        }

        public override async Task<Category> GetById<Context>(Context ctx, int id)
        {
            var context = ctx as ApplicationDbContext;
            return await context.Categories.FindAsync(id);
        }

        public override async Task<Category> Remove<Context>(Context ctx, Category model)
        {
            var context = ctx as ApplicationDbContext;
            context.Remove(model);
            await context.SaveChangesAsync();
            return model;
        }

        public override async Task<Category> Update<Context>(Context ctx, Category model)
        {
            var context = ctx as ApplicationDbContext;
            context.Update(model);
            await context.SaveChangesAsync();
            return model;
        }
    }
}
