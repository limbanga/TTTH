using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TTTH.Models.DAO;
using TTTH.Models.DTO;

namespace TTTH.GUI
{
    public partial class viewCalender : UserControl
    {
        public EventHandler? SwtichToViewClassDate;
        DateTime startDate = BUS.GetWeekMonday(DateTime.Now);
        DTOUser teacher = new DTOUser();

        public viewCalender()
        {
            InitializeComponent();
            AsignClickEvent();
            InitWeekDate();
        }
        //-----------------------------------------------------
        // EVENTS
        //-----------------------------------------------------
        private void calenderCells_Click(object? sender, EventArgs e)
        {
            if (sender is not CalenderCell) { return; }
            CalenderCell cell = (CalenderCell)sender;
            BUS.currentClassDate = cell.ClassDate;
            SwtichToViewClassDate?.Invoke(sender, EventArgs.Empty);
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            LoadData(this.StartDate.AddDays(7), this.teacher);
        }
        private void buttonPre_Click(object sender, EventArgs e)
        {
            LoadData(this.StartDate.AddDays(-7), this.teacher);

        }

        private void buttonNow_Click(object sender, EventArgs e)
        {
            LoadData(DateTime.Now, this.teacher);
        }

        //-----------------------------------------------------
        // HELPER FUNCTIONS
        //-----------------------------------------------------

        private void AsignClickEvent()
        {
            foreach (Control c in tableLayoutPanel1.Controls)
            {
                if (c is CalenderCell)
                {
                    CalenderCell calender = (CalenderCell)c;
                    calender.CellClick += calenderCells_Click;
                }
            }
        }

        private void InitWeekDate()
        {
            labelw2.Text = "Thứ 2\n" + StartDate.ToString("dd/MM/yyyy");
            labelw3.Text = "Thứ 3\n" + StartDate.AddDays(1).ToString("dd/MM/yyyy");
            labelw4.Text = "Thứ 4\n" + StartDate.AddDays(2).ToString("dd/MM/yyyy");
            labelw5.Text = "Thứ 5\n" + StartDate.AddDays(3).ToString("dd/MM/yyyy");
            labelw6.Text = "Thứ 6\n" + StartDate.AddDays(4).ToString("dd/MM/yyyy");
            labelw7.Text = "Thứ 7\n" + StartDate.AddDays(5).ToString("dd/MM/yyyy");
            labelw1.Text = "Chủ nhật\n" + StartDate.AddDays(6).ToString("dd/MM/yyyy");

            labelPeriod.Text = $"{StartDate.ToString("dd/MM/yyyy")} - {StartDate.AddDays(6).ToString("dd/MM/yyyy")}";
        }

        public void LoadData(DateTime _startDate, DTOUser teacher)
        {
            this.StartDate = _startDate;
            this.teacher = teacher;
            int teacherID = teacher.Id;

            InitWeekDate();

            for (int i = 0; i < 7; i++)
            {
                DateTime tempDate = this.StartDate.AddDays(i);
                for (int j = 1; j <= 5; j++)
                {
                    CalenderCell cell = (CalenderCell) tableLayoutPanel1.GetControlFromPosition(i+1, j);
                    DTOClassDate cd = ModelClassDate.GetClassDate(tempDate, teacherID, j); 
                    cell.ClassDate = cd;
                    cell.Refresh();
                }
                    
            }
        }
        public DateTime StartDate {
            get
            {
                return this.startDate;
            }
            set {
                this.startDate = BUS.GetWeekMonday(value);
            }
        }
    }
}
