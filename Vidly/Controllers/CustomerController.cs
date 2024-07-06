
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vidly.Data;
using Microsoft.AspNetCore.Mvc;
using Vidly.Models;
using Vidly.ViewModel;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {

        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

    
        // GET: /<controller>/
        public IActionResult Customers()
        {

            var customers = _context.Customers
                                    .Include(c => c.MemberShipType)
                                    .ToList();
            return View(customers);
        }

        public IActionResult Edit(int id)
        {
            //if (id > viewModel.Customers.Count)
            //    return Empty;


            var customer = _context.Customers
                //.Include(c => (DateOnly) c.BirthDate)
                .Include(c => c.MemberShipType)
                .SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return Empty;
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MemberShipTypes = _context.MemberShipType.ToList()
            };
            return View("CustomerForm", viewModel);
        }

        public IActionResult New()
        {
            var membershipTypes = _context.MemberShipType.ToList();
            var viewModel = new CustomerFormViewModel
            {
                MemberShipTypes = membershipTypes
            };

            return View("CustomerForm",viewModel);
        }

        [HttpPost] //This attribute ensure it can only be called via http post
        public ActionResult Save(Customer customer)
        {
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.MemberShipTypeId = customer.MemberShipTypeId;
                customerInDb.MemberShipType = customer.MemberShipType;
            }
            _context.SaveChanges();

            return RedirectToAction("Customers", "Customer");
        }

    }


}





//RandomViewModel viewModel = new RandomViewModel
//{
//    Movies = new List<Movie>()
//    {
//        new Movie { Id = 1, Title = "Bad Boys 4" },
//        new Movie { Id = 2, Title = "Kingdom Of Planet Apes" }
//    },
//    Customers = new List<Customer>()
//        {
//            new Customer { Id = 1,  Name = "Daps Owolabi"},
//            new Customer { Id = 2, Name = "Tilly Owolabi"}
//        }

//};