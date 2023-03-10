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
    public partial class DialogUpdateOrAddRoom : Form
    {
        private bool forAdd = true;
        // forAdd = true -> add form
        // forAdd = false -> update form
        public DialogUpdateOrAddRoom(bool _forAdd)
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
            ModelRoom inputRoom = GetInput();

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

            //if ("trống tên phòng")
            //{
            //    MessageBox.Show("Tên phòng không được bỏ trống.", "Vui lòng nhập lại", MessageBoxButtons.OK);
            //    return false;
            //}

            return true;
        }

        private void BindData()
        {
            // binding old data
            if (forAdd || Env.modelRoom is null)
            {
                return;
            }
            MessageBox.Show($"Test'{Env.modelRoom.Type}'");
            textBoxName.Text = Env.modelRoom.Name;
            textBoxType.Text = Env.modelRoom.Type;
            textBoxCapacity.Text = Env.modelRoom.Capacity.ToString();
        }

        private ModelRoom GetInput()
        {
            int id = (forAdd || Env.modelRoom is null)? -1 : Env.modelRoom.Id;
            string name = textBoxName.Text;
            string type = textBoxType.Text;
            MessageBox.Show($"ip line 89 '{type}'");
            int capacity = Convert.ToInt32(textBoxCapacity.Text);

            return new ModelRoom(id, name, type, capacity);
        }

        private void AddRoom(ModelRoom inputRoom)
        {
            string errorMsg = "";
            try
            {
                DAORoom.Insert(inputRoom);
            }
            catch (Exception e)
            {
                errorMsg = e.Message;
            }
            finally 
            {
                // error msg null -> have no error
                if (string.IsNullOrEmpty(errorMsg))
                {
                    MessageBox.Show("Theem phong thaanh cong :3.", "Them thanh cong", MessageBoxButtons.OK);
                    // close after add
                    this.Close();
                }
                else
                {
                    MessageBox.Show(errorMsg, "da xay ra loi, khong thẻ them", MessageBoxButtons.OK);
                }
            }
        }

        private void UpdateRoom(ModelRoom inputRoom)
        {
            string errorMsg = "";
            try
            {
                DAORoom.Update(inputRoom);
            }
            catch (Exception e)
            {
                errorMsg = e.Message;
            }
            finally
            {
                // error msg null -> have no error
                if (string.IsNullOrEmpty(errorMsg))
                {
                    MessageBox.Show("Cập nhật thông tin phòng thành công!", "Cập nhật thành công", MessageBoxButtons.OK);
                    // close after add
                    this.Close();
                }
                else
                {
                    MessageBox.Show(errorMsg, "Đã xảy ra lỗi, không thể cập nhật", MessageBoxButtons.OK);
                }
            }
        }
    }
}
