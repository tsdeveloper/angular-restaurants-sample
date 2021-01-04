using System;
using System.Globalization;

namespace Restaurant.Core.Extensions
{
    public static class DateTimeExtensionHelper
    {
        public static DateTime FirstDayOfWeek(this DateTime date)
        {
            DayOfWeek fdow = CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
            int offset = fdow - date.DayOfWeek;
            DateTime fdowDate = date.AddDays(offset);
            return fdowDate;
        }

        public static DateTime LastDayOfWeek(this DateTime date)
        {
            DateTime ldowDate = FirstDayOfWeek(date).AddDays(6);
            return ldowDate;
        }
        
        public static bool Between(this DateTime input, DateTime date1, DateTime date2)
        {
            return (input > date1 && input < date2);
        }
    }
}