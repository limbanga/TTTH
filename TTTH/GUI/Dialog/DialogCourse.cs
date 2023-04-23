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
    public partial class DialogCourse : Form
    {
        private DTOCourse? oldCourse;

        public DialogCourse(DTOCourse courseInput)
        {
            InitializeComponent();
            // có truyền vào thanh số nghĩa là update ngược lại add
            this.oldCourse = courseInput;
        }
        public DialogCourse()
        {
            InitializeComponent();
        }
        //-----------------------------------------------------------------------
        // ENVENTS 
        //-----------------------------------------------------------------------
        private void FormUpdateOrAddCourse_Load(object sender, EventArgs e)
        {
            BindOldData();
            DisableIfCourseHasBegun();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) { return; }
            DTOCourse inputCourse = GetInput();

            if (oldCourse is null) 
            {
                HandleAddNewCourse(inputCourse);
            }
            else 
            {
                HandleUpdateCourse(inputCourse);
            }
        }

        private void textBoxFee_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && (((TextBox)sender).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

            const int maxLength = 9;
            if (((TextBox)sender).Text.Length >= maxLength)
            {
                e.Handled = true;
            }
        }

        private void textBoxDuration_KeyPress(object sender, KeyPressEventArgs e)
        {
            // accept number only
            if (!char.IsControl(e.KeyChar) &&
                !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //-----------------------------------------------------------------------
        // HELPER FUNCTIONS
        //-----------------------------------------------------------------------
        private void BindOldData()
        {
            if (oldCourse is null) { return; }

            labelHeader.Text = $"Cập nhật khóa học {oldCourse.Name}";
            this.Text = "Cập nhật khóa học";

            textBoxName.Text = oldCourse.Name;
            textBoxDuration.Text = oldCourse.Duration.ToString();
            textBoxFee.Text = oldCourse.Fee.ToString();
        }

        private void DisableIfCourseHasBegun()
        {
            if (oldCourse is null) { return; }
            if (ModelCourse.CheckCourseBegin(oldCourse.Id) == false) { return; }
            // if has already use
            textBoxDuration.Enabled = false;
            textBoxFee.Enabled = false;
        }

        private DTOCourse GetInput()
        {
            DTOCourse course = new DTOCourse();
            course.Id = oldCourse is null? -1: oldCourse.Id;
            course.Name = textBoxName.Text;
            course.Fee = Convert.ToDouble(textBoxFee.Text);
            course.Duration = Convert.ToInt32(textBoxDuration.Text);

            return course;
        }

        // validate and alert to user
        private bool ValidateInput()
        {
            const string caption = "Vui lòng kiểm tra thông tin trường này";

            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show(
                    "Tên khóa học không thể bỏ trống. Vui lòng nhập lại.",
                    caption,
                    MessageBoxButtons.OK);
                return false;
            }

            if (string.IsNullOrEmpty(textBoxFee.Text))
            {
                MessageBox.Show(
                    "Không thể để trống học phí. Vui lòng nhập lại.",
                    caption,
                    MessageBoxButtons.OK);
                return false;
            }

            if (string.IsNullOrEmpty(textBoxDuration.Text))
            {
                MessageBox.Show(
                    "Không thể bỏ trống thời lượng của khóa học. Vui lòng nhập lại.",
                    caption,
                    MessageBoxButtons.OK);
                return false;
            }
            // điều kiện đúng -> học phí là số thực và học phí >= 0
            // -> phủ định điều kiện đúng dc diều kiện sai 
            if (! 
                (Validator.IsDouble(textBoxFee.Text) && 
                 Convert.ToDouble(textBoxFee.Text) >= 0)
               )
            {
                MessageBox.Show(
                    "Học phí phải là một số không âm. Vui lòng nhập lại.",
                    caption,
                    MessageBoxButtons.OK);
                return false;
            }

            if (!
                (Validator.IsInteger(textBoxDuration.Text) &&
                 Convert.ToInt32(textBoxDuration.Text) >= 1)
               )
            {
                MessageBox.Show(
                    "Thời lượng buổi học phải là một số nguyên dương. Vui lòng nhập lại.",
                    caption,
                    MessageBoxButtons.OK);
                return false;
            }

            return true;
        }

        private void HandleUpdateCourse(DTOCourse inputCourse)
        {
            try
            {
                ModelCourse.Update(inputCourse);
                MessageBox.Show(
                    "Cập nhật thông tin khóa học thành công.",
                    "Cập nhập thông tin thành công",
                    MessageBoxButtons.OK);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Không thể cập nhật thông tin khóa học. Vui lòng thử lại.",
                    MessageBoxButtons.OK
                    );
            }
        }
        private void HandleAddNewCourse(DTOCourse inputCourse)
        {
            try
            {
                ModelCourse.Insert(inputCourse);
                MessageBox.Show(
                    "Thêm mới khóa học thành công",
                    "Thêm thành công",
                    MessageBoxButtons.OK);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Không thể thêm mới khóa học. Vui lòng thử lại.",
                    MessageBoxButtons.OK
                    );
            }
        }
    }
}
