using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTTH.Models.DTO
{
    public class DTOroom : DTOEntity
    {
        private string name = "-";
        private string type = "-";
        private int capacity = -1;
        public string Name { get => name; set => name = value; }
        public string Type { get => type; set => type = value; }
        public int Capacity { get => capacity; set => capacity = value; }

        public string Name_Capacity { 
            get {
                if (this.Id == -1)
                {
                    return "-";
                }
                return name + " - " + capacity;
            } 
        }



        public DTOroom() { }

        public DTOroom(int id, string name, string type, int capacity)
        {
            Id = id;
            Name = name;
            Type = type;
            Capacity = capacity;
        }

    }
}
