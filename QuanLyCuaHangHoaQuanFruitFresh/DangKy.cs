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
    public partial class _2DangKy : Form
    {
        public _2DangKy()
        {
            InitializeComponent();
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-14D46B2\\VUONGDINHTRANG;Initial Catalog=CNPMQLCUAHANGHOAQUAFRUITFRESH;Integrated Security=True");
            try
            {
                conn.Open();
                string taikhoan = txtTaiKhoan.Text;
                string matkhau = txtMatKhau.Text;
                string hoten = txtHoTen.Text;
                string email = txtEmail.Text;
                string sdt = txtSoDienThoai.Text;
                string query = String.Format("insert into NguoiDung( TaiKhoan, MatKhau, HoTen, Email, SDT) " +
                    "values (N'{0}', N'{1}', N'{2}', N'{3}', N'{4}')", taikhoan, matkhau, hoten, email, sdt);
                SqlCommand cmd = new SqlCommand(query, conn);
                int s1 = cmd.ExecuteNonQuery();
                if (s1 == 1)
                {
                    MessageBox.Show("Dang ky thanh cong ");

                }
                else
                    MessageBox.Show("Dang ky khong thanh cong");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtHoTen_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
