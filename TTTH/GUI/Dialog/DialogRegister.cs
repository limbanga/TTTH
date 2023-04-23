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
    public partial class DialogRegister : Form
    {
        private DTOClass currentClass;
        private List<DTOStudent> displayStudentList = new List<DTOStudent>();
        public DialogRegister(DTOClass currentClass)
        {
            InitializeComponent();
            this.currentClass = currentClass;
        }
        //-----------------------------------------------------------------
        // EVENTS
        //-----------------------------------------------------------------
        private void DialogRegister_Load(object sender, EventArgs e)
        {
            LoadData();
            labelHeader.Text = $"Ghi danh lớp {currentClass.Name}";
        }

        private void checkBoxShowInClass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowInClass.Checked)
            {
                dataGridView.DataSource = displayStudentList.FindAll(st => st.IsInClass);
            }
            else
            {
                dataGridView.DataSource = displayStudentList;
            }
        }


        private void buttonSave_Click(object sender, EventArgs e)
        {
            int classID = currentClass.Id;
            HandleRegister(classID);
        }

        //-----------------------------------------------------------------
        // HELPER FUNCTTIONS
        //-----------------------------------------------------------------
        
        private void LoadData()
        {
            displayStudentList = ModelStudent.GetStudentsToRegister(currentClass.Id);
            dataGridView.DataSource = displayStudentList;
        }

        private void HandleRegister(int classID)
        {
            string errorMsg = "";
            foreach (DTOStudent student in displayStudentList)
            {
                try
                {
                    if (student.IsInClass)
                    {
                        ModelRegister.RegisterToClass(student.Id, classID);
                    }
                    else
                    {
                        ModelRegister.UnRegisterFromClass(student.Id, classID);
                    }
                }
                catch (Exception ex)
                {
                    errorMsg += ex;
                }
            }

            if (string.IsNullOrEmpty(errorMsg))
            {
                MessageBox.Show(
                    "Lưu thành công!",
                    "Lưu thành công.",
                    MessageBoxButtons.OK
                    );
                this.Close();
            }
            else
            {
                MessageBox.Show(
                    "Không thể lưu thông tin của những học viên dưới đây:" + errorMsg,
                    "Đã xảy ra lỗi.",
                    MessageBoxButtons.OK
                    );
            }
        }
    }
}
