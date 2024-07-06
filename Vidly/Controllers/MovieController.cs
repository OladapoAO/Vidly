
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vidly.Models;
using Vidly.ViewModel;
using Vidly.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {

        private ApplicationDbContext _context;
        //Movie movie = new Movie { Id = 1, Title = "Bad Boys 4" };
        RandomViewModel viewModel = new RandomViewModel
        {
            Movies = new List<Movie>()
            {
                new Movie { Id = 1, Title = "Bad Boys 4" },
                new Movie { Id = 2, Title = "Kingdom Of Planet Apes" }
            },
            Customers = new List<Customer>()
                {
                    new Customer { Id = 1,  Name = "Daps Owolabi"},
                    new Customer { Id = 2, Name = "Tilly Owolabi"}
                }

        };

        public MovieController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // Command + B = Build
        // GET: /<controller>


        public IActionResult Movies()
        {
            var movies = _context.Movies
                                 .Include(m => m.Genre)
                                 .ToList();
            return View(movies);
        }

        public IActionResult Details(int id)
        {
            var movie = _context.Movies
                         .Include(m => m.Genre)
                         .SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return Empty;

            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = _context.Genre.ToList()
            };
            return View("MovieForm", viewModel);
        }


        public IActionResult New()
        {
            var genres = _context.Genre.ToList();
            var viewModel = new MovieFormViewModel
            {
                Genres = genres
            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        public IActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
                _context.Movies.Add(movie);
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);

                movieInDb.Title = movie.Title;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.Genre = movie.Genre;
                movieInDb.Stock = movie.Stock;
            }

            _context.SaveChanges();

            return RedirectToAction("Movies", "Movie");
        }

    }
}

