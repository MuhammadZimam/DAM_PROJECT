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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace DAM_PROJECT
{
    public partial class Signup : Form
    {
        public Signup()
        {
            InitializeComponent();
        }

        string constring = "Data Source=DESKTOP-B2SBOMN\\SQLEXPRESS01;Initial Catalog=DAM;Integrated Security=True;Encrypt=False";
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxemail.Text == "")
            {
                MessageBox.Show("Enter Email");
            }
            else if (textBoxname.Text == "")
            {
                MessageBox.Show("Enter Name");
            }
            else if (textBoxpassword.Text == "")
            {
                MessageBox.Show("Enter Password");

            }
            else if (textBoxcpassword.Text == "")
            {
                MessageBox.Show("Enter Password");
            }
            else if (textBoxcpassword.Text != textBoxpassword.Text)
            {
                MessageBox.Show("Password Isnt Matching");
            }
            else
            {
                string emailpattern = @"^[a-zA-Z0-9_.+-]+@gmail\.com$";
                if (Regex.IsMatch(textBoxemail.Text, emailpattern))
                {
                    string passwordPattern = @"^.{4,}$";
                    if (Regex.IsMatch(textBoxpassword.Text, passwordPattern))
                    {
                        using (SqlConnection connection = new SqlConnection(constring))
                        {
                            connection.Open();

                            SqlCommand command = new SqlCommand("insert_signup", connection);
                            command.CommandType = CommandType.StoredProcedure;

                            command.Parameters.AddWithValue("@name", textBoxname.Text);
                            command.Parameters.AddWithValue("@email", textBoxemail.Text);
                            command.Parameters.AddWithValue("@password", textBoxpassword.Text);

                            command.ExecuteNonQuery();

                            MessageBox.Show("Signup successfull.");

                            connection.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Password must be more than 3 digits");
                    }

                        
                }
                else
                {
                    MessageBox.Show("Invalid Email");
                }
               
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Close();
            form1.Show();
        }
    }
}
