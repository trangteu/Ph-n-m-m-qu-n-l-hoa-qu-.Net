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
    public partial class QuanLyHangHoa : Form
    {
        public QuanLyHangHoa()
        {
            InitializeComponent();
        }
        private void getdata()
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-14D46B2\\VUONGDINHTRANG;Initial Catalog=CNPMQLCUAHANGHOAQUAFRUITFRESH;Integrated Security=True");
            try
            {
                conn.Open();
                string query = "select * from HangHoa";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvQLHangHoa.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void QuanLyHangHoa_Load(object sender, EventArgs e)
        {
            getdata();
            dgvQLHangHoa.Columns[0].HeaderText = "Mã Hàng Hóa";
            dgvQLHangHoa.Columns[1].HeaderText = "Tên Hàng Hóa";
            dgvQLHangHoa.Columns[2].HeaderText = "Ngày Nhập";
            dgvQLHangHoa.Columns[3].HeaderText = "Ngày Hết Hạn";
            dgvQLHangHoa.Columns[4].HeaderText = "Giá Thành";
            dgvQLHangHoa.Columns[0].Width = 210;
            dgvQLHangHoa.Columns[1].Width = 210;
            dgvQLHangHoa.Columns[2].Width = 205;
            dgvQLHangHoa.Columns[3].Width = 210;
            dgvQLHangHoa.Columns[4].Width = 205;
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            getdata();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-14D46B2\\VUONGDINHTRANG;Initial Catalog=CNPMQLCUAHANGHOAQUAFRUITFRESH;Integrated Security=True");
            try
            {
                conn.Open();
                string mahanghoa = txtMaHangHoa.Text;
                string tenhanghoa = txtTenHangHoa.Text;
                string ngaynhap = dtpNgayNhap.Text;
                string ngayhethan = dtpNgayHetHan.Text;
                string giathanh = txtGiaThanh.Text;
                string query = String.Format("insert into HangHoa( MaHangHoa, TenHangHoa, NgayNhap, NgayHetHan, GiaThanh) " +
                    "values (N'{0}', N'{1}', N'{2}', N'{3}', N'{4}')", mahanghoa, tenhanghoa, ngaynhap, ngayhethan, giathanh);
                SqlCommand cmd = new SqlCommand(query, conn);
                int s1 = cmd.ExecuteNonQuery();
                if (s1 == 1)
                {
                    getdata();
                    MessageBox.Show("Thêm hàng hóa thành công ");

                }
                else
                    MessageBox.Show("Thêm hàng hóa không thành công");
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
                string mahanghoa = txtMaHangHoa.Text;
                string tenhanghoa = txtTenHangHoa.Text;
                string ngaynhap = dtpNgayNhap.Text;
                string ngayhethan = dtpNgayHetHan.Text;
                string giathanh = txtGiaThanh.Text;
                if (txtMaHangHoa.Text.Length == 0|| txtTenHangHoa.Text.Length == 0|| dtpNgayNhap.Text.Length == 0|| dtpNgayHetHan.Text.Length == 0|| txtGiaThanh.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMaHangHoa.Focus();
                    txtTenHangHoa.Focus();
                    dtpNgayNhap.Focus();
                    dtpNgayHetHan.Focus();
                    txtGiaThanh.Focus();
                    return;
                }
                string query = String.Format("update HangHoa set TenHangHoa = N'{1}', NgayNhap = N'{2}', NgayHetHan = N'{3}', GiaThanh = N'{4}' where MaHangHoa = N'{0}'", mahanghoa, tenhanghoa, ngaynhap, ngayhethan, giathanh);
                SqlCommand cmd = new SqlCommand(query, conn);
                int s1 = cmd.ExecuteNonQuery();
                if (s1 == 1)
                {
                    getdata();
                    MessageBox.Show("Sưa Thông Tin Hàng Hóa Thành Công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                    MessageBox.Show("Sửa Thông Tin Hàng Hóa Thất Bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                string query = String.Format("delete HangHoa where MaHangHoa = '" + txtMaHangHoa.Text + "'");
                SqlCommand cmd = new SqlCommand(query, conn);
                int s1 = cmd.ExecuteNonQuery();
                if (s1 == 1)
                {
                    getdata();
                    MessageBox.Show("Xoa Thông Tin Hàng Hóa Thành Công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                    MessageBox.Show("Xóa Thông Tin Hàng Hóa Thất Bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvQLHangHoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //Lưu lại dòng dữ liệu vừa kích chọn
                DataGridViewRow row = this.dgvQLHangHoa.Rows[e.RowIndex];
                //Đưa dữ liệu vào textbox
                txtMaHangHoa.Text = row.Cells[0].Value.ToString();
                txtTenHangHoa.Text = row.Cells[1].Value.ToString();
                dtpNgayNhap.Text = row.Cells[2].Value.ToString();
                dtpNgayHetHan.Text = row.Cells[3].Value.ToString();
                txtGiaThanh.Text = row.Cells[4].Value.ToString();

            }
            //txtMaHangHoa.Enabled = false;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-14D46B2\\VUONGDINHTRANG;Initial Catalog=CNPMQLCUAHANGHOAQUAFRUITFRESH;Integrated Security=True");
            try
            {
                conn.Open();
                string query = "select * from HangHoa where TenHangHoa like N'%" + txtTimKiem.Text + "%'";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvQLHangHoa.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvQLHangHoa_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            GiaoDienChinh gdc = new GiaoDienChinh();
            gdc.Show();
            this.Hide();
        }
    }
}
































