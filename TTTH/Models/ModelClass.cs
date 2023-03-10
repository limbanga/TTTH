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
        private ModelCourse course;
        private ModelRoom room;

        // for query
        public ModelClass(int id, string name, DateTime start, DateTime end, int maxCapacity, int shift, ModelCourse course, ModelRoom room)
        {
            this.Id = id;
            this.Name = name;
            this.Start = start;
            this.End = end;
            this.MaxCapacity = maxCapacity;
            this.Shift = shift;
            this.Course = course;
            this.Room = room;
        }
        // for add or update
        public ModelClass(int id, string name, DateTime start, DateTime end, int maxCapacity, int shift, int courseID, int roomID)
        {
            MessageBox.Show("Test id nhajn duocj la"+ id);
            this.Id = id;
            this.Name = name;
            this.Start = start;
            this.End = end;
            this.MaxCapacity = maxCapacity;
            this.Shift = shift;
            this.Course = new ModelCourse(courseID);
            this.Room = new ModelRoom(roomID);
        }

        public string Name { get => name; set => name = value; }
        public DateTime Start { get => start; set => start = value; }
        public DateTime End { get => end; set => end = value; }
        public int MaxCapacity { get => maxCapacity; set => maxCapacity = value; }
        public int Shift { get => shift; set => shift = value; }
        public ModelCourse Course { get => course; set => course = value; }
        public string CourseName { get => course.Name; }
        public ModelRoom Room { get => room; set => room = value; }
        public string RoomName { get => room.Name; }

    }
}
