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
    public partial class DeleteBooks : Form
    {
        public DeleteBooks()
        {
            InitializeComponent();

        }

        private void button9_Click(object sender, EventArgs e)
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


                    dataGridView1.DataSource = dt;
                }
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

        private void label7_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            this.Close();
            form.Show();
        }

        private void e(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                try
                {
                    string connectionString = "Data Source=DESKTOP-B2SBOMN\\SQLEXPRESS01;Initial Catalog=DAM;Integrated Security=True;Encrypt=False";


                    string isbn = dataGridView1.Rows[e.RowIndex].Cells["ISBN"].Value.ToString();


                    string sql = "DELETE FROM Book WHERE ISBN = @isbn";


                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {

                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {

                            command.Parameters.AddWithValue("ISBN", isbn);


                            connection.Open();


                            command.ExecuteNonQuery();


                            dataGridView1.Rows.RemoveAt(e.RowIndex);

                            MessageBox.Show("Book deleted successfully!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
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
