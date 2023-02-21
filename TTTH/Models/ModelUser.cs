using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTTH.Models
{
    public class ModelUser : ModelEntity
    {
        private string showName;
        private string email;
        private string phoneNumber;
        private string address;
        private int permissionID;

        public string ShowName { get => showName; set => showName = value; }
        public string Email { get => email; set => email = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Address { get => address; set => address = value; }
        public int PermissionID { get => permissionID; set => permissionID = value; }

        public ModelUser(string showName, string email, string phoneNumber, string address, int permissionID)
        {
            this.ShowName = showName;
            this.Email = email;
            this.PhoneNumber = phoneNumber;
            this.Address = address;
            this.PermissionID = permissionID;
        }
    }
}
