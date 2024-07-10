using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAM_PROJECT
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            this.Close();
            form.Show();
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
