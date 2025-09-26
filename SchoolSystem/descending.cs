using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolSystem
{
    public partial class descending : Form
    {
        public descending()
        {
            InitializeComponent();
        }

        private void descending_Load(object sender, EventArgs e)
        {

        }
        public void LoadData(DataTable data)
        {
            // Ensure dataGridView1 exists on the form
            if (dataGridView1 != null)
            {
                dataGridView1.DataSource = data; // Populate the DataGridView with the passed DataTable
            }
            else
            {
                MessageBox.Show("DataGridView is not initialized.");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
