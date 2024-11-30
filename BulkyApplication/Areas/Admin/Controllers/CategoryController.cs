using Bulky.DataAccess.Repository.IRepository;
using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitofwork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitofwork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Category> getallcategories = _unitofwork.CategoryRepository.GetAll().ToList();
            return View(getallcategories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            //if(category.Name == obj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("name", "The DisplayOrder Cannot Exactly match the Name");
            //}
            if (ModelState.IsValid)
            {
                _unitofwork.CategoryRepository.Add(category);
                _unitofwork.Save();
                TempData["success"] = "Category created successfully";
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
            Category categoryfromdb = _unitofwork.CategoryRepository.Get(u => u.CategoryId == id);
            if (categoryfromdb == null)
            {
                return NotFound();
            }
            return View(categoryfromdb);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {

            if (ModelState.IsValid)
            {
                _unitofwork.CategoryRepository.Update(category);
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
            Category categoryfromdb = _unitofwork.CategoryRepository.Get(u => u.CategoryId == id);
            if (categoryfromdb == null)
            {
                return NotFound();
            }
            return View(categoryfromdb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Category? cat = _unitofwork.CategoryRepository.Get(u => u.CategoryId == id);
            if (cat == null)
            {
                return NotFound();
            }
            _unitofwork.CategoryRepository.Remove(cat);
            _unitofwork.Save();
            TempData["success"] = "Category Deleted successfully";
            return RedirectToAction("Index");


        }

    }
}



