using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsAndDailyPlanner.DAL.Extensions
{
    public static class StringExtensions
    {
        //compare strings with rules
        //for example ignore case
        public static bool Contains(this string source, string toCheck, StringComparison comp)
        {
            return source?.IndexOf(toCheck, comp) >= 0;
        }
    }
}
