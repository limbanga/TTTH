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
    public partial class DialogRoom : Form
    {
        private bool forAdd = true;
        // forAdd = true -> add form
        // forAdd = false -> update form
        public DialogRoom(bool _forAdd)
        {
            InitializeComponent();
            this.forAdd = _forAdd;
        }
        //-----------------------------------------------------------------------
        // EVENTS
        //-----------------------------------------------------------------------
        private void DialogUpdateOrAddRoom_Load(object sender, EventArgs e)
        {
            BindData();
        }



        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) { return; }
            DTOroom inputRoom = GetInput();

            if (forAdd)
            {
                AddRoom(inputRoom);
            }
            else
            {
                UpdateRoom(inputRoom);
            }

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            // close form
            this.Close();
        }
        //-----------------------------------------------------------------------
        // HELPER FUNCTIONS
        //-----------------------------------------------------------------------
        private bool ValidateInput()
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Tên phòng không được bỏ trống.", "Vui lòng nhập lại", MessageBoxButtons.OK);
                return false;
            }

            if (string.IsNullOrEmpty(textBoxCapacity.Text))
            {
                MessageBox.Show("Sức chứa không được bỏ trống.", "Vui lòng nhập lại", MessageBoxButtons.OK);
                return false;
            }

            if (string.IsNullOrEmpty(textBoxType.Text))
            {
                MessageBox.Show("Loại phòng không được bỏ trống.", "Vui lòng nhập lại", MessageBoxButtons.OK);
                return false;
            }

            return true;
        }

        private void BindData()
        {
            // binding old data
            if (forAdd || BUS.modelRoom is null) { return; }
            textBoxName.Text = BUS.modelRoom.Name;
            textBoxType.Text = BUS.modelRoom.Type;
            textBoxCapacity.Text = BUS.modelRoom.Capacity.ToString();
        }

        private DTOroom GetInput()
        {
            int id = (forAdd || BUS.modelRoom is null)? -1 : BUS.modelRoom.Id;
            string name = textBoxName.Text;
            string type = textBoxType.Text;
            int capacity = Convert.ToInt32(textBoxCapacity.Text);

            return new DTOroom(id, name, type, capacity);
        }

        private void AddRoom(DTOroom inputRoom)
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

        private void UpdateRoom(DTOroom inputRoom)
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
