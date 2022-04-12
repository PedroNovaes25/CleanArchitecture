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

        [HttpGet()]
        public async Task<IActionResult> Edit(int? idProduct)
        {
            if (idProduct == 0)
                return NotFound();

            var productVm = await _productServices.GetById(idProduct);
            if (productVm == null)
                return NotFound();

            return View(productVm);
        }

        [HttpPost()]
        //Bind define quais campos são aceitos 
        public IActionResult Edit([Bind("Id, Name, Description, Price")] ProductViewModel productVm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _productServices.Update(productVm);
                }
                catch (Exception)
                {
                    throw;
                }

                return RedirectToAction(nameof(Index));
            }
            return View(productVm);
        }

        [HttpGet]

        public async Task<IActionResult> Details(int idProduct)
        {
            if (idProduct == 0)
                return NotFound();

            var productVm = await _productServices.GetById(idProduct);
            if (productVm == null)
                return NotFound();

            return View(productVm);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
                return NotFound();

            var productVm = await _productServices.GetById(id);
            if (productVm == null)
                return NotFound();

            return View(productVm);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _productServices.Remove(id);

            return RedirectToAction(nameof(Index));
        }

    }
}
