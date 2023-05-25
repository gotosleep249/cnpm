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
    public partial class BanHang : Form
    {
        public BanHang()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void BanHang_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cNPMDataSet.CTHoaDon' table. You can move, or remove it, as needed.
            this.cTHoaDonTableAdapter.Fill(this.cNPMDataSet.CTHoaDon);

        }
        public void getDataSet()
        {
            String sql = @"Data Source=GOTOSLEEP249;Initial Catalog=CNPM;Integrated Security=True";
            SqlConnection conn = new SqlConnection(sql);
            string Query = "Select * from CTHoaDon";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(Query, conn);
            da.Fill(ds, "CTHoaDon");
            dataGridView1.DataSource = ds.Tables["CTHoaDon"];
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView1.CurrentRow.Index;
            txtMaHD.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txtSanPham.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            txtDonGia.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            txtSoLuong.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            txtThanhTien.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
             
            String sql = @"Data Source=GOTOSLEEP249;Initial Catalog=CNPM;Integrated Security=True";
            SqlConnection conn = new SqlConnection(sql);
            conn.Open();
            string Query = "Insert into CTHoaDon values('" + txtMaHD.Text + "','" + txtSanPham.Text + "','" + txtDonGia.Text + "','" + txtSoLuong.Text + "','" + txtThanhTien.Text + "'); Update CTHoaDon Set ThanhTien= CTHoaDon.DonGia* CTHoaDon.SoLuong";
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
            string Query = "Update CTHoaDon set SanPham='" + txtSanPham.Text + "',DonGia='" + txtDonGia.Text + "',SoLuong='" + txtSoLuong.Text + "' where MaHD='"+txtMaHD.Text+"'; Update CTHoaDon Set ThanhTien= CTHoaDon.DonGia* CTHoaDon.SoLuong ";
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
            string Query = " Delete from CTHoaDon where MaHD='"+txtMaHD.Text+"'";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            getDataSet();
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            TuhuBread TB = new TuhuBread();
            TB.Show();
            this.Close();
        }
    }
}
