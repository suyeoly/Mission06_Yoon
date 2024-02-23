using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_Yoon.Models;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

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

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.CategoryTable = _context.CategoryTable
            .OrderBy(x => x.Category)
            .ToList();

            return View("Create", new AddingMovie());
        }

        [HttpPost]
        public IActionResult Create(AddingMovie response)
        {
            if (ModelState.IsValid)
            {
                _context.MoviesAdded.Add(response);
                _context.SaveChanges();

                return View("Confirmation", response);
            }
            else
            {
                ViewBag.CategoryTable = _context.CategoryTable
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

            var applications = _context.MoviesAdded.Include("Category").ToList();

            return View(applications);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.MoviesAdded
                .Single(x => x.MovieId == id);

            ViewBag.CategoryTable = _context.CategoryTable
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
            var recordToDelete = _context.MoviesAdded
                .Single(x => x.MovieId == id);

            return View("Delete", recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(AddingMovie application)
        {
            _context.MoviesAdded.Remove(application);
            _context.SaveChanges();

            return RedirectToAction("MovieList");
        }
    }
}
