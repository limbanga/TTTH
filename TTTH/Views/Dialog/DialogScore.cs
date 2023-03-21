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
        private ModelClass modelClass;
        List<ModelScore> displayData = new List<ModelScore>();
        public DialogScore(ModelClass _modelClass)
        {
            InitializeComponent();
            this.modelClass = _modelClass;
        }

        //------------------------------------------------------
        // FORM EVENTS
        //------------------------------------------------------

        private void DialogScore_Load(object sender, EventArgs e)
        {
            bindDataForExamNumberComboBox();
            LoadData2Datagridview();
        }

        private void bindDataForExamNumberComboBox()
        {
            int lastExamNumber = DAOScore.GetLastExamNumber(modelClass.Id);
            MessageBox.Show(modelClass.Id+"Test" +lastExamNumber);

            // bind data to combobox
            for (int i = 1; i <= lastExamNumber; i++)
            {
                comboBox1.Items.Add(i);
            }
            comboBox1.SelectedItem = lastExamNumber;
        }


        //------------------------------------------------------
        // HELPER FUNCTIONS
        //------------------------------------------------------

        private void LoadData2Datagridview()
        {
            int examNumber = Convert.ToInt32(comboBox1.SelectedItem);
            displayData = DAOScore.GetAll(modelClass.Id, examNumber);
            dataGridView1.DataSource = displayData;
        }

    }
}
