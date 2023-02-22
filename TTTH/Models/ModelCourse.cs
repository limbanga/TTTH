using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTTH.Models
{
    public class ModelCourse : ModelEntity
    {
        private string name;
        private double fee;
        private int duration;

        public string Name { get => name; set => name = value; }
        public double Fee { get => fee; set => fee = value; }
        public int Duration { get => duration; set => duration = value; }

        public ModelCourse(int id ,string name, double fee, int duration)
        {
            this.Id = id;
            this.Name = name;
            this.Fee = fee;
            this.Duration = duration;
        }
    }
}
