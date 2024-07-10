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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace DAM_PROJECT
{
    public partial class ReturnedBooks : Form
    {
        public ReturnedBooks()
        {
            InitializeComponent();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-B2SBOMN\\SQLEXPRESS01;Initial Catalog=DAM;Integrated Security=True;Encrypt=False";



            try
            {
                dataGridView1.Rows.Clear();
                string sql = "SELECT * FROM ReturnedBooks";


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
                        searchCriteria = "Name";
                    else if (radioButtonisbn.Checked)
                        searchCriteria = "ISBN";



                    string sql = $"SELECT * FROM ReturnedBooks WHERE {searchCriteria} LIKE '%' + @searchText + '%'";


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

        private void button11_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-B2SBOMN\\SQLEXPRESS01;Initial Catalog=DAM;Integrated Security=True;Encrypt=False";



            try
            {
                dataGridView1.Rows.Clear();
                
                DateTime d1 = DateTime.Now;
                


                SqlDataAdapter adapter = new SqlDataAdapter("exec returnDate '"+d1+"'", connectionString);


                DataTable dt = new DataTable();


                adapter.Fill(dt);


                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message);
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

        private void button7_Click(object sender, EventArgs e)
        {
            BuyedBooks buyed = new BuyedBooks();
            this.Close();
            buyed.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            BooktoUser booktoUser = new BooktoUser();
            this.Hide();
            booktoUser.Show();
        }
    }
}
