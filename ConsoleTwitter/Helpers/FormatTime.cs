using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTwitter.Helpers
{
    public static class FormatTime
    {
        public static string Format(DateTime date)
        {
            DateTime dateToFormat = date;
            var ts = dateToFormat.Subtract(DateTime.Now);

            var days = Math.Abs(ts.Days);
            if (days > 0)
            {
                if(days == 1)
                    return "(" + days.ToString() + " day ago)";
                else
                    return "(" + days.ToString() + " days ago)";
            }

            var minutes = Math.Abs(ts.Minutes);
            if (minutes > 0)
            {
                if (minutes == 1)
                    return "(" + minutes.ToString() + " minute ago)";
                else
                    return "(" + minutes.ToString() + " minutes ago)";
            }

            var seconds = Math.Abs(ts.Seconds);
            if (seconds == 1)
                return "(" + seconds.ToString() + " second ago)"; 
            else
                return "(" + seconds.ToString() + " seconds ago)";
        }
    }
}
