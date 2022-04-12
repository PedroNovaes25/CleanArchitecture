using CleanArch.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Interfaces
{
    public interface IProductServices
    {
        Task<IEnumerable<ProductViewModel>> GetProducts();
        Task<ProductViewModel> GetById(int? idProduct);
        void Add(ProductViewModel productViewModel);
        void Update(ProductViewModel productViewModel);
        void Remove(int idProduct);
    }
}
