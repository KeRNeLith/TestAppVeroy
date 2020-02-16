using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tests
{
    static class Helpers
    {
        public static bool IsDay(int day)
        {
            var d = DateTime.Now;

            return d.Day == day;
        }
    }
}
