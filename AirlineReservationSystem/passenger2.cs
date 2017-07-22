using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace AirlineReservationSystem
{
    public partial class passenger2 : Form
    {
        SqlConnection con = new SqlConnection(@"server=LENOVO-PC\SQLEXPRESS;database=airline;Trusted_Connection=True");

        public passenger2()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("select p.fname,p.lname from passenger p inner join reservation r on r.p_id=p.p_id  where r.destination ='"+textBox1.Text+"'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            bool m=dr.Read();
            con.Close();
        
            if (m!=true)
            {
                MessageBox.Show("no data here");
                con.Close();
            }
            else
            {
                con.Close();
                con.Open();
                SqlCommand cmd1 = new SqlCommand("select  p.fname,p.lname from passenger p inner join reservation r on r.p_id=p.p_id  where r.destination='" + textBox1.Text + "' and (r.traveldate>='"+dateTimePicker1.Value+"' and r.traveldate<='"+dateTimePicker2.Value+"' )", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd1);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                con.Close();
                

            }



        }

        private void button2_Click(object sender, EventArgs e)
        {

            con.Open();

            SqlCommand cmd = new SqlCommand("select f.aircraft from flight f where f.sourc!='" + textBox2.Text + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (!dr.HasRows)
            {
               
                con.Close();
                con.Open();
               SqlCommand cmd1 = new SqlCommand("select c.aircraft from conflight c where c.sourc!='" + textBox2.Text + "'", con);
                     SqlDataReader dr1 = cmd1.ExecuteReader();
                if (!dr1.HasRows)
                {
                 con.Close();
                 con.Open();
                 SqlCommand cmd12 = new SqlCommand("select c.aircraft from conflight c where c.sourc!='" + textBox2.Text + "'", con);
                 SqlDataAdapter da = new SqlDataAdapter(cmd12);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                     con.Close();

                }
                else
                {
                    MessageBox.Show("no such flight");
                }
       
                }
                else
                {

                    con.Close();
                    con.Open();
                    SqlCommand cmd1 = new SqlCommand("select  f.aircraft from flight f where f.sourc!='" + textBox2.Text + "'", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd1);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    con.Close();

            }


        }

        private void button3_Click(object sender, EventArgs e)
        {

            con.Close();
            con.Open();

            SqlCommand cmd = new SqlCommand("select f.airline from flight f where f.sourc='" + textBox2.Text + "'and f.destination='" + textBox5.Text + "'", con);

            SqlDataReader dr = cmd.ExecuteReader();
            if (!dr.HasRows)
            {
                con.Close();
                con.Open();
                SqlCommand cmdc = new SqlCommand("select  d.airline from conflight d where d.sourc='" + textBox2.Text + "'and (d.con_detination='" + textBox5.Text + "' or d.destination='"+textBox5.Text+"')"  , con);

                SqlDataReader drc = cmdc.ExecuteReader();
                drc.Read();
                if (drc.HasRows)
                {
                    con.Close();
                    con.Open();

                    SqlCommand cmd1 = new SqlCommand("select f.airline from conflight f where f.sourc='" + textBox2.Text + "'and (f.con_detination='" + textBox5.Text + "' or f.destination='" + textBox5.Text + "')", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd1);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    con.Close();
                }
                else
                {
                    MessageBox.Show("no flight for such root");

                }
            }

            else
            {

                con.Close();
                con.Open();
                SqlCommand cmd1 = new SqlCommand("select  f.airline from flight f where f.sourc='"+textBox2.Text+"'and f.destination='"+textBox5.Text+"'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd1);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();

            }




        }

        private void button4_Click(object sender, EventArgs e)
        {
            int m=0, b=0, a=0;
            string qr1 = "select min(travel_hours) from flight where sourc='" + textBox2.Text + "'and destination='" + textBox5.Text + "'";
            con.Close();
            con.Open();
            SqlCommand cmd1 = new SqlCommand(qr1,con);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            dr1.Read();
            
            if(dr1.HasRows)
            {
                int.TryParse(dr1.GetValue(0).ToString(), out m);


                con.Close();
            }



            if (m>0)
            {

                string qr12 = "select min(travel_hours) from flight where sourc='" + textBox2.Text + "'and destination='" + textBox5.Text + "'";
                con.Open();
                SqlCommand cmd12 = new SqlCommand(qr12, con);
                SqlDataReader dr12 = cmd12.ExecuteReader();
                dr12.Read();


                int.TryParse(dr12.GetValue(0).ToString(), out m);

                textBox6.Text = m.ToString();
                con.Close();
            }


            else
            {
                MessageBox.Show("you have to go with connecting flight");
                
                con.Open();
                string qr2 = "select min(travel_hours) from conflight where sourc='"+textBox2.Text+"'and con_detination='"+textBox5.Text+"'";
                SqlCommand cmd2 = new SqlCommand(qr2, con);
                SqlDataReader dr2 = cmd2.ExecuteReader();
                dr2.Read();
                if (dr2.HasRows)
                {

                    int.TryParse(dr2.GetValue(0).ToString(), out a);
                   // a = Convert.ToInt32(dr2.GetValue(0).ToString());
                    con.Close();

                    string qr3 = "select min(travel_hours) from destflight where sourc in ((select destination from conflight where con_detination='" + textBox5.Text + "')) and destination='" + textBox5.Text + "'";

                    con.Open();
                    SqlCommand cmd3 = new SqlCommand(qr3, con);
                    SqlDataReader dr3 = cmd3.ExecuteReader();
                    dr3.Read();
                    if (dr3.HasRows)
                    {
                        int.TryParse(dr3.GetValue(0).ToString(), out b);
                        con.Close();
                        int s = a + b+m;
                        textBox6.Text = s.ToString();

                    }
                    
                }
                else
                {
                    MessageBox.Show("no such flight");
                }






            }


        }

        private void button5_Click(object sender, EventArgs e)
        {
            con.Open();
            string m1 = "select destination from reservation group by destination having destination=(select MAX(destination) from reservation);";
            SqlCommand cmd = new SqlCommand(m1, con);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            textBox7.Text = dr.GetValue(0).ToString();
            con.Close();


        }

        private void passenger2_Load(object sender, EventArgs e)
        {
            BackgroundImageLayout = ImageLayout.Stretch;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            passengercs p1 = new passengercs();
            this.Hide();
            p1.Show();
            
        }
    }
    }
