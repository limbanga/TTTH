using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTTH.Models.DTO
{
    public class DTOStudent : DTOEntity
    {
        private string _name = "-";
        private string phoneNumber = "-";
        private int totalAbsence = 0;
        private int totalLate = 0;
        private double avgScore = 0;


        private bool isInClass = false;
        private bool isConflict = false;


        public string Name { get => _name; set => _name = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public bool IsInClass { get => isInClass; set => isInClass = value; }
        public int TotalAbsence { get => totalAbsence; set => totalAbsence = value; }
        public int TotalLate { get => totalLate; set => totalLate = value; }
        public double AvgScore { get => avgScore; set => avgScore = value; }
        public bool IsConflict { get => isConflict; set => isConflict = value; }

        public DTOStudent() { }
        public DTOStudent(int id, string name, string phoneNumber)
        {
            Id = id;
            Name = name;
            PhoneNumber = phoneNumber;
        }
        public DTOStudent(int id, string name, string phoneNumber, bool isInClass, bool isConflict)
        {
            Id = id;
            Name = name;
            PhoneNumber = phoneNumber;
            IsInClass = isInClass;
            IsConflict = isConflict;
        }
    }
}
