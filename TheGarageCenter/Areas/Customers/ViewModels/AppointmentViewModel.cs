using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheGarageCenter.Models;

namespace TheGarageCenter.Areas.Customers.ViewModels
{
    public class AppointmentViewModel
    {
        public int DealerId { get; set; }
        public string DealerAddress { get; set; }
        public string DealerName { get; set; }

        public string DealerDescription { get; set; }

        [Required]
        public DateTime? Date { get; set; }
        public int Time { get; set; }

        public IEnumerable<SelectListItem> Hours { get; set; } 

        [Required]
        [Display(Name = "Licence Plate")]
        public string LicencePlate { get; set; }
        public WeekSchedule WeekSchedule { get; set; }
    }
}