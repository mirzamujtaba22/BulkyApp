using Bulky.DataAccess.Repository.IRepository;
using BulkyWeb.Models;
using BulkyWeb.Data;
using Microsoft.AspNetCore.Mvc;

namespace BulkyApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitofwork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitofwork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Product> getallProduct = _unitofwork.ProductRepository.GetAll().ToList();
            return View(getallProduct);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product prod)
        {
            //if(category.Name == obj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("name", "The DisplayOrder Cannot Exactly match the Name");
            //}
            if (ModelState.IsValid)
            {
                _unitofwork.ProductRepository.Add(prod);
                _unitofwork.Save();
                TempData["success"] = "Product created successfully";
                return RedirectToAction("Index");

            }
            return View();

        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product productfromdb = _unitofwork.ProductRepository.Get(u => u.Id == id);
            if (productfromdb == null)
            {
                return NotFound();
            }
            return View(productfromdb);
        }

        [HttpPost]
        public IActionResult Edit(Product prod)
        {

            if (ModelState.IsValid)
            {
                _unitofwork.ProductRepository.Update(prod);
                _unitofwork.Save();
                TempData["success"] = "Category Updated successfully";
                return RedirectToAction("Index");

            }
            return View();

        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product categoryfromdb = _unitofwork.ProductRepository.Get(u => u.Id == id);
            if (categoryfromdb == null)
            {
                return NotFound();
            }
            return View(categoryfromdb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Product? prod = _unitofwork.ProductRepository.Get(u => u.Id == id);
            if (prod == null)
            {
                return NotFound();
            }
            _unitofwork.ProductRepository.Remove(prod);
            _unitofwork.Save();
            TempData["success"] = "Product Deleted successfully";
            return RedirectToAction("Index");


        }

    }
}



