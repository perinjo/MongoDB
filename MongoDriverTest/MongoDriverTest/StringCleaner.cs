using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MongoDriverTest
{
    class StringCleaner
    {

        public static string checkString(string stringToCheck)
        {
            stringToCheck = Regex.Replace(stringToCheck, @"\t|\r", " ");
            stringToCheck = Regex.Replace(stringToCheck, @"( \n){2,}", "\n");
            stringToCheck = Regex.Replace(stringToCheck, " {2,}", " ");

            stringToCheck = stringToCheck.Trim();

            return stringToCheck;
        }
    }
}
