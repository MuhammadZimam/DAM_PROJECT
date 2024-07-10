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
    public partial class Deleteuser : Form
    {
        public Deleteuser()
        {
            InitializeComponent();
        }
        string connectionString = "Data Source=DESKTOP-B2SBOMN\\SQLEXPRESS01;Initial Catalog=DAM;Integrated Security=True;Encrypt=False";


        private void button9_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            try
            {

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

        private void e(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                try
                {
                    string connectionString = "Data Source=DESKTOP-B2SBOMN\\SQLEXPRESS01;Initial Catalog=DAM;Integrated Security=True;Encrypt=False";


                    int ID = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["ID"].Value.ToString());


                    string sql = "DELETE FROM Users WHERE ID = @ID";


                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {

                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {

                            command.Parameters.AddWithValue("ID", ID);


                            connection.Open();


                            command.ExecuteNonQuery();


                            dataGridView1.Rows.RemoveAt(e.RowIndex);

                            MessageBox.Show("User deleted successfully!");
                        }
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
    }
}