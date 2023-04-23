using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTTH.Models.DTO
{
    public class DTOCourse : DTOEntity
    {
        private string name = "-";
        private double fee = -1;
        private int duration = -1;
        private double income = -1;

        public string Name { get => name; set => name = value; }
        public double Fee { get => fee; set => fee = value; }
        public int Duration { get => duration; set => duration = value; }
        public string StringFee { get => string.Format("{0:0,0}", fee) + " vnd"; }
        public double Income { get => income; set => income = value; }

        public DTOCourse() { }
    }
}
