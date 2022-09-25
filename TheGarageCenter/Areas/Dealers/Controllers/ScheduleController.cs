using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheGarageCenter.Areas.Dealers.ViewModels;
using TheGarageCenter.Models;

namespace TheGarageCenter.Areas.Dealers.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ScheduleController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Edit
        public ActionResult Index()
        {
            return View();
        }

       
        [Authorize(Roles = "Dealer")]
        public ActionResult Edit()
        {
            var viewModel = new ScheduleViewModel();

            var userId = User.Identity.GetUserId();
            var dealer = _context.Dealers.FirstOrDefault(d => d.ApplicationUserId == userId);

            var dealerTable = _context.DayTables.Where(d => d.DealerId == dealer.Id);

            viewModel = viewModel.WeekTable(dealerTable);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ScheduleViewModel viewModel)
        {
            if (viewModel.MondayTable.FirstAppointment > viewModel.MondayTable.LastAppointment)
            {
                ModelState.AddModelError("MondayTable.FirstAppointment", "Last appointment can't be earlier than the first appointment");
            }

            if (viewModel.TuesdayTable.FirstAppointment > viewModel.TuesdayTable.LastAppointment)
            {
                ModelState.AddModelError("TuesdayTable.FirstAppointment", "Last appointment can't be earlier than the first appointment");
            }

            if (viewModel.WednesdayTable.FirstAppointment > viewModel.WednesdayTable.LastAppointment)
            {
                ModelState.AddModelError("WednesdayTable.FirstAppointment", "Last appointment can't be earlier than the first appointment");
            }

            if (viewModel.ThursdayTable.FirstAppointment > viewModel.ThursdayTable.LastAppointment)
            {
                ModelState.AddModelError("ThursdayTable.FirstAppointment", "Last appointment can't be earlier than the first appointment");
            }

            if (viewModel.FridayTable.FirstAppointment > viewModel.FridayTable.LastAppointment)
            {
                ModelState.AddModelError("FridayTable.FirstAppointment", "Last appointment can't be earlier than the first appointment");
            }

            if (viewModel.SaturdayTable.FirstAppointment > viewModel.SaturdayTable.LastAppointment)
            {
                ModelState.AddModelError("SaturdayTable.FirstAppointment", "Last appointment can't be earlier than the first appointment");
            }

            if (viewModel.SundayTable.FirstAppointment > viewModel.SundayTable.LastAppointment)
            {
                ModelState.AddModelError("SundayTable.FirstAppointment", "Last appointment can't be earlier than the first appointment");
            }

            if (!ModelState.IsValid)
            {
                return View("Edit", viewModel);
            }

            var userId = User.Identity.GetUserId();
            var dealer = _context.Dealers.FirstOrDefault(d => d.ApplicationUserId == userId);
            var dealerTimeTables = _context.DayTables.Where(d => d.DealerId == dealer.Id);

            _context.DayTables.RemoveRange(dealerTimeTables);

            if (viewModel.MondayTable.FirstAppointment >= 0 && viewModel.MondayTable.LastAppointment > 0)
            {
                var dayTable = new DayTable()
                {
                    Day = "Monday",
                    FirstAppointment = viewModel.MondayTable.FirstAppointment,
                    LastAppointment = viewModel.MondayTable.LastAppointment,
                    DealerId = dealer.Id
                };

                _context.DayTables.Add(dayTable);
            }

            if (viewModel.TuesdayTable.FirstAppointment >= 0 && viewModel.TuesdayTable.LastAppointment > 0)
            {
                var dayTable = new DayTable()
                {
                    Day = "Tuesday",
                    FirstAppointment = viewModel.TuesdayTable.FirstAppointment,
                    LastAppointment = viewModel.TuesdayTable.LastAppointment,
                    DealerId = dealer.Id
                };

                _context.DayTables.Add(dayTable);
            }

            if (viewModel.WednesdayTable.FirstAppointment >= 0 && viewModel.WednesdayTable.LastAppointment > 0)
            {
                var dayTable = new DayTable()
                {
                    Day = "Wednesday",
                    FirstAppointment = viewModel.WednesdayTable.FirstAppointment,
                    LastAppointment = viewModel.WednesdayTable.LastAppointment,
                    DealerId = dealer.Id
                };

                _context.DayTables.Add(dayTable);
            }

            if (viewModel.ThursdayTable.FirstAppointment >= 0 && viewModel.ThursdayTable.LastAppointment > 0)
            {
                var dayTable = new DayTable()
                {
                    Day = "Thursday",
                    FirstAppointment = viewModel.ThursdayTable.FirstAppointment,
                    LastAppointment = viewModel.ThursdayTable.LastAppointment,
                    DealerId = dealer.Id
                };

                _context.DayTables.Add(dayTable);
            }

            if (viewModel.FridayTable.FirstAppointment >= 0 && viewModel.FridayTable.LastAppointment > 0)
            {
                var dayTable = new DayTable()
                {
                    Day = "Friday",
                    FirstAppointment = viewModel.FridayTable.FirstAppointment,
                    LastAppointment = viewModel.FridayTable.LastAppointment,
                    DealerId = dealer.Id
                };

                _context.DayTables.Add(dayTable);
            }

            if (viewModel.SaturdayTable.FirstAppointment >= 0 && viewModel.SaturdayTable.LastAppointment > 0)
            {
                var dayTable = new DayTable()
                {
                    Day = "Saturday",
                    FirstAppointment = viewModel.SaturdayTable.FirstAppointment,
                    LastAppointment = viewModel.SaturdayTable.LastAppointment,
                    DealerId = dealer.Id
                };

                _context.DayTables.Add(dayTable);
            }

            if (viewModel.SundayTable.FirstAppointment >= 0 && viewModel.SundayTable.LastAppointment > 0)
            {
                var dayTable = new DayTable()
                {
                    Day = "Sunday",
                    FirstAppointment = viewModel.SundayTable.FirstAppointment,
                    LastAppointment = viewModel.SundayTable.LastAppointment,
                    DealerId = dealer.Id
                };

                _context.DayTables.Add(dayTable);
            }

            _context.SaveChanges();
            TempData["success"] = "Schedule saved succesfully";
            return RedirectToAction("Index", "Home");
        }
    }
}