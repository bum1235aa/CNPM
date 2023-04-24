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
    public partial class SanPham : Form
    {
        private SanPhamController controller = new SanPhamController();
        public SanPham()
        {
            InitializeComponent();
        }

        private void SanPham_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = controller.GetAllSanPham();
            textBoxId.Text = controller.GetMaxId().ToString();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(textBoxId.Text);
            string name = textBoxName.Text;
            string decs = textBoxDecs.Text;
            int price = Int32.Parse(textBoxPrice.Text);
            int quantity = Int32.Parse(textBoxQuantity.Text);

            controller.AddSanPham(id, name, decs, price, quantity);
            dataGridView1.DataSource = controller.GetAllSanPham();
            Clear();
        }

        private void Clear()
        {
            textBoxId.Text = controller.GetMaxId().ToString(); ;
            textBoxDecs.Text = "";
            textBoxName.Text = "";
            textBoxPrice.Text = "";
            textBoxQuantity.Text = "";
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

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            int id = GetSelectedId();
            if (id != -1)
            {
                controller.DeleteSanPham(id);

                dataGridView1.DataSource = controller.GetAllSanPham();

                Clear();
            }
            else
            {
                MessageBox.Show("Please select a student to delete.");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxId.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBoxName.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBoxDecs.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBoxPrice.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBoxQuantity.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            int id = GetSelectedId();
            if (id != -1)
            {
                string name = textBoxName.Text;
                string decs = textBoxDecs.Text;
                int price = Int32.Parse(textBoxPrice.Text);
                int quantity = Int32.Parse(textBoxQuantity.Text);

                controller.UpdateSanPham(id, name, decs, price, quantity);
                dataGridView1.DataSource = controller.GetAllSanPham();
                Clear();
            }
            else
            {
                MessageBox.Show("Please select a student to delete.");
            }
            
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            this.Hide();
            form.Show();
        }

        private void btn_Reload_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = controller.GetAllSanPham();
            textBoxId.Text = controller.GetMaxId().ToString();
        }
    }
}
