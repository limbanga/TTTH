using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTTH.Models
{
    internal class DataBaseException : Exception
    {
        public DataBaseException(string message) : base(message) { }
    }
}
