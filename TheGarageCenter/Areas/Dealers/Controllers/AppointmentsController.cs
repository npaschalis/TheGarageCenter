using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheGarageCenter.Areas.Customers.ViewModels;
using TheGarageCenter.Models;

namespace TheGarageCenter.Areas.Dealers.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AppointmentsController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize(Roles = "Dealer")]
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult AppointmentList(bool includeCancelled, bool showFuture)
        {
            var userId = User.Identity.GetUserId();
            var dealer = _context.Dealers.FirstOrDefault(d => d.ApplicationUserId == userId);
            var appointments = _context.Appointments
                .Include(a => a.Customer)
                .Where(a => a.DealerId == dealer.Id);

            if (includeCancelled == false)
            {
                appointments = appointments.Where(a => a.IsCancelled == false);
            }

            var today = DateTime.Today;

            if (showFuture == false)
            {
                appointments = appointments.Where(a => a.Date < today);
                ViewBag.Past = "past";
            }
            else
            {
                appointments = appointments.Where(a => a.Date >= today);
            }

            appointments = appointments.OrderBy(a => a.Date).ThenBy(a => a.Hour);

            return PartialView("_AppointmentList", appointments);
        }
    }
}