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

namespace TTTH.GUI.Dialog
{
    public partial class DialogClassDate : Form
    {
        private DTOClassDate classDate;
        public DialogClassDate(DTOClassDate _classDate)
        {
            InitializeComponent();
            this.classDate = _classDate;
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
            int roomID = ((DTOroom) comboBoxRoom.SelectedItem).Id;
            int teacherID = ((DTOUser)comboBoxTeacher.SelectedItem).Id;
            DateTime date = dateTimePickerDateHappen.Value;
            int shift = Convert.ToInt32(comboBoxShift.SelectedItem);

            DTOClassDate inputClassDate = new DTOClassDate(classDate.Id, roomID, teacherID, date, shift);

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
            dateTimePickerDateHappen.Value = classDate.Date;
            comboBoxShift.SelectedItem = classDate.Shift.ToString();
        }
        void BindingOldTeacher()
        {
            foreach (var item in comboBoxTeacher.Items)
            {
                DTOUser user = (DTOUser)item;
                if (user is not null && user.Id == classDate.TeacherID)
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
                if (room is not null && room.Id == classDate.RoomID)
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
                    "Cập nhật lịch học thành công.",
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
