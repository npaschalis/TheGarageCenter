using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TheGarageCenter.Models;

namespace TheGarageCenter.ViewModels
{
    public class HomeFormViewModel
    {
        [Required]
        public byte Brand { get; set; }

        public int NumberOfDealers { get; set; }
        public int NumberOfCustomers { get; set; }
        public int NumberOfAppointments { get; set; }

        public IEnumerable<Brand> Brands { get; set; }
    }
}