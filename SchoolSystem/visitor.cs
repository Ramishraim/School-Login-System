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
    public partial class visitor : Form
    {
        public visitor()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AcademicCalendar academicCalendarForm = new AcademicCalendar();
            academicCalendarForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fees feesForm = new fees();
            feesForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            curriculum curriculumForm = new curriculum();
            curriculumForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
           whyus whyusForm = new whyus();
            whyusForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void visitor_Load(object sender, EventArgs e)
        {

        }
    }
}
