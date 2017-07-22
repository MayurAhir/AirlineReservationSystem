using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
namespace AirlineReservationSystem
{
    public partial class checkstatusn : Form
    {
        SqlCommand cmd;
        string nm1;

        //= new SqlCommand();

        SqlConnection con = new SqlConnection(@"server=LENOVO-PC\SQLEXPRESS;database=airline;Trusted_Connection=True");

        public checkstatusn( string nm)
        {
            nm1=nm;
            InitializeComponent();
        }

        private void checkstatusn_Load(object sender, EventArgs e)
        {
            BackgroundImageLayout = ImageLayout.Stretch;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker2.Format = DateTimePickerFormat.Short;
            label5.Visible = true;
            label6.Visible = true;
            dateTimePicker1.Visible = true;
            dateTimePicker2.Visible = true;
            dataGridView1.Visible = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" )
            {

                int ps = Convert.ToInt32(textBox2.Text);
                string nm = textBox1.Text;
                con.Close();
                con.Open();
                string qry = "select top 1(r.traveldate) from reservation r inner join passenger p on  p.p_id=r.p_id where p.passport_no='" + ps + "'";
                SqlCommand cmdf = new SqlCommand(qry, con);
                SqlDataReader drf = cmdf.ExecuteReader();
                int f = 0;

                drf.Read();
                if (drf.HasRows)
                {
                    //string dtf= drf.GetValue(0).ToString();
                    // Convert.ToDateTime(drf.GetValue(0).ToString())

                    //int m;
                    //int.TryParse((drf.GetValue(0).ToString()), out m);
                    if (Convert.ToDateTime(drf.GetValue(0).ToString()) > DateTime.Now)
                    {

                        con.Close();
                        // MessageBox.Show("data found");
                        con.Open();
                        SqlCommand cmd = new SqlCommand("select p.p_id,p.fname,p.lname,p.city,p.state1,p.country,p.passport_no,p.dob,r.sourc,r.destination,r.booking_dt,r.traveldate,t.t_type,t.price,f.aircraft,f.airline,f.flighttime,f.departure,f.arrival,f.travel_hours from passenger p inner join reservation r on p.p_id=r.p_id inner join ticket t on t.t_id=r.t_id inner join flight f on  f.f_no=r.f_no where p.fname='" + textBox1.Text + "'and p.passport_no='" + ps + "'", con);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.Visible = true;
                        dataGridView1.DataSource = dt;
                        con.Close();

                    }

                    else
                    {

                        MessageBox.Show("There is a no booking found on this passport for future traveling, you can review your traveled history.");
                        con.Close();

                        con.Open();



                        DateTime std = dateTimePicker1.Value;
                        DateTime etd = dateTimePicker2.Value;

                        // int std = Convert.ToInt32(dateTimePicker1.Value);
                        //int etd = Convert.ToInt32(dateTimePicker2.Value);
                        string std1 = std.ToString();
                        string etd1 = etd.ToString();

                        advance(std1, etd1, nm, ps);


                        /*   SqlCommand cmd = new SqlCommand("select p.p_id,p.fname,p.lname,p.city,p.state1,p.country,p.passport_no,p.dob,r.sourc,r.destination,r.booking_dt,r.traveldate,t.t_type,t.price,f.aircraft,f.airline,f.flighttime,f.departure,f.arrival,f.travel_hours from passenger p inner join reservation r on p.p_id=r.p_id inner join ticket t on t.t_id=r.t_id inner join flight f on  f.f_no=r.f_no where p.fname='" + textBox1.Text + "'and p.passport_no='" + ps + "'", con);

                           //            SqlCommand cmd = new SqlCommand("select p.p_id,p.fname,p.lname,p.city,p.state1,p.country,p.passport_no,p.dob,r.sourc,r.destination,r.booking_dt,r.traveldate,t.t_type,t.price,f.aircraft,f.airline,f.flighttime,f.departure,f.arrival,f.travel_hours from passenger p inner join reservation r on p.p_id=r.p_id inner join ticket t on t.t_id=r.t_id inner join flight f on  f.f_no=r.f_no where p.fname='" + textBox1.Text + "'passport_no='" + Convert.ToInt32(textBox2.Text) + "'", con);

                           SqlDataReader dr = cmd.ExecuteReader();
                           dr.Read();
                           if (dr.HasRows)
                           {
                               con.Close();

                               MessageBox.Show("query exe");
                               con.Open();
                               SqlCommand cmd1 = new SqlCommand("select p.p_id,p.fname,p.lname,p.city,p.state1,p.country,p.passport_no,p.dob,r.sourc,r.destination,r.booking_dt,r.traveldate,t.t_type,t.price,f.aircraft,f.airline,f.flighttime,f.departure,f.arrival,f.travel_hours from passenger p inner join reservation r on p.p_id=r.p_id inner join ticket t on t.t_id=r.t_id inner join flight f on  f.f_no=r.f_no where p.fname='" + textBox1.Text + "'and p.passport_no='" + ps + "'", con);

                               SqlDataAdapter da = new SqlDataAdapter(cmd1);
                               DataTable dt = new DataTable();
                               da.Fill(dt);
                               dataGridView1.DataSource = dt;
                               con.Close();
                           }
                           else
                           {
                               con.Close();
                               con.Open();
                               SqlCommand cmd2 = new SqlCommand("select p.p_id,p.fname,p.lname,p.city,p.state1,p.country,p.passport_no,p.dob,r.sourc,r.destination,r.booking_dt,r.traveldate,t.t_type,t.price,c.aircraft,c.airline,c.flighttime,c.departure,c.arrival,c.travel_hours from passenger p inner join reservation r on p.p_id=r.p_id inner join ticket t on t.t_id=r.t_id inner join conflight c on  c.cf_no=r.cf_no where p.fname='" + textBox1.Text + "'and p.passport_no='" + ps + "'", con);
                               SqlDataAdapter da = new SqlDataAdapter(cmd2);
                               DataTable dt = new DataTable();
                               da.Fill(dt);
                               dataGridView1.DataSource = dt;
                               con.Close();
                           }*/
                    }
                }
                else
                {

                    MessageBox.Show("No Person Had traveled with This Passport Number Or Name Thank You");
                }
            }
            else
                MessageBox.Show("Please insert and select required details");
        }
        public void advance(string s, string e,string nm,int ps)
        {
         
            con.Close();
            con.Open();
            int c=0;
            
            SqlCommand cmd = new SqlCommand("select p.p_id,p.fname,p.lname,p.city,p.state1,p.country,p.passport_no,p.dob,r.sourc,r.destination,r.booking_dt,r.traveldate,t.t_type,t.price,f.aircraft,f.airline,f.flighttime,f.departure,f.arrival,f.travel_hours from passenger p inner join reservation r on p.p_id=r.p_id inner join ticket t on t.t_id=r.t_id inner join flight f on  f.f_no=r.f_no where p.fname='" + nm + "'and p.passport_no='" + ps + "' and r.traveldate between '"+s+"'and'"+e+"'", con);

//            SqlCommand cmd = new SqlCommand("select p.p_id,p.fname,p.lname,p.city,p.state1,p.country,p.passport_no,p.dob,r.sourc,r.destination,r.booking_dt,r.traveldate,t.t_type,t.price,f.aircraft,f.airline,f.flighttime,f.departure,f.arrival,f.travel_hours from passenger p inner join reservation r on p.p_id=r.p_id inner join ticket t on t.t_id=r.t_id inner join flight f on  f.f_no=r.f_no where p.fname='" + nm + "'and p.passport_no='" + ps + "' and (r.traveldate >='" + s + "'and r.traveldate<='" + e + ")'", con);

            //            SqlCommand cmd = new SqlCommand("select p.p_id,p.fname,p.lname,p.city,p.state1,p.country,p.passport_no,p.dob,r.sourc,r.destination,r.booking_dt,r.traveldate,t.t_type,t.price,f.aircraft,f.airline,f.flighttime,f.departure,f.arrival,f.travel_hours from passenger p inner join reservation r on p.p_id=r.p_id inner join ticket t on t.t_id=r.t_id inner join flight f on  f.f_no=r.f_no where p.fname='" + textBox1.Text + "'passport_no='" + Convert.ToInt32(textBox2.Text) + "'", con);

            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                c = c + Convert.ToInt32(dr.GetValue(19).ToString());

                con.Close(); 

              //  MessageBox.Show("query exe");
                con.Open();
                SqlCommand cmd1 = new SqlCommand("select p.p_id,p.fname,p.lname,p.city,p.state1,p.country,p.passport_no,p.dob,r.sourc,r.destination,r.booking_dt,r.traveldate,t.t_type,t.price,f.aircraft,f.airline,f.flighttime,f.departure,f.arrival,f.travel_hours from passenger p inner join reservation r on p.p_id=r.p_id inner join ticket t on t.t_id=r.t_id inner join flight f on  f.f_no=r.f_no where p.fname='" + nm + "'and p.passport_no='" + ps + "'  and r.traveldate between '" + s + "'and'" + e + "'", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd1);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.Visible = true;
                dataGridView1.DataSource = dt;
                con.Close();
            }
            else
            {
                con.Close();
                con.Open();
                SqlCommand cmd2 = new SqlCommand("select p.p_id,p.fname,p.lname,p.city,p.state1,p.country,p.passport_no,p.dob,r.sourc,r.destination,r.booking_dt,r.traveldate,t.t_type,t.price,c.aircraft,c.airline,c.flighttime,c.departure,c.arrival,c.travel_hours from passenger p inner join reservation r on p.p_id=r.p_id inner join ticket t on t.t_id=r.t_id inner join conflight c on  c.cf_no=r.cf_no where p.fname='" + nm + "'and p.passport_no='" + ps + "'  and r.traveldate between '" + s + "'and'" + e + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd2);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.Visible = true;
                dataGridView1.DataSource = dt;
                
                con.Close();
            }



        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;

            textBox1.Text = "";
            textBox2.Text = "";
            dataGridView1.Visible = false;


        }

        private void button3_Click(object sender, EventArgs e)
        {
            welcompage w1 = new welcompage(nm1);
            w1.Show();
            this.Hide();

        }
    }
}
