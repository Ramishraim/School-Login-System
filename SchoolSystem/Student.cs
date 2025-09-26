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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace SchoolSystem
{
    public partial class Student : Form
    {
        private string studentId;
        public Student(string studentId)
        {
            InitializeComponent();
            this.studentId = studentId; // Initialize Student ID

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Ensure either Midterm or Final is selected
            if (!checkBox1.Checked && !checkBox2.Checked)
            {
                MessageBox.Show("Please select either Midterm or Final.");
                return;
            }

            // Determine which column to fetch
            string columnToFetch = checkBox1.Checked ? "MidtermGrade" : "FinalGrade";

            // SQL query to fetch the selected grade
            string query = $"SELECT {columnToFetch} FROM StudentInfo WHERE [Student Number] = @studentId";

            try
            {
                using (SqlConnection connection = Con1.GetConnection()) // Assuming Con1.GetConnection() is already defined
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add the Student ID as a parameter to prevent SQL injection
                        command.Parameters.AddWithValue("@studentId", studentId);

                        // Execute the query and fetch the result
                        object result = command.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            // Display the grade on the form
                            string grade = result.ToString();
                            labelGrade.Text = $"{columnToFetch.Replace("Grade", "")} Grade: {grade}"; // Example: "Midterm Grade: 85"
                            labelGrade.Visible = true; // Ensure the label is visible
                        }
                        else
                        {
                            labelGrade.Text = "Grade not found. Please check your ID or contact administration.";
                            labelGrade.Visible = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                labelGrade.Text = "An error occurred: " + ex.Message;
                labelGrade.Visible = true;
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // SQL query to fetch midterm and final grades
            string query = "SELECT MidtermGrade, FinalGrade FROM StudentInfo WHERE [Student Number] = @studentId";

            try
            {
                using (SqlConnection connection = Con1.GetConnection()) // Use your existing connection method
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add the Student ID as a parameter
                        command.Parameters.AddWithValue("@studentId", studentId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Retrieve the grades
                                double midterm = reader["MidtermGrade"] != DBNull.Value ? Convert.ToDouble(reader["MidtermGrade"]) : 0;
                                double final = reader["FinalGrade"] != DBNull.Value ? Convert.ToDouble(reader["FinalGrade"]) : 0;

                                // Calculate the average
                                double average = (midterm + final) / 2;

                                // Display the grades and average in labels
                                labelMidtermGrade.Text = $"Midterm Grade: {midterm:F2}";
                                labelFinalGrade.Text = $"Final Grade: {final:F2}";
                                labelAverage.Text = $"Average: {average:F2}";
                                labelMidtermGrade.Visible = true;
                                labelFinalGrade.Visible = true;
                                labelAverage.Visible = true;
                            }
                            else
                            {
                                labelMidtermGrade.Text = "No grades found for the provided Student ID.";
                                labelMidtermGrade.Visible = true;
                                labelFinalGrade.Visible = false;
                                labelAverage.Visible = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                labelMidtermGrade.Text = "An error occurred: " + ex.Message;
                labelMidtermGrade.Visible = true;
                labelFinalGrade.Visible = false;
                labelAverage.Visible = false;
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            // SQL query to fetch the student's grades
            string studentQuery = "SELECT MidtermGrade, FinalGrade FROM StudentInfo WHERE [Student Number] = @studentId";

            // SQL query to calculate the class average
            string classQuery = "SELECT AVG((MidtermGrade + FinalGrade) / 2.0) AS ClassAverage FROM StudentInfo";

            try
            {
                using (SqlConnection connection = Con1.GetConnection()) // Use your connection method
                {
                    connection.Open();

                    // Fetch the student's average
                    double studentAverage = 0;
                    using (SqlCommand studentCommand = new SqlCommand(studentQuery, connection))
                    {
                        studentCommand.Parameters.AddWithValue("@studentId", studentId);

                        using (SqlDataReader reader = studentCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                double midterm = reader["MidtermGrade"] != DBNull.Value ? Convert.ToDouble(reader["MidtermGrade"]) : 0;
                                double final = reader["FinalGrade"] != DBNull.Value ? Convert.ToDouble(reader["FinalGrade"]) : 0;

                                studentAverage = (midterm + final) / 2.0;
                            }
                            else
                            {
                                labelComparison.Text = "No grades found for the provided Student ID.";
                                labelComparison.Visible = true;
                                return;
                            }
                        }
                    }

                    // Fetch the class average
                    double classAverage = 0;
                    using (SqlCommand classCommand = new SqlCommand(classQuery, connection))
                    {
                        object result = classCommand.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            classAverage = Convert.ToDouble(result);
                        }
                        else
                        {
                            labelComparison.Text = "Failed to calculate class average.";
                            labelComparison.Visible = true;
                            return;
                        }
                    }

                    // Compare and display results
                    string comparison = studentAverage > classAverage
                        ? "above"
                        : studentAverage < classAverage
                            ? "below"
                            : "equal to";

                    labelStudentAverage.Text = $"Your Average: {studentAverage:F2}";
                    labelClassAverage.Text = $"Class Average: {classAverage:F2}";
                    labelComparison.Text = $"Your average is {comparison} the class average.";
                    labelStudentAverage.Visible = true;
                    labelClassAverage.Visible = true;
                    labelComparison.Visible = true;
                }
            }
            catch (Exception ex)
            {
                labelComparison.Text = "An error occurred: " + ex.Message;
                labelComparison.Visible = true;
                labelStudentAverage.Visible = false;
                labelClassAverage.Visible = false;
            }
        }
    



private void Student_Load(object sender, EventArgs e)
        {
            {
                // Set the font style for all cells
                dataGridView1.DefaultCellStyle.Font = new Font("Palatino Linotype", 8, FontStyle.Bold | FontStyle.Italic);
                dataGridView1.DefaultCellStyle.ForeColor = Color.Black; // Set text color (optional)
                dataGridView1.DefaultCellStyle.BackColor = Color.White; // Set background color (optional)

                // Set the font style for column headers
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Palatino Linotype", 8, FontStyle.Bold | FontStyle.Italic);
                dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue;
                dataGridView1.EnableHeadersVisualStyles = false; // Allows custom styles for headers

                // Set the font style for row headers
                dataGridView1.RowHeadersDefaultCellStyle.Font = new Font("Palatino Linotype", 8, FontStyle.Bold | FontStyle.Italic);
                dataGridView1.RowHeadersDefaultCellStyle.ForeColor = Color.Black;
                dataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.LightGray;
            }
        }

     

       

        private void button5_Click(object sender, EventArgs e)
        {
            // SQL query to fetch the entire row for the logged-in student
            string query = "SELECT * FROM StudentInfo WHERE [Student Number] = @studentId";

            try
            {
                using (SqlConnection connection = Con1.GetConnection()) // Use your existing connection method
                {
                    connection.Open();

                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        // Add the Student ID parameter to prevent SQL injection
                        adapter.SelectCommand.Parameters.AddWithValue("@studentId", studentId);

                        // Fill a DataTable with the fetched data
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Bind the DataTable to the DataGridView
                        dataGridView1.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}    


        
