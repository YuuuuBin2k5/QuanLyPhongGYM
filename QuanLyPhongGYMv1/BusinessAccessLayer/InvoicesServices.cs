using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Security.Cryptography;


namespace BussinessAccessLayer
{
    public class InvoicesServices 
    {
        private readonly DAL dal = null;

        public InvoicesServices()
        {
            dal = new DAL();
        }

        // 1. Lấy tất cả hóa đơn
        public DataSet LayTatCaHoaDon()
        {
            // Chỉ truyền câu lệnh và kiểu CommandType để tương thích với ExecuteQueryDataSet
            return dal.ExecuteQueryDataSet("spLayTatCaHoaDon", CommandType.StoredProcedure);
        }

        // 2. Lấy hóa đơn theo mã khách hàng
        public DataSet LayHoaDonTheoMaKhachHang(int maKhachHang)
        {
            return dal.ExecuteQueryDataSet("spLayHoaDonTheoMaKhachHang", CommandType.StoredProcedure,
                new SqlParameter("@CustomerID", maKhachHang));
        }

        // 3. Lấy hóa đơn theo số điện thoại
        public DataSet LayHoaDonTheoSoDienThoai(string soDienThoai)
        {
            return dal.ExecuteQueryDataSet("spLayHoaDonTheoSoDienThoai", CommandType.StoredProcedure,
                new SqlParameter("@PhoneNumber", soDienThoai));
        }

        public bool ThemHoaDon(ref string loi, int maKhachHang, string tenKhachHang,string SDT ,decimal tongTien)
        {
            return dal.MyExecuteNonQuery("spThemHoaDon", CommandType.StoredProcedure, ref loi,
                new SqlParameter("@CustomerID", maKhachHang),
                new SqlParameter("@FullName", tenKhachHang),
                new SqlParameter("@PhoneNumber", SDT),
                new SqlParameter("@TotalAmount", tongTien));
        }
        

        // 5. Cập nhật hóa đơn
        public bool CapNhatHoaDon(ref string loi, int maHoaDon, int maKhachHang, decimal tongTien, DateTime invoiceDate)
        {
            return dal.MyExecuteNonQuery("spCapNhatHoaDon", CommandType.StoredProcedure, ref loi,
                new SqlParameter("@InvoiceID", maHoaDon),
                new SqlParameter("@CustomerID", maKhachHang),
                new SqlParameter("@TotalAmount", tongTien),
                new SqlParameter("@InvoiceDate", invoiceDate)); 
        }

        // 6. Xóa hóa đơn theo mã hóa đơn
        public bool XoaHoaDon(ref string loi, int maHoaDon)
        {
            return dal.MyExecuteNonQuery("spXoaHoaDon", CommandType.StoredProcedure, ref loi,
                new SqlParameter("@InvoiceID", maHoaDon));
        }

        // 7. Kiểm tra hóa đơn tồn tại theo mã khách hàng
        public bool KiemTraHoaDonTonTai(int maKhachHang)
        {
            SqlParameter[] thamSo = new SqlParameter[]
            {
                new SqlParameter("@CustomerID", maKhachHang)
            };

            DataSet ds = dal.ExecuteQueryDataSet("spKiemTraHoaDonTonTai", CommandType.StoredProcedure, thamSo);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return Convert.ToBoolean(ds.Tables[0].Rows[0]["IsExist"]);
            }

            return false;
        }

        // 8. Lấy thông tin chi tiết hóa đơn
        public DataSet LayChiTietHoaDon(int maHoaDon)
        {
            return dal.ExecuteQueryDataSet("spLayChiTietHoaDon", CommandType.StoredProcedure,
                new SqlParameter("@InvoiceID", maHoaDon));
        }

        
    }
}
    