using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using System.Data.SqlClient;

namespace AirlineReservationSystem
{
    public partial class Reservation : Form
    {
        string t_id;
        SqlCommand cmd;
      
        //= new SqlCommand();

        SqlConnection con = new SqlConnection(@"server=LENOVO-PC\SQLEXPRESS;database=airline;Trusted_Connection=True");


        public Reservation()
        {
            InitializeComponent();
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Reservation_Load(object sender, EventArgs e)
        {
            BackgroundImageLayout = ImageLayout.Stretch;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            textBox10.Text = availabilityreservation.d;
            textBox9.Text = availabilityreservation.s;
            textBox14.Text = availabilityreservation.dt;

            textBox13.Text = availabilityreservation.a;
            textBox15.Text = availabilityreservation.f;

            con.Open();
            SqlCommand cmd = new SqlCommand("select max(p_id) from passenger",con);

            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            int m = dr.GetInt32(0)+1;
          
            textBox3.Text = m.ToString();
            con.Close();
            con.Open();
            SqlCommand cmd1 = new SqlCommand("select max(r_id) from reservation", con);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            dr1.Read();
            int n = dr1.GetInt32(0) + 1;
          
            textBox2.Text = n.ToString();
            con.Close();
           // comboBox2.Items.Add("airindia");
           //comboBox2.Items.Add("aircanada");
           // comboBox2.Items.Add("jetairways");


        }

        /*private void button2_Click(object sender, EventArgs e)
        {
            con.Open();

            string  qry = "select sourc,destination from flight where sourc='" + textBox9.Text + "' and destination='" + textBox10.Text + "'";
      

            SqlCommand cmd = new SqlCommand(qry, con);
            SqlDataReader dr = cmd.ExecuteReader();// for single row
            dr.Read();// this is for find ticket
            if (!dr.HasRows)
            {
                con.Close();
                con.Open();
                MessageBox.Show("you have connecting flight option!!");
                SqlCommand cmdc = new SqlCommand("select c.cf_no,c.aircraft,c.sourc,c.destination,c.airline,c.flighttime,c.seats,c.departure,c.arrival,c.travel_hours,d.df_no,d.aircraft,d.sourc,d.destination,d.airline,d.flighttime,d.seats,d.departure,d.arrival,d.travel_hours from conflight c join  destflight d on c.df_no=d.df_no where c.sourc='" + textBox9.Text + "' and c.con_detination='" + textBox10.Text + "';",con);
                SqlDataReader dr1 = cmdc.ExecuteReader();
                dr1.Read();
                if (!dr1.HasRows)
                {
                    MessageBox.Show("no flight for such route");
                    con.Close();
                }
                else
                {
                    con.Close();
                    con.Open();
                    SqlCommand cmdc1 = new SqlCommand("select c.cf_no,c.aircraft,c.sourc,c.destination,c.airline,c.flighttime,c.seats,c.departure,c.arrival,c.travel_hours,d.df_no,d.aircraft,d.sourc,d.destination,d.airline,d.flighttime,d.seats,d.departure,d.arrival,d.travel_hours from conflight c join  destflight d on c.df_no=d.df_no where c.sourc='" + textBox9.Text + "' and c.con_detination='" + textBox10.Text + "';", con);
                    SqlDataAdapter sd11 = new SqlDataAdapter(cmdc1);
                    DataTable dt11 = new DataTable();
                    sd11.Fill(dt11);
                    dataGridView1.DataSource = dt11;
                    con.Close();

                   /* con.Open();
                    SqlCommand combo1 = new SqlCommand("select c.aircraft from conflight c join  destflight d on c.df_no=d.df_no where c.sourc='" + textBox9.Text + "' and c.con_detination='" + textBox10.Text + "';", con);
                    SqlDataAdapter scom11 = new SqlDataAdapter(cmdc1);
                    DataTable dtc11 = new DataTable();
                    scom11.Fill(dtc11);
                  
                    comboBox2.DataSource = dtc11;
                    comboBox2.DisplayMember = "airline";
                    comboBox2.ValueMember = "airline";
                   
                  
                    con.Close();
                }
            }
            else
            {
                string f = dr.GetValue(0).ToString();

                string m = dr.GetValue(1).ToString();
                con.Close();
               
                con.Open();
                string qrymain = "select * from flight where sourc='" + textBox9.Text + "' and destination='" + textBox10.Text + "'";// and destination='"+textBox2.Text+"'";//remember
                SqlCommand cmd1 = new SqlCommand(qrymain, con);
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
                DataTable dt = new DataTable();
                sda1.Fill(dt);
                comboBox2.DataSource = dt;
                comboBox2.DisplayMember = "airline";
                comboBox2.ValueMember = "airline";
             
                dataGridView1.DataSource = dt;
                con.Close();
            }
        }*/
        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (validation())
            {
                dateTimePicker1.Format = DateTimePickerFormat.Short;
                string bdt = Convert.ToString(dateTimePicker1.Value);

                string f1;
                string air;
                con.Close();
                con.Open();
                string pass = "select passport_no,fname from passenger where passport_no=" + textBox11.Text + ";";
                SqlCommand cmdp = new SqlCommand(pass, con);
                SqlDataReader drp = cmdp.ExecuteReader();
                drp.Read();
                if (drp.HasRows)
                {

                    string p = drp.GetValue(0).ToString();
                    string nm = drp.GetValue(1).ToString();
                    string p1 = textBox11.Text;
                    string nm1 = textBox1.Text;
                    if (nm == nm1 && p1 == p)
                    {
                        //here data resdudancy
                        con.Close();
                        MessageBox.Show("Your Personal Details Already Stored");
                        con.Open();
                        SqlCommand cmdp1 = new SqlCommand("select p_id from passenger where passport_no=" + textBox11.Text + ";", con);

                        SqlDataReader drp1 = cmdp1.ExecuteReader();
                        drp1.Read();
                        int m = drp1.GetInt32(0);

                        textBox3.Text = m.ToString();
                        con.Close();

                        con.Open();
                        //string qry = "select sourc,destination,airline from flight where sourc='" + textBox9.Text + "' and destination='" + textBox10.Text + "'and delet is null";
                        string qry = "select f_no,airline from flight where sourc='" + textBox9.Text + "' and destination='" + textBox10.Text + "' and flighttime>='" + textBox14.Text + "'and delet is null";

                        SqlCommand cmd = new SqlCommand(qry, con);
                        SqlDataReader dr = cmd.ExecuteReader();// for single row
                        dr.Read();
                        if (!dr.HasRows)
                        {
                            MessageBox.Show("connecting flight for such route");
                            con.Close();



                            con.Open();
                            string qry1 = "select c.cf_no,c.airline from conflight c where c.sourc='" + textBox9.Text + "' and c.con_detination='" + textBox10.Text + "' and c.flighttime='" + textBox14.Text + "'and c.delet is null";

                            SqlCommand cm = new SqlCommand(qry1, con);
                            SqlDataReader dr2 = cm.ExecuteReader();// for single row
                            dr2.Read();
                            if (!dr2.HasRows)
                            {
                                MessageBox.Show("no flight");
                                con.Close();
                            }
                            else
                            {

                                f1 = dr2.GetValue(0).ToString();// value of f_no for  insert to reservation;
                                air = dr2.GetValue(1).ToString();//airline

                                con.Close();

                                //MessageBox.Show("inside connecting flight");
                                /*con.Open();
                                string inspase = "insert into passenger (p_id,fname,lname,city,state1,country,dob,passport_no) values('" + Convert.ToInt32(textBox3.Text) + "','" + this.textBox1.Text + "','" + this.textBox4.Text + "','" + this.textBox5.Text + "','" + this.textBox7.Text + "','" + this.textBox8.Text + "','" + bdt + "','" + textBox11.Text + "');";
                                SqlCommand cmd1 = new SqlCommand();
                                cmd1.CommandText = inspase;
                                cmd1.CommandType = CommandType.Text;
                                cmd1.Connection = con;


                                cmd1.ExecuteNonQuery();
                                MessageBox.Show("passenger detail stored");
                                con.Close();*/


                                con.Open();
                                string flightq = "select cf_no,seats from conflight where airline='" + textBox13.Text + "'and aircraft='" + textBox15.Text + "'and flighttime='" + textBox14.Text + "'and delet is null";
                                SqlCommand fc = new SqlCommand(flightq, con);
                                int fno = 0, s = 0;
                                SqlDataReader dr1 = fc.ExecuteReader();
                                dr1.Read();
                                if (dr1.HasRows)
                                {
                                    fno = Convert.ToInt32(dr1.GetValue(0).ToString());
                                    s = Convert.ToInt32(dr1.GetValue(1).ToString()) - 1;

                                    con.Close();
                                }
                                else
                                {
                                    con.Close();
                                }
                                string insres = "insert into reservation (r_id,sourc,destination,booking_dt,traveldate,t_id,p_id,cf_no)values('" + Convert.ToInt32(textBox2.Text) + "','" + this.textBox9.Text + "','" + textBox10.Text + "','" + DateTime.Now + "','" + textBox14.Text + "','" + Convert.ToInt32(t_id) + "','" + textBox3.Text + "','" + fno + "');";




                                SqlCommand cm1 = new SqlCommand();// every time u have to use sqlcommand()
                                cm1.CommandText = insres;
                                cm1.CommandType = CommandType.Text;
                                cm1.Connection = con;
                                con.Open();
                                cm1.ExecuteNonQuery();
                                MessageBox.Show("data is inserted");

                                con.Close();


                                string updt = "update conflight set seats='" + s + "'where cf_no='" + fno + "'";



                                SqlCommand cm2 = new SqlCommand();// every time u have to use sqlcommand()
                                cm2.CommandText = updt;
                                cm2.CommandType = CommandType.Text;
                                cm2.Connection = con;
                                con.Open();
                                cm2.ExecuteNonQuery();
                                MessageBox.Show("data is inserted");

                                con.Close();


                            }



                        }
                        else
                        {





                            f1 = dr.GetValue(0).ToString();// value of f_no for  insert to reservation;
                            air = dr.GetValue(1).ToString();//airline
                            con.Close();

                            /*  string inspase = "insert into passenger (p_id,fname,lname,city,state1,country,dob,passport_no) values('" + Convert.ToInt32(textBox3.Text) + "','" + this.textBox1.Text + "','" + this.textBox4.Text + "','" + this.textBox5.Text + "','" + this.textBox7.Text + "','" + this.textBox8.Text + "','" + bdt + "','" + textBox11.Text + "');";
                              SqlCommand cmd1 = new SqlCommand();
                              cmd1.CommandText = inspase;
                              cmd1.CommandType = CommandType.Text;
                              cmd1.Connection = con;
                              con.Open();
                              cmd1.ExecuteNonQuery();
                              con.Close();
                          */


                            con.Open();
                            string flightq = "select f_no,seats from flight where airline='" + textBox13.Text + "'and aircraft='" + textBox15.Text + "'and flighttime>='" + textBox14.Text + "'and delet is null"; ;
                            SqlCommand fc = new SqlCommand(flightq, con);
                            SqlDataReader dr1 = fc.ExecuteReader();
                            int fno = 0;
                            int s = 0;
                            dr1.Read();
                            if (dr1.HasRows)
                            {

                                fno = Convert.ToInt32(dr1.GetValue(0).ToString());
                                s = Convert.ToInt32(dr1.GetValue(1).ToString()) - 1;
                                con.Close();
                            }
                            else
                            {
                                con.Close();
                            }
                            string insres = "insert into reservation (r_id,sourc,destination,booking_dt,traveldate,f_no,t_id,p_id)values('" + Convert.ToInt32(textBox2.Text) + "','" + this.textBox9.Text + "','" + textBox10.Text + "','" + DateTime.Now + "','" + textBox14.Text + "','" + fno + "','" + Convert.ToInt32(t_id) + "','" + textBox3.Text + "');";



                            SqlCommand cm1 = new SqlCommand();// every time u have to use sqlcommand()
                            cm1.CommandText = insres;
                            cm1.CommandType = CommandType.Text;
                            cm1.Connection = con;
                            con.Open();
                            cm1.ExecuteNonQuery();
                            MessageBox.Show("data is inserted");
                            con.Close();

                            string updt = "update flight set seats='" + s + "'where f_no='" + fno + "'";



                            SqlCommand cm2 = new SqlCommand();// every time u have to use sqlcommand()
                            cm2.CommandText = updt;
                            cm2.CommandType = CommandType.Text;
                            cm2.Connection = con;
                            con.Open();
                            cm2.ExecuteNonQuery();
                            MessageBox.Show("data is update");

                            con.Close();



                        }


                    }
                    else
                    {
                        MessageBox.Show("Please Enter Valid Passport Number Or Name ");
                    }


                }
                else
                {
                    con.Close();

                    con.Open();
                    string qry = "select sourc,destination,airline from flight where sourc='" + textBox9.Text + "' and destination='" + textBox10.Text + "'and delet is null";
                    SqlCommand cmd = new SqlCommand(qry, con);
                    SqlDataReader dr = cmd.ExecuteReader();// for single row
                    dr.Read();
                    if (!dr.HasRows)
                    {
                        MessageBox.Show("connecting flight for such route");
                        con.Close();


                        /* con.Open();
                         string qrymain= "select c.cf_no,c.aircraft,c.sourc,c.destination,c.airline,c.flighttime,c.seats,c.departure,c.arrival,c.travel_hours,d.df_no,d.aircraft,d.sourc,d.destination,d.airline,d.flighttime,d.seats,d.departure,d.arrival,d.travel_hours from conflight c join  destflight d on c.df_no=d.df_no where c.sourc='" + textBox9.Text + "' and c.con_detination='" + textBox10.Text + "';";
                         SqlCommand cmd2 = new SqlCommand(qrymain, con);
                         SqlDataAdapter sda1 = new SqlDataAdapter(cmd2);
                         DataTable dt = new DataTable();
                         sda1.Fill(dt);
                         dataGridView1.DataSource = dt;
                         con.Close();
                         */
                        con.Open();
                        string qry1 = "select c.cf_no,c.airline from conflight c where c.sourc='" + textBox9.Text + "' and c.con_detination='" + textBox10.Text + "' and c.flighttime='" + textBox14.Text + "'and c.delet is null";

                        SqlCommand cm = new SqlCommand(qry1, con);
                        SqlDataReader dr2 = cm.ExecuteReader();// for single row
                        dr2.Read();
                        if (!dr2.HasRows)
                        {
                            MessageBox.Show("no flight");
                            con.Close();
                        }
                        else
                        {

                            f1 = dr2.GetValue(0).ToString();// value of f_no for  insert to reservation;
                            air = dr2.GetValue(1).ToString();//airline

                            con.Close();

                            MessageBox.Show("inside connecting flight");
                            con.Open();
                            string inspase = "insert into passenger (p_id,fname,lname,city,state1,country,dob,passport_no) values('" + Convert.ToInt32(textBox3.Text) + "','" + this.textBox1.Text + "','" + this.textBox4.Text + "','" + this.textBox5.Text + "','" + this.textBox7.Text + "','" + this.textBox8.Text + "','" + bdt + "','" + textBox11.Text + "');";
                            SqlCommand cmd1 = new SqlCommand();
                            cmd1.CommandText = inspase;
                            cmd1.CommandType = CommandType.Text;
                            cmd1.Connection = con;


                            cmd1.ExecuteNonQuery();
                            MessageBox.Show("passenger detail stored");
                            con.Close();


                            con.Open();
                            string flightq = "select cf_no,seats from conflight where airline='" + textBox13.Text + "'and aircraft='" + textBox15.Text + "'and flighttime='" + textBox14.Text + "'and delet is null";
                            SqlCommand fc = new SqlCommand(flightq, con);
                            int fno = 0, s = 0;
                            SqlDataReader dr1 = fc.ExecuteReader();
                            dr1.Read();
                            if (dr1.HasRows)
                            {
                                fno = Convert.ToInt32(dr1.GetValue(0).ToString());
                                s = Convert.ToInt32(dr1.GetValue(1).ToString()) - 1;

                                con.Close();
                            }
                            else
                            {
                                con.Close();
                            }
                            string insres = "insert into reservation (r_id,sourc,destination,booking_dt,traveldate,t_id,p_id,cf_no)values('" + Convert.ToInt32(textBox2.Text) + "','" + this.textBox9.Text + "','" + textBox10.Text + "','" + DateTime.Now + "','" + textBox14.Text + "','" + Convert.ToInt32(t_id) + "','" + textBox3.Text + "','" + fno + "');";




                            SqlCommand cm1 = new SqlCommand();// every time u have to use sqlcommand()
                            cm1.CommandText = insres;
                            cm1.CommandType = CommandType.Text;
                            cm1.Connection = con;
                            con.Open();
                            cm1.ExecuteNonQuery();
                            MessageBox.Show("data is inserted");

                            con.Close();


                            string updt = "update conflight set seats='" + s + "'where cf_no='" + fno + "'";



                            SqlCommand cm2 = new SqlCommand();// every time u have to use sqlcommand()
                            cm2.CommandText = updt;
                            cm2.CommandType = CommandType.Text;
                            cm2.Connection = con;
                            con.Open();
                            cm2.ExecuteNonQuery();
                            MessageBox.Show("data is update");

                            con.Close();


                        }



                    }
                    else
                    {
                        //string f = dr.GetValue(0).ToString();

                        //string m = dr.GetValue(2).ToString();


                        con.Close();

                        /*con.Open();
                        string qrymain = "select * from flight where sourc='" + textBox9.Text + "' and destination='" + textBox10.Text + "'";// and destination='"+textBox2.Text+"'";//remember
                        SqlCommand cmd2 = new SqlCommand(qrymain, con);
                        SqlDataAdapter sda1 = new SqlDataAdapter(cmd2);
                        DataTable dt = new DataTable();
                        sda1.Fill(dt);
                        dataGridView1.DataSource = dt;
                        con.Close();
                        */
                        con.Open();
                        string qry1 = "select f_no,airline from flight where sourc='" + textBox9.Text + "' and destination='" + textBox10.Text + "' and flighttime>='" + textBox14.Text + "'and delet is null";

                        SqlCommand cm = new SqlCommand(qry1, con);
                        SqlDataReader dr2 = cm.ExecuteReader();// for single row
                        dr2.Read();
                        if (!dr2.HasRows)
                        {
                            MessageBox.Show("no flight");
                            con.Close();
                        }
                        else
                        {

                            f1 = dr2.GetValue(0).ToString();// value of f_no for  insert to reservation;
                            air = dr2.GetValue(1).ToString();//airline
                            con.Close();

                            string inspase = "insert into passenger (p_id,fname,lname,city,state1,country,dob,passport_no) values('" + Convert.ToInt32(textBox3.Text) + "','" + this.textBox1.Text + "','" + this.textBox4.Text + "','" + this.textBox5.Text + "','" + this.textBox7.Text + "','" + this.textBox8.Text + "','" + bdt + "','" + textBox11.Text + "');";
                            SqlCommand cmd1 = new SqlCommand();
                            cmd1.CommandText = inspase;
                            cmd1.CommandType = CommandType.Text;
                            cmd1.Connection = con;
                            con.Open();
                            cmd1.ExecuteNonQuery();
                            con.Close();



                            con.Open();
                            string flightq = "select f_no,seats from flight where airline='" + textBox13.Text + "'and aircraft='" + textBox15.Text + "'and flighttime>='" + textBox14.Text + "'and delet is null"; ;
                            SqlCommand fc = new SqlCommand(flightq, con);
                            SqlDataReader dr1 = fc.ExecuteReader();
                            int fno = 0, s = 0;
                            dr1.Read();
                            if (dr1.HasRows)
                            {

                                fno = Convert.ToInt32(dr1.GetValue(0).ToString());
                                s = Convert.ToInt32(dr1.GetValue(1).ToString()) - 1;
                                con.Close();
                            }
                            else
                            {
                                con.Close();
                            }
                            string insres = "insert into reservation (r_id,sourc,destination,booking_dt,traveldate,f_no,t_id,p_id)values('" + Convert.ToInt32(textBox2.Text) + "','" + this.textBox9.Text + "','" + textBox10.Text + "','" + DateTime.Now + "','" + Convert.ToDateTime(textBox14.Text) + "','" + f1 + "','" + Convert.ToInt32(t_id) + "','" + textBox3.Text + "');";



                            SqlCommand cm1 = new SqlCommand();// every time u have to use sqlcommand()
                            cm1.CommandText = insres;
                            cm1.CommandType = CommandType.Text;
                            cm1.Connection = con;
                            con.Open();
                            cm1.ExecuteNonQuery();
                            MessageBox.Show("data is inserted");

                            con.Close();


                            string updt = "update flight set seats='" + s + "'where f_no='" + f1 + "'";



                            SqlCommand cm2 = new SqlCommand();// every time u have to use sqlcommand()
                            cm2.CommandText = updt;
                            cm2.CommandType = CommandType.Text;
                            cm2.Connection = con;
                            con.Open();
                            cm2.ExecuteNonQuery();
                            MessageBox.Show("data is update");

                            con.Close();

                        }

                    }



                }

            }
            else
                MessageBox.Show("Enter full details");
        }
        
