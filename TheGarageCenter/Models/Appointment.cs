using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheGarageCenter.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int Hour { get; set; }

        [Required]
        public string LicencePlate { get; set; }
        public bool IsConfirmed { get; set; }
        public bool IsCancelled { get; set; }

        [Required]
        public int DealerId { get; set; }
        public Dealer Dealer { get; set; }

        [Required]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}