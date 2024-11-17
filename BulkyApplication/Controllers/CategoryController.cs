using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
 
    public class CategoryController : Controller
    {
        private readonly AppDbContext _db;
        public CategoryController(AppDbContext db) {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> getallcategories = _db.Categories.ToList();
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
                _db.Categories.Add(category);
                _db.SaveChanges();
                TempData["success"]="Category created successfully";
                return RedirectToAction("Index");

            }
            return View();
           
        }
        public IActionResult Edit(int? id)
        {
            if(id == null || id==0)
            {
                return NotFound();
            }
            Category categoryfromdb = _db.Categories.Find(id);
            if(categoryfromdb == null) {
                return NotFound();
            }
            return View(categoryfromdb);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
           
            if (ModelState.IsValid)
            {
                _db.Categories.Update(category);
                _db.SaveChanges();
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
            Category categoryfromdb = _db.Categories.Find(id);
            if (categoryfromdb == null)
            {
                return NotFound();
            }
            return View(categoryfromdb);
        }

        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Category? cat = _db.Categories.Find(id);
            if (cat == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(cat);
            _db.SaveChanges();
            TempData["success"] = "Category Deleted successfully";
            return RedirectToAction("Index");


        }
           
        }
    }



