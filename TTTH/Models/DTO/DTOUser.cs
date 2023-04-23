using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTTH.Models.DTO
{
    public class DTOUser : DTOEntity
    {
        private string loginName = "-";
        private string showName = "-";
        private string email = "-";
        private string phoneNumber = "-";
        private string address = "-";
        private int permissionID = -1;
        private string passWord = "-";

        public string ShowName { get => showName; set => showName = value; }
        public string Email { get => email; set => email = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Address { get => address; set => address = value; }
        public int PermissionID { get => permissionID; set => permissionID = value; }
        public string Role { 
            get
            {
                if (permissionID == 1)
                {
                    return "ADMIN";
                }
                return "Teacher";
            }
        }
        public string LoginName { get => loginName; set => loginName = value; }
        public string PassWord { get => passWord; set => passWord = value; }

        public DTOUser() { }

        public DTOUser(int id, string loginName, string showName, string email, string phoneNumber, string address, int permissionID)
        {
            Id = id;
            ShowName = showName;
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;
            PermissionID = permissionID;
            LoginName = loginName;
        }
    }
}
