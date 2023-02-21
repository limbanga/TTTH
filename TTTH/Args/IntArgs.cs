using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTTH.Args
{
    internal class IntArgs : EventArgs
    {
        private int value;
        public int Value { get => value; set => this.value = value; }

        public IntArgs(int value)
        {
            Value = value;
        }

    }
}
