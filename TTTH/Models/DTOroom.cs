using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTTH.Models
{
    public class DTOroom : ModelEntity
    {
        private string name = "-";
        private string type = "-";
        private int capacity = -1;
        public string Name { get => name; set => name = value; }
        public string Type { get => type; set => type = value; }
        public int Capacity { get => capacity; set => capacity = value; }

        public DTOroom() { }
        public DTOroom(int id) 
        {
            this.Id = id;
        }
        public DTOroom(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
        public DTOroom(int id, string name, string type, int capacity)
        {
            this.Id = id;
            this.Name = name;
            this.Type = type;
            this.Capacity = capacity;
        }

    }
}
