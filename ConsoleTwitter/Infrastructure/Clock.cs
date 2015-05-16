using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTwitter.Infrastructure
{
    public static class Clock
    {
        private static Func<DateTime> clock = () => SystemClock.Instance.Now.ToDateTimeUtc();

        public static DateTime Now { get { return clock(); } }

        public static Func<DateTime> ClockExpression
        {
            set
            {
                clock = value;
            }
        }
    }
}
