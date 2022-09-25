using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TheGarageCenter.Models;

namespace TheGarageCenter.ViewModels
{
    public class DealerViewModel
    {
        public Dealer Dealer { get; set; }

        [Required]
        public DateTime Date { get; set; }
        public int Time { get; set; }

        [Required]
        public string LicencePlate { get; set; }
        public WeekSchedule WeekSchedule { get; set; }
    }
}