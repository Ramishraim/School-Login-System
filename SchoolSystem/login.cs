using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace SchoolSystem
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void login_Load(object sender, EventArgs e)
        {
            
            timer1.Start();

            // Test the database connection
            try
            {
                using (SqlConnection connection = Con1.GetConnection())
                {
                    connection.Open();
                    MessageBox.Show("Database connection successful!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to the database: " + ex.Message);
            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Ensure only one checkbox is selected
            if (!ValidateCheckboxes())
            {
                MessageBox.Show("Please select only one option.");
                return;
            }

            if (checkBox1.Checked) // Student
            {
                string studentId = textBox4.Text;
                string password = textBox5.Text;

                // Validate student credentials
                if (string.IsNullOrWhiteSpace(studentId) || string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("Student ID and password are required.");
                    return;
                }

                try
                {
                    using (SqlConnection connection = Con1.GetConnection())
                    {
                        connection.Open();

                        // Query to validate credentials and retrieve the student's name
                        string query = "SELECT Name FROM StudentInfo WHERE [Student Number] = @studentId AND password = @password";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@studentId", studentId);
                        command.Parameters.AddWithValue("@password", password);

                        object result = command.ExecuteScalar();

                        if (result != null) // If a matching student is found
                        {
                            string studentName = result.ToString(); // Retrieve the name
                            MessageBox.Show($"Login successful. Welcome, {studentName}!");

                            // Stop and dispose the timer before transitioning
                            timer1.Stop();
                            timer1.Dispose();

                            // Open the Student form
                            Student studentForm = new Student(studentId);
                            studentForm.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Invalid Student ID or password.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error during login: " + ex.Message);
                }
            }
            else if (checkBox2.Checked) // Instructor
            {
                string password = textBox5.Text;

                if (password == "visual")
                {
                    MessageBox.Show("Login successful. Welcome, Instructor!");

                    // Stop and dispose the timer before transitioning
                    timer1.Stop();
                    timer1.Dispose();

                    // Open the Instructor form
                    Instructor instructorForm = new Instructor();
                    instructorForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid Instructor password.");
                }
            }
            else if (checkBox3.Checked) // Visitor
            {
                MessageBox.Show("Welcome, Visitor!");

                // Stop and dispose the timer before transitioning
                timer1.Stop();
                timer1.Dispose();

                // Open the Visitor form
                visitor visitorForm = new visitor();
                visitorForm.Show();
                this.Hide();
            }
        }

        private bool ValidateCheckboxes()
        {
            // Ensure only one checkbox is checked
            int checkedCount = 0;
            if (checkBox1.Checked) checkedCount++;
            if (checkBox2.Checked) checkedCount++;
            if (checkBox3.Checked) checkedCount++;

            return checkedCount == 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private int timeLeft = 60;

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Decrement the time left
            timeLeft--;

            // Update the label to show the remaining time in mm:ss format
            labelTimer.Text = $"{timeLeft / 60:D2}:{timeLeft % 60:D2}";

            // If time runs out, terminate the application
            if (timeLeft <= 0)
            {
                timer1.Stop(); // Stop the timer
                MessageBox.Show("Time is up! The application will now terminate.", "Timeout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Application.Exit(); // Terminate the application
            }
        }

        private void login_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Stop and dispose the timer to prevent it from running after the form is closed
            if (timer1 != null)
            {
                timer1.Stop();
                timer1.Dispose();
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            // Optional: Validate Student ID format in real-time
            if (!string.IsNullOrEmpty(textBox4.Text) && !int.TryParse(textBox4.Text, out _))
            {
                MessageBox.Show("Student ID must be a number.");
                textBox4.Clear();
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            // Optional: Mask password input for better security
            textBox5.PasswordChar = '*';
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void labelTimer_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
