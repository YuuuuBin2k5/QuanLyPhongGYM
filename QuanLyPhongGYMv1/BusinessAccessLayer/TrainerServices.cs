using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;


namespace BussinessAccessLayer
{
    public class TrainerServices 
    {
        private DAL dal = new DAL();

        // 1. Lấy tất cả huấn luyện viên
        public DataTable LayTatCaTrainer()
        {
            const string spName = "spLayAllTrainers";
            DataSet ds = dal.ExecuteQueryDataSet(
                spName,
                CommandType.StoredProcedure
            );
            return (ds != null && ds.Tables.Count > 0)
                ? ds.Tables[0]
                : new DataTable();
        }

        // 2. Thêm huấn luyện viên
        public bool ThemTrainer(string fullName, string phoneNumber, decimal salary, ref string error)
        {
            const string spName = "spThemTrainer";
            return dal.MyExecuteNonQuery(
                spName,
                CommandType.StoredProcedure,
                ref error,
                new SqlParameter("@FullName", fullName),
                new SqlParameter("@PhoneNumber", phoneNumber),
                new SqlParameter("@Salary", salary)
            );
        }

        // 3. Xóa huấn luyện viên theo ID
        public bool XoaTrainer(int trainerId, ref string error)
        {
            const string spName = "spXoaTrainer";
            return dal.MyExecuteNonQuery(
                spName,
                CommandType.StoredProcedure,
                ref error,
                new SqlParameter("@TrainerID", trainerId)
            );
        }

        // 4. Lấy huấn luyện viên theo ID (string input)
        public DataTable LayTrainerTheoID(string trainerId)
        {
            const string spName = "spLayTrainerById";

            if (!int.TryParse(trainerId, out int id))
            {
                // Trường hợp truyền sai định dạng ID (không phải số), trả về bảng rỗng
                return new DataTable();
            }

            DataSet ds = dal.ExecuteQueryDataSet(
                spName,
                CommandType.StoredProcedure,
                new SqlParameter("@TrainerID", id)
            );

            return (ds != null && ds.Tables.Count > 0)
                ? ds.Tables[0]
                : new DataTable();
        }


        // 5. Lấy huấn luyện viên theo số điện thoại
        public DataTable LayTrainerTheoSDT(string phoneNumber)
        {
            const string spName = "spLayTrainerByPhoneNumber";
            DataSet ds = dal.ExecuteQueryDataSet(
                spName,
                CommandType.StoredProcedure,
                new SqlParameter("@PhoneNumber", phoneNumber)
            );
            return (ds != null && ds.Tables.Count > 0)
                ? ds.Tables[0]
                : new DataTable();
        }

        // 6. Cập nhật thông tin huấn luyện viên
        public bool CapNhatTrainer(int trainerId, string fullName, string phoneNumber, decimal salary, ref string error)
        {
            const string spName = "spCapNhatTrainer";
            return dal.MyExecuteNonQuery(
                spName,
                CommandType.StoredProcedure,
                ref error,
                new SqlParameter("@TrainerID", trainerId),
                new SqlParameter("@FullName", fullName),
                new SqlParameter("@PhoneNumber", phoneNumber),
                new SqlParameter("@Salary", salary)
            );
        }
    }
}
