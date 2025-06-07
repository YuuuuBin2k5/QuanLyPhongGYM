using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;


namespace BussinessAccessLayer
{
    public class ScheduleServices
    {
        private DAL dal = new DAL();

        // 1. Lấy lịch tập của một khách hàng trong một tuần qua Stored Procedure
        public DataTable LayLichTapTheoTuan(int customerId, DateTime mondayOfWeek, DateTime sundayOfWeek)
        {
            var ds = dal.ExecuteQueryDataSet(
                "spLayLichTapTheoTuan",
                CommandType.StoredProcedure,
                new SqlParameter("@CustomerID", customerId),
                new SqlParameter("@Monday", mondayOfWeek.Date),
                new SqlParameter("@Sunday", sundayOfWeek.Date)
            );

            return (ds != null && ds.Tables.Count > 0)
                ? ds.Tables[0]
                : new DataTable();
        }

        // 2. Thêm lịch tập (dùng SP spAddWorkoutSchedule)
        public bool ThemLichTap(int customerId, int trainerId, DateTime trainingDate, ref string loi)
        {
            const string spName = "spThemWorkoutSchedule";
            return dal.MyExecuteNonQuery(
                spName,
                CommandType.StoredProcedure,
                ref loi,
                new SqlParameter("@CustomerID", customerId),
                new SqlParameter("@TrainerID", trainerId),
                new SqlParameter("@TrainingDate", trainingDate)
            );
        }

        // 3. Xóa lịch tập theo ScheduleID (dùng SP spDeleteWorkoutSchedule)
        public bool XoaLichTap(int scheduleId, ref string loi)
        {
            const string spName = "spXoaWorkoutSchedule";
            return dal.MyExecuteNonQuery(
                spName,
                CommandType.StoredProcedure,
                ref loi,
                new SqlParameter("@ScheduleID", scheduleId)
            );
        }

        // 4. Lấy chi tiết lịch tập theo ScheduleID qua Stored Procedure
        public DataTable LayLichTapTheoID(int scheduleId)
        {
            const string spName = "spLayWorkoutSchedule";
            var ds = dal.ExecuteQueryDataSet(
                spName,
                CommandType.StoredProcedure,
                new SqlParameter("@ScheduleID", scheduleId)
            );
            return (ds != null && ds.Tables.Count > 0) ? ds.Tables[0] : new DataTable();
        }
    }
}
