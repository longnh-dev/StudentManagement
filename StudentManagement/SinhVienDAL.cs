using System;
using System.Data;
using System.Data.SqlClient;

namespace StudentManagement
{
    internal class SinhVienDAL
    {
        private DataConnection dc;
        private SqlDataAdapter da;
        private SqlCommand cmd;

        public SinhVienDAL()
        {
            dc = new DataConnection();
        }

        public bool DeleteSinhVien(tblSinhVien tblSv)
        {
            string query = "DELETE tblSinhVien WHERE Id=@Id";
            SqlConnection conn = dc.getConnect();
            try
            {
                cmd = new SqlCommand(query, conn);
                conn.Open();
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = tblSv.Id;
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public DataTable getAllSinhVien()
        {
            string query = "SELECT * FROM tblSinhVien";
            SqlConnection conn = dc.getConnect();
            da = new SqlDataAdapter(query, conn);
            conn.Open();

            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt;
        }

        public bool InsertSinhVien(tblSinhVien tblSv)
        {
            string sql = "INSERT INTO tblSinhVien(MaSV,TenSV,Lop,DiaChi,Diem) VALUES(@MaSV,@TenSV,@Lop,@DiaChi,@Diem)";
            SqlConnection conn = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, conn);
                conn.Open();
                cmd.Parameters.Add("@MaSV", SqlDbType.NVarChar).Value = tblSv.MaSV;
                cmd.Parameters.Add("@TenSV", SqlDbType.NVarChar).Value = tblSv.TenSV;
                cmd.Parameters.Add("@Lop", SqlDbType.NVarChar).Value = tblSv.Lop;
                cmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = tblSv.DiaChi;
                cmd.Parameters.Add("@Diem", SqlDbType.Float).Value = tblSv.Diem;
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        public bool UpdateSinhVien(tblSinhVien tblSv)
        {
            string query = "UPDATE tblSinhVien SET MaSV=@MaSV, TenSV=@TenSV, Lop=@Lop, DiaChi=@DiaChi, Diem=@Diem WHERE Id=@Id";
            SqlConnection conn = dc.getConnect();
            try
            {
                cmd = new SqlCommand(query, conn);
                conn.Open();
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = tblSv.Id;
                cmd.Parameters.Add("@MaSV", SqlDbType.NChar).Value = tblSv.MaSV;
                cmd.Parameters.Add("@TenSV", SqlDbType.NVarChar).Value = tblSv.TenSV;
                cmd.Parameters.Add("@Lop", SqlDbType.NChar).Value = tblSv.Lop;
                cmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = tblSv.DiaChi;
                cmd.Parameters.Add("@Diem", SqlDbType.Float).Value = tblSv.Diem;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}