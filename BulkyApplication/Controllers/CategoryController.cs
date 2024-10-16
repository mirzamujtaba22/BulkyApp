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
    }
}
