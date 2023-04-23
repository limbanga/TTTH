using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TTTH.Models.DTO;

namespace TTTH.GUI.Dialog
{
    public partial class DialogUserInformation : Form
    {
        DTOUser user;
        public DialogUserInformation(DTOUser user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void DialogUserInformation_Load(object sender, EventArgs e)
        {
            BindOldData();
        }

        private void BindOldData()
        {
            textBoxLoginName.Text = user.LoginName;
            textBoxShowName.Text = user.ShowName;
            textBoxPhoneNumber.Text = user.PhoneNumber;
            textBoxEmail.Text = user.Email;
            textBoxAdress.Text = user.Address;
        }
    }
}