        public bool validation()
        {
            int f = 0;
            if (textBox1.Text != "")
            {
                if (textBox2.Text != "")
                {
                    if (textBox3.Text != "")
                    {
                        if (textBox4.Text != "")
                        {
                            if (textBox5.Text != "")
                            {
                                if (textBox6.Text != "")
                                {
                                    if (textBox7.Text != "")
                                    {
                                        if (textBox8.Text != "")
                                        {
                                            if (textBox9.Text != "")
                                            {
                                                if(textBox10.Text!="")
                                                {
                                                    if(textBox11.Text!="")
                                                    {
                                                        if(textBox13.Text!="")
                                                        {
                                                            if(textBox14.Text!="")
                                                            {
                                                                if(textBox15.Text!="")
                                                                {

                                                                    if (comboBox1.SelectedIndex > -1)
                                                                    {
                                                                        f = 1;
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                                
                                                //  return true;
                                            }


                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (f == 0)
            {
                MessageBox.Show("Please enter full flight details ");
                return false;
            }

            else
                return true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            con.Open();
            string m1 = comboBox1.SelectedItem.ToString();
            string tqry = "select t_id,price from ticket where t_type='" + m1.ToString() + "'";
            SqlCommand cmdc = new SqlCommand(tqry, con);
            SqlDataReader drc = cmdc.ExecuteReader();
            drc.Read();
            t_id = drc.GetValue(0).ToString();// retrieve t_id
            textBox6.Text = drc.GetValue(1).ToString();
            con.Close();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //admin a = new admin();
            //a.Show();
        }

       
     

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();

            string final = "select p.fname,p.lname,p.city,p.state1,p.country,p.dob,p.passport_no,r.sourc,r.destination,r.traveldate from passenger p inner join reservation r on r.p_id=p.p_id where p.p_id=" + textBox3.Text;

            SqlCommand cmd2 = new SqlCommand(final, con);
            SqlDataAdapter sda1 = new SqlDataAdapter(cmd2);
            DataTable dt = new DataTable();
            sda1.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            availabilityreservation a1 = new availabilityreservation("name");
            a1.Show();
            this.Hide();
        }

       
    }
}
