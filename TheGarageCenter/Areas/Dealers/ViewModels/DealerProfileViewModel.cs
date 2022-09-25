using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TheGarageCenter.Models;

namespace TheGarageCenter.Areas.Dealers.ViewModels
{
    public class DealerProfileViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public byte Brand { get; set; }

        public IEnumerable<Brand> Brands { get; set; }
    }
}