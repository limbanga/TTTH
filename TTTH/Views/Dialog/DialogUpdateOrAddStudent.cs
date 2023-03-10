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
    public partial class DialogUpdateOrAddStudent : Form
    {
        private bool forAdd;
        private int idStudent2Update  = -1;
        // true -> form add otherwise form update
        public DialogUpdateOrAddStudent(bool _forAdd)
        {
            forAdd = _forAdd;
            InitializeComponent();
        }

        //-----------------------------------------------------------------------
        // ENVENTS 
        //-----------------------------------------------------------------------

        private void DialogUpdateOrAddStudent_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            bool isSuccess = false;
            // validate

            // get input
            string name = textBoxName.Text;
            string phoneNumber = textBoxFee.Text;

            // query
            if (forAdd)
            {
                isSuccess = DAOStudent.Insert(name, phoneNumber);
            }
            else
            {
                isSuccess = DAOStudent.Update(idStudent2Update, name, phoneNumber);
            }
            // alert
            if (isSuccess)
            {
                MessageBox.Show("them hoc vien thanh cong");
                this.Close();
            }   
            else
            {
                MessageBox.Show("them hoc vien that bai :(");
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
            if (Env.modelStudent is null) { return; }
            if (forAdd) { return; }

            labelHeader.Text = "Cập nhật sinh viên";

            idStudent2Update = Env.modelStudent.Id;
            textBoxName.Text = Env.modelStudent.Name;
            textBoxFee.Text = Env.modelStudent.PhoneNumber;
        }


    }
}
