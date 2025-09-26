using System.Data;
using System.Windows.Forms;
using System;


namespace SchoolSystem
{
    public partial class ascending : Form
    {
        public ascending()
        {
            InitializeComponent();
        }

        // Method to load data into the DataGridView
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

        private void ascending_Load(object sender, EventArgs e)
        {
            // Any additional setup logic for the form can go here
        }
    }
}
