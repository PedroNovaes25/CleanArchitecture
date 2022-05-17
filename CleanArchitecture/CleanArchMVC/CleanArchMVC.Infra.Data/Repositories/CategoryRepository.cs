using CleanArchMVC.Domain.Entities;
using CleanArchMVC.Domain.Interfaces;
using CleanArchMVC.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMVC.Infra.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext contextCategory;

        public CategoryRepository(ApplicationDbContext applicationDbContext)
        {
            this.contextCategory = applicationDbContext;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await contextCategory.Categories.ToListAsync();
        }

        public async Task<Category> GetByIdAsync(int? idCategory)
        {
            return await contextCategory.Categories.FindAsync(idCategory);
        }

        public async Task<Category> CreateAsync(Category category)
        {
            contextCategory.Add(category);
            await contextCategory.SaveChangesAsync();
            return category;
        }
        public async Task<Category> UpdateAsync(Category category)
        {
            contextCategory.Update(category);
            await contextCategory.SaveChangesAsync();
            return category;
        }

        public async Task<Category> RemoveAsync(Category category)
        {
            contextCategory.Remove(category);
            await contextCategory.SaveChangesAsync();
            return category;
        }
    }
}
