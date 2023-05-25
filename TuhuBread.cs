using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Giao_dien_chinh
{
    public partial class TuhuBread : Form
    {
        public TuhuBread()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNV_Click(object sender, EventArgs e)
        {
            NhanVien NV = new NhanVien();
            NV.Show();
            this.Close();
        }

        private void btnNCC_Click(object sender, EventArgs e)
        {
            NhaCungCap NCC = new NhaCungCap();
            NCC.Show();
            this.Close();
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            HoaDon HD = new HoaDon();
            HD.Show();
            this.Close();
        }

        private void btnKho_Click(object sender, EventArgs e)
        {
           
        }

        private void btnBanHang_Click(object sender, EventArgs e)
        {
            BanHang BH = new BanHang();
            BH.Show();
            this.Close();
        }
    }
}
