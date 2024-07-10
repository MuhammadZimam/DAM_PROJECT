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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace DAM_PROJECT
{
    public partial class BuyedBooks : Form
    {
        public BuyedBooks()
        {
            InitializeComponent();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-B2SBOMN\\SQLEXPRESS01;Initial Catalog=DAM;Integrated Security=True;Encrypt=False";

            

            try
            {
                dataGridView1.Rows.Clear();
                string sql = "SELECT * FROM BuyedBooks";


                SqlDataAdapter adapter = new SqlDataAdapter(sql, connectionString);


                DataTable dt = new DataTable();


                adapter.Fill(dt);


                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Enter Value");
            }
            else
            {
                try
                {
                    string connectionString = "Data Source=DESKTOP-B2SBOMN\\SQLEXPRESS01;Initial Catalog=DAM;Integrated Security=True;Encrypt=False";
                    string searchCriteria = "";
                    if (radioButtonid.Checked)
                        searchCriteria = "UserID";
                    else if (radioButtontitle.Checked)
                        searchCriteria = "BookTitle";
                    else if (radioButtonisbn.Checked)
                        searchCriteria = "ISBN";



                    string sql = $"SELECT * FROM BuyedBooks WHERE {searchCriteria} LIKE '%' + @searchText + '%'";


                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {

                        SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);


                        adapter.SelectCommand.Parameters.AddWithValue("@searchText", textBox1.Text);


                        DataTable dt = new DataTable();


                        adapter.Fill(dt);


                        dataGridView1.DataSource = dt;
                        
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            this.Close();
            form.Show();
        }

        private void e(object sender, DataGridViewCellEventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-B2SBOMN\\SQLEXPRESS01;Initial Catalog=DAM;Integrated Security=True;Encrypt=False";


            string userid = dataGridView1.Rows[e.RowIndex].Cells["UserID"].Value.ToString();
            string name = dataGridView1.Rows[e.RowIndex].Cells["UserName"].Value.ToString();
            // Assuming this is where you enter price per day
            string isbn = dataGridView1.Rows[e.RowIndex].Cells["ISBN"].Value.ToString();
            string title = dataGridView1.Rows[e.RowIndex].Cells["BookTitle"].Value.ToString();
            int price =int.Parse( dataGridView1.Rows[e.RowIndex].Cells["Price"].Value.ToString());

            // Calculate assign date (current date and time)


            // Calculate return date (assign date + 14 days as an example)
            DateTime returnDate = DateTime.Parse(dataGridView1.Rows[e.RowIndex].Cells["ReturnedDate"].Value.ToString()); // Change this to your desired number of days

            

            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO ReturnedBooks (UserID, Name, ISBN,  ReturnDate,Price) " +
                               "VALUES (@UserID, @Name, @ISBN,  @ReturnDate,@Price)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserID", userid);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@ISBN", isbn);
                command.Parameters.AddWithValue("@Price", price);


                command.Parameters.AddWithValue("@ReturnDate", returnDate);

                
                
                    connection.Open();
                    command.ExecuteNonQuery();
                string query1 = "Update Book set Quantity=Quantity+1";
                SqlCommand cmd = new SqlCommand(query1, connection);
                cmd.ExecuteNonQuery();
                string query2 = $"Delete from BuyedBooks where ISBN={isbn}";
                SqlCommand cmd1 = new SqlCommand(query2, connection);
                cmd1.ExecuteNonQuery();
                
                connection.Close();
                
                    MessageBox.Show("Book Returned");
                



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
