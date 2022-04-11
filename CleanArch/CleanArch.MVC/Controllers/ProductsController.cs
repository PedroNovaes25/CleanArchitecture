using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArch.MVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductServices _productServices;

        public ProductsController(IProductServices productServices)
        {
            this._productServices = productServices;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _productServices.GetProducts();
            return View(result);
        }

        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //Bind define quais campos são aceitos 
        public IActionResult Create([Bind("Id, Name, Description, Price")]ProductViewModel product) 
        {
            if (ModelState.IsValid)
            {
                _productServices.Add(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

    }
}
