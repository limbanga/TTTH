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
    public partial class DialogCheckAttendend : Form
    {

        const string IS_PRESENT = "isPresent";
        const string IS_LATE = "isLate";
        const string IS_ABSENCE = "isAbsence";


        private DTOCLass modelClass = new DTOCLass();
        List<RelationShipAttendance> displayData = new List<RelationShipAttendance>();

        public DialogCheckAttendend(DTOCLass _modelClass)
        {
            InitializeComponent();
            this.modelClass = _modelClass;
        }
        //-------------------------------------------------------------------
        // EVENTS
        //-------------------------------------------------------------------

        private void DialogCheckAttendend_Load(object sender, EventArgs e)
        {
            int classID = this.modelClass.Id;
            int nextDate = 1;

            LoadDataByDateNumber(classID, nextDate);
            //for (int i = 0; i < this.modelClass.Course.Duration; i++)
            //{
            //    comboBoxDateNumber.Items.Add(i+1);
            //}
            comboBoxDateNumber.SelectedItem = nextDate;
        }

        private void comboBoxDateNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            int dateNumber  = Convert.ToInt32(comboBoxDateNumber.SelectedItem);
            int classID = this.modelClass.Id;

            LoadDataByDateNumber(classID, dateNumber);
        }
        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            string columnName = dataGridView.Columns[e.ColumnIndex].Name;

            RelationShipAttendance selectedRelationShipAttendance = displayData[e.RowIndex];

            if (columnName.Equals(IS_LATE))
            {
                selectedRelationShipAttendance.Status = 'l';
            }
            else if (columnName.Equals(IS_PRESENT))
            {
                selectedRelationShipAttendance.Status = 'p';
            }
            else if (columnName.Equals(IS_ABSENCE))
            {
                selectedRelationShipAttendance.Status = 'a';
            }

            ReFreshDataGridViewNotQuery();
        }

        private void ReFreshDataGridViewNotQuery()
        {
            displayData = (List<RelationShipAttendance>)dataGridView.DataSource;
            dataGridView.DataSource = new List<RelationShipAttendance>();
            dataGridView.DataSource = displayData;
        }

        //-------------------------------------------------------------------
        // HELPER FUNCTIONS
        //-------------------------------------------------------------------

        private void LoadDataByDateNumber(int classID, int dateNumber)
        {
            displayData = DAOAttendance.GetAttendanceInClass(classID, dateNumber);
            dataGridView.DataSource = displayData;
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            int dateNumber = Convert.ToInt32(comboBoxDateNumber.SelectedItem.ToString());
            string listErrorName = "";

            foreach (RelationShipAttendance r in displayData)
            {
                string studentNameErrors = HandleSave(this.modelClass.Id, r.ModelStudent.Id, dateNumber, r.Status);
                if (!string.IsNullOrEmpty(studentNameErrors))
                {
                    listErrorName += studentNameErrors + "\n";
                }
            }
            if (!string.IsNullOrEmpty(listErrorName))
            {
                MessageBox.Show(
                    $"Không thể cập nhập thông tin những học sinh sau đây: {listErrorName}.",
                    "Vui lòng thử lại.", 
                    MessageBoxButtons.OK);
            }
            else
            {
                this.Close();
            }

        }
        private string HandleSave(int classID, int studentID, int dateNumber,char staus)
        {
            try
            {
                DAOAttendance.TakeAttendance(classID, studentID, dateNumber, staus);
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
