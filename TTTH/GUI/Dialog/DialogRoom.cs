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
    public partial class DialogRoom : Form
    {
        private DTOroom? oldRoom;

        public DialogRoom()
        {
            InitializeComponent();
        }
        public DialogRoom(DTOroom? currentRoom)
        {
            InitializeComponent();
            this.oldRoom = currentRoom;
        }
        //-----------------------------------------------------------------------
        // EVENTS
        //-----------------------------------------------------------------------
        private void DialogUpdateOrAddRoom_Load(object sender, EventArgs e)
        {
            BindOldData();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) { return; }
            DTOroom inputRoom = GetInput();

            if (oldRoom is null)
            {
                HandleAddRoom(inputRoom);
            }
            else
            {
                HandleUpdateRoom(inputRoom);
            }

        }

        //-----------------------------------------------------------------------
        // HELPER FUNCTIONS
        //-----------------------------------------------------------------------
        private bool ValidateInput()
        {
            string cap = "Vui lòng nhập lại";
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show(
                    "Tên phòng không được bỏ trống.",
                    cap, 
                    MessageBoxButtons.OK);
                return false;
            }

            if (string.IsNullOrEmpty(textBoxCapacity.Text))
            {
                MessageBox.Show(
                    "Sức chứa không được bỏ trống.",
                    cap, 
                    MessageBoxButtons.OK);
                return false;
            }

            if (Validator.IsInteger(textBoxCapacity.Text) == false)
            {
                MessageBox.Show(
                    "Sức chứa phải là số nguyên.",
                    cap, 
                    MessageBoxButtons.OK);
                return false;
            }

            if (Convert.ToInt32(textBoxCapacity.Text) <= 0)
            {
                MessageBox.Show(
                    "Sức chứa phải lớn hơn 0.",
                    cap,
                    MessageBoxButtons.OK);
                return false;
            }

            return true;
        }

        private void BindOldData()
        {
            if (oldRoom is null) { return; }
            // binding old data
            labelHeader.Text = "Cập nhật thông tin phòng học";
            this.Text = "Cập nhật thông tin phòng học";
            textBoxName.Text = oldRoom.Name;
            textBoxType.Text = oldRoom.Type;
            textBoxCapacity.Text = oldRoom.Capacity.ToString();
        }

        private DTOroom GetInput()
        {
            DTOroom inputRoom = new DTOroom();
            inputRoom.Id = BUS.currentRoom is null? -1 : BUS.currentRoom.Id;
            inputRoom.Name = textBoxName.Text;
            inputRoom.Type = textBoxType.Text;
            inputRoom.Capacity = Convert.ToInt32(textBoxCapacity.Text);

            return inputRoom;
        }

        private void HandleAddRoom(DTOroom inputRoom)
        {
            try
            {
                ModelRoom.Insert(inputRoom);
                MessageBox.Show(
                    "Thêm mới phòng thành công.",
                    "Thêm thành công",
                    MessageBoxButtons.OK);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Đã có lỗi xảy ra!",
                    MessageBoxButtons.OK
                    );
            }
        }

        private void HandleUpdateRoom(DTOroom inputRoom)
        {
            try
            {
                ModelRoom.Update(inputRoom);
                MessageBox.Show(
                    "Cập nhật thông tin phòng thành công.",
                    "Lưu thành công.",
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
