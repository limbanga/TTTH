using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTTH
{
    public static class Validator
    {
        // This class prove method to check input is valid?
        public static bool IsDouble(string text) 
        {
            double temp;
            bool isDouble = Double.TryParse(text, out temp);
            return isDouble;
        }

        public static bool IsInteger(string text)
        {
            int temp;
            bool isInteger = Int32.TryParse(text, out temp);
            return isInteger;
        }
    }
}
