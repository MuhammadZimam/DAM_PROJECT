using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DAM_PROJECT
{
    public partial class Adduser : Form
    {
        public Adduser()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            this.Close();
            form.Show();
        }
        private void InsertUser(string name, int id, string email, string phoneNo)
        {
            string connectionString = "Data Source=DESKTOP-B2SBOMN\\SQLEXPRESS01;Initial Catalog=DAM;Integrated Security=True;Encrypt=False";

            if (textBoxname.Text == "")
            {
                MessageBox.Show("Enter Name");
            }
            else if (textBoxID.Text == "")
            {
                MessageBox.Show("Enter ID");
            }
            else if (textBoxemail.Text == "")
            {
                MessageBox.Show("Enter Email");
            }
            else if (textBoxphno.Text == "")
            {
                MessageBox.Show("Enter Phone no");
            }
            else
            {
                string emailpattern = @"^[a-zA-Z0-9_.+-]+@gmail\.com$";
                if (Regex.IsMatch(textBoxemail.Text, emailpattern))
                {
                    string phnoPattern = @"^.{11,11}$";
                    if (Regex.IsMatch(textBoxphno.Text, phnoPattern))
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {

                            string procedureName = "InsertUser";


                            using (SqlCommand command = new SqlCommand(procedureName, connection))
                            {

                                command.CommandType = System.Data.CommandType.StoredProcedure;


                                command.Parameters.AddWithValue("@Name", name);
                                command.Parameters.AddWithValue("@ID", id);
                                command.Parameters.AddWithValue("@Email", email);
                                command.Parameters.AddWithValue("@PhoneNo", phoneNo);

                                try
                                {

                                    connection.Open();


                                    command.ExecuteNonQuery();
                                    textBoxname.Clear();
                                    textBoxID.Clear();
                                    textBoxemail.Clear();
                                    textBoxphno.Clear();
                                    MessageBox.Show("User Inserted");
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Error inserting user: " + ex.Message);
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid Phoneno");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Email");
                }


                    
            }
        }
        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                string name = textBoxname.Text;
                int id = int.Parse(textBoxID.Text);
                string email = textBoxemail.Text;
                string phoneNo = textBoxphno.Text;


                InsertUser(name, id, email, phoneNo);


                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddBook addbook = new AddBook();
            this.Hide();
            addbook.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ViewBooks viewBooks = new ViewBooks();
            this.Hide();
            viewBooks.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {


            DeleteBooks delete = new DeleteBooks();
            this.Close();
            delete.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Deleteuser deleteuser = new Deleteuser();
            this.Close();
            deleteuser.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            BuyedBooks buyed = new BuyedBooks();
            this.Close();
            buyed.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ReturnedBooks returned = new ReturnedBooks();
            this.Close();
            returned.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            BooktoUser booktoUser = new BooktoUser();
            this.Hide();
            booktoUser.Show();
        }
    }
}
