using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTTH.Models
{
    public class ModelClass : ModelEntity
    {
        private string name;
        private DateTime start;
        private DateTime end;
        private int maxCapacity;
        private int shift;
        private int courseId = -1;
        private string courseName;
        private int roomId = -1;
        private string roomName;
        public string Name { get => name; set => name = value; }
        public DateTime Start { get => start; set => start = value; }
        public DateTime End { get => end; set => end = value; }
        public int MaxCapacity { get => maxCapacity; set => maxCapacity = value; }
        public int Shift { get => shift; set => shift = value; }
        public string CourseName { get => courseName; set => courseName = value; }
        public string RoomName { get => roomName; set => roomName = value; }
        public int RoomId { get => roomId; set => roomId = value; }
        public int CourseId { get => courseId; set => courseId = value; }

        public ModelClass(int id, string name, DateTime start, DateTime end, int maxCapacity, int shift, string courseName, string roomName)
        {
            this.Id = id;
            this.Name = name;
            this.Start = start;
            this.End = end;
            this.MaxCapacity = maxCapacity;
            this.Shift = shift;
            this.CourseName = courseName;
            this.RoomName = roomName;
        }

        public ModelClass(string name, DateTime start, DateTime end, int maxCapacity, int shift, int courseId, int roomId)
        {
            this.name = name;
            this.start = start;
            this.end = end;
            this.maxCapacity = maxCapacity;
            this.shift = shift;
            this.courseId = courseId;
            this.roomId = roomId;
        }
    }
}
