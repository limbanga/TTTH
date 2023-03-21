using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTTH.Models
{
    public class ModelClass : ModelEntity
    {
        private string name = "";
        private DateTime start = DateTime.MinValue;
        private DateTime end = DateTime.MaxValue;
        private int maxCapacity = -1;
        private int shift = -1;
        private List<Int32> listDatesInWeek = new List<Int32>();
        private ModelCourse course = new ModelCourse();
        private ModelRoom room = new ModelRoom();

        public ModelClass() { }
        public ModelClass(int id) 
        {
            this.Id = id;
        }

        // for query
        public ModelClass(int id, string name, DateTime start, DateTime end,
            int maxCapacity, int shift, List<Int32> listDatesInWeek, ModelCourse course, ModelRoom room)
        {
            this.Id = id;
            this.Name = name;
            this.Start = start;
            this.End = end;
            this.MaxCapacity = maxCapacity;
            this.Shift = shift;
            this.Course = course;
            this.Room = room;
            this.ListDatesInWeek = listDatesInWeek;
        }
        // for add or update
        public ModelClass(int id, string name, DateTime start, DateTime end,
            int maxCapacity, int shift, int courseID, int roomID)
        {
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
        public List<int> ListDatesInWeek { get => listDatesInWeek; set => listDatesInWeek = value; }
    }
}
