using CleanArchMVC.Application.DTOs;
using CleanArchMVC.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMVC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            this._productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> Get() 
        {
            var products = await _productService.GetProducts();
            if (products == null)
                return NotFound("Products not found");

            return Ok(products);
        }

        [HttpGet("{id}", Name = "GetProduct")]
        public async Task<ActionResult<ProductDTO>> GetProduct(int id)
        {
            var product = await _productService.GetById(id);
            if (product == null)
                return NotFound("Product not found");
            
            return Ok(product);
        }

        [HttpPost()]
        public async Task<ActionResult> Post([FromBody] ProductDTO productDTO)
        {
            if (productDTO == null) 
                    return BadRequest("Invalid Data");
            await _productService.Add(productDTO);

            return new CreatedAtRouteResult(nameof(GetProduct), new { id = productDTO.Id }, productDTO);
        }

        [HttpPut("id")]
        public async Task<ActionResult> Put(int id, [FromBody] ProductDTO productDTO)
        {
            if (productDTO == null || productDTO.Id != id)
                return BadRequest("Invalid Data");
            
            await _productService.Update(productDTO);

            return Ok(productDTO);
        }

        [HttpDelete("id")]
        public async Task<ActionResult> Delete(int id) 
        {
            var productDTO = await _productService.GetById(id);
            if (productDTO == null)
                NotFound("Product not found");
            await _productService.Remove(id);

            return Ok(productDTO);
        }
    }
}
