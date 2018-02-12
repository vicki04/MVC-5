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
    public class CustomersController : Controller
    {

       private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Customers
        public ActionResult Index()
        {
            //var customers = GetCustomers();

            var customers = _context.Customers.Include(m=>m.MembershipType).ToList();

            if (customers == null)
            {
                return Content("No customer has registered yet");
            }
            else
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            //var customers = new RandomMoviesViewModel();
            var customer = _context.Customers.Include(m=>m.MembershipType).SingleOrDefault(c => c.Id == id);
            
            
                if (customer==null)
                {
                return HttpNotFound();
                }
            

            return View(customer);
        }

       /* public IEnumerable<Customers> GetCustomers()
        {
            return new List<Customers>
            {
                new Customers{name="John",Id=1},
                new Customers{name="Smith",Id=2}
            };
        }*/
    }
}