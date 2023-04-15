using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTTH.Models
{
    public class DTOClassDate : ModelEntity
    {
        private int classID = -1;
        private int roomID = -1;
        private int teacherID = -1;

        private int dateNumber = -1;
        private DateTime date = DateTime.MinValue;
        private int shift = -1;

        private string roomName = "-";
        private string teacherName = "-";

        public DTOClassDate(int id, int roomID, int teacherID, DateTime date, int shift)
        {
            this.Id = id;
            this.roomID = roomID;
            this.teacherID = teacherID;
            this.Date = date;
            this.shift = shift;
        }

        public DTOClassDate(int id, int classID, int roomID, int teacherID, int dateNumber, DateTime date, int shift, string roomName, string teacherName)
        {
            this.Id = id;
            this.classID = classID;
            this.roomID = roomID;
            this.teacherID = teacherID;
            this.dateNumber = dateNumber;
            this.Date = date;
            this.shift = shift;
            this.roomName = roomName;
            this.teacherName = teacherName;
        }


        public int ClassID { get => classID; set => classID = value; }
        public int RoomID { get => roomID; set => roomID = value; }
        public int TeacherID { get => teacherID; set => teacherID = value; }
        public int DateNumber { get => dateNumber; set => dateNumber = value; }
        public DateTime Date { get => date; set => date = value; }
        public int Shift { get => shift; set => shift = value; }
        public string RoomName { get => roomName; set => roomName = value; }
        public string TeacherName { get => teacherName; set => teacherName = value; }
    }
}
