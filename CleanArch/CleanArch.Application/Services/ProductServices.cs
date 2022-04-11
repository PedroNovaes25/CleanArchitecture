using AutoMapper;
using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductServices(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductViewModel>> GetProducts()
        {
            var productModel = await _productRepository.GetProducts();
            return _mapper.Map<IEnumerable<ProductViewModel>>(productModel);
        }
     
        public async Task<ProductViewModel> GetById(int idProduct)
        {
            var productModel = await _productRepository.GetById(idProduct);
            return _mapper.Map<ProductViewModel>(productModel);
        }

        public void Add(ProductViewModel productViewModel)
        {
            var mapProductModel = _mapper.Map<Product>(productViewModel);
            _productRepository.Add(mapProductModel);
        }
        public void Update(ProductViewModel productViewModel)
        {
            var mapProductModel = _mapper.Map<Product>(productViewModel);
            _productRepository.Update(mapProductModel);

        }
        public void Delete(ProductViewModel productViewModel)
        {
            var mapProductModel = _mapper.Map<Product>(productViewModel);
            _productRepository.Delete(mapProductModel);
        }

    }
}
