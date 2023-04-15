using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TTTH.Models;
using TTTH.Models.DAO;
using TTTH.Views.Dialog;

namespace TTTH.Views
{
    public partial class ViewClassDate : UserControl
    {
        private DTOCLass modelClass = new DTOCLass();
        List<ModelStudent>  displayData = new List<ModelStudent>();
        public ViewClassDate()
        {
            InitializeComponent();
        }
        //--------------------------------------------------------------------
        //  ENVENTS
        //--------------------------------------------------------------------

        private void ViewClassDetail_Load(object sender, EventArgs e)
        {
            
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            // open form for user select students in list to add into class
            // mở form cho người dùng chọn những học sinh để thêm vào lớp
            DialogRegister2Class enrollForm = new DialogRegister2Class();
            enrollForm.ShowDialog();
            ReloadData();
        }

        private void buttonTakeAttention_Click(object sender, EventArgs e)
        {
            // mở form điểm danh
            DialogCheckAttendend dialogCheckAttendend = new DialogCheckAttendend(modelClass);
            dialogCheckAttendend.ShowDialog();
            //reload data
            ReloadData();
        }

        private void buttonEnterScore_Click(object sender, EventArgs e)
        {
            DialogScore dialogScore = new DialogScore(modelClass);
            dialogScore.ShowDialog();
            //reload data
            ReloadData();
        }

        //--------------------------------------------------------------------
        //  HELPER FUNCTIONS
        //--------------------------------------------------------------------

        public void ReloadData()
        {
            if (BUS.modelClass is null) { return; }
            displayData = DAOStudent.GetStudentsInClass(BUS.modelClass.Id);
            dataGridView.DataSource = displayData;
        }

        public void SetDataForClass(DTOCLass c)
        {
            this.modelClass = c;

            labelClassName.Text = $"Lớp: { c.Name }";
            labelTeacher.Text = $"Giảng viên: { "-" }";
            labelShift.Text = $"Ca học: { c.Shift }";
            string dateInWeekString = string.Join(",", c.ListDatesInWeek.ToArray());

        }

        private void labelShift_Click(object sender, EventArgs e)
        {

        }
    }
}
