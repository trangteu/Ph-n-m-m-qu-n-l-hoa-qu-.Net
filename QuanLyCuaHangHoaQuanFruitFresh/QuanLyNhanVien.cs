using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangHoaQuanFruitFresh
{
    public partial class QuanLyNhanVien : Form
    {
        public QuanLyNhanVien()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-14D46B2\\VUONGDINHTRANG;Initial Catalog=CNPMQLCUAHANGHOAQUAFRUITFRESH;Integrated Security=True");
            try
            {
                conn.Open();
                string a0 = txtMaNhanVien.Text;
                string a1 = txtTenNhanVien.Text;
                string a2 = txtDiaChi.Text;
                string a3 = cbbGioiTinh.Text;
                string a4 = txtSoDienThoai.Text;
                string a5 = txtNamSinh.Text;
                string query = String.Format("insert into NhanVien( MaNhanVien, TenNhanVien, DiaChi, GioiTinh, SDT, NamSinh) " +
                    "values (N'{0}', N'{1}', N'{2}', N'{3}', N'{4}', N'{5}')", a0, a1, a2, a3, a4, a5);
                SqlCommand cmd = new SqlCommand(query, conn);
                int s1 = cmd.ExecuteNonQuery();
                if (s1 == 1)
                {
                    getdata();
                    MessageBox.Show("Thêm Thông Tin Nhân Viên Thành Công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Thêm Thông Tin Nhân Viên Thất Bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void getdata()
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-14D46B2\\VUONGDINHTRANG;Initial Catalog=CNPMQLCUAHANGHOAQUAFRUITFRESH;Integrated Security=True");
            try
            {
                conn.Open();
                string query = "select * from NhanVien";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvQLNhanVien.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void QuanLyNhanVien_Load(object sender, EventArgs e)
        {
            getdata();
            dgvQLNhanVien.Columns[0].HeaderText = "Mã Nhân Viên";
            dgvQLNhanVien.Columns[1].HeaderText = "Tên Nhân Viên";
            dgvQLNhanVien.Columns[2].HeaderText = "Giới Tính";
            dgvQLNhanVien.Columns[3].HeaderText = "Địa Chỉ";
            dgvQLNhanVien.Columns[4].HeaderText = "Năm Sinh";
            dgvQLNhanVien.Columns[5].HeaderText = "Số Điện Thoại";
            dgvQLNhanVien.Columns[0].Width = 200;
            dgvQLNhanVien.Columns[1].Width = 200;
            dgvQLNhanVien.Columns[2].Width = 150;
            dgvQLNhanVien.Columns[3].Width = 220;
            dgvQLNhanVien.Columns[4].Width = 130;
            dgvQLNhanVien.Columns[5].Width = 180;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-14D46B2\\VUONGDINHTRANG;Initial Catalog=CNPMQLCUAHANGHOAQUAFRUITFRESH;Integrated Security=True");
            try
            {
                conn.Open();
                string a0 = txtMaNhanVien.Text;
                string a1 = txtTenNhanVien.Text;
                string a2 = txtDiaChi.Text;
                string a3 = cbbGioiTinh.Text;
                string a4 = txtSoDienThoai.Text;
                string a5 = txtNamSinh.Text;
                if (txtMaNhanVien.Text.Length == 0 || txtTenNhanVien.Text.Length == 0 || txtDiaChi.Text.Length == 0 || cbbGioiTinh.Text.Length == 0 || txtNamSinh.Text.Length == 0|| txtSoDienThoai.Text.Length ==0)
                {
                    MessageBox.Show("Bạn phải nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMaNhanVien.Focus();
                    txtTenNhanVien.Focus();
                    txtDiaChi.Focus();
                    cbbGioiTinh.Focus();
                    txtSoDienThoai.Focus();
                    txtNamSinh.Focus();
                    return;
                }
                string query = String.Format("update NhanVien set TenNhanVien = N'{1}', DiaChi = N'{2}', GioiTinh = N'{3}', SDT = N'{4}', NamSinh = N'{5}' where MaNhanVien = N'{0}'", a0, a1, a2, a3, a4, a5);
                SqlCommand cmd = new SqlCommand(query, conn);
                int s1 = cmd.ExecuteNonQuery();
                if (s1 == 1)
                {
                    getdata();
                    MessageBox.Show("Cập nhật thông tin nhân viên thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                    MessageBox.Show("Cập nhật thông tin nhân viên thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-14D46B2\\VUONGDINHTRANG;Initial Catalog=CNPMQLCUAHANGHOAQUAFRUITFRESH;Integrated Security=True");
            try
            {
                conn.Open();

                string query = String.Format("delete NhanVien where MaNhanVien = '" + txtMaNhanVien.Text + "'");
                SqlCommand cmd = new SqlCommand(query, conn);
                int s1 = cmd.ExecuteNonQuery();
                if (s1 == 1)
                {
                    getdata();
                    MessageBox.Show("Xoa Thông Tin Nhân Viên Thành Công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                    MessageBox.Show("Xóa Thông Tin Nhân Viên Thất Bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-14D46B2\\VUONGDINHTRANG;Initial Catalog=CNPMQLCUAHANGHOAQUAFRUITFRESH;Integrated Security=True");
            try
            {
                conn.Open();
                string query = "select * from NhanVien where TenNhanVien like N'%" + txtTenNhanVien.Text + "%'";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvQLNhanVien.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            
        }

        private void dgvQLNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //Lưu lại dòng dữ liệu vừa kích chọn
                DataGridViewRow row = this.dgvQLNhanVien.Rows[e.RowIndex];
                //Đưa dữ liệu vào textbox
                txtMaNhanVien.Text = row.Cells[0].Value.ToString();
                txtTenNhanVien.Text = row.Cells[1].Value.ToString();
                txtDiaChi.Text = row.Cells[2].Value.ToString();
                cbbGioiTinh.Text = row.Cells[3].Value.ToString();
                txtNamSinh.Text = row.Cells[4].Value.ToString();
                txtSoDienThoai.Text = row.Cells[5].Value.ToString();

            }
            //txtMaKhachHang.Enabled = false;
        }

        private void btnHienThi_Click_1(object sender, EventArgs e)
        {
            getdata();
            dgvQLNhanVien.Columns[0].HeaderText = "Mã Nhân Viên";
            dgvQLNhanVien.Columns[1].HeaderText = "Tên Nhân Viên";
            dgvQLNhanVien.Columns[2].HeaderText = "Giới Tính";
            dgvQLNhanVien.Columns[3].HeaderText = "Địa Chỉ";
            dgvQLNhanVien.Columns[4].HeaderText = "Năm Sinh";
            dgvQLNhanVien.Columns[5].HeaderText = "Số Điện Thoại";
            dgvQLNhanVien.Columns[0].Width = 200;
            dgvQLNhanVien.Columns[1].Width = 200;
            dgvQLNhanVien.Columns[2].Width = 150;
            dgvQLNhanVien.Columns[3].Width = 220;
            dgvQLNhanVien.Columns[4].Width = 130;
            dgvQLNhanVien.Columns[5].Width = 180;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            GiaoDienChinh gdc = new GiaoDienChinh();
            gdc.Show();
            this.Hide();
        }
    }
}
