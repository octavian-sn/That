﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using That.DataAccess.Repository.IRepository;
using That.Models;
using That.Models.ViewModel;

namespace ThatWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<Product> objProductList = _unitOfWork.Product.GetAll().ToList();
            return View(objProductList);
        }

        public IActionResult Upsert(int? id)
        {
            ProductVM productVM = new ProductVM()
            {
                /* Using projections in EF Core */
                CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString(),
                }),
                Product = new Product()
            };
            //Create
            if (id == 0 || id == null) return View(productVM);
            else
            //Edit
            {
                productVM.Product = _unitOfWork.Product.Get(u => u.Id == id);
                return View(productVM);
            }

        }
        [HttpPost]
        //Edit the name, pass it the IFormFile?
        public IActionResult Create(ProductVM productVM)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Add(productVM.Product);
                _unitOfWork.Save();
                TempData["success"] = "The Product has been added successfully.";
                return RedirectToAction("Index");
            }
            else
            {
                productVM.CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString(),
                });
                return View(productVM);
            }
        }

        /*public IActionResult Edit(int? id)
        {
            if (id == null || id == 0) return NotFound();
            Product productFromDb = _unitOfWork.Product.Get(item => item.Id == id);
            if (productFromDb == null) return NotFound();
            return View(productFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Update(product);
                _unitOfWork.Save();
                TempData["success"] = "The Product has been updated successfully.";
                return RedirectToAction("Index");
            }
            return View();
        }*/

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0) return NotFound();
            Product? product = _unitOfWork.Product.Get(item => id == item.Id);
            if (product == null) return NotFound();
            return View(product);
        }
        [HttpPost]
        public IActionResult Delete(Product product)
        {
            if (product == null) return NotFound();
            _unitOfWork.Product.Remove(product);
            _unitOfWork.Save();
            TempData["success"] = "The Product has been removed successfully.";
            return RedirectToAction("Index");
        }
    }
}
