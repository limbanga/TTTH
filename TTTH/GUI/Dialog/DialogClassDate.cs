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

namespace TTTH.GUI.Dialog
{
    public partial class DialogClassDate : Form
    {
        private DTOClassDate currentClassDate;
        public DialogClassDate(DTOClassDate _classDate)
        {
            InitializeComponent();
            this.currentClassDate = _classDate;
        }
        //---------------------------------------------------------------------------
        // EVENTS
        //---------------------------------------------------------------------------

        private void DialogClassDate_Load(object sender, EventArgs e)
        {
            FillFormData();
            BindingOldData();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            DTOClassDate inputClassDate = new DTOClassDate();
            inputClassDate.Id = this.currentClassDate.Id;
            inputClassDate.RoomID = ((DTOroom) comboBoxRoom.SelectedItem).Id;
            inputClassDate.TeacherID = ((DTOUser)comboBoxTeacher.SelectedItem).Id;
            inputClassDate.Date = dateTimePickerDateHappen.Value;
            inputClassDate.Shift = Convert.ToInt32(comboBoxShift.SelectedItem);
            inputClassDate.IsHappend = checkBoxIsHappen.Checked;

            HandleUpdateClassDate(inputClassDate);
        }

        //---------------------------------------------------------------------------
        // HELPER FUNCTION
        //---------------------------------------------------------------------------
        private void FillFormData()
        {
            FillRoomCombobox();
            FillTeacherCombobox();
        }

        private void FillTeacherCombobox()
        {
            comboBoxTeacher.Items.Clear();
            DTOUser nullTeacher = new DTOUser();
            comboBoxTeacher.Items.Add(nullTeacher);
            List<DTOUser> teacherList = ModelUser.GetAllTeacher();
            foreach (DTOUser teacher in teacherList)
            {
                comboBoxTeacher.Items.Add(teacher);
            }
            comboBoxTeacher.DisplayMember = "ShowName";
            comboBoxTeacher.SelectedIndex = 0;
        }

        private void FillRoomCombobox()
        {
            comboBoxRoom.Items.Clear();
            DTOroom nullRoom = new DTOroom();
            comboBoxRoom.Items.Add(nullRoom);
            List<DTOroom> roomList = ModelRoom.GetAll();
            foreach (DTOroom room in roomList)
            {
                comboBoxRoom.Items.Add(room);
            }
            comboBoxRoom.DisplayMember = "Name";
            comboBoxRoom.SelectedIndex = 0;
        }

        private void BindingOldData()
        {
            BindingOldRoom();
            BindingOldTeacher();
            labelHeader.Text = $"Điều chỉnh thông tin buổi học {currentClassDate.DateNumber} - {currentClassDate.ClassName}";
            dateTimePickerDateHappen.Value = currentClassDate.Date;
            comboBoxShift.SelectedItem = currentClassDate.Shift.ToString();
            checkBoxIsHappen.Checked = currentClassDate.IsHappend;
        }

        void BindingOldTeacher()
        {
            foreach (var item in comboBoxTeacher.Items)
            {
                DTOUser user = (DTOUser)item;
                if (user is not null && user.Id == currentClassDate.TeacherID)
                {
                    comboBoxTeacher.SelectedItem = item;
                    return;
                }
            }
        }
        private void BindingOldRoom()
        {
            foreach (var item in comboBoxRoom.Items)
            {
                DTOroom room = (DTOroom)item;
                if (room is not null && room.Id == currentClassDate.RoomID)
                {
                    comboBoxRoom.SelectedItem = item;
                    return;
                }
            }
        }
        private void HandleUpdateClassDate(DTOClassDate inputClassDate)
        {
            try
            {
                ModelClassDate.Update(inputClassDate);
                MessageBox.Show(
                    "Cập nhật thông tin buổi học thành công.",
                    "Thành công",
                    MessageBoxButtons.OK
                    );
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Xảy ra lỗi.",
                    MessageBoxButtons.OK
                    );
            }
        }
    }
}
