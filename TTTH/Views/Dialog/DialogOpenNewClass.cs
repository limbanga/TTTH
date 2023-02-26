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


namespace TTTH.Views.Dialog
{
    public partial class DialogOpenNewClass : Form
    {
        private ModelCourse? course;
        private ModelClass? _modelClass;

        public DialogOpenNewClass(ModelCourse? _course)
        {
            course = _course;
            InitializeComponent();
        }

        //---------------------------------------------------------------------------
        // EVENTS
        //---------------------------------------------------------------------------
        private void DialogOpenNewClass_Load(object sender, EventArgs e)
        {
            SetLabelHeader();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            // get input
            GetInput();
            if (_modelClass is null) { return; }
            bool isSuccess = DAOClass.Insert(_modelClass);
            if (isSuccess)
            {
                MessageBox.Show("Tạo lớp thành công.", "Thêm thành công.", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Đã xảy ra lỗi. Không thể tạo lớp.", "Đã xảy ra lỗi.", MessageBoxButtons.OK);
            }

        }

        //---------------------------------------------------------------------------
        // HELPER FUNCTION
        //---------------------------------------------------------------------------
        private void SetLabelHeader()
        {
            labelHeader.Text = "Thêm lớp học mới";
            if (course is not null)
            {
                labelHeader.Text = $"Mở lớp cho khóa học {course.Name}";
            }
        }
        private void GetInput()
        {
            if (course is null) { return; }
            int courseId = course.Id;
            string name = textBoxName.Text;
            int maxCapacity = Convert.ToInt32(textBoxLimitStudent.Text);
            int shift = Convert.ToInt32(comboBoxShift.SelectedItem);
            int roomId = -1; // ty lam--------------------------------------------------------------------------------------
            DateTime start = dateTimePickerStart.Value;
            DateTime end = dateTimePickerEnd.Value;

            _modelClass = new ModelClass(name, start, end, maxCapacity, shift, courseId, roomId);
        }
    }
}
