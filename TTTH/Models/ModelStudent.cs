using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTTH.Models
{
    public class ModelStudent : ModelEntity
    {
        private string _name = "-";
        private string phoneNumber = "-";
        private int totalAbsence = 0;
        private int totalLate = 0;
        private double avgScore = 0;

        // variables for hanlde form
        private bool isInClass = false;


        public string Name { get => _name; set => _name = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public bool IsInClass { get => isInClass; set => isInClass = value; }
        public int TotalAbsence { get => totalAbsence; set => totalAbsence = value; }
        public int TotalLate { get => totalLate; set => totalLate = value; }
        public double AvgScore { get => avgScore; set => avgScore = value; }

        public ModelStudent() { }
        public ModelStudent(int id, string name, string phoneNumber)
        {
            this.Id = id;
            Name = name;
            this.PhoneNumber = phoneNumber;
        }
        public ModelStudent(int id, string name, string phoneNumber, bool isInClass)
        {
            this.Id = id;
            Name = name;
            this.PhoneNumber = phoneNumber;
            this.IsInClass = isInClass;
        }

        public ModelStudent(int id, string name, string phoneNumber, int totalAbsence, int totalLate, double avgScore)
        {
            this.Id = id;
            this.Name = name;
            this.PhoneNumber = phoneNumber;
            this.TotalAbsence = totalAbsence;
            this.TotalLate = totalLate;
            this.avgScore = avgScore;
        }
    }
}
