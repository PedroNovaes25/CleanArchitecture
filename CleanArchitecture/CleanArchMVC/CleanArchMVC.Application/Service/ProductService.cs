using AutoMapper;
using CleanArchMVC.Application.DTOs;
using CleanArchMVC.Application.Interfaces;
using CleanArchMVC.Application.Products.Commands;
using CleanArchMVC.Application.Products.Queries;
using CleanArchMVC.Domain.Entities;
using CleanArchMVC.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMVC.Application.Service
{
    public class ProductService : IProductService
    {
        private readonly IMediator _mediator;
        private IMapper _mapper;

        public ProductService(IMediator mediator, IMapper mapper)
        {
            this._mediator = mediator;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {

            var productsQuery = new GetProductsQuery();
            if (productsQuery == null)
                throw new Exception("Entity could not be loaded.");

            var result = await _mediator.Send(productsQuery);

            return _mapper.Map<IEnumerable<ProductDTO>>(result);
        }

        public async Task<ProductDTO> GetById(int? idProduct)
        {
            var productByIdQuery = new GetProductByIdQuery(idProduct.Value);
            if (productByIdQuery == null)
                throw new Exception("Entity could not be loaded.");

            var result = await _mediator.Send(productByIdQuery);

            return _mapper.Map<ProductDTO>(result);
        }

        //public async Task<ProductDTO> GetProductCategory(int? idCategory)
        //{
        //    var productByIdQuery = new GetProductByIdQuery(idCategory.Value);
        //    if (productByIdQuery == null)
        //        throw new Exception("Entity could not be loaded.");

        //    var result = await _mediator.Send(productByIdQuery);

        //    return _mapper.Map<ProductDTO>(result);

        //}

        public async Task Add(ProductDTO productDTO)
        {
            var productCreateCommand = _mapper.Map<ProductCreateCommand>(productDTO);
            await _mediator.Send(productCreateCommand);
        }

        public async Task Remove(int? idProduct)
        {
            var productRemoveCommand = new ProductRemoveCommand(idProduct.Value);
            if (productRemoveCommand == null)
                throw new Exception("Entity could not be loaded.");

            await _mediator.Send(productRemoveCommand);
        }

        public async Task Update(ProductDTO productDTO)
        {
            var productUpdateCommand = _mapper.Map<ProductUpdateCommand>(productDTO);
            await _mediator.Send(productUpdateCommand);
        }
    }
}
