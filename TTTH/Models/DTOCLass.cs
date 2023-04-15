using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTTH.Models
{
    public class DTOCLass : ModelEntity
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
        private List<Int32> listDatesInWeek = new List<Int32>();
        private int numberOfStudent = -1;



        public DTOCLass() { }
        public DTOCLass(int id) 
        {
            this.Id = id;
        }

        public DTOCLass(int id, string name, DateTime start, int maxCapacity, int shift, int courseID, int roomID, int teacherID)
        {
            this.Id = id;
            this.Name = name;
            this.Start = start;
            this.End = end;
            this.MaxCapacity = maxCapacity;
            this.Shift = shift;
            this.CourseName = courseName;
            this.CourseID = courseID;
            this.RoomID = roomID;
            this.TeacherID = teacherID;
        }

        public DTOCLass(int id, string name, DateTime start, DateTime end,
            int maxCapacity, int shift, string courseName, int numberOfStudent)
        {
            this.Id = id;
            this.Name = name;
            this.Start = start;
            this.End = end;
            this.MaxCapacity = maxCapacity;
            this.Shift = shift;
            this.CourseName = courseName;
            this.numberOfStudent = numberOfStudent;
        }

        public string Name { get => name; set => name = value; }
        public DateTime Start { get => start; set => start = value; }
        public int MaxCapacity { get => maxCapacity; set => maxCapacity = value; }
        public int Shift { get => shift; set => shift = value; }
        public List<int> ListDatesInWeek { get => listDatesInWeek; set => listDatesInWeek = value; }
        public string CourseName { get => courseName; set => courseName = value; }
        public DateTime End { get => end; set => end = value; }
        public int CourseID { get => courseID; set => courseID = value; }
        public int RoomID { get => roomID; set => roomID = value; }
        public int NumberOfStudent { get => numberOfStudent; set => numberOfStudent = value; }
        public string RoomName { get => roomName; set => roomName = value; }
        public int TeacherID { get => teacherID; set => teacherID = value; }
        public string TeacherName { get => teacherName; set => teacherName = value; }
    }
}
