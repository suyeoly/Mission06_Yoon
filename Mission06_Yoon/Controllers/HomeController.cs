using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_Yoon.Models;

namespace Mission06_Yoon.Controllers
{
    public class HomeController : Controller
    {
        private MoviesContext _context;
        public HomeController(MoviesContext temp) 
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

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.CategoryTable = _context.Categories
            .OrderBy(x => x.Category)
            .ToList();

            return View("Create", new AddingMovie());
        }

        [HttpPost]
        public IActionResult Create(AddingMovie response)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(response);
                _context.SaveChanges();

                return View("Confirmation", response);
            }
            else
            {
                ViewBag.CategoryTable = _context.Categories
                    .OrderBy(x => x.Category)
                    .ToList();

                return View(response);
            }
        }

        public IActionResult MovieList()
        {

            //var applications = _context.MoviesAdded
            //    .Include(x => x.Category)
            //    .OrderBy(x => x.Title)
            //    .ToList();

            var applications = _context.Movies.Include("Category").ToList();

            return View(applications);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Movies
                .Single(x => x.MovieId == id);

            ViewBag.CategoryTable = _context.Categories
                .OrderBy(x => x.Category)
                .ToList();

            return View("Create", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(AddingMovie updatedInfo)
        {
            _context.Update(updatedInfo);
            _context.SaveChanges();

            return RedirectToAction("MovieList");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Movies
                .Single(x => x.MovieId == id);

            return View("Delete", recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(AddingMovie application)
        {
            _context.Movies.Remove(application);
            _context.SaveChanges();

            return RedirectToAction("MovieList");
        }
    }
}
