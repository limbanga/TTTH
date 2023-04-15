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
    public partial class DialogClass : Form
    {
        private ModelCourse? course;
        private DTOCLass? modelClass;

        List<DTOroom> roomList = new List<DTOroom>();

        public DialogClass(ModelCourse? _course, DTOCLass? _modelClass)
        {
            InitializeComponent();
            course = _course;
            modelClass = _modelClass;
        }
        //---------------------------------------------------------------------------
        // EVENTS
        //---------------------------------------------------------------------------
        private void DialogOpenNewClass_Load(object sender, EventArgs e)
        {
            CloseIfCourseNull();
            BindOldData();
            FillFormData();
        }

        private void FillFormData()
        {
            BindComboboxRoom();
            BindComboboxTeacher();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {

            // if (!ValidateInput()) { return; }

            List<Int32> datesWeek = GetDatesInWeek();
            if (datesWeek.Count <= 0)
            {
                MessageBox.Show(
                    "Bạn phải những ngày học trong tuần.",
                    "Vui lòng kiểm tra lại",
                    MessageBoxButtons.OK);
                return;
            }

            // get input
            DTOCLass inputClass = GetInput();

            if (modelClass is null) // add new
            {
                HandleAddNewClass(inputClass, datesWeek);
            }
            else
            {
                HandleUpdateClass(inputClass);
            }
        }

        private void HandleUpdateClass(DTOCLass inputClass)
        {
            MessageBox.Show("chua lam update class");
        }



        private void HandleAddNewClass(DTOCLass inputClass, List<Int32> dates)
        {
            try
            {
                DAOClass.Insert(inputClass, dates);
                MessageBox.Show(
                    "Tạo lớp thành công.",
                    "Thành công.", 
                    MessageBoxButtons.OK);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "Không thể tạo lớp.",
                    MessageBoxButtons.OK);
            }
        }

        //---------------------------------------------------------------------------
        // HELPER FUNCTION
        //---------------------------------------------------------------------------
        private void BindOldData()
        {
            if (modelClass is not null) // update
            {
                labelHeader.Text = $"Cập nhật thông tin lớp {modelClass.Name}";
                textBoxName.Text = modelClass.Name;
                textBoxLimitStudent.Text = modelClass.MaxCapacity.ToString();
                comboBoxShift.SelectedItem = modelClass.Shift;
                dateTimePickerStart.Value = modelClass.Start;
                foreach (int d in modelClass.ListDatesInWeek)
                {
                    if (d == 1)
                    {
                        checkBox7.Checked = true;
                    }
                    else if (d == 2)
                    {
                        checkBox1.Checked = true;
                    }
                    else if(d == 3)
                    {
                        checkBox2.Checked = true;
                    }
                    else if(d == 4)
                    {
                        checkBox3.Checked = true;
                    }
                    else if (d == 5)
                    {
                        checkBox4.Checked = true;
                    }
                    else if (d == 6)
                    {
                        checkBox5.Checked = true;
                    }
                    else if (d == 7)
                    {
                        checkBox6.Checked = true;
                    }
                }
                checkHasBegined(modelClass);
            }
            else // add
            {
                labelHeader.Text = $"Mở lớp cho khóa học {course?.Name}";
            }
        }

        private void checkHasBegined(DTOCLass modelClass)
        {
            if (modelClass.Start < DateTime.Now)
            {
                MessageBox.Show(
                    "Lớp học này đã bắt đầu. Bạn sẽ không thể chỉnh sửa một số thông tin.",
                    "Thông báo!",
                    MessageBoxButtons.OK);
                groupBoxDatesInWeek.Enabled = false;
                textBoxLimitStudent.Enabled = false;
                dateTimePickerStart.Enabled = false;
                comboBoxShift.Enabled = false;
            }
        }

        private DTOCLass GetInput()
        {
            // classID = -1 -> add new
            int classID = modelClass is null? -1: modelClass.Id;
            int courseID = course is null? -1: course.Id;
            int roomID = ((DTOroom) comboBoxRoom.SelectedItem).Id;
            int teacherID = ((DTOUser) comboBoxTeacher.SelectedItem).Id;

            string name = textBoxName.Text;
            int maxCapacity = Convert.ToInt32(textBoxLimitStudent.Text);
            int shift = Convert.ToInt32(comboBoxShift.SelectedItem);
            DateTime start = dateTimePickerStart.Value;

            return new DTOCLass(classID, name, start, maxCapacity, shift, courseID, roomID, teacherID);
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
        private void BindComboboxRoom()
        {
            roomList = BUS.ReloadRoom();
            DTOroom nullRoom = new DTOroom();
            comboBoxRoom.Items.Add(nullRoom);

            foreach (DTOroom room in roomList )
            {
                comboBoxRoom.Items.Add(room);
            }

            comboBoxRoom.DisplayMember = "Name";
            comboBoxRoom.ValueMember = "Id";
            comboBoxRoom.SelectedIndex = 0;
        }

        private void BindComboboxTeacher()
        {
            List<DTOUser> teacherList = ModelUser.GetAllTeacher();
            DTOUser nullUser = new DTOUser();
            comboBoxTeacher.Items.Add(nullUser);

            foreach (DTOUser teacher in teacherList)
            {
                comboBoxTeacher.Items.Add(teacher);
            }

            comboBoxTeacher.DisplayMember = "ShowName";
            comboBoxTeacher.ValueMember = "Id";
            comboBoxTeacher.SelectedIndex = 0;
        }
        private bool ValidateInput()
        {
            const string cap = "Vui lòng kiểm tra lại";

            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show(
                    "Không thể để trống tên lớp học.",
                    cap,
                    MessageBoxButtons.OK);
                return false;
            }


            if (string.IsNullOrEmpty(textBoxLimitStudent.Text))
            {
                MessageBox.Show(
                    "Không thể để trống giới hạn học viên.",
                    cap,
                    MessageBoxButtons.OK);
                return false;
            }


            if (!(Validator.isInteger(textBoxLimitStudent.Text) && Convert.ToInt32(textBoxLimitStudent.Text) > 0))
            {
                MessageBox.Show(
                    "Giới hạn học viên phải là số nguyên dương.",
                    cap,
                    MessageBoxButtons.OK);
                return false;
            }

            return true;
        }

        private List<int> GetDatesInWeek()
        {
            List<int> list = new List<int>();
            foreach (CheckBox checkBox in flowLayoutPanel.Controls.OfType<CheckBox>())
            {
                if (checkBox.Checked)
                {
                    if (checkBox.Text.Equals("cn"))
                    {
                        list.Add(1);
                    }
                    else
                    {
                        int temp = Convert.ToInt32(checkBox.Text);
                        list.Add(temp);
                    }
                }
            }
            return list;
        }
    }
}
