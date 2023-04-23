using DocumentFormat.OpenXml.Spreadsheet;
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

namespace TTTH.GUI
{
    public partial class ViewClassDetail : UserControl
    {
        public EventHandler? SwtichToViewClassDate;
        public EventHandler? SwtichToViewClass;

        private DTOClass currentClass = new DTOClass();
        private List<DTOClassDate> displayList = new List<DTOClassDate>();
        public ViewClassDetail()
        {
            InitializeComponent();
        }

        //---------------------------------------------------
        // ENVENTS
        //---------------------------------------------------
        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) { return; }

            int columnIndex = e.ColumnIndex;
            string columnName = dataGridView.Columns[columnIndex].Name;

            // get selected class date
            DTOClassDate selectedClassDate = displayList[e.RowIndex];

            if (columnName.Equals("UpdateButton"))
            {
                DialogClassDate dialogUpdate = new DialogClassDate(selectedClassDate);
                dialogUpdate.ShowDialog();
                ReloadDataGridview(currentClass.Id);
            }
            else
            {
                // public envent to main form
                BUS.currentClassDate = selectedClassDate;
                SwtichToViewClassDate?.Invoke(this, new EventArgs());
            }
        }

        private void ButtonBack_Click(object sender, EventArgs e)
        {
            // public event to main form
            SwtichToViewClass?.Invoke(this, new EventArgs());   
        }

        private void buttonExportSchedule_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog()
            {
                InitialDirectory = Application.StartupPath + "\\CSV\\",
                Title = "Save file",
                CheckPathExists = true,
                DefaultExt = "csv",
                Filter = "Text files (*.csv)|*.csv|All files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true
            };

            if (sfd.ShowDialog() != DialogResult.OK) { return; }
            File.WriteAllText(sfd.FileName, GetScheduleContent());
        }

        private void buttonExportAttendance_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog()
            {
                InitialDirectory = Application.StartupPath + "\\CSV\\",
                Title = "Save file",
                CheckPathExists = true,
                DefaultExt = "csv",
                Filter = "Text files (*.csv)|*.csv|All files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true
            };

            if (sfd.ShowDialog() != DialogResult.OK) { return; }
            File.WriteAllText(sfd.FileName, GetAttendanceContent());
        }

        //---------------------------------------------------
        // HELPER FUNCTIONS
        //---------------------------------------------------

        public void LoadDataByClassID(DTOClass dtoclass)
        {
            this.currentClass = dtoclass;
            labelHeader.Text = $"Lịch trình giảng dạy lớp {dtoclass.Name}";

            ReloadDataGridview(dtoclass.Id);
        }

        private void ReloadDataGridview(int classID)
        {
            displayList = ModelClassDate.GetClassDatesByClassID(classID);
            dataGridView.DataSource = displayList;
        }
        private string GetScheduleContent()
        {
            string r = "Buổi,Ngày,Ca,Phòng,Giảng viên,Đã hoàn thành\n";
            string date = "";
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                date = ((DateTime)row.Cells[1].Value).ToString("dd/MM/yyyy");

                r += row.Cells[0].Value.ToString() + "," +
                    date + "," +
                    row.Cells[2].Value.ToString() + "," +
                    row.Cells[3].Value.ToString() + "," +
                    row.Cells[4].Value.ToString() + "," +
                    row.Cells[5].Value.ToString() + "\n"
                    ;
            }
            return r;
        }

        private string GetAttendanceContent()
        {
            int classID = currentClass.Id;
            int duration = dataGridView.RowCount;
            List<DTOStudent> studentList = ModelStudent.GetStudentsInClass(classID);
            string content = "";
            string status = "p";
            foreach (DTOStudent student in studentList)
            {
                content += student.Name + "," + student.PhoneNumber + ",";
                for (int i = 1; i <= duration; i++)
                {
                    status = ModelAttendance.GetStatus(classID, student.Id, i);
                    content += status + ",";
                }
                content += "\n";
            }

            string header = "Họ tên, Số điện thoại,";
            for (int i = 1; i <= duration - 1; i++)
            {
                header += "Buổi " + i + ",";
            }
            header += "Buổi " + duration + "\n";
            return header + content;
        }
    }
}
