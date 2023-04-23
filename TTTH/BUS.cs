using TTTH.Models.DAO;
using TTTH.Models.DTO;

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

        //------------------------------------------------------------------------
        // CÁC BIẾN TOÀN CỤC
        //------------------------------------------------------------------------
        
        //----------------------------------USER----------------------------------
        public static DTOUser user = new DTOUser();

        //------------------------------NOTIFICATION------------------------------
        public static List<DTONotification> notificatonList = new List<DTONotification>();
        public static DTONotification? notification = null;
        public static List<DTONotification> ReloadNotificatonList()
        {
            return notificatonList = ModelNotification.GetAll();
        }
        //------------------------------NOTIFICATION------------------------------
        public static List<DTOCourse> courseList = new List<DTOCourse> ();
        public static DTOCourse? course = null;
        public static List<DTOCourse> ReloadCourse()
        {
            return courseList = ModelCourse.GetAll();
        }
        //------------------------------CLASS------------------------------
        public static List<DTOClass> classList = new List<DTOClass>();
        public static DTOClass? currentClass = null;
        public static List<DTOClass> ReloadClass() 
        {
            return classList = ModelClass.GetAll();
        }
        //------------------------------ROOM------------------------------
        public static List<DTOroom> roomList = new List<DTOroom>();
        public static DTOroom? currentRoom = null;
        public static List<DTOroom> ReloadRoom()
        {
            return roomList = ModelRoom.GetAll();
        }

        //------------------------------STUDENT------------------------------
        public static List<DTOStudent> studentList = new List<DTOStudent>();
        public static DTOStudent? modelStudent = null;
        public static List<DTOStudent> ReloadStudent()
        {
            return studentList = ModelStudent.GetAll();
        }

        //------------------------------CLASS DATE------------------------------
        public static DTOClassDate? currentClassDate = null;

        //----------------------------------------------------------------------
        // LIB các hàm dùng chung, ít hàm nên không tách ra
        //----------------------------------------------------------------------
        public static string ConvertWeekDateNumberToWeekDate(int weekDateNumber)
        {
            weekDateNumber = ((weekDateNumber + 1) % 7);
            switch (weekDateNumber)
            {
                case 1:
                    return "Chủ nhật";
                case 2:
                    return "Thứ 2";
                case 3:
                    return "Thứ 3";
                case 4:
                    return "Thứ 4";
                case 5:
                    return "Thứ 5";
                case 6:
                    return "Thứ 6";
                default:
                    return "Thứ 7";
            }
        }
        public static DateTime GetWeekMonday(DateTime dt)
        {
            // nhận vào một ngày
            // trả về ngày thứ 2 gần nhất trước ngày đó (thứ 2 trong tuần đó)
            int m = (int) dt.DayOfWeek;
            int n = (m - 1) % 7;
            return dt.AddDays(-n);
        }
        public static string HashPass(string pass)
        {
            string hashedPass = pass;
            return hashedPass;
        }
    }
}
