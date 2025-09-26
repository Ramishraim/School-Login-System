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

namespace SchoolSystem
{
    public partial class Instructor : Form
    {
        public Instructor()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Get input values
            string studentNumber = textBox2.Text; // Student ID
            string gradeText = textBox3.Text;    // Grade
            bool isMidtermChecked = checkBox1.Checked; // Checkbox for midterm
            bool isFinalChecked = checkBox2.Checked;   // Checkbox for final

            // Validate input
            if (string.IsNullOrWhiteSpace(studentNumber))
            {
                MessageBox.Show("Please enter a valid student number.");
                return;
            }

            if (string.IsNullOrWhiteSpace(gradeText) || !double.TryParse(gradeText, out double grade))
            {
                MessageBox.Show("Please enter a valid grade.");
                return;
            }

            if (!isMidtermChecked && !isFinalChecked)
            {
                MessageBox.Show("Please select either midterm or final to update.");
                return;
            }

            // Determine which column to update
            string columnToUpdate = isMidtermChecked ? "MidtermGrade" : "FinalGrade";

            // SQL query to update the grade
            string query = $"UPDATE StudentInfo SET {columnToUpdate} = @grade WHERE [Student Number] = @studentNumber";

            try
            {
                // Use the existing connection from Con1
                using (SqlConnection connection = Con1.GetConnection())
                {
                    connection.Open(); // Open the database connection

                    // Create the SQL command
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters to prevent SQL injection
                        command.Parameters.AddWithValue("@grade", grade);
                        command.Parameters.AddWithValue("@studentNumber", studentNumber);

                        // Execute the query
                        int rowsAffected = command.ExecuteNonQuery();

                        // Provide feedback to the user
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"Successfully updated {columnToUpdate} for Student ID {studentNumber}.");
                        }
                        else
                        {
                            MessageBox.Show("No matching student found. Please check the student number.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Display error message in case of any issues
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void Instructor_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // SQL query to calculate the average midterm grade
            string query = "SELECT AVG(MidtermGrade) AS AverageMidterm FROM StudentInfo";

            try
            {
                // Use the existing connection from Con1
                using (SqlConnection connection = Con1.GetConnection())
                {
                    connection.Open(); // Open the database connection

                    // Create the SQL command
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Execute the query and fetch the result
                        object result = command.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            // Display the average midterm in textbox6
                            double average = Convert.ToDouble(result);
                            textBox6.Text = average.ToString("F2"); // Format to 2 decimal places
                        }
                        else
                        {
                            // Handle case where no data is available
                            textBox6.Text = "No data available.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Display error message in case of any issues
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // SQL query to calculate the average final grade
            string query = "SELECT AVG(FinalGrade) AS AverageFinal FROM StudentInfo";

            try
            {
                // Use the existing connection from Con1
                using (SqlConnection connection = Con1.GetConnection())
                {
                    connection.Open(); // Open the database connection

                    // Create the SQL command
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Execute the query and fetch the result
                        object result = command.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            // Display the average final grade in textbox7
                            double average = Convert.ToDouble(result);
                            textBox7.Text = average.ToString("F2"); // Format to 2 decimal places
                        }
                        else
                        {
                            // Handle case where no data is available
                            textBox7.Text = "No data available.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Display error message in case of any issues
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // SQL query to calculate the total average of midterm and final grades
            string query = "SELECT AVG((MidtermGrade + FinalGrade) / 2.0) AS TotalAverage FROM StudentInfo";

            try
            {
                // Use the existing connection from Con1
                using (SqlConnection connection = Con1.GetConnection())
                {
                    connection.Open(); // Open the database connection

                    // Create the SQL command
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Execute the query and fetch the result
                        object result = command.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            // Display the total average in textbox8
                            double totalAverage = Convert.ToDouble(result);
                            textBox8.Text = totalAverage.ToString("F2"); // Format to 2 decimal places
                        }
                        else
                        {
                            // Handle case where no data is available
                            textBox8.Text = "No data available.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Display error message in case of any issues
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e) // Ascending Grades
        {
            if (!checkBox3.Checked && !checkBox4.Checked)
            {
                MessageBox.Show("Please select either Midterms or Finals to sort.");
                return;
            }

            // Determine the grade type based on the checkbox
            string gradeColumn = checkBox3.Checked ? "MidtermGrade" : "FinalGrade";

            // SQL query for ascending grades
            string query = $"SELECT [Student Number], [Name], {gradeColumn} AS Grade FROM StudentInfo ORDER BY {gradeColumn} ASC";

            try
            {
                using (SqlConnection connection = Con1.GetConnection())
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            // Open the Ascending form and pass the data
                            ascending ascendingForm = new ascending();
                            ascendingForm.LoadData(dataTable);
                            ascendingForm.Show();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e) // Descending Grades
        {
            if (!checkBox3.Checked && !checkBox4.Checked)
            {
                MessageBox.Show("Please select either Midterms or Finals to sort.");
                return;
            }

            // Determine the grade type based on the checkbox
            string gradeColumn = checkBox3.Checked ? "MidtermGrade" : "FinalGrade";

            // SQL query for descending grades
            string query = $"SELECT [Student Number], [Name], {gradeColumn} AS Grade FROM StudentInfo ORDER BY {gradeColumn} DESC";

            try
            {
                using (SqlConnection connection = Con1.GetConnection())
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            // Open the Descending form and pass the data
                            descending descendingForm = new descending();
                            descendingForm.LoadData(dataTable);
                            descendingForm.Show();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

