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

namespace Giao_dien_chinh
{
    public partial class HoaDon : Form
    {
        public HoaDon()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void HoaDon_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbHoaDon.NhapHang' table. You can move, or remove it, as needed.
            this.nhapHangTableAdapter.Fill(this.dbHoaDon.NhapHang);

        }
        public void getDataSet()
        {
            String sql = @"Data Source=GOTOSLEEP249;Initial Catalog=CNPM;Integrated Security=True";
            SqlConnection conn = new SqlConnection(sql);
            string Query = "Select * from NhapHang";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(Query, conn);
            da.Fill(ds, "NhapHang");
            dataGridView1.DataSource = ds.Tables["NhapHang"];
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            getDataSet();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView1.CurrentRow.Index;
            txtMaHD.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txtTenHH.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            txtSoLuong.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            txtThanhTien.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            txtTenNCC.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            txtDiaChiNCC.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            String sql = @"Data Source=GOTOSLEEP249;Initial Catalog=CNPM;Integrated Security=True";
            SqlConnection conn = new SqlConnection(sql);
            conn.Open();
            string Query = "Insert into NhapHang values('" + txtMaHD.Text + "','" + txtTenHH.Text + "','" + txtSoLuong.Text + "','" + txtThanhTien.Text + "','" + txtTenNCC.Text + "','" + txtDiaChiNCC.Text + "')";
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
            string Query = "Update NhapHang set TenHH='" + txtTenHH.Text + "',SoLuong='" + txtSoLuong.Text + "',ThanhTien='" + txtThanhTien.Text + "',TenNCC='" + txtTenNCC.Text + "',DiaChiNCC='" + txtDiaChiNCC.Text + "' where  MaHD='" + txtMaHD.Text + "' ";
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
            string Query = "Delete from NhapHang where MaHD='" + txtMaHD.Text+"'";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            getDataSet();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            String sql = @"Data Source=GOTOSLEEP249;Initial Catalog=CNPM;Integrated Security=True";
            SqlConnection conn = new SqlConnection(sql);
            string Query = "Select * from NhapHang where  MaHD='" + txtMaHD.Text + "'";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(Query, conn);
            da.Fill(ds, "NhapHang");
            dataGridView1.DataSource = ds.Tables["NhapHang"];
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
            TuhuBread TB = new TuhuBread();
            TB.Show();
        }

        private void txtMaHD_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
