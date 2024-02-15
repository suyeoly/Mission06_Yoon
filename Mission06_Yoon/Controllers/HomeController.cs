using Microsoft.AspNetCore.Mvc;
using Mission06_Yoon.Models;
using System.Diagnostics;

namespace Mission06_Yoon.Controllers
{
    public class HomeController : Controller
    {
        private MovieAddedContext _context;
        public HomeController(MovieAddedContext temp) 
        {
               _context = temp;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetToKnowJoel()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(AddingMovie response)
        {
            _context.MoviesAdded.Add(response);
            _context.SaveChanges();
                
            return View("Confirmation");
        }
    }
}
