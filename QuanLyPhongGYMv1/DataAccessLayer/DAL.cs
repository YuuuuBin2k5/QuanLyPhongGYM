using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.VariantTypes;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DataAccessLayer
{
    public class DAL
    {
        protected readonly string ConnStr = "Data Source=YUUUUUBIN;Initial Catalog=QuanLyPhongGymV1;Integrated Security=True";
        protected readonly SqlConnection conn;
        protected readonly SqlCommand comm;
        protected readonly SqlDataAdapter da;
        

        public DAL()
        {
            conn = new SqlConnection(ConnStr);
            comm = new SqlCommand();
        }

        // Các phương thức thực thi SQL trong lớp DAL
        //ExecuteQueryDataSet cho phép bạn lấy dữ liệu dạng bảng (SELECT).
        //MyExecuteNonQuery dùng cho các thao tác thay đổi(INSERT/UPDATE/DELETE).
        //ExecuteScalar dùng khi bạn cần một giá trị đơn(đếm, tổng, ID).

        // Khai bao ham thuc thi tang ket noi
        public DataSet ExecuteQueryDataSet(string strSQL, CommandType ct, params SqlParameter[] p)
        {
            DataSet ds = new DataSet();

            using (SqlConnection conn = new SqlConnection(ConnStr))  // Khởi tạo kết nối
            using (SqlCommand cmd = new SqlCommand(strSQL, conn))   // Tạo SqlCommand với kết nối conn
            {
                cmd.CommandType = ct;

                // Gán tham số nếu có
                if (p != null && p.Length > 0)
                    cmd.Parameters.AddRange(p);

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))  // Dùng SqlDataAdapter để điền dữ liệu
                {
                    conn.Open();  // Mở kết nối
                    da.Fill(ds);  // Điền dữ liệu vào DataSet
                }
            }

            return ds;
        }

        // Action Query = Insert | Delete | Update | Stored Procedure
        public bool MyExecuteNonQuery(string strSQL, CommandType ct, ref string error, params SqlParameter[] param)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnStr))
                using (SqlCommand cmd = new SqlCommand(strSQL, conn))
                {
                    cmd.CommandType = ct;

                    if (param != null && param.Length > 0)
                        cmd.Parameters.AddRange(param);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
            
        }

        // Thực thi và trả về giá trị đầu tiên (thường dùng cho COUNT, SUM...)
        public object ExecuteScalar(string cmdText, CommandType cmdType, params SqlParameter[] parameters)
        {
            using (SqlCommand cmd = new SqlCommand(cmdText, conn))
            {
                cmd.CommandType = cmdType;
                if (parameters != null && parameters.Length > 0)
                    cmd.Parameters.AddRange(parameters);

                if (conn.State != ConnectionState.Open)
                    conn.Open();

                object result = cmd.ExecuteScalar();
                conn.Close();
                return result;
            }
        }

    }
}
