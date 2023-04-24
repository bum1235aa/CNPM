using Controllers;
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
    public partial class HoaDon : Form
    {
        public HoaDonController controller = new HoaDonController();
        public HoaDon()
        {
            InitializeComponent();
        }

        private void HoaDon_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = controller.GetAllHoaDons();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            dataGridView1.DataSource = controller.GetChiTiets(GetSelectedId());
        }
        private int GetSelectedId()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                return id;
            }
            else
            {
                return -1;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            this.Hide();
            form.Show();

        }
    }
}
