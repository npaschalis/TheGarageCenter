using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TheGarageCenter.Models;

namespace TheGarageCenter.Areas.Dealers.Controllers
{
    public class ConfirmAppointmentController : ApiController
    {
        private readonly ApplicationDbContext _context;
        public ConfirmAppointmentController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Confirm(int id)
        {
            var appointment = _context.Appointments.FirstOrDefault(a => a.Id == id);
            if (appointment != null)
            {
                appointment.IsConfirmed = true;
                _context.SaveChanges();
            }
            return Ok();
        }
    }
}
