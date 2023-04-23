using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTTH.Models.DTO
{
    public class DTOScore
    {
        private int examNumber = -1;

        private DTOClass modelClass = new DTOClass();
        private DTOStudent modelStudent = new DTOStudent();
        private double score = 0;

        public DTOScore() { }

        public int ExamNumber { get => examNumber; set => examNumber = value; }
        public DTOClass ModelClass { get => modelClass; set => modelClass = value; }
        public DTOStudent DTOStudent { get => modelStudent; set => modelStudent = value; }
        public string StudentName { get => modelStudent.Name; }
        public string StudentPhoneNumber { get => modelStudent.PhoneNumber; }
        public double Score { get => score; set => score = value; }
    }
}
