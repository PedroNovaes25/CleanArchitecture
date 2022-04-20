﻿using CleanArchMVC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMVC.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetByIdAsync(int? idProduct);
        Task<Product> GetProductCategorysAsync(int? idCategory);
        Task<Product> CreateAsync();
        Task<Product> UpdateAsync();
        Task<Product> RemoveAsync();
    }
}