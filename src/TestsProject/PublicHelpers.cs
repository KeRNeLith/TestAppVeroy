using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tests
{
    public static class PublicHelpers
    {
        public static int MakeSomeStuff()
        {
            return MakeSomeStuff(16);
        }

        public static int MakeSomeStuff(int d)
        {
            var b = Helpers.IsDay(d);
            var b2 = Helpers.IsDay(DateTime.Now.Day);
            if (b && b2)
            {
                return 16 + DateTime.Now.Day;
            }

            return 0;
        }
    }
}
