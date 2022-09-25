using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using TheGarageCenter.Areas.Customers.ViewModels;
using TheGarageCenter.Models;

namespace TheGarageCenter.Areas.Customers.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AppointmentsController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize(Roles = "Customer")]
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult AppointmentList(bool includeCancelled, bool showFuture)
        {
            var userId = User.Identity.GetUserId();
            var customer = _context.Customers.FirstOrDefault(c => c.ApplicationUserId == userId);
            var appointments = _context.Appointments
                .Include(a => a.Dealer)
                .Where(a => a.CustomerId == customer.Id);

            if (includeCancelled == false)
            {
                appointments = appointments.Where(a => a.IsCancelled == false);
            }

            var today = DateTime.Today;

            if (showFuture == false)
            {
                appointments = appointments.Where(a => a.Date < today);
                ViewBag.Past = "past";
            } else
            {
                appointments = appointments.Where(a => a.Date >= today);
            }
           
            appointments = appointments.OrderBy(a => a.Date).ThenBy(a => a.Hour);

            return PartialView("_AppointmentList", appointments);
        }


        [Authorize(Roles = "Customer")]
        public ActionResult Create(int id)
        {
            var dealer = _context.Dealers.FirstOrDefault(d => d.Id == id);
            if (dealer == null)
                return HttpNotFound();

            var viewModel = new AppointmentViewModel()
            {
                DealerName = dealer.Name,
                DealerDescription = dealer.Description,
                DealerAddress = dealer.Address,
                DealerId = id,
                WeekSchedule = new WeekSchedule(),
                Hours = new SelectList(new List<int>())
            };

            var dealerTable = _context.DayTables.Where(d => d.DealerId == dealer.Id);
            if (dealerTable != null)
            {
                viewModel.WeekSchedule = viewModel.WeekSchedule.WeekTable(dealerTable);
            }

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AppointmentViewModel viewModel)
        {
            var userId = User.Identity.GetUserId();
            Customer customer = _context.Customers.FirstOrDefault(c => c.ApplicationUserId == userId);

            var appointment = new Appointment()
            {
                Date = (DateTime)viewModel.Date,
                Hour = viewModel.Time,
                LicencePlate = viewModel.LicencePlate,
                IsConfirmed = false,
                IsCancelled = false,
                DealerId = viewModel.DealerId,
                CustomerId = customer.Id
            };

            _context.Appointments.Add(appointment);
            _context.SaveChanges();
            TempData["success"] = "Appointment added succesfully";
            return RedirectToAction("Index", "Home");
        }
    }
}