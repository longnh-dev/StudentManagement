using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement
{
    public class tblSinhVien
    {
        public int Id { get; set; }
        public string MaSV { get; set; }
        public string TenSV { get; set; }
        public string Lop { get; set; }
        public string DiaChi { get; set; }
        public double Diem { get; set; }
    }
}