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
    public class MemberShipServices 
    {
        private DAL dal = new DAL();
        // 1. Lấy tất cả các gói tập (MembershipPackages) qua Stored Procedure
        public DataTable LayTatCaGoiTap()
        {
            // Gọi SP spLayTatCaGoiTap, chỉ việc trả về DataTable đầu tiên
            DataSet ds = dal.ExecuteQueryDataSet(
                "spLayTatCaGoiTap",
                CommandType.StoredProcedure
            );

            return (ds != null && ds.Tables.Count > 0)
                ? ds.Tables[0]
                : new DataTable();
        }

        // 2. Lấy MembershipID từ tên gói tập qua Stored Procedure
        public int? LayMembershipIDTheoTenGoi(string packageName)
        {
            // ExecuteScalar trả về object hoặc null nếu không tìm thấy
            object result = dal.ExecuteScalar(
                "spLayMembershipIDTheoTenGoi",
                CommandType.StoredProcedure,
                new SqlParameter("@PackageName", packageName)
            );

            return (result != null)
                ? Convert.ToInt32(result)
                : (int?)null;
        }

        public DataTable layMembershipPackagesFromView()
        {
            return dal.ExecuteQueryDataSet("SELECT * FROM vw_MembershipPackages", CommandType.Text).Tables[0];
        }


    }
}
