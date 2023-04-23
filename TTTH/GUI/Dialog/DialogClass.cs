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

namespace TTTH.Views.Dialog
{
    public partial class DialogClass : Form
    {
        private DTOCourse? course;
        private DTOClass? oldClass;

        List<DTOroom> roomList = new List<DTOroom>();

        public DialogClass(DTOCourse? _course, DTOClass? dTOClass)
        {
            InitializeComponent();
            course = _course;
            this.oldClass = dTOClass;
        }
        //---------------------------------------------------------------------------
        // EVENTS
        //---------------------------------------------------------------------------
        private void DialogOpenNewClass_Load(object sender, EventArgs e)
        {
            FillFormData();
            BindOldData();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {

            if (!ValidateInput()) { return; }

            // get input
            DTOClass inputClass = GetInput();

            if (oldClass is null) // add new
            {
                #region Get date in week
                // lấy lịch học trong tuần
                List<Int32> datesWeek = GetDatesInWeek();
                if (datesWeek.Count <= 0)
                {
                    MessageBox.Show(
                        "Bạn phải những ngày học trong tuần.",
                        "Vui lòng kiểm tra lại",
                        MessageBoxButtons.OK);
                    return;
                }
                #endregion
                HandleAddNewClass(inputClass, datesWeek);
            }
            else
            {
                HandleUpdateClass(inputClass);
            }
        }

        //---------------------------------------------------------------------------
        // HELPER FUNCTION
        //---------------------------------------------------------------------------
        private void FillFormData()
        {
            BindComboboxRoom();
            BindComboboxTeacher();
        }

        private void HandleAddNewClass(DTOClass inputClass, List<Int32> dates)
        {
            try
            {
                ModelClass.Insert(inputClass, dates);
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

        private void BindOldData()
        {
            if (oldClass is not null) // update
            {
                labelHeader.Text = $"Cập nhật thông tin lớp {oldClass.Name}";
                textBoxClassName.Text = oldClass.Name;
                textBoxLimitStudent.Text = oldClass.MaxCapacity.ToString();
                comboBoxShift.SelectedItem = oldClass.Shift.ToString();
                dateTimePickerStart.Value = oldClass.Start;
                BindOldTeacher();
                BindOldRoom();

                dateTimePickerStart.Enabled = false;
                flowLayoutPanelWeekDate.Enabled = false;
            }
            else // add
            {
                labelHeader.Text = $"Mở lớp cho khóa học {course?.Name}";
            }
        }

        private void BindOldRoom()
        {
            if (oldClass is null)
            {
                this.Close();
                return;
            }

            foreach (DTOroom room in comboBoxRoom.Items)
            {
                if (room.Id == oldClass.RoomID)
                {
                    comboBoxRoom.SelectedItem = room;
                    return;
                }
            }
        }

        private void BindOldTeacher()
        {
            if (oldClass is null)
            { 
                this.Close();
                return; 
            }

            foreach (DTOUser teacher in comboBoxTeacher.Items)
            {
                if (teacher.Id == oldClass.TeacherID)
                {
                    comboBoxTeacher.SelectedItem = teacher;
                    return;
                }
            }
        }

        private DTOClass GetInput()
        {
            DTOClass inputClass = new DTOClass();
            // classID = -1 -> add new
            inputClass.Id = oldClass is null? -1: oldClass.Id;
            inputClass.CourseID = course is null? -1: course.Id;
            inputClass.RoomID = ((DTOroom) comboBoxRoom.SelectedItem).Id;
            inputClass.TeacherID = ((DTOUser) comboBoxTeacher.SelectedItem).Id;

            inputClass.Name = textBoxClassName.Text;
            inputClass.MaxCapacity = Convert.ToInt32(textBoxLimitStudent.Text);
            inputClass.Shift = Convert.ToInt32(comboBoxShift.SelectedItem);
            inputClass.Start = dateTimePickerStart.Value;

            return inputClass;
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

            comboBoxRoom.DisplayMember = "Name_Capacity";
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

            if (string.IsNullOrEmpty(textBoxClassName.Text))
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


            if (!(Validator.IsInteger(textBoxLimitStudent.Text) && Convert.ToInt32(textBoxLimitStudent.Text) > 0))
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
            foreach (CheckBox checkBox in flowLayoutPanelWeekDate.Controls.OfType<CheckBox>())
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

        private void HandleUpdateClass(DTOClass inputClass)
        {
            try
            {
                ModelClass.Update(inputClass);
                MessageBox.Show(
                  "Cập nhật thông tin lớp thành công.",
                  "Thành công.",
                  MessageBoxButtons.OK);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Đã xảy ra lỗi.",
                    MessageBoxButtons.OK);
            }
        }
    }
}
