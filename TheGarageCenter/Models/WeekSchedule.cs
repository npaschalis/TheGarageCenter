using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheGarageCenter.Models
{
    public class WeekSchedule
    {
        public DayTable MondayTable { get; set; }
        public DayTable TuesdayTable { get; set; }
        public DayTable WednesdayTable { get; set; }
        public DayTable ThursdayTable { get; set; }
        public DayTable FridayTable { get; set; }
        public DayTable SaturdayTable { get; set; }
        public DayTable SundayTable { get; set; }

        public WeekSchedule WeekTable(IEnumerable<DayTable> dealerTable)
        {
            WeekSchedule weekTable = new WeekSchedule()
            {
                MondayTable = dealerTable.FirstOrDefault(d => d.Day == "Monday"),
                TuesdayTable = dealerTable.FirstOrDefault(d => d.Day == "Tuesday"),
                WednesdayTable = dealerTable.FirstOrDefault(d => d.Day == "Wednesday"),
                ThursdayTable = dealerTable.FirstOrDefault(d => d.Day == "Thursday"),
                FridayTable = dealerTable.FirstOrDefault(d => d.Day == "Friday"),
                SaturdayTable = dealerTable.FirstOrDefault(d => d.Day == "Saturday"),
                SundayTable = dealerTable.FirstOrDefault(d => d.Day == "Sunday")
            };

            return weekTable;
        }
    }
}