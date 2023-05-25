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
    public partial class ThemNguoiDung : Form
    {
        public ThemNguoiDung()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void Them_Click(object sender, EventArgs e)
        {
            String sql = @"Data Source=GOTOSLEEP249;Initial Catalog=CNPM;Integrated Security=True";
            SqlConnection conn = new SqlConnection(sql);
            conn.Open();
            string Query = "Insert into NguoiDung values('" + txtMaNV.Text + "','" + txtMatKhau.Text + "')";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.ExecuteReader();
            conn.Close();
            MessageBox.Show("Thêm thành công");
            this.Close();
            
        }

        private void Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
