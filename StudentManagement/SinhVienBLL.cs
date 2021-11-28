using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement
{
    internal class SinhVienBLL
    {
        private SinhVienDAL dalSV;

        public SinhVienBLL()
        {
            dalSV = new SinhVienDAL();
        }

        public DataTable getAllSinhVien()
        {
            return dalSV.getAllSinhVien();
        }

        public bool InsertSinhVien(tblSinhVien tblSv)
        {
            return dalSV.InsertSinhVien(tblSv);
        }

        public bool UpdateSinhVien(tblSinhVien tblSv)
        {
            return dalSV.UpdateSinhVien(tblSv);
        }

        public bool DeleteSinhVien(tblSinhVien tblSv)
        {
            return dalSV.DeleteSinhVien(tblSv);
        }
    }
}