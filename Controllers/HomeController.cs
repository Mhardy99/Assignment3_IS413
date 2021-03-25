using Assignment3_IS413.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3_IS413.Controllers
{
    public class HomeController : Controller
    {
       // private readonly ILogger<HomeController> _logger;

      //  private IMovieRepository _repository;

        private MovieDbContext context { get; set; }

        public HomeController(MovieDbContext con)
        {
            // in controllerILogger<HomeController> logger , IMovieRepository repository
            //_logger = logger;
            // _repository = repository;
            context = con;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyPodcasts()
        {
            return View();
        }

        public IActionResult MovieList()
        {
          //  return View(TempStorage.Listmovies);
            return View(context.movieResponses);
        }
        [HttpGet]
        public IActionResult EnterMovie()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Remove(int RemoveIt)
        {
            MovieResponse movietodelete = context.movieResponses.Single(x => x.MovieID == RemoveIt);
            context.movieResponses.Remove(movietodelete);
            context.SaveChanges();
            return RedirectToAction("MovieList");
        }

        [HttpPost]
        public IActionResult EnterMovie(MovieResponse movie)
        {
            if (ModelState.IsValid)
            {
                context.movieResponses.Add(movie);
                context.SaveChanges();
                Response.Redirect("MovieList"); ; // , movie
            }

            return View();
        }
        [HttpGet]
        public IActionResult EditMovieInfo(int MovieID)
        {
            return View();
        }
        [HttpPost]
        public IActionResult EditMovieInfo(int EditIt, MovieResponse movie)
        {
            if (ModelState.IsValid)
            {
                MovieResponse movietoedit = context.movieResponses.FirstOrDefault(x => x.MovieID == EditIt);
                //context.movieResponses.Add(movietoedit);
                movietoedit.Category = movie.Category;
                movietoedit.Title = movie.Title;
                context.SaveChanges();
                Response.Redirect("MovieList"); ; // , movie
            }

            return View();
        }
    
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
