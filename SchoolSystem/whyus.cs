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
    public partial class whyus : Form
    {
        public whyus()
        {
            InitializeComponent();
        }

        private void whyus_Load(object sender, EventArgs e)
        {
            // Define Why Us features dynamically
            var features = new[]
            {
        new
        {
            Title = "Experienced Faculty",
            Description = "Our educators are industry leaders with over 20 years of experience, dedicated to providing personalized learning opportunities that prepare students for the future."
        },
        new
        {
            Title = "Modern Facilities",
            Description = "Our state-of-the-art labs, smart classrooms, and well-equipped libraries provide the perfect environment for learning, innovation, and creativity."
        },
        new
        {
            Title = "Global Partnerships",
            Description = "We collaborate with top universities worldwide to offer exchange programs, joint research projects, and global internships for our students."
        },
        new
        {
            Title = "Holistic Education",
            Description = "We focus on the all-around development of our students by integrating academics with extracurricular activities, leadership programs, and community involvement."
        },
        new
        {
            Title = "Excellent Placement Opportunities",
            Description = "With strong industry connections, we boast a 95% placement rate, ensuring our graduates secure roles in top companies globally."
        }
    };

            // Create a FlowLayoutPanel dynamically
            FlowLayoutPanel flowLayoutPanelWhyUs = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                WrapContents = true,
                Padding = new Padding(10),
                BackColor = Color.White
            };
            this.Controls.Add(flowLayoutPanelWhyUs);

            // Dynamically generate cards
            foreach (var feature in features)
            {
                // Create a panel for each card
                Panel card = new Panel
                {
                    Width = 320,
                    Height = 180,
                    Margin = new Padding(10),
                    BackColor = Color.LightGray,
                    BorderStyle = BorderStyle.FixedSingle
                };

                // Add a title label
                Label titleLabel = new Label
                {
                    Text = feature.Title,
                    Font = new Font("Arial", 16, FontStyle.Bold),
                    AutoSize = false,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Top,
                    Height = 50,
                    ForeColor = Color.DarkBlue
                };
                card.Controls.Add(titleLabel);

                // Add a description label
                Label descriptionLabel = new Label
                {
                    Text = feature.Description,
                    Font = new Font("Arial", 12, FontStyle.Regular),
                    AutoSize = false,
                    TextAlign = ContentAlignment.TopCenter,
                    Dock = DockStyle.Fill,
                    Padding = new Padding(10),
                    ForeColor = Color.Black
                };
                card.Controls.Add(descriptionLabel);

                // Add the card to the FlowLayoutPanel
                flowLayoutPanelWhyUs.Controls.Add(card);
            }
            
            }
        }
    }
    

