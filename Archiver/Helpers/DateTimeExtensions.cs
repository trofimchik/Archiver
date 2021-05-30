using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archiver.Helpers
{
    public static class DateTimeExtensions
    {
        public static bool IsEarlierThan(this DateTime dateToCompare, DateTime date)
        {
            if (dateToCompare < date) return true;
            else return false;
        }
    }
}
