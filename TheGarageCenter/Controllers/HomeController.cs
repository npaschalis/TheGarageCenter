using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheGarageCenter.Models;
using TheGarageCenter.ViewModels;

namespace TheGarageCenter.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            if (User.IsInRole("Dealer"))
            {
                return RedirectToAction("Index", "Home", new { area = "Dealers" });
            }

            if (User.IsInRole("Customer"))
            {
                return RedirectToAction("Index", "Home", new { area = "Customers" });
            }

            var viewModel = new HomeFormViewModel()
            {
                Brands = _context.Brands.ToList(),
                NumberOfDealers = _context.Dealers.Count(),
                NumberOfCustomers = _context.Customers.Count(),
                NumberOfAppointments = _context.Appointments.Count()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(HomeFormViewModel viewModel)
        {
            var brand = _context.Brands.FirstOrDefault(b => b.Id == viewModel.Brand);

            if (brand == null)
            {
                return RedirectToAction("Index","Home");
            }

            return RedirectToAction("Index", "Brands", new { id = viewModel.Brand });
        }



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}