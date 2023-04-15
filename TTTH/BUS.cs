﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTTH.Models;
using TTTH.Models.DAO;

namespace TTTH
{
    public static class BUS
    {
        /// <summary>
        /// Chứa cac biến toàn cục và cái thiết lập cho dự án.
        /// </summary>
        ///
        
        //------------------------------------------------------------------------
        // PHẦN THIẾT lẬP THÔNG TIN DỰ ÁN
        //------------------------------------------------------------------------
        public static string stringConnect = @"Data Source=TCS\SQLEXPRESS;Initial Catalog=ttth_test;Integrated Security=True";
        // --------------------------ERROR MESSAGE--------------------------------
        public static string wrongPassMessage = "Thông tin tài khoản hoặc mật khẩu không chính xác";

        //------------------------------------------------------------------------
        // CÁC BIẾN TOÀN CỤC
        //------------------------------------------------------------------------
        
        //----------------------------------USER----------------------------------
        public static DTOUser? user;
        
        //------------------------------NOTIFICATION------------------------------
        public static List<ModelNotification> notificatonList = DAONotification.GetAll();
        public static ModelNotification? notification = null;
        public static List<ModelNotification> ReloadNotificatonList()
        {
            return notificatonList = DAONotification.GetAll();
        }
        //------------------------------NOTIFICATION------------------------------
        public static List<ModelCourse> courseList = DAOCourse.GetAll();
        public static ModelCourse? course = null;
        public static List<ModelCourse> ReloadCourse()
        {
            return courseList = DAOCourse.GetAll();
        }
        //------------------------------CLASS------------------------------
        public static List<DTOCLass> classList = DAOClass.GetAll();
        public static DTOCLass? modelClass = null;
        public static List<DTOCLass> ReloadClass() 
        {
            return classList = DAOClass.GetAll();
        }
        //------------------------------ROOM------------------------------
        public static List<DTOroom> roomList = ModelRoom.GetAll();
        public static DTOroom? modelRoom = null;
        public static List<DTOroom> ReloadRoom()
        {
            return roomList = ModelRoom.GetAll();
        }

        //------------------------------STUDENT------------------------------
        public static List<ModelStudent> studentList = DAOStudent.GetAll();
        public static ModelStudent? modelStudent = null;
        public static List<ModelStudent> ReloadStudent()
        {
            return studentList = DAOStudent.GetAll();
        }
    }
}