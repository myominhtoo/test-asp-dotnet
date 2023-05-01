using BasicCrud.Data;
using BasicCrud.Models;
using BasicCrud.service;
using Microsoft.AspNetCore.Mvc;

namespace BasicCrud.Controllers
{

    public class CategoryController : Controller
    {

        private readonly CategoryService _categoryService;

        public CategoryController( CategoryService categoryService )
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var categories = _categoryService.GetAll();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View(new Category());
        }

        [HttpPost]
        public IActionResult Create( Category category )
        {
            if( !ModelState.IsValid)
            {
                return View(category);
            }

            category.CreatedDateTime = DateTime.Now;

            _categoryService.SaveCategory(category);

            TempData["message"] = "Successfully Created Category!";

            return RedirectToAction(nameof(Index));
        }

        public IActionResult DeleteCategory( int? id )
        {
            bool deleteStatus = _categoryService.DeleteCategory(id);

            TempData[deleteStatus ? "message" : "error"] = deleteStatus 
                ? "Successfully deleted!" 
                : "Failed to delete!";

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update( int? categoryId )
        {
            if (categoryId == null || categoryId == 0)
                return NotFound();

            Category? category = _categoryService.GetCategoryById(categoryId);

            if (category == null)
                return NotFound();

            return View(category);
        }

        [HttpPost]
        public IActionResult Update( Category category )
        {
            category.UpdatedDateTime = DateTime.Now;
            bool status = _categoryService.UpdateCategory(category);

            TempData[status ? "message" : "error"] = status
                ? "Successfully updated!"
                : "Failed to update!";


            return RedirectToAction(nameof(Index));
        }

    }
}
