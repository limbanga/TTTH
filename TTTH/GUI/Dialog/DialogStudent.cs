using TTTH.Models.DAO;
using TTTH.Models.DTO;

namespace TTTH.Views.Dialog
{
    public partial class DialogStudent : Form
    {
        private DTOStudent? oldStudent;
        public DialogStudent()
        {
            InitializeComponent();
        }

        public DialogStudent(DTOStudent student)
        {
            InitializeComponent();
            oldStudent = student;
        }

        //-----------------------------------------------------------------------
        // ENVENTS 
        //-----------------------------------------------------------------------

        private void DialogUpdateOrAddStudent_Load(object sender, EventArgs e)
        {
            BindOldData();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            // validate
            if (!CheckValidInput()) { return; }
            // get input
            DTOStudent inputStudent = getInput();

            // query
            if (oldStudent is null)
            {
                HandleAddStudent(inputStudent);
            }
            else
            {
                HandleUpdateStudent(inputStudent);
            }
        }

        //-----------------------------------------------------------------------
        // HELPER FUNCTIONS
        //-----------------------------------------------------------------------

        private void BindOldData()
        {
            if (oldStudent is null) { return; }
            labelHeader.Text = "Cập nhật thông tin học viên";
            this.Text = "Cập nhật thông tin học viên";

            textBoxName.Text = oldStudent.Name;
            textBoxPhoneNumber.Text = oldStudent.PhoneNumber;
        }

        private bool CheckValidInput()
        {
            string cap = "Vui lòng kiểm tra lại.";

            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show(
                    "Tên học viên không thể để trống.",
                    cap,
                    MessageBoxButtons.OK);
                return false;
            }

            if (string.IsNullOrEmpty(textBoxPhoneNumber.Text))
            {
                MessageBox.Show(
                    "Số điện thoại không thể để trống.",
                    cap,
                    MessageBoxButtons.OK);
                return false;
            }

            return true;
        }
        private DTOStudent getInput()
        {
            DTOStudent st = new DTOStudent();
            st.Id = oldStudent is null ? -1 : oldStudent.Id;
            st.Name = textBoxName.Text;
            st.PhoneNumber = textBoxPhoneNumber.Text;

            return st;
        }

        private void HandleAddStudent(DTOStudent inputStudent)
        {
            try
            {
                ModelStudent.Insert(inputStudent);
                MessageBox.Show(
                    "Thêm học viên thành công.",
                    "Thêm thành công.",
                    MessageBoxButtons.OK);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Đã xảy ra lỗi.",
                    MessageBoxButtons.OK);
            }
        }

        private void HandleUpdateStudent(DTOStudent inputStudent)
        {
            try
            {
                ModelStudent.Update(inputStudent);
                MessageBox.Show(
                    "Cập nhật thông tin học viên thành công.",
                    "Lưu thành công.",
                    MessageBoxButtons.OK);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Đã xảy ra lỗi.",
                    MessageBoxButtons.OK);
            }
        }
    }
}
