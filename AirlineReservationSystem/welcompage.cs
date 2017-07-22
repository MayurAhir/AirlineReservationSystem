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
    public partial class welcompage : Form
    {
        string nm;
        Timer tm = new Timer();
        SqlConnection con = new SqlConnection(@"server=LENOVO-PC\SQLEXPRESS;database=airline;Trusted_Connection=True");

        //inorder to show current time use timer().use timer interval method to set interval in milisecond
        //use tick event that invoke tm_tick method 
        public welcompage(string nm1)
        {
            InitializeComponent();
            nm = nm1;
        }

        private void welcompage_Load(object sender, EventArgs e)
        {
            BackgroundImageLayout = ImageLayout.Stretch;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            
            tm.Interval = 1000;
           tm.Tick += new EventHandler(tm_tick);
          
            tm.Start();

            dataGridView1.Visible = false;
            dataGridView2.Visible = false;


            DateTime cdt = DateTime.Now;
            string dat = cdt.ToString();
            string q1 = "select * from flight where updat='y'and delet is null  and flighttime>'" + dat + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(q1, con);

            SqlDataReader dr1 = cmd.ExecuteReader();
            dr1.Read();
            if (!dr1.HasRows)
            {
                con.Close();
                con.Open();

                string q2 = "select * from conflight where updat='y' and delet is null and flighttime>'" + dat + "'";
               
                SqlCommand cmd2 = new SqlCommand(q2, con);

                SqlDataReader dr2 = cmd.ExecuteReader();
                dr2.Read();
                if (!dr2.HasRows)
                {
                    con.Close();
                    con.Open();
                    string q3 = "select * from destflight where updat='y' and delet is null  and flighttime>'" + dat + "'";

                    SqlCommand cmd3 = new SqlCommand(q3, con);

                    SqlDataReader dr3 = cmd.ExecuteReader();
                    dr3.Read();

                    if (!dr3.HasRows)
                    {
                        con.Close();


                    }
                    else
                    {

                        SqlCommand cmdc3 = new SqlCommand("select * from destflight where updat='y' and delet is null  and flighttime>'" + dat + "'", con);
                        SqlDataAdapter sd3 = new SqlDataAdapter(cmdc3);
                        DataTable dt3 = new DataTable();
                        sd3.Fill(dt3);
                        dataGridView1.Visible = true;
                        dataGridView1.DataSource = dt3;
                        con.Close();



                    }


                }

                else
                {
                    SqlCommand cmdc2 = new SqlCommand("select * from conflight where updat='y'and flighttime>'" + dat + "'and delet is null ", con);
                    SqlDataAdapter sd2 = new SqlDataAdapter(cmdc2);
                    DataTable dt2 = new DataTable();
                    sd2.Fill(dt2);
                    dataGridView1.Visible = true;
                    dataGridView1.DataSource = dt2;
                    con.Close();


                }

            }
            else
            {
                con.Close();
                SqlCommand cmdc1 = new SqlCommand("select * from flight where updat='y'and flighttime>'" + dat + "'and delet is null ", con);
                SqlDataAdapter sd1 = new SqlDataAdapter(cmdc1);
                DataTable dt1 = new DataTable();
                sd1.Fill(dt1);
                dataGridView1.Visible = true;
                dataGridView1.DataSource = dt1;
                con.Close();

            }


            DateTime cdt1 = DateTime.Now;
            string dat1 = cdt1.ToString();
            string q11 = "select * from flight where  delet='y'  and flighttime>'" + dat + "'";
            con.Open();
            SqlCommand cmd1 = new SqlCommand(q11, con);

            SqlDataReader dr11 = cmd.ExecuteReader();
            dr11.Read();
            if (!dr11.HasRows)
            {
                con.Close();
                con.Open();

                string q21 = "select * from conflight where  delet='y' and flighttime>'" + dat + "'";

                SqlCommand cmd21 = new SqlCommand(q21, con);

                SqlDataReader dr21 = cmd.ExecuteReader();
                dr21.Read();
                if (!dr21.HasRows)
                {
                    con.Close();
                    con.Open();
                    string q31 = "select * from destflight where delet='y'  and flighttime>'" + dat + "'";

                    SqlCommand cmd31 = new SqlCommand(q31, con);

                    SqlDataReader dr31 = cmd.ExecuteReader();
                    dr31.Read();

                    if (!dr31.HasRows)
                    {
                        con.Close();


                    }
                    else
                    {

                        SqlCommand cmdc31 = new SqlCommand("select * from destflight where  delet='y'  and flighttime>'" + dat + "'", con);
                        SqlDataAdapter sd31 = new SqlDataAdapter(cmdc31);
                        DataTable dt31 = new DataTable();
                        sd31.Fill(dt31);
                        dataGridView2.Visible = true;
                        dataGridView2.DataSource = dt31;
                        con.Close();



                    }


                }

                else
                {
                    SqlCommand cmdc21 = new SqlCommand("select * from conflight where  flighttime>'" + dat + "'and delet='y' ", con);
                    SqlDataAdapter sd21 = new SqlDataAdapter(cmdc21);
                    DataTable dt21 = new DataTable();
                    sd21.Fill(dt21);
                    dataGridView2.Visible = true;
                    dataGridView2.DataSource = dt21;
                    con.Close();


                }

            }
            else
            {
                con.Close();
                SqlCommand cmdc11 = new SqlCommand("select * from flight where  flighttime>'" + dat + "'and delet='y' ", con);
                SqlDataAdapter sd11 = new SqlDataAdapter(cmdc11);
                DataTable dt11 = new DataTable();
                sd11.Fill(dt11);
                dataGridView2.Visible = true;
                dataGridView2.DataSource = dt11;
                con.Close();

            }

           
           

        }
        void tm_tick(object sender, EventArgs e)
        {
            label5.Text = DateTime.Now.ToShortTimeString();
            label6.Text = DateTime.Now.ToShortDateString();
            label2.Text = nm;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            checkstatusn ch1 = new checkstatusn(nm);
            ch1.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Reservation r1 = new Reservation();
            r1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            availabilityreservation av = new availabilityreservation(nm);
            av.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
            admincheck a1 = new admincheck();
            a1.Show();
            //this.Hide();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            passengercs p1 = new passengercs();
            p1.Show();
            this.Hide();
        }
    }
}
