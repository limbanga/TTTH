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
using TTTH.Views.Dialog;

namespace TTTH.Views
{
    public partial class ViewStudent : UserControl
    {
        public ViewStudent()
        {
            InitializeComponent();
        }

        //--------------------------------------------------------------
        // EVENTS
        //--------------------------------------------------------------
        private void ViewStudent_Load(object sender, EventArgs e)
        {
            dataGridView.DataSource = BUS.studentList;
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            // open form handle add student
            DialogStudent dialogAdd = new DialogStudent();
            dialogAdd.ShowDialog();
            // reload new data after update
            ReloadData();
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int columnIndex = e.ColumnIndex;
            string columnName = dataGridView.Columns[columnIndex].Name;

            // get student
            DTOStudent selectedStudent = (DTOStudent) dataGridView.Rows[e.RowIndex].DataBoundItem;
            if (columnName.Equals("UpdateButton"))
            {
                // create new form to update
                DialogStudent dialogUpdate = new DialogStudent(selectedStudent);
                dialogUpdate.ShowDialog();
                // reload data after update
                ReloadData();
            }
            else if (columnName.Equals("DeleteButton"))
            {
                int studentID = selectedStudent.Id;
                string msg = $"Bạn có muốn xóa học viên {selectedStudent.Name } và các thông tin liên quan không?";

                if (ModelStudent.CheckStudentJoinAnyClass(studentID))
                {
                    msg = $"Học viên {selectedStudent.Name} đã tham gia lớp học, bạn có muốn xóa học viên và các thông tin liên quan không?";
                }

                DialogResult r = MessageBox.Show(
                    msg,
                    "Xác nhận xóa.",
                    MessageBoxButtons.YesNo
                    );

                if (r != DialogResult.Yes) { return; }

                HandleDeleteStudent(studentID);
                ReloadData();
            }

        }



        //--------------------------------------------------------------
        // HELPER FUNCTIONS
        //--------------------------------------------------------------
        public void ReloadData()
        {
            dataGridView.DataSource = BUS.ReloadStudent();
        }

        private void HandleDeleteStudent(int studentID)
        {
            try
            {
                ModelStudent.Delete(studentID);
                MessageBox.Show(
                    "Xóa học viên thành công",
                    "Xóa thành công.",
                    MessageBoxButtons.OK
                    );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Đã xảy ra lỗi.",
                    MessageBoxButtons.OK
                    );
            }
        }

    }
}
