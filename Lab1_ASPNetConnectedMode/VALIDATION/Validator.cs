using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Lab1_ASPNetConnectedMode.VALIDATION
{
    public static class Validator
    {
        public static bool IsValidId(string input)
        {
            if (!(Regex.IsMatch(input,@"^\d{4}$")))
            {

                return false;
            }
            return true;
        }
    }
}