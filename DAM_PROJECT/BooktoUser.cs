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
    public partial class BooktoUser : Form
    {
        public BooktoUser()
        {
            InitializeComponent();
            
            
        }
        public string isbn { get; set; }
        public string title { get; set; }
        public int price { get; set; }

        private void label7_Click(object sender, EventArgs e)
        {
            AssignBook assignBook = new AssignBook();
            this.Close();
            assignBook.Show();
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
                    if (radioButtonname.Checked)
                        searchCriteria = "Name";
                    else if (radioButtonID.Checked)
                        searchCriteria = "ID";


                    string sql = $"SELECT * FROM users WHERE {searchCriteria} LIKE '%' + @searchText + '%'";


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

        private void button7_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            try
            {
                string connectionString = "Data Source=DESKTOP-B2SBOMN\\SQLEXPRESS01;Initial Catalog=DAM;Integrated Security=True;Encrypt=False";


                string sql = "SELECT * FROM Users";


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
        public void ReceiveValuesFromAssignBook(string isbn, string title, int price)
        {
            this.isbn = isbn;
            this.title = title;
            this.price = price;

            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {

                string userid = dataGridView1.Rows[e.RowIndex].Cells["ID"].Value.ToString();
                string name= dataGridView1.Rows[e.RowIndex].Cells["Name"].Value.ToString();
               
                textBoxid.Text = userid;
                
                textBoxname.Text = name;
                AssignBook assignBook = new AssignBook();
                textBoxtitle.Text = title;
                textBoxisbn.Text = isbn;


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "Data Source=DESKTOP-B2SBOMN\\SQLEXPRESS01;Initial Catalog=DAM;Integrated Security=True;Encrypt=False";


                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    string sql = "SELECT * FROM Book";


                    SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);


                    DataTable dt = new DataTable();


                    adapter.Fill(dt);


                    dataGridView2.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                MessageBox.Show("Enter Value");
            }
            else
            {
                try
                {
                    string connectionString = "Data Source=DESKTOP-B2SBOMN\\SQLEXPRESS01;Initial Catalog=DAM;Integrated Security=True;Encrypt=False";
                    string searchCriteria = "";
                    if (radioButtonisbn.Checked)
                        searchCriteria = "isbn";
                    else if (radioButtontitle.Checked)
                        searchCriteria = "title";
                    else if (radioButtonauthor.Checked)
                        searchCriteria = "author";
                    string sql = $"SELECT * FROM Book WHERE {searchCriteria} LIKE '%' + @searchText + '%'";


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

        private void e(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {

                isbn = dataGridView2.Rows[e.RowIndex].Cells["ISBN"].Value.ToString();
                title = dataGridView2.Rows[e.RowIndex].Cells["Title"].Value.ToString();
                price = int.Parse(dataGridView2.Rows[e.RowIndex].Cells["Price"].Value.ToString());

                textBoxisbn.Text = isbn;
                textBoxtitle.Text = title;
                textBoxprice.Text = price.ToString();
                



                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-B2SBOMN\\SQLEXPRESS01;Initial Catalog=DAM;Integrated Security=True;Encrypt=False";


            string userid = textBoxid.Text;
            string name = textBoxname.Text;
            string isbn = textBoxisbn.Text;
            string title = textBoxtitle.Text;
            int pricePerDay = int.Parse(textBoxprice.Text); // Assuming this is where you enter price per day

            // Calculate assign date (current date and time)
            DateTime assignDate =DateTime.Parse( dateTimePicker1.Text);

            // Calculate return date (assign date + 14 days as an example)
            DateTime returnDate = DateTime.Parse(dateTimePicker2.Text); // Change this to your desired number of days

            // Calculate total price
            TimeSpan duration = returnDate - assignDate;
            int totalDays = (int)duration.TotalDays;
            int totalPrice = totalDays * pricePerDay;

            // Insert into database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO BuyedBooks (UserID, UserName, ISBN,BookTitle, BuyedDate, ReturnedDate,  Price) " +
                               "VALUES (@UserID, @Name, @ISBN, @Title, @AssignDate, @ReturnDate, @Price)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserID", userid);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@ISBN", isbn);
                command.Parameters.AddWithValue("@Title", title);
                command.Parameters.AddWithValue("@AssignDate", assignDate);
                command.Parameters.AddWithValue("@ReturnDate", returnDate);
                
                command.Parameters.AddWithValue("@Price", totalPrice);
                if (assignDate<returnDate)
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    string query1 = "Update Book set Quantity=Quantity-1";
                    SqlCommand cmd = new SqlCommand(query1, connection);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Book Assigned");
                }
                else
                {
                    MessageBox.Show("Enter Valid Return date");
                }
               

                
            }
        }
    }
}