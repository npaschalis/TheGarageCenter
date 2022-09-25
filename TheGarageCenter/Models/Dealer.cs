using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheGarageCenter.Models
{
    public class Dealer
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Address { get; set; }

        public bool isSubscribed { get; set; }

        [Required]
        public byte BrandId { get; set; }

        public Brand Brand { get; set; }

        public IEnumerable<DayTable> WeekTable { get; set; }

        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}