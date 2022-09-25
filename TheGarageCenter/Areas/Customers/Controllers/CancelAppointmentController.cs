using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TheGarageCenter.Models;

namespace TheGarageCenter.Areas.Customers.Controllers
{
    public class CancelAppointmentController : ApiController
    {
        private readonly ApplicationDbContext _context;
        public CancelAppointmentController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Cancel(int id)
        {
            var appointment = _context.Appointments.FirstOrDefault(a => a.Id == id);
            if (appointment != null)
            {
                appointment.IsCancelled = true;
                _context.SaveChanges();
            }
            return Ok();
        }
    }
}
