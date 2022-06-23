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
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext contextProduct;

        public ProductRepository(ApplicationDbContext applicationDbContext)
        {
            this.contextProduct = applicationDbContext;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await contextProduct.Products.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int? id)
        {
            //return await contextProduct.Products.FindAsync(idProduct);
            return await contextProduct.Products
                .Include(c => c.Category)
                .SingleOrDefaultAsync(c => c.Id == id);
        }

        //public async Task<Product> GetProductCategoryAsync(int? idCategory)
        //{
        //    return await contextProduct.Products
        //        .Include(c => c.Category)
        //        .SingleOrDefaultAsync(c => c.CategoryId == idCategory);
        //}

        public async Task<Product> CreateAsync(Product product)
        {
            contextProduct.Add(product);
            await contextProduct.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            contextProduct.Update(product);
            await contextProduct.SaveChangesAsync();
            return product;
        }

        public async Task<Product> RemoveAsync(Product product)
        {
            contextProduct.Remove(product);
            await contextProduct.SaveChangesAsync();
            return product;
        }
    }
}
