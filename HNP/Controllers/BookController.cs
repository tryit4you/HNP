
using HNP.DATA.DI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HNP.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;
        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public ActionResult GetAll()
        {
            var data = _bookRepository.GetAll();
            return Ok(data);
        }
    }
}