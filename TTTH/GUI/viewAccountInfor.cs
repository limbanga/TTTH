using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TTTH.GUI.Dialog;
using TTTH.Models.DAO;
using TTTH.Models.DTO;
using TTTH.Views.Dialog;

namespace TTTH
{
    public partial class viewAccountInfor : UserControl
    {
        List<DTOUser> displayList = new List<DTOUser>();

        public viewAccountInfor()
        {
            InitializeComponent();
        }

        //------------------------------------------------
        // EVENTS
        //------------------------------------------------
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            DialogTeacher dialogTeacher = new DialogTeacher();
            dialogTeacher.ShowDialog();
            LoadData2DataGridView();
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) { return; }

            int columnIndex = e.ColumnIndex;
            string columnName = dataGridView.Columns[columnIndex].Name;

            DTOUser selectedUser = (DTOUser) dataGridView.Rows[e.RowIndex].DataBoundItem;
            if (columnName.Equals("DeleteButton"))
            {
                DialogResult r = MessageBox.Show(
                    $"Bạn có muốn xóa tài khoản của giảng viên {selectedUser.ShowName} không?",
                    "Xác nhận xóa.",
                    MessageBoxButtons.YesNo);
                if (r != DialogResult.Yes) { return; }

                HandleDeleteTeacher(selectedUser.Id);
                LoadData2DataGridView();

            }
            else if (columnName.Equals("UpdateButton"))
            {
                DialogTeacher dialogTeacher = new DialogTeacher(selectedUser);
                dialogTeacher.ShowDialog();
                LoadData2DataGridView();
            }
        }

        private void HandleDeleteTeacher(int id)
        {
            try
            {
                ModelUser.Delete(id);
                MessageBox.Show(
                    "Xóa tài khoản giảng viên thành công.",
                    "Xóa thành công.",
                    MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Đã có lỗi xảy ra.",
                    MessageBoxButtons.OK);
            }
        }

        //------------------------------------------------
        // HELP FUNCTIONS
        //------------------------------------------------

        public void LoadData2DataGridView()
        {
            displayList = ModelUser.GetAllAccount();
            dataGridView.DataSource = displayList;
        }
    }
}
