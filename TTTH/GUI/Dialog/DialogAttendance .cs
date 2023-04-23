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
    public partial class DialogAttendend : Form
    {
        private DTOClassDate currentClassDate;
        List<DTOAttendance> displayList = new List<DTOAttendance>();

        public DialogAttendend(DTOClassDate dTOClassDate)
        {
            InitializeComponent();
            this.currentClassDate = dTOClassDate;
        }
        //-------------------------------------------------------------------
        // EVENTS
        //-------------------------------------------------------------------

        private void DialogCheckAttendend_Load(object sender, EventArgs e)
        {
            int classID = currentClassDate.ClassID;
            int dateNumber = currentClassDate.DateNumber;
            LoadDataByDateNumber(classID, dateNumber);

            BindData();
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) { return; }
            FakeRadio(e.RowIndex, e.ColumnIndex);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            HandleAttendance();
        }

        //-------------------------------------------------------------------
        // HELPER FUNCTIONS
        //-------------------------------------------------------------------

        private void LoadDataByDateNumber(int classID, int dateNumber)
        {
            displayList = ModelAttendance.GetAttendanceInClass(classID, dateNumber);
            dataGridView.DataSource = displayList;
        }
        private void BindData()
        {
            labelDate.Text = $"Ngày {currentClassDate.Date.ToString("dd/MM/yyyy")}";
            labelHeader.Text = $"Điểm danh lớp {currentClassDate.ClassName}" +
                $" - Buổi {currentClassDate.DateNumber}";
            labelShift.Text = $"Ca {currentClassDate.Shift}";
        }

        private void HandleAttendance()
        {
            bool isError = false;
            foreach (DTOAttendance attendance in displayList)
            {
                try
                {
                    ModelAttendance.TakeAttendance(
                        currentClassDate.ClassID,
                        attendance.ModelStudent.Id,
                        currentClassDate.DateNumber,
                        attendance.Status);
                }
                catch (Exception)
                {
                    isError = true;
                }
            }

            if (isError)
            {
                MessageBox.Show(
                    "Đã xảy ra lỗi. Xin hãy kiểm tra lại kết quả điểm danh.",
                    "Đã xảy ra lỗi.",
                    MessageBoxButtons.OK
                    );
            }
            else
            {
                MessageBox.Show(
                    "Lưu thông tin điểm danh thành công.",
                    "Lưu thành công.",
                    MessageBoxButtons.OK
                    );
            }
            this.Close();
        }
   
        private void FakeRadio(int rowIndex, int state)
        {
            if (rowIndex < 0 || (state < 2 || state > 4)) { return; }

            dataGridView.Rows[rowIndex].Cells[2].Value = false;
            dataGridView.Rows[rowIndex].Cells[3].Value = false;
            dataGridView.Rows[rowIndex].Cells[4].Value = false;

            dataGridView.Rows[rowIndex].Cells[state].Value = true;
            dataGridView.Refresh();
        }

    }
}
