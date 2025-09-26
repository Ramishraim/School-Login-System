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
    public partial class AcademicCalendar : Form
    {
        public AcademicCalendar()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
           
        

    }

        private void AcademicCalendar_Load(object sender, EventArgs e)
        {
            // Add columns
            dataGridView1.Columns.Add("Event", "Event");
            dataGridView1.Columns.Add("Type", "Type");
            dataGridView1.Columns.Add("StartDate", "Start Date");
            dataGridView1.Columns.Add("EndDate", "End Date");
            dataGridView1.Columns.Add("Description", "Description");

            // Add rows with detailed events
            dataGridView1.Rows.Add("Spring Semester Begins", "Academic", "Jan 10, 2024", "Jan 10, 2024", "First day of classes.");
            dataGridView1.Rows.Add("Registration Deadline", "Administrative", "Jan 15, 2024", "Jan 15, 2024", "Last day for course registration.");
            dataGridView1.Rows.Add("Spring Break", "Holiday", "Mar 10, 2024", "Mar 16, 2024", "A week-long break.");
            dataGridView1.Rows.Add("Midterm Exams", "Exams", "Mar 20, 2024", "Mar 25, 2024", "Midterm examination period.");
            dataGridView1.Rows.Add("Graduation Ceremony", "Event", "May 20, 2024", "May 20, 2024", "For graduating students.");
            dataGridView1.Rows.Add("Summer Semester Begins", "Academic", "Jun 1, 2024", "Jun 1, 2024", "First day of summer classes.");
            dataGridView1.Rows.Add("Independence Day", "Holiday", "Jul 4, 2024", "Jul 4, 2024", "University closed for holiday.");

            // Adjust DataGridView appearance
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Adjust column sizes to fit the form
            dataGridView1.ReadOnly = true; // Make the DataGridView read-only
            dataGridView1.RowHeadersVisible = false; // Hide row headers for cleaner look

            // Enable text wrapping for the Description column
            DataGridViewCellStyle wrapStyle = new DataGridViewCellStyle();
            wrapStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.Columns["Description"].DefaultCellStyle = wrapStyle;

            // Adjust row height to fit wrapped text
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // Enhance styling (optional)
            dataGridView1.RowTemplate.Height = 40; // Increase default row height
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold); // Header font
            dataGridView1.Columns["StartDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Align start date
            dataGridView1.Columns["EndDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Align end date
        }

    }
}
