using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TheGarageCenter.Models;

namespace TheGarageCenter.Areas.Dealers.ViewModels
{
    public class ExcludeViewModel
    {
        [Display(Name = "Date")]
        public string DateText { get; set; }
        public WeekSchedule WeekSchedule { get; set; }
    }
}