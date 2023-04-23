using TTTH.Models.DAO;
using TTTH.Models.DTO;

namespace TTTH
{
    public partial class viewStatistic : UserControl
    {
        List<DTOClass> displayList = new List<DTOClass>();
        public viewStatistic()
        {
            InitializeComponent();
        }
        //---------------------------------------------------------------
        // EVENTS
        //---------------------------------------------------------------
        private void buttonFind_Click(object sender, EventArgs e)
        {
            string keyWord = textBoxFind.Text;
            FillByKeyWord(keyWord);
        }

        private void dataGridView_DataSourceChanged(object sender, EventArgs e)
        {
            double sum = 0;
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                sum += ((DTOClass)row.DataBoundItem).Income;
            }
            labelTotal.Text = $"Tổng: {string.Format("{0:0,0}", sum) + " vnd"}";
        }

        private void checkBoxTime_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTime.Checked)
            {
                dataGridView.DataSource = displayList.FindAll(c =>
                c.Start >= dateTimePickerFrom.Value &&
                c.End <= dateTimePickerTo.Value
                );
            }
            else
            {
                dataGridView.DataSource = displayList;
            }
        }

        //---------------------------------------------------------------
        // HELPER FUNCTIONS
        //---------------------------------------------------------------

        public void LoadData2DataGridView()
        {
            displayList = ModelClass.GetAll();
            dataGridView.DataSource = displayList;
        }

        private void FillByKeyWord(string keyWord)
        {
            dataGridView.DataSource = displayList.FindAll(c =>
                (
                    c.CourseName.Contains(keyWord) ||
                    c.Name.Contains(keyWord) ||
                    c.TeacherName.Contains(keyWord)
                ) &&
                (   
                    !checkBoxTime.Checked ||
                    (c.Start >= dateTimePickerFrom.Value &&
                    c.End <= dateTimePickerTo.Value)
                ) 

            );
            dataGridView.Refresh();
        }
    }
}
