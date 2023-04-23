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

namespace TTTH
{
    public partial class CalenderCell : UserControl
    {
        public EventHandler? CellClick;
        private DTOClassDate classDate = new DTOClassDate();
        public CalenderCell()
        {
            InitializeComponent();
            ChangeUI();
        }

        private void ChangeUI()
        {
            if (classDate.Id == -1)
            {
                BackColor = Color.White;
                ForeColor = Color.White;
                labelDateNumber.Text = "";
                labelClass.Text = "";
                labelRoom.Text = "";
            }
            else
            {
                BackColor = Color.Yellow;
                ForeColor = Color.Black;
                labelDateNumber.Text = "Buổi: " + classDate.DateNumber.ToString();
                labelClass.Text = "Lớp: " + classDate.ClassName;
                labelRoom.Text = "Phòng: " + classDate.RoomName;
            }
        }

        public DTOClassDate ClassDate {
            get
            {
                return classDate;
            }
            set
            {
                classDate = value;
                ChangeUI();
            } 
        }

        private void labelClass_Click(object sender, EventArgs e)
        {
            CellClick?.Invoke(this, EventArgs.Empty);
        }
    }
}
