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
    public partial class DialogScore : Form
    {
        private DTOCLass modelClass;
        List<ModelScore> displayData = new List<ModelScore>();
        public DialogScore(DTOCLass _modelClass)
        {
            InitializeComponent();
            this.modelClass = _modelClass;
        }

        //------------------------------------------------------
        // FORM EVENTS
        //------------------------------------------------------

        private void DialogScore_Load(object sender, EventArgs e)
        {
            int lastExam = DAOScore.GetLastExamNumber(modelClass.Id);
            if (lastExam <= 0)
            {
                DialogResult r = MessageBox.Show(
                    "Lớp học hiện tại chưa có bài kiểm tra nào. Bạn có muốn tạo mới một bài kiểm tra?",
                    "Chưa có bài kiểm tra nào được tạo.",
                    MessageBoxButtons.OKCancel
                    );
                if (r == DialogResult.Cancel) { this.Close(); }
                // else
                // make new exam
                int classID = modelClass.Id;
                int newLastExamNumber = DAOScore.MakeNewExam(classID);
            }

            bindDataForExamNumberComboBox();
            LoadData2Datagridview();
        }

        private void bindDataForExamNumberComboBox()
        {
            int lastExamNumber = DAOScore.GetLastExamNumber(modelClass.Id);
            // bind data to combobox
            for (int i = 1; i <= lastExamNumber; i++)
            {
                comboBoxExamNumber.Items.Add(i);
            }
            comboBoxExamNumber.SelectedItem = lastExamNumber;
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInputScore()) { return; }
            HandleSaveScore();
        }

        private bool ValidateInputScore()
        {
            // -------------------------------------------------------------------------------------------
            // check input

            return true;
        }
        private void comboBoxExamNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData2Datagridview();
        }

        private void buttonAddNewExam_Click(object sender, EventArgs e)
        {
            // make new exam
            int classID = modelClass.Id;
            int newLastExamNumber = DAOScore.MakeNewExam(classID);
            // reload form
            comboBoxExamNumber.Items.Add(newLastExamNumber);
            comboBoxExamNumber.SelectedItem = newLastExamNumber;
            LoadData2Datagridview();
        }


        //------------------------------------------------------
        // HELPER FUNCTIONS
        //------------------------------------------------------

        private void LoadData2Datagridview()
        {
            int examNumber = Convert.ToInt32(comboBoxExamNumber.SelectedItem);
            displayData = DAOScore.GetAll(modelClass.Id, examNumber);
            if (displayData.Count <= 0) 
            {
                // displayData = 
            }
            dataGridView.DataSource = displayData;
        }


        private void HandleSaveScore()
        {
            int examNumber = (int)comboBoxExamNumber.SelectedItem;
            int classID = modelClass.Id;
            // save all student in datagridview
            foreach (ModelScore score in displayData)
            {
                int studentID = score.ModelStudent.Id;
                double s = score.Score;
                try
                {
                    DAOScore.UpdateScore(examNumber, classID, studentID, s);
                }
                catch (Exception)
                {
                    MessageBox.Show(
                        "Đã xảy ra lỗi. Không thể cập nhật!",
                        "Vui lòng thử lại.",
                        MessageBoxButtons.OK);
                    return;
                }
            }
            MessageBox.Show("Cập nhật thông tin thành công!", "Lưu thành công", MessageBoxButtons.OK);
            LoadData2Datagridview();
        }
        
    }
}
