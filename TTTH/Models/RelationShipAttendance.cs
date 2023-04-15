using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTTH.Models
{
    public class RelationShipAttendance
    {
        private ModelStudent modelStudent;
        private DTOCLass modelClass;
        private char status;
        private DateTime date;
        private int dateNumber;
        private DateTime updateTime;
        public ModelStudent ModelStudent { get => modelStudent; set => modelStudent = value; }
        public DTOCLass ModelClass { get => modelClass; set => modelClass = value; }
        public char Status { get => status; set => status = value; }
        public DateTime Date { get => date; set => date = value; }
        public int DateNumber { get => dateNumber; set => dateNumber = value; }
        public DateTime UpdateTime { get => updateTime; set => updateTime = value; }
        public string StudentName { get => modelStudent is null ? "-": modelStudent.Name; }
        public string StudentPhoneNumber { get => modelStudent is null ? "-" : modelStudent.PhoneNumber; }
        public bool isLate { get => status == 'l'; set => status = 'l'; }
        public bool isAbsence { get => status == 'a'; set => status = 'a'; }
        public bool isPresent { get => status == 'p'; set => status = 'p'; }




        public RelationShipAttendance(ModelStudent modelStudent, DTOCLass modelClass, char status, DateTime date, int dateNumber, DateTime updateTime)
        {
            this.modelStudent = modelStudent;
            this.modelClass = modelClass;
            this.status = status;
            this.date = date;
            this.dateNumber = dateNumber;
            this.updateTime = updateTime;
        }

        public RelationShipAttendance(ModelStudent modelStudent, DTOCLass modelClass, char status, DateTime date, int dateNumber)
        {
            this.modelStudent = modelStudent;
            this.modelClass = modelClass;
            this.status = status;
            this.date = date;
            this.dateNumber = dateNumber;
        }
        public RelationShipAttendance(ModelStudent modelStudent, DTOCLass modelClass, char status, int dateNumber)
        {
            this.modelStudent = modelStudent;
            this.modelClass = modelClass;
            this.status = status;
            this.dateNumber = dateNumber;
        }
    }
}
