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
    public partial class DialogScore : Form
    {
        List<DTOScore> displayData = new List<DTOScore>();
        private DTOClassDate dTOClassDate;
        public DialogScore(DTOClassDate dTOClassDate)
        {
            InitializeComponent();  
            this.dTOClassDate = dTOClassDate;
        }

        //------------------------------------------------------
        // EVENTS
        //------------------------------------------------------

        private void DialogScore_Load(object sender, EventArgs e)
        {
            int classID = dTOClassDate.ClassID;
            int lastExamNumber = ModelScore.GetLastExamNumber(classID);
            if (lastExamNumber <= 0)
            {
                DialogResult r = MessageBox.Show(
                    "Lớp học hiện tại chưa có bài kiểm tra nào. Bạn có muốn tạo mới một bài kiểm tra?",
                    "Chưa có bài kiểm tra nào được tạo.",
                    MessageBoxButtons.OKCancel
                    );
                if (r == DialogResult.Cancel) { this.Close(); }
                // else
                
                try
                {
                    lastExamNumber = ModelScore.MakeNewExam(classID);
                }
                catch (Exception)
                {
                    MessageBox.Show(
                        "Đã có lỗi xảy ra. Không thể tạo bài kiểm tra",
                        "Xảy ra lỗi",
                        MessageBoxButtons.OK);
                    this.Close();
                }
            }

            bindDataForExamNumberComboBox(lastExamNumber);
            LoadData2Datagridview();
        }


        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInputScore()) { return; }
            HandleSaveScore();
        }

        private void comboBoxExamNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData2Datagridview();
        }

        private void buttonAddNewExam_Click(object sender, EventArgs e)
        {
            // make new exam
            int classID = dTOClassDate.ClassID;
            int newLastExamNumber = ModelScore.MakeNewExam(classID);
            // reload form
            comboBoxExamNumber.Items.Add(newLastExamNumber);
            comboBoxExamNumber.SelectedItem = newLastExamNumber;
            LoadData2Datagridview();
        }

        //------------------------------------------------------
        // HELPER FUNCTIONS
        //------------------------------------------------------
        private void bindDataForExamNumberComboBox(int numberExam)
        {
            // bind data to combobox
            for (int i = 1; i <= numberExam; i++)
            {
                comboBoxExamNumber.Items.Add(i);
            }
            comboBoxExamNumber.SelectedItem = numberExam;
        }

        private void LoadData2Datagridview()
        {
            int examNumber = Convert.ToInt32(comboBoxExamNumber.SelectedItem);
            displayData = ModelScore.GetScoreByClassID(dTOClassDate.ClassID, examNumber);
            dataGridView.DataSource = displayData;
        }

        private void HandleSaveScore()
        {
            int examNumber = (int) comboBoxExamNumber.SelectedItem;
            int classID = dTOClassDate.ClassID;
            // save all student in datagridview
            foreach (DTOScore score in displayData)
            {
                int studentID = score.DTOStudent.Id;
                double s = score.Score;
                try
                {
                    ModelScore.UpdateScore(examNumber, classID, studentID, s);
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
            MessageBox.Show(
                "Cập nhật thông tin thành công!",
                "Lưu thành công",
                MessageBoxButtons.OK);
            this.Close();
        }

        private bool ValidateInputScore()
        {
            int maxScore = 10;
            int minScore = 0;
            foreach (DTOScore score in displayData)
            {
                double s = score.Score;
                if (s < minScore || s > maxScore)
                {
                    string studentName = score.StudentName;
                    MessageBox.Show(
                        $"Điểm của học sinh {studentName} không hợp lệ.",
                        "Vui lòng kiểm tra lại.",
                        MessageBoxButtons.OK);
                    return false;
                }
            }

            return true;
        }
    }
}
