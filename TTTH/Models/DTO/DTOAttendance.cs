using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTTH.Models.DTO
{
    public class DTOAttendance
    {
        private DTOStudent modelStudent = new DTOStudent();
        private DTOClass modelClass = new DTOClass();
        private char status;
        private DateTime date;
        private int dateNumber;
        private DateTime updateTime;
        public DTOStudent ModelStudent { get => modelStudent; set => modelStudent = value; }
        public DTOClass ModelClass { get => modelClass; set => modelClass = value; }
        public char Status { get => status; set => status = value; }
        public DateTime Date { get => date; set => date = value; }
        public int DateNumber { get => dateNumber; set => dateNumber = value; }
        public DateTime UpdateTime { get => updateTime; set => updateTime = value; }
        public string StudentName { get => modelStudent is null ? "-" : modelStudent.Name; }
        public string StudentPhoneNumber { get => modelStudent is null ? "-" : modelStudent.PhoneNumber; }
        public bool isLate { get => status == 'l'; set => status = 'l'; }
        public bool isAbsence { get => status == 'a'; set => status = 'a'; }
        public bool isPresent { get => status == 'p'; set => status = 'p'; }

        public DTOAttendance(DTOStudent modelStudent, DTOClass modelClass, char status, int dateNumber)
        {
            ModelStudent = modelStudent;
            ModelClass = modelClass;
            this.status = status;
            this.dateNumber = dateNumber;
        }
    }
}
