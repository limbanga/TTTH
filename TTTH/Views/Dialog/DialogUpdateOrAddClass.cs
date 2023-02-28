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
    public partial class DialogUpdateOrAddClass : Form
    {
        private ModelCourse? course;
        private ModelClass? modelClass;

        public DialogUpdateOrAddClass(ModelCourse? _course, ModelClass? _modelClass)
        {
            course = _course;
            modelClass = _modelClass;
            InitializeComponent();
        }
        //---------------------------------------------------------------------------
        // EVENTS
        //---------------------------------------------------------------------------
        private void DialogOpenNewClass_Load(object sender, EventArgs e)
        {
            CloseIfCourseNull();
            BindData();
            BindData2Room();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            int rid = ((ModelRoom)comboBoxRoom.SelectedItem).Id;
            MessageBox.Show("room id = " + rid);


            bool isSuccess = false;
            // ValidateInput();
            // get input
            ModelClass inputClass = GetInput();
            if (modelClass is null) // add new
            {
                isSuccess = DAOClass.Insert(inputClass);
            }
            else
            {

            }

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
        private void BindData()
        {
            if (modelClass is not null) // update
            {
                labelHeader.Text = $"Cập nhật thông tin lớp {modelClass.Name}";
                textBoxName.Text = modelClass.Name;
                textBoxLimitStudent.Text = modelClass.MaxCapacity.ToString();
                comboBoxShift.SelectedItem = modelClass.Shift;
                comboBoxRoom.SelectedItem = modelClass.RoomName;
                dateTimePickerEnd.Value = modelClass.End;
                dateTimePickerStart.Value = modelClass.Start;
            }
            else // add
            {
               
                labelHeader.Text = $"Mở lớp cho khóa học {course.Name}";
            }
        }
        private ModelClass GetInput()
        {

            int courseId = course is null? -1: course.Id;
            string name = textBoxName.Text;
            int maxCapacity = Convert.ToInt32(textBoxLimitStudent.Text);
            int shift = Convert.ToInt32(comboBoxShift.SelectedItem);
            int roomId = ((ModelRoom) comboBoxRoom.SelectedItem).Id;  
            DateTime start = dateTimePickerStart.Value;
            DateTime end = dateTimePickerEnd.Value;

            return new ModelClass(name, start, end, maxCapacity, shift, courseId, roomId);
        }
        private void CloseIfCourseNull()
        {
            /*
                XỬ LÝ TRƯỜNG HỌC MỞ LỚP MÀ KHÔNG DỰA VÀO KHÓA HỌC NÀO
             */
            // class is null -> tạo mới lớp
            // nhưng lớp tạo mới phải từ course => course is not null
            // mà course mà null nghĩa là không tạo mới dc
            if (modelClass is null && course is null) 
            {
                MessageBox.Show(
                     "Khoá học bạn chọn không tồn tại hoặc đã bị xóa. Vui lòng thử lại sau.",
                     "Không tìm thấy khóa học",
                     MessageBoxButtons.OK
                     );
                this.Close();
                return;
            }
        }
        private void BindData2Room()
        {
            comboBoxRoom.DataSource = Env.ReloadRoom();
            comboBoxRoom.DisplayMember = "Name";
        }
    }
}
