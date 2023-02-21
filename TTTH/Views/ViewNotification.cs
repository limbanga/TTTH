﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TTTH.Models.DAO;
using TTTH.Models;
using TTTH.Args;


namespace TTTH.Views
{
    public partial class ViewNotification : UserControl
    {
        public EventHandler? SwtichToViewNotificationDetail;
        public ViewNotification()
        {
            InitializeComponent();

        }
        //-------------------------------------------------------------------------------
        // VIEWS ENVENTS
        //-------------------------------------------------------------------------------
        private void ViewNotification_Load(object sender, EventArgs e)
        {
            dataGridView.DataSource = Env.ReloadNotificatonList();
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int columnIndex = e.ColumnIndex;
            string columnName = dataGridView.Columns[columnIndex].Name;
            if (columnName.Equals("ViewDetail"))
            {
                // get notìication id
                ModelNotification notification = Env.NotificatonList[e.RowIndex];
                int id = notification.Id;
                // pass id to main form // phát đi sự kiện
                SwtichToViewNotificationDetail?.Invoke(this, new IntArgs(id));

            }
        }

        //-------------------------------------------------------------------------------
        // HELPER FUNCTIONS
        //-------------------------------------------------------------------------------
    }
}
