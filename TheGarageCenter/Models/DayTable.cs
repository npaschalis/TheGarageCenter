using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheGarageCenter.Models
{
    public class DayTable
    {
        public int Id { get; set; }
        public string Day { get; set; }

        [Range(0, 21)]
        public int? FirstAppointment { get; set; }

        [Range(0, 21)]
        public int? LastAppointment { get; set; }
        public int DealerId { get; set; }
        public Dealer Dealer { get; set; }
    }
}