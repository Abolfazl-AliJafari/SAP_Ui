using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public static class Validation
    {

        public static bool CheckScoreFormat(string Score)
        {
            bool checkNumber =double.TryParse(Score, out double score);
            if (checkNumber)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CheckStringFormat(string Str)
        {
            foreach (char chr in Str)
            {
                if (byte.TryParse(chr.ToString(), out byte a))
                {
                    return false;
                }
            }
            return true;
        }
        public static bool CheckRangeFormat(string Str , byte Range )
        {
            if (Str.Length == Range)
            {
                return true;
            }
            return false;
        }

        public static bool CheckNumberFormat(string Str)
        {
            bool result= long.TryParse(Str, out long a);
            return result;
        }
    }
}
