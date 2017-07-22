using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AirlineReservationSystem
{
    public partial class admincheck : Form
    {

        SqlConnection conn = new SqlConnection(@"server=LENOVO-PC\SQLEXPRESS;database=airline;Trusted_Connection=True");
        public admincheck()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ad = "select username from users where username='" + textBox1.Text + "'and password1='" + textBox2.Text + "'and utype='a'";
     
            SqlCommand cmd = new SqlCommand(ad, conn);
            conn.Open();
            SqlDataReader dr=cmd.ExecuteReader();
            dr.Read();
            if(dr.HasRows)
            {
                conn.Close();
                admin a1 = new admin(textBox1.Text);
                a1.Show();
                this.Hide();

                welcompage w1 = new welcompage("");
                w1.Hide();
            }
            else
            {
                MessageBox.Show("Invalid user name and password");
                conn.Close();
                welcompage w1 = new welcompage(textBox1.Text);
                w1.Show();
                this.Hide();

            }
        }

        private void admincheck_Load(object sender, EventArgs e)
        {
            // BackgroundImageLayout = ImageLayout.Stretch;
            

           /* this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;*/

        }
    }
}