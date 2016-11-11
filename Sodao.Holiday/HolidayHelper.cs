using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sodao.Holiday
{
    public class HolidayHelper
    {
        public List<Holiday> OfficeHoliday = new List<Holiday>();
        public HolidayHelper()
        {
            OfficeHoliday.Add(new Holiday(1, 1));
            OfficeHoliday.Add(new Holiday(2, 7));
            OfficeHoliday.Add(new Holiday(2, 8));
            OfficeHoliday.Add(new Holiday(2, 9));
            OfficeHoliday.Add(new Holiday(2, 10));
            OfficeHoliday.Add(new Holiday(2, 11));
            OfficeHoliday.Add(new Holiday(2, 12));
            OfficeHoliday.Add(new Holiday(2, 13));
        }
        public DateTime CalculateDelay(DateTime data)
        {
            var temp = new Holiday(data.Month, data.Day);
            if (OfficeHoliday.Count(p=>p.Month==data.Month&&p.Day==data.Day)>0)
            {
                data = data.AddDays(1);
                return CalculateDelay(data);
            }
            else
            {
                return data;
            }
        }
    }
    public class Holiday
    {
        public Holiday(int month, int day)
        {
            Month = month;
            Day = day;
        }
        public int Month { get; set; }
        public int Day { get; set; }
    }
}
