using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheGarageCenter.Areas.Dealers.ViewModels;
using TheGarageCenter.Models;

namespace TheGarageCenter.Areas.Dealers.Controllers
{
    public class ExcludeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ExcludeController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize(Roles = "Dealer")]
        public ActionResult Manage()
        {
            var viewModel = new ExcludeViewModel()
            {
                WeekSchedule = new WeekSchedule()
            };
            var userId = User.Identity.GetUserId();
            var dealer = _context.Dealers.FirstOrDefault(d => d.ApplicationUserId == userId);

            var dealerTable = _context.DayTables.Where(d => d.DealerId == dealer.Id);
            if (dealerTable != null)
            {
                viewModel.WeekSchedule = viewModel.WeekSchedule.WeekTable(dealerTable);
            }
            return View(viewModel);
        }

        public ActionResult GetHoursAction(string dateText)
        {
            DateTime date = DateTime.Parse(dateText);
            string day = date.ToString("dddd", new CultureInfo("en-US"));

            var userId = User.Identity.GetUserId();
            var dealer = _context.Dealers.FirstOrDefault(d => d.ApplicationUserId == userId);

            var hours = _context.DayTables.FirstOrDefault(d => d.DealerId == dealer.Id && d.Day == day);

            List<int> hourList = new List<int>();
            hourList.Add((int)hours.FirstAppointment);
            hourList.Add((int)hours.LastAppointment);

            int[] hoursArray = Enumerable.Range((int)hours.FirstAppointment, (int)hours.LastAppointment - (int)hours.FirstAppointment + 1).ToArray();
            for (int i = (int)hours.FirstAppointment; i <= (int)hours.LastAppointment; i++)
            {
                if (!_context.NotAvailable.Any(n => n.DealerId == dealer.Id
                    && n.Hour == i
                    && n.DateTime.Year == date.Year
                    && n.DateTime.Month == date.Month
                    && n.DateTime.Day == date.Day
                    ))
                {
                    hourList.Add(i);
                }
            }

            return Content(String.Join(",", hourList.ToArray()));
        }

        public JsonResult GetHoursActionById(int dealerId, string dateText)
        {
            DateTime date = DateTime.Parse(dateText);
            string day = date.ToString("dddd", new CultureInfo("en-US"));

            var hours = _context.DayTables.FirstOrDefault(d => d.DealerId == dealerId && d.Day == day);

            List<int> hourList = new List<int>();

            if (hours !=null)
            {
                for (int i=(int)hours.FirstAppointment; i<=(int)hours.LastAppointment; i++)
                {
                    if (!_context.NotAvailable.Any(n => n.DealerId == dealerId 
                        && n.Hour == i 
                        && n.DateTime.Year == date.Year
                        && n.DateTime.Month == date.Month
                        && n.DateTime.Day == date.Day
                        ))
                    {
                        hourList.Add(i);
                    }
                }
            }
            
            return Json(hourList, JsonRequestBehavior.AllowGet);
        }
    }
}