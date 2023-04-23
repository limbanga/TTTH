using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTTH.Models.DTO
{
    public class DTOClass : DTOEntity
    {
        private int courseID = -1;
        private string courseName = "-";
        private int roomID = -1;
        private string roomName = "-";
        private int teacherID = -1;
        private string teacherName = "-";

        private string name = "";
        private DateTime start = DateTime.MinValue;
        private DateTime end = DateTime.MinValue;
        private int maxCapacity = -1;
        private int shift = -1;
        private int numberOfStudent = -1;
        private double income = -1;


        public DTOClass() { }

        public string Name { get => name; set => name = value; }
        public DateTime Start { get => start; set => start = value; }
        public int MaxCapacity { get => maxCapacity; set => maxCapacity = value; }
        public int Shift { get => shift; set => shift = value; }
        public string CourseName { get => courseName; set => courseName = value; }
        public DateTime End { get => end; set => end = value; }
        public int CourseID { get => courseID; set => courseID = value; }
        public int RoomID { get => roomID; set => roomID = value; }
        public int NumberOfStudent { get => numberOfStudent; set => numberOfStudent = value; }
        public string RoomName { get => roomName; set => roomName = value; }
        public int TeacherID { get => teacherID; set => teacherID = value; }
        public string TeacherName { get => teacherName; set => teacherName = value; }
        public string NumberOfStudentFormated { get => numberOfStudent+"/"+maxCapacity; }
        public double Income { get => income; set => income = value; }
        public string IncomeFormated { get => string.Format("{0:0,0}", income) + " vnd"; }

    }
}
