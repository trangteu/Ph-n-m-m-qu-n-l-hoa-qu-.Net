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
    public partial class QuanLyKhachHang : Form
    {
        public QuanLyKhachHang()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void getdata()
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-14D46B2\\VUONGDINHTRANG;Initial Catalog=CNPMQLCUAHANGHOAQUAFRUITFRESH;Integrated Security=True");
            try
            {
                conn.Open();
                string query = "select * from KhachHang";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvQLKhachHang.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void QuanLyKhachHang_Load(object sender, EventArgs e)
        {
            getdata();
            dgvQLKhachHang.Columns[0].HeaderText = "Mã Khách Hàng";
            dgvQLKhachHang.Columns[1].HeaderText = "Tên Khách Hàng";
            dgvQLKhachHang.Columns[2].HeaderText = "Địa Chỉ";
            dgvQLKhachHang.Columns[3].HeaderText = "Giới Tính";
            dgvQLKhachHang.Columns[4].HeaderText = "Quê Quán";
            dgvQLKhachHang.Columns[0].Width = 200;
            dgvQLKhachHang.Columns[1].Width = 200;
            dgvQLKhachHang.Columns[2].Width = 150;
            dgvQLKhachHang.Columns[3].Width = 150;
            dgvQLKhachHang.Columns[4].Width = 180;
        }

        private void dgvQLKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //Lưu lại dòng dữ liệu vừa kích chọn
                DataGridViewRow row = this.dgvQLKhachHang.Rows[e.RowIndex];
                //Đưa dữ liệu vào textbox
                txtMaKhachHang.Text = row.Cells[0].Value.ToString();
                txtTenKhachHang.Text = row.Cells[1].Value.ToString();
                txtDiaChi.Text = row.Cells[2].Value.ToString();
                cbbGioiTinh.Text = row.Cells[3].Value.ToString();
                txtSoDienThoai.Text = row.Cells[4].Value.ToString();

            }
            //txtMaKhachHang.Enabled = false;
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            getdata();
            dgvQLKhachHang.Columns[0].HeaderText = "Mã Khách Hàng";
            dgvQLKhachHang.Columns[1].HeaderText = "Tên Khách Hàng";
            dgvQLKhachHang.Columns[2].HeaderText = "Địa Chỉ";
            dgvQLKhachHang.Columns[3].HeaderText = "Giới Tính";
            dgvQLKhachHang.Columns[4].HeaderText = "Quê Quán";
            dgvQLKhachHang.Columns[0].Width = 200;
            dgvQLKhachHang.Columns[1].Width = 200;
            dgvQLKhachHang.Columns[2].Width = 150;
            dgvQLKhachHang.Columns[3].Width = 150;
            dgvQLKhachHang.Columns[4].Width = 180;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-14D46B2\\VUONGDINHTRANG;Initial Catalog=CNPMQLCUAHANGHOAQUAFRUITFRESH;Integrated Security=True");
            try
            {
                conn.Open();
                string a0 = txtMaKhachHang.Text;
                string a1 = txtTenKhachHang.Text;
                string a2 = txtDiaChi.Text;
                string a3 = cbbGioiTinh.Text;
                string a4 = txtSoDienThoai.Text;
                string query = String.Format("insert into KhachHang( MaKhachHang, TenKhachHang, DiaChi, GioiTinh, SDT) " +
                    "values (N'{0}', N'{1}', N'{2}', N'{3}', N'{4}')", a0, a1, a2, a3, a4);
                SqlCommand cmd = new SqlCommand(query, conn);
                int s1 = cmd.ExecuteNonQuery();
                if (s1 == 1)
                {
                    getdata();
                    MessageBox.Show("Thêm Thông Tin Khách Hàng Thành Công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Thêm Thông Tin Khách Hàng Thất Bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-14D46B2\\VUONGDINHTRANG;Initial Catalog=CNPMQLCUAHANGHOAQUAFRUITFRESH;Integrated Security=True");
            try
            {
                conn.Open();
                string a0 = txtMaKhachHang.Text;
                string a1 = txtTenKhachHang.Text;
                string a2 = txtDiaChi.Text;
                string a3 = cbbGioiTinh.Text;
                string a4 = txtSoDienThoai.Text;
                if (txtMaKhachHang.Text.Length == 0 || txtTenKhachHang.Text.Length == 0 || txtDiaChi.Text.Length == 0 || cbbGioiTinh.Text.Length == 0 || txtSoDienThoai.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMaKhachHang.Focus();
                    txtTenKhachHang.Focus();
                    txtDiaChi.Focus();
                    cbbGioiTinh.Focus();
                    txtSoDienThoai.Focus();
                    return;
                }
                string query = String.Format("update KhachHang set TenKhachHang = N'{1}', DiaChi = N'{2}', GioiTinh = N'{3}', SDT = N'{4}' where MaKhachHang = N'{0}'", a0, a1, a2, a3, a4);
                SqlCommand cmd = new SqlCommand(query, conn);
                int s1 = cmd.ExecuteNonQuery();
                if (s1 == 1)
                {
                    getdata();
                    MessageBox.Show("Cập nhật thông tin khách hàng thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                    MessageBox.Show("Cập nhật thông tin khách hàng thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                string query = String.Format("delete KhachHang where MaKhachHang = '" + txtMaKhachHang.Text + "'");
                SqlCommand cmd = new SqlCommand(query, conn);
                int s1 = cmd.ExecuteNonQuery();
                if (s1 == 1)
                {
                    getdata();
                    MessageBox.Show("Xoa Thông Tin Khách Hàng Thành Công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                    MessageBox.Show("Xóa Thông Tin Khách Hàng Thất Bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                string query = "select * from KhachHang where TenKhachHang like N'%" + txtTimKiem.Text + "%'";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvQLKhachHang.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            GiaoDienChinh gdc = new GiaoDienChinh();
            gdc.Show();
            this.Hide();
        }
    }
}
