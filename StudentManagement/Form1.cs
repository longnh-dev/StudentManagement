using System;
using System.Data;
using System.Windows.Forms;

namespace StudentManagement
{
    public partial class Form1 : Form
    {
        private SinhVienBLL bllSV;

        public Form1()
        {
            InitializeComponent();
            bllSV = new SinhVienBLL();
        }

        public void ShowAllSinhVien()
        {
            DataTable dt = bllSV.getAllSinhVien();
            dataGridView1.DataSource = dt;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ShowAllSinhVien();
        }

        public bool CheckData()
        {
            if (string.IsNullOrEmpty(txtMaSV.Text))
            {
                MessageBox.Show("Bạn chưa nhập Mã sinh viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaSV.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtTenSV.Text))
            {
                MessageBox.Show("Bạn chưa nhập Tên sinh viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenSV.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtLop.Text))
            {
                MessageBox.Show("Bạn chưa nhập Lớp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtLop.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtDiaChi.Text))
            {
                MessageBox.Show("Bạn chưa nhập Địa chỉ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiaChi.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtDiem.Text))
            {
                MessageBox.Show("Bạn chưa nhập Điểm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiem.Focus();
                return false;
            }
            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                tblSinhVien sv = new tblSinhVien();
                sv.MaSV = txtMaSV.Text;
                sv.TenSV = txtTenSV.Text;
                sv.Lop = txtLop.Text;
                sv.DiaChi = txtDiaChi.Text;
                sv.Diem = double.Parse(txtDiem.Text);

                if (bllSV.InsertSinhVien(sv))
                    ShowAllSinhVien();
                else
                    MessageBox.Show("Đã có lỗi xảy ra, vui lòng thử lại sau", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private int ID;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                ID = Int32.Parse(dataGridView1.Rows[index].Cells["Id"].Value.ToString());
                txtMaSV.Text = dataGridView1.Rows[index].Cells["MaSV"].Value.ToString();
                txtTenSV.Text = dataGridView1.Rows[index].Cells["TenSV"].Value.ToString();
                txtLop.Text = dataGridView1.Rows[index].Cells["Lop"].Value.ToString();
                txtDiaChi.Text = dataGridView1.Rows[index].Cells["DiaChi"].Value.ToString();
                txtDiem.Text = dataGridView1.Rows[index].Cells["Diem"].Value.ToString();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                tblSinhVien sv = new tblSinhVien();
                sv.Id = ID;
                sv.MaSV = txtMaSV.Text;
                sv.TenSV = txtTenSV.Text;
                sv.Lop = txtLop.Text;
                sv.DiaChi = txtDiaChi.Text;
                sv.Diem = double.Parse(txtDiem.Text);

                if (bllSV.UpdateSinhVien(sv))
                    ShowAllSinhVien();
                else
                    MessageBox.Show("Đã có lỗi xảy ra, vui lòng thử lại sau", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa hay không ?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                tblSinhVien sv = new tblSinhVien();
                sv.Id = ID;
                if (bllSV.DeleteSinhVien(sv))
                    ShowAllSinhVien();
                else
                    MessageBox.Show("Đã có lỗi xảy ra, vui lòng thử lại sau", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
    }
}