using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        
        // GET: Movies
        public ActionResult Index()
        {
            var movies = GetMovie();
            
            return View(movies);
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