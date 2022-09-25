using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TheGarageCenter.Areas.Dealers.ViewModels;
using TheGarageCenter.Models;

namespace TheGarageCenter.Areas.Dealers.Controllers
{
    [Authorize]
    public class ExclusionController : ApiController
    {
        private readonly ApplicationDbContext _context;
        public ExclusionController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Manage([FromBody] ExclusionAPIModel model)
        {
            var userId = User.Identity.GetUserId();
            var dealer = _context.Dealers.FirstOrDefault(d => d.ApplicationUserId == userId);

            DateTime dateTime = DateTime.ParseExact(model.DateText, "dd/MM/yyyy", new CultureInfo("en-US")); 

            var existingTime = _context.NotAvailable.FirstOrDefault(e => e.DateTime == dateTime && e.Hour == model.Hour && e.DealerId == dealer.Id);

            if (existingTime == null)
            {
                var notAvailable = new NotAvailable()
                {
                    DateTime = dateTime,
                    Hour = model.Hour,
                    Dealer = dealer
                };

                _context.NotAvailable.Add(notAvailable);
            }
            else
            {
                _context.NotAvailable.Remove(existingTime);
            }

            _context.SaveChanges();

            return Ok();
        }
    }
}
