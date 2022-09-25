using Microsoft.AspNet.Identity;
using Stripe;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheGarageCenter.Areas.Dealers.ViewModels;
using TheGarageCenter.Models;

namespace TheGarageCenter.Areas.Dealers.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize(Roles = "Dealer")]
        public ActionResult Index()
        {
            var viewModel = new ScheduleViewModel();

            var stripePublishKey = ConfigurationManager.AppSettings["stripePublishableKey"];
            ViewBag.StripePublishKey = stripePublishKey;

            var userId = User.Identity.GetUserId();
            var dealer = _context.Dealers.FirstOrDefault(d => d.ApplicationUserId == userId);

            var dealerTable = _context.DayTables.Where(d => d.DealerId == dealer.Id);

            if (dealerTable != null)
            {
                viewModel = viewModel.WeekTable(dealerTable);
            }

            viewModel.Dealer = dealer;

            return View(viewModel);
        }

        public ActionResult Charge(string stripeEmail, string stripeToken)
        {
            var customers = new CustomerService();
            var charges = new ChargeService();

            var customer = customers.Create(new CustomerCreateOptions
            {
                Email = stripeEmail,
                Source = stripeToken
            });

            var charge = charges.Create(new ChargeCreateOptions
            {
                Amount = 10000,
                Description = "The Garage Center subscription",
                Currency = "eur",
                Customer = customer.Id
            });

            var userId = User.Identity.GetUserId();
            var dealer = _context.Dealers.FirstOrDefault(d => d.ApplicationUserId == userId);

            dealer.isSubscribed = true;
            _context.SaveChanges();

            return View();
        }
    }
}