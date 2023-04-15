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
    public partial class DialogRegister2Class : Form
    {
        private List<ModelStudent> displayStudentList = new List<ModelStudent>();
        private List<ModelStudent> changedStudentList = new List<ModelStudent>();
        public DialogRegister2Class()
        {
            InitializeComponent();
            ReloadData();
        }
        //-----------------------------------------------------------------
        // EVENTS
        //-----------------------------------------------------------------
        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) { return; }

            int columnIndex = e.ColumnIndex;
            // changed display
            bool isChecked = (bool) dataGridView.Rows[e.RowIndex].Cells[3].Value;
            dataGridView.Rows[e.RowIndex].Cells[3].Value = !isChecked;

            // get selected student
            ModelStudent st = displayStudentList[e.RowIndex];
            st.IsInClass = !isChecked;

            // add to handle list
            // remove old value before add
            changedStudentList.RemoveAll(s => s.Id == st.Id); 
            changedStudentList.Add(st);
        }

        private void checkBoxShowInClass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowInClass.Checked) 
            {
                ShowAllStudent();
            }
            else
            {
                ReloadData();   
            }

        }


        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (BUS.modelClass is null)
            {
                MessageBox.Show("Thông tin lớp học bạn chọn đã bị thay đổi. Vui lòng thử lại sau!", "Đã xảy ra lỗi", MessageBoxButtons.OK);
                this.Close();
                return;
            }

            foreach (ModelStudent st in changedStudentList)
            {
                if (st.IsInClass)
                {
                    try
                    {
                        DAORegister.RegisterToClass(st.Id, BUS.modelClass.Id);
                    }
                    catch (Exception)
                    {
                    }
                }
                else
                {
                    try
                    {
                        DAORegister.UnRegisterFromClass(st.Id, BUS.modelClass.Id);
                    }
                    catch (Exception)
                    {
                    }
                }
            }

            this.Close();
        }

        //-----------------------------------------------------------------
        // HELPER FUNCTTIONS
        //-----------------------------------------------------------------

        private void ReloadData()
        {
            if (BUS.modelClass is null) { return; }
            displayStudentList = DAOStudent.GetStudentsNotInClass(BUS.modelClass.Id);
            dataGridView.DataSource = displayStudentList;
        }

        private void ShowAllStudent()
        {
            if (BUS.modelClass is null) { return; }
            displayStudentList = DAOStudent.GetAllStudentsAndCheckIfInClass(BUS.modelClass.Id);
            dataGridView.DataSource = displayStudentList;
        }

    }
}
