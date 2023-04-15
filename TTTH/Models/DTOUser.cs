using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTTH.Models
{
    public class DTOUser : ModelEntity
    {
        private string loginName = "-";
        private string showName = "-";
        private string email = "-";
        private string phoneNumber = "-";
        private string address = "-";
        private int permissionID = -1;

        public string ShowName { get => showName; set => showName = value; }
        public string Email { get => email; set => email = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Address { get => address; set => address = value; }
        public int PermissionID { get => permissionID; set => permissionID = value; }
        public string LoginName { get => loginName; set => loginName = value; }

        public DTOUser() { }

        public DTOUser(int id, string loginName, string showName, string email, string phoneNumber, string address, int permissionID)
        {
            this.Id = id;
            this.ShowName = showName;
            this.Email = email;
            this.PhoneNumber = phoneNumber;
            this.Address = address;
            this.PermissionID = permissionID;
            this.LoginName = loginName;
        }

        public DTOUser(int id, string showName)
        {
            this.Id = id;
            this.ShowName = showName;
        }
    }
}
