using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheGarageCenter.Models
{
    public class NotAvailable
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public int Hour { get; set; }
        public int DealerId { get; set; }
        public Dealer Dealer { get; set; }
    }
}