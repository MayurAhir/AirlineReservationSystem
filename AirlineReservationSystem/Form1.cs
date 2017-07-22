using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

    

namespace AirlineReservationSystem
{
    public partial class Form1 : Form
    {

        SqlCommand cmd = new SqlCommand();
        SqlConnection con = new SqlConnection(@"server=LENOVO-PC\SQLEXPRESS;database=airline;Trusted_Connection=True");

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                var uname = textBox1.Text;
                var pass = textBox2.Text;

                con.Open();
                SqlCommand cmd = new SqlCommand("select username,password1 from users", con);
                SqlDataReader dr = cmd.ExecuteReader();
                string un;
                string pas;
                dr.Read();
                un = dr.GetValue(0).ToString();
                pas = dr.GetValue(1).ToString();
                if (un == uname && pas == pass)
                {
                    // Reservation p1 = new Reservation();
                    welcompage w1 = new welcompage(un);
                    w1.Show();
                    //p1.Show();
                    Form1 f1 = new Form1();

                    this.Hide();

                }
                else
                {
                    MessageBox.Show("you are not valid user !!!!!!");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    con.Close();
                }
            }
            else
                MessageBox.Show("Please enter valid details");
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            BackgroundImageLayout = ImageLayout.Stretch;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;

        }

       

    }
}
