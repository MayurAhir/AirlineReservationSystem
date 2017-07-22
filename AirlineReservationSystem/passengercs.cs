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
    public partial class passengercs : Form
    {
        SqlConnection con = new SqlConnection(@"server=LENOVO-PC\SQLEXPRESS;database=airline;Trusted_Connection=True");
        public passengercs()
        {
            InitializeComponent();
        }

        private void passengercs_Load(object sender, EventArgs e)
        {
            BackgroundImageLayout = ImageLayout.Stretch;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            con.Open();


            string cmbn = "select p.p_id,p.fname,p.lname,p.city,p.state1,p.country,p.passport_no,p.dob,r.sourc,r.destination,r.booking_dt,r.traveldate,t.t_type,t.price,c.aircraft,c.airline,c.flighttime,c.departure,c.arrival,c.travel_hours from passenger p inner join reservation r on p.p_id=r.p_id inner join ticket t on t.t_id=r.t_id inner join conflight c on  c.cf_no=r.cf_no where p.passport_no='" + textBox1.Text + "';select p.p_id,p.fname,p.lname,p.city,p.state1,p.country,p.passport_no,p.dob,r.sourc,r.destination,r.booking_dt,r.traveldate,t.t_type,t.price,f.aircraft,f.airline,f.flighttime,f.departure,f.arrival,f.travel_hours from passenger p inner join reservation r on p.p_id=r.p_id inner join ticket t on t.t_id=r.t_id inner join flight f on  f.f_no=r.f_no where p.passport_no='" + textBox1.Text + "'";
            SqlCommand cmd = new SqlCommand(cmbn, con);

         //   SqlCommand cmd = new SqlCommand("select p.p_id,p.fname,p.lname,p.city,p.state1,p.country,p.passport_no,p.dob,r.sourc,r.destination,r.booking_dt,r.traveldate,t.t_type,t.price,f.aircraft,f.airline,f.flighttime,f.departure,f.arrival,f.travel_hours from passenger p inner join reservation r on p.p_id=r.p_id inner join ticket t on t.t_id=r.t_id inner join flight f on  f.f_no=r.f_no where p.passport_no='" + textBox1.Text + "'", con);

            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                con.Close();

                MessageBox.Show("query exe");
                con.Open();

                string cmbn1 = "select p.p_id,p.fname,p.lname,p.city,p.state1,p.country,p.passport_no,p.dob,r.sourc,r.destination,r.booking_dt,r.traveldate,t.t_type,t.price,c.aircraft,c.airline,c.flighttime,c.departure,c.arrival,c.travel_hours from passenger p inner join reservation r on p.p_id=r.p_id inner join ticket t on t.t_id=r.t_id inner join conflight c on  c.cf_no=r.cf_no where p.passport_no='" + textBox1.Text + "';select p.p_id,p.fname,p.lname,p.city,p.state1,p.country,p.passport_no,p.dob,r.sourc,r.destination,r.booking_dt,r.traveldate,t.t_type,t.price,f.aircraft,f.airline,f.flighttime,f.departure,f.arrival,f.travel_hours from passenger p inner join reservation r on p.p_id=r.p_id inner join ticket t on t.t_id=r.t_id inner join flight f on  f.f_no=r.f_no where p.passport_no='" + textBox1.Text + "'";

                SqlCommand cmd1 = new SqlCommand(cmbn1, con);

                SqlDataAdapter da = new SqlDataAdapter(cmd1);
                DataTable dt = new DataTable();
                
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                MessageBox.Show("done");
            }  
            else{

                con.Close();
                con.Open();
             SqlCommand cmd1 = new SqlCommand("select p.p_id,p.fname,p.lname,p.city,p.state1,p.country,p.passport_no,p.dob,r.sourc,r.destination,r.booking_dt,r.traveldate,t.t_type,t.price,f.aircraft,f.airline,f.flighttime,f.departure,f.arrival,f.travel_hours from passenger p inner join reservation r on p.p_id=r.p_id inner join ticket t on t.t_id=r.t_id inner join flight f on  f.f_no=r.f_no where p.passport_no='" + textBox1.Text + "'", con);

               // SqlCommand cmdc = new SqlCommand("select p.p_id,p.fname,p.lname,p.city,p.state1,p.country,p.passport_no,p.dob,r.sourc,r.destination,r.booking_dt,r.traveldate,t.t_type,t.price,c.aircraft,c.airline,c.flighttime,c.departure,c.arrival,c.travel_hours from passenger p inner join reservation r on p.p_id=r.p_id inner join ticket t on t.t_id=r.t_id inner join conflight c on  c.cf_no=r.cf_no where p.passport_no='" + textBox1.Text + "'", con);

               // con.Open();
                SqlDataReader drc = cmd.ExecuteReader();
                drc.Read();
                if (drc.HasRows)
                {
                    con.Close();
                    con.Open();
                    SqlCommand cmd2 = new SqlCommand("select p.p_id,p.fname,p.lname,p.city,p.state1,p.country,p.passport_no,p.dob,r.sourc,r.destination,r.booking_dt,r.traveldate,t.t_type,t.price,c.aircraft,c.airline,c.flighttime,c.departure,c.arrival,c.travel_hours from passenger p inner join reservation r on p.p_id=r.p_id inner join ticket t on t.t_id=r.t_id inner join conflight c on  c.cf_no=r.cf_no where p.passport_no='" + textBox1.Text + "'", con);
                    SqlDataAdapter da1 = new SqlDataAdapter(cmd2);
                    DataTable dt1 = new DataTable();
                    da1.Fill(dt1);
                

                    dataGridView1.DataSource = dt1;

                   
                    con.Close();
                }
                else
                {
                    con.Close();
                    con.Open();
                     SqlCommand cmd12 = new SqlCommand("select p.p_id,p.fname,p.lname,p.city,p.state1,p.country,p.passport_no,p.dob,r.sourc,r.destination,r.booking_dt,r.traveldate,t.t_type,t.price,f.aircraft,f.airline,f.flighttime,f.departure,f.arrival,f.travel_hours from passenger p inner join reservation r on p.p_id=r.p_id inner join ticket t on t.t_id=r.t_id inner join flight f on  f.f_no=r.f_no where p.passport_no='" + textBox1.Text + "'", con);

                    SqlDataReader dr12 = cmd12.ExecuteReader();
                    dr12.Read();
                    if (dr12.HasRows)
                    {

                        con.Close();
                        con.Open();
                        SqlCommand cmd2 = new SqlCommand("select p.p_id,p.fname,p.lname,p.city,p.state1,p.country,p.passport_no,p.dob,r.sourc,r.destination,r.booking_dt,r.traveldate,t.t_type,t.price,f.aircraft,f.airline,f.flighttime,f.departure,f.arrival,f.travel_hours from passenger p inner join reservation r on p.p_id=r.p_id inner join ticket t on t.t_id=r.t_id inner join flight f on  f.f_no=r.f_no where p.passport_no='" + textBox1.Text + "'", con);
                        SqlDataAdapter da = new SqlDataAdapter(cmd2);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                        con.Close();
                    }
                    else
                    {
                        MessageBox.Show("No Data Exist With This Passport Number ");
                        con.Close();
                    }
                }
               
            }
            /*else
            {
                
                con.Open();
                SqlCommand cmd2 = new SqlCommand("select p.p_id,p.fname,p.lname,p.city,p.state1,p.country,p.passport_no,p.dob,r.sourc,r.destination,r.booking_dt,r.traveldate,t.t_type,t.price,c.aircraft,c.airline,c.flighttime,c.departure,c.arrival,c.travel_hours from passenger p inner join reservation r on p.p_id=r.p_id inner join ticket t on t.t_id=r.t_id inner join conflight c on  c.cf_no=r.cf_no where p.passport_no='" + textBox1.Text + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd2);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }*/

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int m=0,b=0,a=0;
            con.Open();
            SqlCommand cmd1 = new SqlCommand("select sum(travel_hours) from flight where aircraft = '" + textBox2.Text + "' and (flighttime >='" +dateTimePicker3.Value + "' and flighttime <= '" + dateTimePicker4.Value + "')", con);
            SqlDataReader dr = cmd1.ExecuteReader();
            dr.Read();
            if (!dr.HasRows)
            {
                MessageBox.Show("no data in fl");
                con.Close();
            }
            else
            {
                  int.TryParse((dr.GetValue(0).ToString()),out m);
                con.Close();
            }
         
            con.Open();
            SqlCommand cmd2 = new SqlCommand("select sum(travel_hours) from conflight where aircraft = '" + textBox2.Text + "' and (flighttime >='" + dateTimePicker3.Value + "' and flighttime <= '" + dateTimePicker4.Value + "')", con);
            SqlDataReader dr2 = cmd2.ExecuteReader();
            dr2.Read();
            if (!dr2.HasRows)
            {
                MessageBox.Show("no data in cf");
                con.Close();
            }
            else
            {
                int.TryParse((dr2.GetValue(0).ToString()),out a);
                con.Close();
            }
            con.Open();
            SqlCommand cmd3 = new SqlCommand("select sum(travel_hours) from destflight where aircraft = '" + textBox2.Text + "' and (flighttime >='" + dateTimePicker3.Value + "' and flighttime <= '" +dateTimePicker4.Value + "')", con);
            SqlDataReader dr3 = cmd3.ExecuteReader();
            dr3.Read();
            if(!dr3.HasRows)
            {
                MessageBox.Show("no data");
                con.Close();
            }
            else
            {

              int.TryParse((dr3.GetValue(0).ToString()),out b);
                con.Close();
            }
            int s = a + b + m;
            textBox4.Text = s.ToString();
            con.Close();




        }

        
        private void button3_Click(object sender, EventArgs e)
        {
            int m = 0, b = 0, a = 0;
            con.Open();
            SqlCommand cmd1 = new SqlCommand("select count(aircraft) from flight where airline='" + textBox2.Text + "'", con);
            SqlDataReader dr = cmd1.ExecuteReader();
            dr.Read();
            if (!dr.HasRows)
            {
                MessageBox.Show("no data in fl");
                con.Close();
            }
            else
            {
           
                int.TryParse((dr.GetValue(0).ToString()),out m);
                con.Close();
            }

            con.Open();
            SqlCommand cmd2 = new SqlCommand("select count(aircraft) from conflight where airline='" + textBox2.Text + "'", con); 
            SqlDataReader dr2 = cmd2.ExecuteReader();
            dr2.Read();
            if (!dr2.HasRows)
            {
                MessageBox.Show("no data in cf");
                con.Close();
            }
            else
            {

        
                int.TryParse((dr2.GetValue(0).ToString()), out a);
                con.Close();
            }
            con.Open();
            SqlCommand cmd3 = new SqlCommand("select count(aircraft) from destflight where airline='" + textBox2.Text + "'", con); 
            SqlDataReader dr3 = cmd3.ExecuteReader();
            dr3.Read();
            if (!dr3.HasRows)
            {
                MessageBox.Show("no data");
                con.Close();
            }
            else
            {

                
                int.TryParse((dr3.GetValue(0).ToString()), out b);
                con.Close();
            }
            int s = a + b + m;
            textBox4.Text = s.ToString();
            con.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int m = 0,b=0,a=0;
            con.Open();
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            DateTime dt1 = dateTimePicker1.Value;
            string sdt = dt1.ToString();

            DateTime dt2 = dateTimePicker2.Value;
            string sdt2 = dt2.ToString();

            string qry = "select sum(f.travel_hours) from passenger p inner join reservation r on p.p_id = r.p_id inner join flight f on f.f_no = r.f_no where p.passport_no ='" + textBox1.Text + "' and (f.flighttime >='" +sdt+ "' and f.flighttime <= '" + sdt2 + "');";
            SqlCommand cmd = new SqlCommand(qry, con);
            SqlDataReader dr12 = cmd.ExecuteReader();
            dr12.Read();

            if (!dr12.HasRows)
            {
               
                con.Close();
            }
            else
            {


                int.TryParse((dr12.GetValue(0).ToString()), out m);
                con.Close();
            }

                con.Open();
            
                SqlCommand cmdcon = new SqlCommand("select sum(c.travel_hours) from passenger p inner join reservation r on p.p_id = r.p_id inner join conflight c on c.cf_no = r.cf_no where p.passport_no ='" + textBox1.Text + "' and (c.flighttime >='" + sdt + "' and c.flighttime <= '" + sdt2 + "')", con); 
                SqlDataReader drcon = cmdcon.ExecuteReader();
                drcon.Read();

            if (!drcon.HasRows)
            {
                MessageBox.Show("no data");
                con.Close();
            }
            else
            {


                int.TryParse((drcon.GetValue(0).ToString()), out b);
                con.Close();
            }
            con.Open();
            SqlCommand cmddf = new SqlCommand("select sum(d.travel_hours) from passenger p inner join reservation r on p.p_id = r.p_id inner join conflight c on c.cf_no=r.cf_no inner join destflight d on d.df_no=c.df_no where p.passport_no ='" + textBox1.Text + "' and (d.flighttime >='" + sdt + "' and d.flighttime <= '" + sdt2 + "')", con);
            SqlDataReader drdf = cmddf.ExecuteReader();
            drdf.Read();



            if (!drdf.HasRows)
            {
                MessageBox.Show("no data");
                con.Close();
            }
            else
            {


                int.TryParse((drdf.GetValue(0).ToString()), out a);
                con.Close();
            }
      
                int s = m+b+a;
                textBox3.Text = s.ToString();


                con.Close();


            textBox3.Text = s.ToString();
                con.Close();
            


            
        }

        private void button5_Click(object sender, EventArgs e)
        {

            int m = 0, b = 0, a = 0;
            con.Open();
            SqlCommand cmd1 = new SqlCommand("select sum(travel_hours) from flight where airline = '" + textBox2.Text + "' and (flighttime >='" + dateTimePicker3.Value + "' and flighttime <= '" + dateTimePicker4.Value + "')", con);
            SqlDataReader dr = cmd1.ExecuteReader();
            dr.Read();
            if (!dr.HasRows)
            {
                MessageBox.Show("no data in fl");
                con.Close();
            }
            else
            {
                
                int.TryParse(dr.GetValue(0).ToString(), out m);
                con.Close();
            }

            con.Open();
            SqlCommand cmd2 = new SqlCommand("select sum(travel_hours) from conflight where airline = '" + textBox2.Text + "' and (flighttime >='" + dateTimePicker3.Value + "' and flighttime <= '" + dateTimePicker4.Value + "')", con);
            SqlDataReader dr2 = cmd2.ExecuteReader();
            dr2.Read();
            if (!dr2.HasRows)
            {
                MessageBox.Show("no data in cf");
                con.Close();
            }
            else
            {

                
                int.TryParse(dr2.GetValue(0).ToString(), out a);
                con.Close();
            }
            con.Open();
            SqlCommand cmd3 = new SqlCommand("select sum(travel_hours) from destflight where airline = '" + textBox2.Text + "' and (flighttime >='" + dateTimePicker3.Value + "' and flighttime <= '" + dateTimePicker4.Value + "')", con);
            SqlDataReader dr3 = cmd3.ExecuteReader();
            dr3.Read();
            if (!dr3.HasRows)
            {
                MessageBox.Show("no data");
                con.Close();
            }
            else
            {

               
                int.TryParse(dr3.GetValue(0).ToString(), out b);
                con.Close();
            }
            int s = a + b + m;
            textBox4.Text = s.ToString();
            con.Close();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            passenger2 p2 = new passenger2();
            p2.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            cancel c1 = new cancel();
            c1.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            welcompage w1 = new welcompage("");
            this.Hide();
            w1.Show();
            
        }
    }
}
