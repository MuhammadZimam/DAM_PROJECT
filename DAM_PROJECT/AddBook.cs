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

namespace DAM_PROJECT
{
    public partial class AddBook : Form
    {
        public AddBook()
        {
            InitializeComponent();
            comboBoxtype.DropDownStyle = ComboBoxStyle.DropDownList; // Make it readonly

            // Set default selected value
            comboBoxtype.SelectedIndex = 0;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBoxtitle.Text == "")
            {
                MessageBox.Show("Enter title");
            }
            else if (textBoxauthor.Text == "")
            {
                MessageBox.Show("Enter Author");
            }
            else if (textBoxisbn.Text == "")
            {
                MessageBox.Show("Enter ISBN");
            }
            else if (textBoxqty.Text == "")
            {
                MessageBox.Show("Enter quantity");

            }
            else if (textBoxprice.Text == "")
            {
                MessageBox.Show("Enter Price");
            }
            else
            {
                string connectionString = "Data Source=DESKTOP-B2SBOMN\\SQLEXPRESS01;Initial Catalog=DAM;Integrated Security=True;Encrypt=False";


                string title = textBoxtitle.Text;
                string author = textBoxauthor.Text;
                string isbn = textBoxisbn.Text;
                int quantity = int.Parse(textBoxqty.Text);
                string type = comboBoxtype.SelectedItem.ToString();

                float price = float.Parse(textBoxprice.Text);


                string sql = "EXEC Insert_Book @title, @author, @isbn, @quantity, @type, @price";


                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {

                        command.Parameters.AddWithValue("@title", title);
                        command.Parameters.AddWithValue("@author", author);
                        command.Parameters.AddWithValue("@isbn", isbn);
                        command.Parameters.AddWithValue("@quantity", quantity);
                        command.Parameters.AddWithValue("@type", type);
                        command.Parameters.AddWithValue("@price", price);

                        try
                        {

                            connection.Open();


                            command.ExecuteNonQuery();
                            MessageBox.Show("Book added successfully!");
                            textBoxauthor.Clear();

                            textBoxisbn.Clear();
                            textBoxprice.Clear();
                            textBoxqty.Clear();
                            textBoxtitle.Clear();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                        }
                    }

                }
            }

        }

        private void label7_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            this.Close();
            form.Show();
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
            Adduser adduser = new Adduser();
            this.Hide();
            adduser.Show();
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