using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Finals
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SanPham sanPham = new SanPham();
            this.Hide();
            sanPham.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            KhachHang kh = new KhachHang();
            this.Hide();
            kh.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HoaDon hd = new HoaDon();
            this.Hide();
            hd.Show();
        }
    }
}
