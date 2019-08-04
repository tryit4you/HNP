using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HNP.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetAll()
        {
            var categories = _categoryRepository.GetAll();
            return Ok(categories);
        }
    }
}