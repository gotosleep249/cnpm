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
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            {
                string sql = @"Data Source=GOTOSLEEP249;Initial Catalog=CNPM;Integrated Security=True";
                SqlConnection conn = new SqlConnection(sql);
                conn.Open();
                String Query = $"Select count(*) from NguoiDung where MaNV='" + txtTK.Text + "'and MatKhau='" + txtMK.Text + "'";
                SqlCommand cmd = new SqlCommand(Query, conn);
                int sl = (int)cmd.ExecuteScalar();
                conn.Close();
                if (sl == 1)
                {
                    MessageBox.Show("Đăng nhập thành công!");
                    this.Close();
                        TuhuBread TB = new TuhuBread();
                        TB.Show();  
                    
                }
                else
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu");
                }
            }
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {

        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            ThemNguoiDung Them = new ThemNguoiDung();
            Them.Show();
        }
    }
}
