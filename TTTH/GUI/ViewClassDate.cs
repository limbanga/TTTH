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
using TTTH.Views.Dialog;

namespace TTTH.Views
{
    public partial class ViewClassDate : UserControl
    {
        public EventHandler? SwtichToViewClassDetail;
        private DTOClassDate dTOClassDate = new DTOClassDate();
        List<DTOStudent>  displayData = new List<DTOStudent>();
        public ViewClassDate()
        {
            InitializeComponent();
        }
        //--------------------------------------------------------------------
        //  ENVENTS
        //--------------------------------------------------------------------

        private void ButtonTakeAttention_Click(object sender, EventArgs e)
        {
            // mở form điểm danh
            DialogAttendend dialogAttendend = new DialogAttendend(dTOClassDate);
            dialogAttendend.ShowDialog();
            //reload data
            ReloadData();
        }

        private void ButtonEnterScore_Click(object sender, EventArgs e)
        {
            DialogScore dialogScore = new DialogScore(dTOClassDate);
            dialogScore.ShowDialog();
            //reload data
            ReloadData();
        }

        private void ButtonBack_Click(object sender, EventArgs e)
        {
            // public to main form
            SwtichToViewClassDetail?.Invoke(sender, new EventArgs());
        }

        //--------------------------------------------------------------------
        //  HELPER FUNCTIONS
        //--------------------------------------------------------------------

        public void ReloadData()
        {
            if (BUS.currentClassDate is null) { return; }
            displayData = ModelStudent.GetStudentsInClass(BUS.currentClassDate.ClassID);
            dataGridView.DataSource = displayData;
        }

        public void BindClassDateData(DTOClassDate cd)
        {
            this.dTOClassDate = cd;

            #region Set label
            labelClassName.Text = $"Lớp '{cd.ClassName}' - Buổi '{cd.DateNumber}'";
            labelShift.Text = $"Ca: {cd.Shift}";
            labelTeacher.Text = $"Giảng viên: {cd.TeacherName}";
            labelDate.Text = $"{BUS.ConvertWeekDateNumberToWeekDate((int)cd.Date.DayOfWeek)}" +
                $" - {cd.Date.ToString("dd/MM/yyyy")}";
            #endregion

            ReloadData();
        }
    }
}
