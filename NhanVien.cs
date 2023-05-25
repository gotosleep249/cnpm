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
using Microsoft.Office.Interop.Excel;
using app = Microsoft.Office.Interop.Excel.Application;


namespace Giao_dien_chinh
{
    public partial class NhanVien : Form
    {
        public NhanVien()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
            TuhuBread TB = new TuhuBread();
            TB.Show();
        }

        private void NhanVien_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbNhanVien.NhanVien' table. You can move, or remove it, as needed.
            this.nhanVienTableAdapter.Fill(this.dbNhanVien.NhanVien);

        }
        public void getDataSet()
        {
            String sql = @"Data Source=GOTOSLEEP249;Initial Catalog=CNPM;Integrated Security=True";
            SqlConnection conn = new SqlConnection(sql);
            string Query = "Select * from NhanVien order by TenNV ASC";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(Query, conn);
            da.Fill(ds, "NhanVien");
            dataGridView1.DataSource = ds.Tables["NhanVien"];
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            getDataSet();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView1.CurrentRow.Index;
            txtMaNV.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txtTenNV.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            txtChucVu.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            txtNgaySinh.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            txtSDT.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            txtDiaChi.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
            txtEmail.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            String sql = @"Data Source=GOTOSLEEP249;Initial Catalog=CNPM;Integrated Security=True";
            SqlConnection conn = new SqlConnection(sql);
            conn.Open();
            string Query = "Insert into NhanVien values('" + txtMaNV.Text + "','" + txtTenNV.Text + "','" + txtChucVu.Text + "','" + txtNgaySinh.Text + "','" + txtSDT.Text + "','" + txtDiaChi.Text + "','" + txtEmail.Text + "')";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.ExecuteReader();
            conn.Close();
            getDataSet();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            String sql = @"Data Source=GOTOSLEEP249;Initial Catalog=CNPM;Integrated Security=True";
            SqlConnection conn = new SqlConnection(sql);
            conn.Open();
            string Query = "Update NhanVien set TenNV='" + txtTenNV.Text + "',ChucVu='" + txtChucVu.Text + "',NgaySinh='" + txtNgaySinh.Text + "',SDT='" + txtSDT.Text + "',DiaChi='" + txtDiaChi.Text + "',Email='" + txtEmail.Text + "' where  MaNV='" + txtMaNV.Text + "' ";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.ExecuteReader();
            conn.Close();
            getDataSet();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            String sql = @"Data Source=GOTOSLEEP249;Initial Catalog=CNPM;Integrated Security=True";
            SqlConnection conn = new SqlConnection(sql);
            conn.Open();
            string Query = "Delete from NguoiDung where MaNV=(Select MaNV from NhanVien where TenNV='" + txtTenNV.Text + "') ; Delete from NhanVien where MaNV=(Select MaNV from NhanVien where TenNV='" + txtTenNV.Text + "')";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            getDataSet();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            String sql = @"Data Source=GOTOSLEEP249;Initial Catalog=CNPM;Integrated Security=True";
            SqlConnection conn = new SqlConnection(sql);
            string Query = "Select * from NhanVien where  MaNV='" + txtMaNV.Text + "'";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(Query, conn);
            da.Fill(ds, "NhanVien");
            dataGridView1.DataSource = ds.Tables["NhanVien"];
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                export2Excel(dataGridView1, saveFileDialog1.FileName);
            }
        }

        private void export2Excel(DataGridView dataGridView1, string tenTep)
        {
            Microsoft.Office.Interop.Excel.Application excel;
            Microsoft.Office.Interop.Excel.Workbook workbook;   
            Microsoft.Office.Interop.Excel.Worksheet worksheet;
            try
            {
                excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Visible = false;
                excel.DisplayAlerts = false;

                workbook = excel.Workbooks.Add(Type.Missing);
                worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets["Sheet1"];

                worksheet.Name = " Quan ly nhan vien  ";

                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    worksheet.Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText;
                }
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {

                        {
                            worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                        }
                    }
                }
                workbook.SaveAs(tenTep);

                workbook.Close();
                excel.Quit();
                MessageBox.Show("Xuat du lieu thanh cong");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi:" +ex.Message);
            }
            finally
            {
                workbook = null;
                worksheet = null;
            }


        }
        
    }
}
