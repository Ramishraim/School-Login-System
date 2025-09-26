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
    public partial class fees : Form
    {
        public fees()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void fees_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("FeeType", "Fee Type");
            dataGridView1.Columns.Add("Amount", "Amount");
            dataGridView1.Columns.Add("Criteria", "Criteria");
            dataGridView1.Columns.Add("Description", "Description");

            // Add rows with detailed fee information
            dataGridView1.Rows.Add("Tuition Fee", "$5000", "All students", "Covers tuition for one semester.");
            dataGridView1.Rows.Add("Lab Fee", "$300", "Science and tech students", "Includes access to laboratory equipment.");
            dataGridView1.Rows.Add("Sports Fee", "$200", "Optional", "Covers gym and sports facility usage.");
            dataGridView1.Rows.Add("Sibling Discount", "-$500", "Siblings in the school", "Applicable per sibling enrolled.");
            dataGridView1.Rows.Add("Late Registration", "$100", "After registration deadline", "Penalty for late registration.");

            // Adjust DataGridView appearance
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Adjust column widths
            dataGridView1.ReadOnly = true; // Make the grid read-only
            dataGridView1.RowHeadersVisible = false; // Hide row headers for a cleaner look

            // Enable text wrapping for the Description column
            DataGridViewCellStyle wrapStyle = new DataGridViewCellStyle();
            wrapStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.Columns["Description"].DefaultCellStyle = wrapStyle;

            // Adjust row height to fit wrapped text
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells; // Automatically adjust row height

            // Optional: Enhance styling
            dataGridView1.RowTemplate.Height = 40; // Default row height
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold); // Header font
        }
    }
}

