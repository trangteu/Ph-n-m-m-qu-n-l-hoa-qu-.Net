using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;
using COMExcel = Microsoft.Office.Interop.Excel;

namespace QuanLyCuaHangHoaQuanFruitFresh
{
    public partial class QuanLyHoaDon : Form
    {
        public QuanLyHoaDon()
        {
            InitializeComponent();
        }
        private void getdata()
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-14D46B2\\VUONGDINHTRANG;Initial Catalog=CNPMQLCUAHANGHOAQUAFRUITFRESH;Integrated Security=True");
            try
            {
                conn.Open();
                string query = "select * from HoaDon";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvQLHoaDon.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void QuanLyHoaDon_Load(object sender, EventArgs e)
        {
            getdata();
            dgvQLHoaDon.Columns[0].HeaderText = "Mã Hóa Đơn";
            dgvQLHoaDon.Columns[1].HeaderText = "Mã Hàng Hóa";
            dgvQLHoaDon.Columns[2].HeaderText = "Mã Nhân Viên";
            dgvQLHoaDon.Columns[3].HeaderText = "Mã Khách Hàng";
            dgvQLHoaDon.Columns[4].HeaderText = "Tên Hóa Đơn";
            dgvQLHoaDon.Columns[5].HeaderText = "Số Lượng";
            dgvQLHoaDon.Columns[6].HeaderText = "Giá Thành";
            dgvQLHoaDon.Columns[7].HeaderText = "Thành Tiền";
            dgvQLHoaDon.Columns[0].Width = 160;
            dgvQLHoaDon.Columns[1].Width = 170;
            dgvQLHoaDon.Columns[2].Width = 170;
            dgvQLHoaDon.Columns[3].Width = 190;
            dgvQLHoaDon.Columns[4].Width = 220;
            dgvQLHoaDon.Columns[5].Width = 130;
            dgvQLHoaDon.Columns[6].Width = 140;
            dgvQLHoaDon.Columns[7].Width = 170;
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            getdata();
            dgvQLHoaDon.Columns[0].HeaderText = "Mã Hóa Đơn";
            dgvQLHoaDon.Columns[1].HeaderText = "Mã Hàng Hóa";
            dgvQLHoaDon.Columns[2].HeaderText = "Mã Nhân Viên";
            dgvQLHoaDon.Columns[3].HeaderText = "Mã Khách Hàng";
            dgvQLHoaDon.Columns[4].HeaderText = "Tên Hóa Đơn";
            dgvQLHoaDon.Columns[5].HeaderText = "Số Lượng";
            dgvQLHoaDon.Columns[6].HeaderText = "Giá Thành";
            dgvQLHoaDon.Columns[7].HeaderText = "Thành Tiền";
            dgvQLHoaDon.Columns[0].Width = 160;
            dgvQLHoaDon.Columns[1].Width = 170;
            dgvQLHoaDon.Columns[2].Width = 170;
            dgvQLHoaDon.Columns[3].Width = 190;
            dgvQLHoaDon.Columns[4].Width = 220;
            dgvQLHoaDon.Columns[5].Width = 130;
            dgvQLHoaDon.Columns[6].Width = 140;
            dgvQLHoaDon.Columns[7].Width = 170;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-14D46B2\\VUONGDINHTRANG;Initial Catalog=CNPMQLCUAHANGHOAQUAFRUITFRESH;Integrated Security=True");
            try
            {
                conn.Open();
                string a0 = txtMaHoaDon.Text;
                string a1 = txtMaHangHoa.Text;
                string a2 = txtMaNhanVien.Text;
                string a3 = txtMaKhachHang.Text;
                string a4 = txtTenHoaDon.Text;
                string a5 = txtSoLuong.Text;
                string a6 = txtGiaThanh.Text;
                string a7 = txtThanhTien.Text;
                string query = String.Format("insert into HoaDon( MaHoaDon, MaHangHoa, MaNhanVien, MaKhachHang, TenHoaDon, SoLuong, GiaThanh, ThanhTien) " +
                    "values (N'{0}', N'{1}', N'{2}', N'{3}', N'{4}', N'{5}', N'{6}', N'{7}')", a0, a1, a2, a3, a4, a5, a6, a7);
                SqlCommand cmd = new SqlCommand(query, conn);
                int s1 = cmd.ExecuteNonQuery();
                if (s1 == 1)
                {
                    getdata();
                    MessageBox.Show("Thêm Hóa Đơn Thành Công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Thêm Hóa Đơn Thất Bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                string a0 = txtMaHoaDon.Text;
                string a1 = txtMaHangHoa.Text;
                string a2 = txtMaNhanVien.Text;
                string a3 = txtMaKhachHang.Text;
                string a4 = txtTenHoaDon.Text;
                string a5 = txtSoLuong.Text;
                string a6 = txtGiaThanh.Text;
                string a7 = txtThanhTien.Text;
                if (txtMaHoaDon.Text.Length == 0 || txtMaHangHoa.Text.Length == 0 || txtMaNhanVien.Text.Length == 0 || txtMaKhachHang.Text.Length == 0 || txtTenHoaDon.Text.Length == 0 || txtSoLuong.Text.Length == 0 || txtGiaThanh.Text.Length == 0 || txtThanhTien.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMaHoaDon.Focus();
                    txtMaHangHoa.Focus();
                    txtMaNhanVien.Focus();
                    txtMaKhachHang.Focus();
                    txtTenHoaDon.Focus();
                    txtSoLuong.Focus();
                    txtGiaThanh.Focus();
                    txtThanhTien.Focus();
                    return;
                }
                string query = String.Format("update HoaDon set MaHangHoa = N'{1}', MaNhanVien = N'{2}', MaKhachHang = N'{3}', TenHoaDon = N'{4}', SoLuong = N'{5}', GiaThanh = N'{6}', ThanhTien = N'{7}' where MaHoaDon = N'{0}'", a0, a1, a2, a3, a4, a5, a6, a7);
                SqlCommand cmd = new SqlCommand(query, conn);
                int s1 = cmd.ExecuteNonQuery();
                if (s1 == 1)
                {
                    getdata();
                    MessageBox.Show("Cập nhật hóa đơn thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                    MessageBox.Show("Cập nhật hóa đơn thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                string query = String.Format("delete HoaDOn where MaHoaDon = '" + txtMaHoaDon.Text + "'");
                SqlCommand cmd = new SqlCommand(query, conn);
                int s1 = cmd.ExecuteNonQuery();
                if (s1 == 1)
                {
                    getdata();
                    MessageBox.Show("Xoa Hoa Đơn Thành Công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                    MessageBox.Show("Xóa Hóa Đơn Thất Bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                string query = "select * from HoaDon where TenHoaDon like N'%" + txtTimKiem.Text + "%'";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvQLHoaDon.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvQLHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //Lưu lại dòng dữ liệu vừa kích chọn
                DataGridViewRow row = this.dgvQLHoaDon.Rows[e.RowIndex];
                //Đưa dữ liệu vào textbox
                txtMaHoaDon.Text = row.Cells[0].Value.ToString();
                txtMaHangHoa.Text = row.Cells[1].Value.ToString();
                txtMaNhanVien.Text = row.Cells[2].Value.ToString();
                txtMaKhachHang.Text = row.Cells[3].Value.ToString();
                txtTenHoaDon.Text = row.Cells[4].Value.ToString();
                txtSoLuong.Text = row.Cells[5].Value.ToString();
                txtGiaThanh.Text = row.Cells[6].Value.ToString();
                txtGiaThanh.Text = row.Cells[7].Value.ToString();
            }
            //txtMaKhachHang.Enabled = false;
        }

        private void txtThanhTien_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtGiaThanh_TextChanged(object sender, EventArgs e)
        {

            string sl = txtSoLuong.Text;
            string gt = txtGiaThanh.Text;

            int a = int.Parse(sl);
            int b = int.Parse(gt);

            int c = a * b;
            txtThanhTien.Text = Convert.ToString(c);

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            GiaoDienChinh gdc = new GiaoDienChinh();
            gdc.Show();
            this.Hide();
        }
        private void ToExcel(DataGridView dataGridView1, string fileName)
        {
            //khai báo thư viện hỗ trợ Microsoft.Office.Interop.Excel
            Microsoft.Office.Interop.Excel.Application excel;
            Microsoft.Office.Interop.Excel.Workbook workbook;
            Microsoft.Office.Interop.Excel.Worksheet worksheet;
            try
            {
                //Tạo đối tượng COM.
                excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Visible = false;
                excel.DisplayAlerts = false;
                //tạo mới một Workbooks bằng phương thức add()
                workbook = excel.Workbooks.Add(Type.Missing);
                worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets["Sheet1"];
                //đặt tên cho sheet
                worksheet.Name = "Quản lý cửa hàng hoa quả Fruit Fresh";

                // export header trong DataGridView
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    worksheet.Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText;
                }
                // export nội dung trong DataGridView
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    }
                }
                // sử dụng phương thức SaveAs() để lưu workbook với filename
                workbook.SaveAs(fileName);
                //đóng workbook
                workbook.Close();
                excel.Quit();
                MessageBox.Show("Xuất dữ liệu ra Excel thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                workbook = null;
                worksheet = null;
            }
        }
        private void btnPDF_Click(object sender, EventArgs e)
        {
            if (dgvQLHoaDon.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = "Output.pdf";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("Không thể ghi dữ liệu tới ổ đĩa. Mô tả lỗi:" + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            PdfPTable pdfTable = new PdfPTable(dgvQLHoaDon.Columns.Count);
                            pdfTable.DefaultCell.Padding = 4;
                            pdfTable.WidthPercentage = 95;
                            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (DataGridViewColumn column in dgvQLHoaDon.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                                pdfTable.AddCell(cell);
                            }

                            foreach (DataGridViewRow row in dgvQLHoaDon.Rows)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    pdfTable.AddCell(cell.Value.ToString());
                                }
                            }

                            using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                            {
                                Document pdfDoc = new Document(PageSize.A3, 10f, 10f, 20f, 8f);
                                PdfWriter.GetInstance(pdfDoc, stream);
                                pdfDoc.Open();
                                pdfDoc.Add(pdfTable);
                                pdfDoc.Close();
                                stream.Close();
                            }

                            MessageBox.Show("Dữ liệu Export thành công!!!", "Info");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Mô tả lỗi :" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Không có bản ghi nào được Export!!!", "Info");
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Excel | .xlsx | Excel 2013 | .xls";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //gọi hàm ToExcel() với tham số là dgviewDiemMH và filename từ SaveFileDialog
                ToExcel(dgvQLHoaDon, saveFileDialog1.FileName);
            }
        }

        private void dgvQLHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
