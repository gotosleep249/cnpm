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
    public partial class NhaCungCap : Form
    {
        public NhaCungCap()
        {
            InitializeComponent();
        }

        private void lbMaNV_Click(object sender, EventArgs e)
        {

        }
        public void getDataSet()
        {
            String sql = @"Data Source=GOTOSLEEP249;Initial Catalog=CNPM;Integrated Security=True";
            SqlConnection conn = new SqlConnection(sql);
            string Query = "Select * from NCC";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(Query, conn);
            da.Fill(ds, "NCC");
            dataGridView1.DataSource = ds.Tables["NCC"];
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            getDataSet();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView1.CurrentRow.Index;
            txtMaNCC.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txtTenNCC.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            txtDiaChi.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            String sql = @"Data Source=GOTOSLEEP249;Initial Catalog=CNPM;Integrated Security=True";
            SqlConnection conn = new SqlConnection(sql);
            conn.Open();
            string Query = "Insert into NCC values('" + txtMaNCC.Text + "','" + txtTenNCC.Text + "','" + txtDiaChi.Text + "')";
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
            string Query = "Update NCC set TenNCC='" + txtTenNCC.Text + "',DiaChi='" + txtDiaChi.Text + "' where  MaNCC='" + txtMaNCC.Text + "' ";
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
            string Query = "Delete from NCC where MaNCC='"+txtMaNCC.Text+"'";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            getDataSet();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            String sql = @"Data Source=GOTOSLEEP249;Initial Catalog=CNPM;Integrated Security=True";
            SqlConnection conn = new SqlConnection(sql);
            string Query = "Select * from NCC where  MaNCC='" + txtMaNCC.Text + "'";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(Query, conn);
            da.Fill(ds, "NCC");
            dataGridView1.DataSource = ds.Tables["NCC"];
        }

        private void NhaCungCap_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbNCC.NCC' table. You can move, or remove it, as needed.
            this.nCCTableAdapter.Fill(this.dbNCC.NCC);

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
            TuhuBread TB = new TuhuBread();
            TB.Show();
        }
    }
}
