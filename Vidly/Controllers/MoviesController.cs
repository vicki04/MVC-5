using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();        
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var genre = _context.Genre.ToList();
            var viewModel = new MovieFormViewModel
            {
                Genre = genre

            };
            ViewBag.action = "New Movie";
            return View("MovieForm",viewModel);
        }
        [HttpPost]
        public ActionResult Create([Bind(Exclude ="Id")] Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel
                {
                    Movie = movie,
                    Genre = _context.Genre.ToList()
                };
                return View("MovieForm", viewModel);
            }
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }

            else
            {
                var movieInDb = _context.Movies.Single(c => c.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
            }
            _context.SaveChanges();
            return RedirectToAction("Index","Movies");
        }

        public ActionResult Edit(int id)
        {
            var movieInDb = _context.Movies.Single(c => c.Id == id);
            var viewModel = new MovieFormViewModel
            {
                Movie = movieInDb,
                Genre = _context.Genre.ToList()
            };
            ViewBag.action = "Edit Movie";
            return View("MovieForm",viewModel);
        }
        // GET: Movies
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m=>m.Genre).ToList();
            
            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(c => c.Id == id);
            return View(movie);
        }

        public ActionResult Random()
        {
            
            var customers = new List<Customers>
            {
                new Customers { name="customer1"},
            new Customers { name="customer1"}
            };

            var viewModel = new RandomMoviesViewModel
            {
                //Movie = movie,
                customer = customers

            };

            return View(viewModel);
        }
        public IEnumerable<Movie> GetMovie()
        {
            return new List<Movie>  {
            new Movie { Name = "Bahubali" },
            new Movie { Name = "Bahubali12" },
            new Movie { Name = "Bahubali2" },
            new Movie { Name = "Bahubali3" }

        };
        }
    }
}