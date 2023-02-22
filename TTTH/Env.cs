using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTTH.Models;
using TTTH.Models.DAO;

namespace TTTH
{
    public class Env
    {
        /// <summary>
        /// Chứa cac biến toàn cục và cái thiết lập cho dự án.
        /// </summary>
        ///
        
        //------------------------------------------------------------------------
        // PHẦN THIẾT lẬP THÔNG TIN DỰ ÁN
        //------------------------------------------------------------------------
        public static string stringConnect = @"Data Source=TCS\SQLEXPRESS;Initial Catalog=TTTH;Integrated Security=True";
        // --------------------------ERROR MESSAGE--------------------------------
        public static string wrongPassMessage = "Thông tin tài khoản hoặc mật khẩu không chính xác";

        //------------------------------------------------------------------------
        // CÁC BIẾN TOÀN CỤC
        //------------------------------------------------------------------------
        
        //----------------------------------USER----------------------------------
        public static ModelUser? user;
        
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


    }
}
