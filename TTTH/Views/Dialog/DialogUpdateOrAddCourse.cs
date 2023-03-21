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
    public partial class DialogUpdateOrAddCourse : Form
    {
        private ModelCourse? modelCourse = null;

        public DialogUpdateOrAddCourse(ModelCourse? courseInput)
        {
            InitializeComponent();
            // có truyền vào thanh số nghĩa là update ngược lại add
            this.modelCourse = courseInput;
        }
        //-----------------------------------------------------------------------
        // ENVENTS 
        //-----------------------------------------------------------------------
        private void FormUpdateOrAddCourse_Load(object sender, EventArgs e)
        {
            BindData();
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            bool isSuccess = false;
            // ValidateInput(); này thư viết nhoa
            ModelCourse inputCourse = GetInput();

            if (modelCourse is null) // add new
            {
                isSuccess = DAOCourse.Insert(inputCourse);
            }
            else // update
            {
                isSuccess = DAOCourse.Update(inputCourse);
            }


            if (isSuccess)
            {
                MessageBox.Show("Cập nhật thành công");
                this.Close();
            }
            else
            {
                MessageBox.Show("Đã có lỗi xảy ra. Không thể cập nhật");
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //-----------------------------------------------------------------------
        // HELPER FUNCTIONS
        //-----------------------------------------------------------------------
        private void BindData()
        {
            if (modelCourse is null) { return; }

            labelHeader.Text = "Cập nhật khóa học";

            textBoxName.Text = modelCourse.Name;
            textBoxDuration.Text = modelCourse.Duration.ToString();
            textBoxFee.Text = modelCourse.Fee.ToString();   
        }
        private ModelCourse GetInput()
        {
            int id = modelCourse is null? -1: modelCourse.Id;
            string name = textBoxName.Text;
            double fee = Convert.ToDouble(textBoxFee.Text);
            int duration = Convert.ToInt32(textBoxDuration.Text);

            return new ModelCourse(id, name, fee, duration);
        }


    }
}
