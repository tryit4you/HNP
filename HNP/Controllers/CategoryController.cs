
using HNP.DATA.DI.Interfaces;
using HNP.DATA.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HNP.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<JsonResult> GetAll()
        {
            IEnumerable<Category> categories = await _categoryRepository.GetAll();
            return Json(new {
                categories
            });
        }
    }
}