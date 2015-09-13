using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer
{
    static class Utilities
    {
        public static void ValidateString(string input, string parameterName)
        {
            if (string.IsNullOrEmpty(parameterName))
            {
                throw new ArgumentException("{0} cannot be null or empty.");
            }
        }
    }
}
