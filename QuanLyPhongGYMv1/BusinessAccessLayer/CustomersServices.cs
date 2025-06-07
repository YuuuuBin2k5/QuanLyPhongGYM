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
    public class CustomersService
    {
        private readonly DAL dal = new DAL();
        public CustomersService()
        {
        }

        public DataSet LayKhachHang()
        {
            return dal.ExecuteQueryDataSet("spLayTatCaKhachHang_Gym", CommandType.StoredProcedure,null);
        }

        // Hàm lấy danh sách khách hàng với tên gói tập từ View
        public DataTable LayTatCaKhachHangWithPackage()
        {
            // Truy vấn dữ liệu từ View 'vwCustomerWithPackage'
            string query = "SELECT * FROM vwCustomerWithPackage";

            // Gọi phương thức ExecuteQueryDataSet của DAL để lấy dữ liệu
            DataSet ds = dal.ExecuteQueryDataSet(query, CommandType.Text);

            // Trả về bảng dữ liệu đầu tiên trong DataSet nếu có
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return new DataTable(); // Trả về DataTable rỗng nếu không có dữ liệu
            }
        }
        public bool ThemKhachHang(ref string err, string FullName, string PhoneNumber, DateTime StartDate, int? MembershipID)
        {
            return dal.MyExecuteNonQuery("spThemKhachHang_Gym", CommandType.StoredProcedure, ref err,
                new SqlParameter("@FullName", FullName),
                new SqlParameter("@PhoneNumber", PhoneNumber),
                new SqlParameter("@StartDate", StartDate),
                new SqlParameter("@MembershipID", (object)MembershipID ?? DBNull.Value));
        }

        public bool CapNhatKhachHang(ref string err, int CustomerID, string FullName, string PhoneNumber, DateTime StartDate, int? MembershipID)
        {
            return dal.MyExecuteNonQuery("spCapNhatKhachHang_Gym", CommandType.StoredProcedure, ref err,
                new SqlParameter("@CustomerID", CustomerID),
                new SqlParameter("@FullName", FullName),
                new SqlParameter("@PhoneNumber", PhoneNumber),
                new SqlParameter("@StartDate", StartDate),
                new SqlParameter("@MembershipID", (object)MembershipID ?? DBNull.Value));
        }

        public bool XoaKhachHang(ref string err, string fullName, string phoneNumber)
        {
            return dal.MyExecuteNonQuery("spXoaKhachHang_Gym",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@FullName", fullName),
                new SqlParameter("@PhoneNumber", phoneNumber));
        }

        public DataSet LayKhachHangTheoSoDienThoai(string phoneNumber)
        {
            return dal.ExecuteQueryDataSet("spLayKhachHangTheoSoDienThoai", CommandType.StoredProcedure,
                new SqlParameter("@PhoneNumber", phoneNumber));
        }

        public string LaySoDienThoaiTheoCustomerID(int customerId)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@CustomerID", customerId)
            };

            DataSet ds = dal.ExecuteQueryDataSet("spLaySoDienThoaiTheoCustomerID", CommandType.StoredProcedure, parameters);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0]["PhoneNumber"].ToString();
            }

            return null;
        }

        //Lấy mã khách hàng theo mã hóa đơn
        public int LayMaKhachHangTheoMaHoaDon(int invoiceId)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@InvoiceID", invoiceId)
            };

            DataSet ds = dal.ExecuteQueryDataSet("spLayKhachHangTheoMaHoaDon", CommandType.StoredProcedure, parameters);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return Convert.ToInt32(ds.Tables[0].Rows[0]["CustomerID"]);
            }

            return -1; // Trả về -1 nếu không tìm thấy
        }
    }
}
