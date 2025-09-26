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
    public partial class curriculum : Form
    {
        public curriculum()
        {
            InitializeComponent();
        }

        private void curriculum_Load(object sender, EventArgs e)
        {
            // Add columns
            dataGridView1.Columns.Add("Subject", "Subject");
            dataGridView1.Columns.Add("GradeLevel", "Grade Level");
            dataGridView1.Columns.Add("Credits", "Credits");
            dataGridView1.Columns.Add("Description", "Description");

            // Add rows with detailed curriculum information
            dataGridView1.Rows.Add("Math", "Grade 10", "3", "Covers algebra, calculus, and geometry.");
            dataGridView1.Rows.Add("Science", "Grade 11", "4", "Includes physics, chemistry, and biology.");
            dataGridView1.Rows.Add("History", "Grade 9", "2", "Focuses on world history and civilizations.");
            dataGridView1.Rows.Add("Technology", "Grade 12", "3", "Introduces programming and IT concepts.");
            dataGridView1.Rows.Add("Physical Education", "All Grades", "1", "Emphasizes fitness and sports.");

            // Adjust DataGridView appearance
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Adjust column widths
            dataGridView1.ReadOnly = true; // Make the grid read-only
            dataGridView1.RowHeadersVisible = false; // Hide row headers for a cleaner look

            // Adjust column and cell styles
            DataGridViewCellStyle wrapStyle = new DataGridViewCellStyle();
            wrapStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.Columns["Description"].DefaultCellStyle = wrapStyle; // Enable text wrapping for the Description column

            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells; // Adjust row height to fit all text
            dataGridView1.RowTemplate.Height = 40; // Set default row height
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold); // Header font
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
