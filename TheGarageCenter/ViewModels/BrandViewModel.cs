using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheGarageCenter.Models;

namespace TheGarageCenter.ViewModels
{
    public class BrandViewModel
    {
        public Brand Brand { get; set; }
        public IEnumerable<Dealer> Dealers { get; set; }
    }
}