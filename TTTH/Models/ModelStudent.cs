using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTTH.Models
{
    public class ModelStudent : ModelEntity
    {
        private string _name = "-";
        private string phoneNumber = "-";

        // variables for hanlde form
        private bool isInClass = false;

        public string Name { get => _name; set => _name = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public bool IsInClass { get => isInClass; set => isInClass = value; }

        public ModelStudent() { }
        public ModelStudent(int id, string name, string phoneNumber)
        {
            this.Id = id;
            Name = name;
            this.PhoneNumber = phoneNumber;
        }
        public ModelStudent(int id, string name, string phoneNumber, bool isInClass)
        {
            this.Id = id;
            Name = name;
            this.PhoneNumber = phoneNumber;
            this.IsInClass = isInClass;
        }
    }
}
