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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            _2DangKy qlx = new _2DangKy();
            qlx.Show();
            this.Hide();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-14D46B2\\VUONGDINHTRANG;Initial Catalog=CNPMQLCUAHANGHOAQUAFRUITFRESH;Integrated Security=True");
            try
            {
                conn.Open();
                string taikhoan = txtTaiKhoan.Text;
                string matkhau = txtMatKhau.Text;
                string query = "select TaiKhoan,MatKhau from NguoiDung where TaiKhoan = '" + taikhoan + "' and MatKhau = '" + matkhau + "'";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read() == true)
                {
                    MessageBox.Show("Dang nhap thanh cong");
                    GiaoDienChinh gdc = new GiaoDienChinh();
                    gdc.Show();
                    this.Hide();
                }
                else
                    MessageBox.Show("Dang nhap khong thanh cong");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
