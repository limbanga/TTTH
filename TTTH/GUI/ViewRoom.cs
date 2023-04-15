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
using TTTH.Views.Dialog;

namespace TTTH.Views
{
    public partial class ViewRoom : UserControl
    {
        public ViewRoom()
        {
            InitializeComponent();
        }

        //--------------------------------------------------
        // EVENTS
        //--------------------------------------------------
        private void ViewRoom_Load(object sender, EventArgs e)
        {
            dataGridView.DataSource = BUS.roomList;
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            // open form handle add event
            DialogRoom addForm = new DialogRoom(true);
            addForm.ShowDialog();

            // update data after add
            ReLoadData();
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // click header row
            if (e.RowIndex < 0) { return; }

            int columnIndex = e.ColumnIndex;
            string columnName = dataGridView.Columns[columnIndex].Name;
            // get clicked room
            BUS.modelRoom = BUS.roomList[e.RowIndex];
            if (columnName.Equals("UpdateButton"))
            {
                // get course
                // create new form to update
                DialogRoom updateForm = new DialogRoom(false); // update -> forAdd = false 
                updateForm.ShowDialog();
                // reload data after change
                ReLoadData();
            }
            else if (columnName.Equals("DeleteButton"))
            {
                int roomID = BUS.modelRoom.Id;
                string msg = "Bạn có chắc chắn muốn xóa phòng này không?";

                if (ModelRoom.CheckRoomBeforeDelete(roomID))
                {
                    msg = "Thông tin của phòng đang được sử dụng bởi các lớp học. Bạn có chắc chắn muốn xóa phòng này không?";
                }

                DialogResult r = MessageBox.Show(
                    msg,
                    "Xác nhận xóa.",
                    MessageBoxButtons.OKCancel);

                if (r != DialogResult.OK) { return; }
                HandleDeleteRoom(roomID);
                ReLoadData();
            }
        }

        private void HandleDeleteRoom(int roomID)
        {
            try
            {
                ModelRoom.Delete(roomID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Xảy ra lỗi.",
                    MessageBoxButtons.OK);
            }
        }


        //--------------------------------------------------
        // HELPER FUNCTIIONS
        //--------------------------------------------------

        public void ReLoadData()
        {
            dataGridView.DataSource = BUS.ReloadRoom();
        }


    }
}
