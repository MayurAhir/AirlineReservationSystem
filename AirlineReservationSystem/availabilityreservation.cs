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
    public partial class availabilityreservation : Form
    {
        SqlCommand cmd;
       public static string s = "";
       public static string d = "";
       public static string a = "";
       public static string f = "";
       public static string dt = "";

        string nm1;
        SqlConnection con = new SqlConnection(@"server=LENOVO-PC\SQLEXPRESS;database=airline;Trusted_Connection=True");

        public availabilityreservation( string nm)
        {
            InitializeComponent();
            nm1 = nm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            con.Close();
            con.Open();
            DateTime dt1=dateTimePicker1.Value;
            string dt=dt1.ToString();
            DateTime cdt = DateTime.Now;
            int fl=1;

            if(textBox1.Text==""|| textBox2.Text=="")
            {
                MessageBox.Show("Please enter source and destination ");
            }

            if (dt1<=cdt )
            {
                
                MessageBox.Show("Please select correct travelling date it should be future date");
                dateTimePicker1.Value = DateTime.Now;
                fl=0;
            }
            if(fl==1)
            {

                string qry = "select sourc,destination,seats from flight where sourc='" + textBox1.Text + "' and destination='" + textBox2.Text + "'and flighttime>='" + dt + "'and delet is null";


            SqlCommand cmd = new SqlCommand(qry, con);
            SqlDataReader dr = cmd.ExecuteReader();// for single row
            dr.Read();// this is for find ticket
            if (!dr.HasRows)
            {
                con.Close();
                con.Open();
                //MessageBox.Show("you have connecting flight option!!");
                SqlCommand cmdc = new SqlCommand("select c.seats,c.cf_no,c.aircraft,c.sourc,c.destination,c.airline,c.flighttime,c.seats,c.departure,c.arrival,c.travel_hours,d.df_no,d.aircraft,d.sourc,d.destination,d.airline,d.flighttime,d.seats,d.departure,d.arrival,d.travel_hours from conflight c join  destflight d on c.df_no=d.df_no where c.sourc='" + textBox1.Text + "' and c.con_detination='" + textBox2.Text + "'and c.flighttime>='" + dt + "'and c.delet is null and d.delet is null;", con);
                SqlDataReader dr1 = cmdc.ExecuteReader();
                dr1.Read();
                if (!dr1.HasRows)
                {
                    MessageBox.Show("No flight for such route during the time which you have selected ");
                    con.Close();
                }
                else
                {
                    string s = dr1.GetValue(0).ToString();
                    textBox3.Text = s;
                    con.Close();
                    con.Open();
                    SqlCommand cmdc1 = new SqlCommand("select c.cf_no,c.aircraft,c.sourc,c.destination,c.airline,c.flighttime,c.seats,c.departure,c.arrival,c.travel_hours,d.df_no,d.aircraft,d.sourc,d.destination,d.airline,d.flighttime,d.seats,d.departure,d.arrival,d.travel_hours from conflight c join  destflight d on c.df_no=d.df_no where c.sourc='" + textBox1.Text + "' and c.con_detination='" + textBox2.Text + "'and c.flighttime>='" + dt + "' and c.delet is null and d.delet is null;", con);
                    SqlDataAdapter sd11 = new SqlDataAdapter(cmdc1);
                    DataTable dt11 = new DataTable();
                    sd11.Fill(dt11);
                    dataGridView1.DataSource = dt11;
                    con.Close();

                    con.Open();
                    SqlCommand combo1 = new SqlCommand("select c.aircraft from conflight c join  destflight d on c.df_no=d.df_no where c.sourc='" + textBox1.Text + "' and c.con_detination='" + textBox2.Text + "'and c.flighttime>='" + dt + "'and c.delet is null and d.delet is null", con);
                    SqlDataAdapter scom11 = new SqlDataAdapter(cmdc1);
                    DataTable dtc11 = new DataTable();
                    scom11.Fill(dtc11);

                    comboBox1.DataSource = dtc11;
                    comboBox1.DisplayMember = "airline";
                    comboBox1.ValueMember = "airline";

                    comboBox3.DataSource = dtc11;
                    comboBox3.DisplayMember = "flighttime";
                    comboBox3.ValueMember = "flighttime";


                    con.Close();
                }
            }
            else
            {
                string f = dr.GetValue(0).ToString();

                string m = dr.GetValue(1).ToString();
                string s = dr.GetValue(2).ToString();
                textBox3.Text = s;
                con.Close();

                con.Open();
                string qrymain = "select * from flight where sourc='" + textBox1.Text + "' and destination='" + textBox2.Text + "'and flighttime>='" + dt + "'and delet is null";// and destination='"+textBox2.Text+"'";//remember
                SqlCommand cmd1 = new SqlCommand(qrymain, con);
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
                DataTable dt2 = new DataTable();
                sda1.Fill(dt2);
                comboBox1.DataSource = dt2;
                comboBox1.DisplayMember = "airline";
                comboBox1.ValueMember = "airline";
                comboBox3.DataSource = dt2;
                comboBox3.DisplayMember = "flighttime";
                comboBox3.ValueMember = "flighttime";
                    dataGridView1.Visible = true;
                dataGridView1.DataSource = dt2;
                con.Close();
            }
        }
        }





        private void availabilityreservation_Load(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            BackgroundImageLayout = ImageLayout.Stretch;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Close();
            con.Open();
            DateTime dt1 = dateTimePicker1.Value;
            string dt = dt1.ToString();
            //  string m1 = comboBox2.SelectedItem.ToString();
            string tqry = "select aircraft,seats from flight where airline='" + comboBox1.SelectedValue + "'and flighttime>='" + dt + "'and sourc='" + textBox1.Text + "'and destination='" + textBox2.Text + "' and delet is null";
            SqlCommand cmdf = new SqlCommand(tqry, con);
            SqlDataReader dr = cmdf.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
               // MessageBox.Show("inside flight");
                string s = dr.GetValue(1).ToString();
                textBox3.Text = s;
                con.Close();
                con.Open();

                SqlCommand cmdc = new SqlCommand(tqry, con);
                SqlDataAdapter sd1 = new SqlDataAdapter(cmdc);
                DataTable ds = new DataTable();
                sd1.Fill(ds);
                comboBox2.DataSource = ds;
                comboBox2.DisplayMember = "aircraft";
                comboBox2.ValueMember = "aircraft";



                con.Close();
            }
            else
            {
                //MessageBox.Show("ingfff");
                con.Close();
                con.Open();
                string n1 = comboBox1.SelectedText;
                string tqry1 = "select seats,aircraft,sourc from conflight where airline='" + comboBox1.SelectedValue + "'and flighttime>='" + dt + "'and delet is null";
                SqlCommand cmdf1 = new SqlCommand(tqry1, con);
                SqlDataReader dr1 = cmdf1.ExecuteReader();
                dr1.Read();
                if (dr1.HasRows)
                {
                    string s = dr1.GetValue(0).ToString();
                    textBox3.Text = s;

                    con.Close();
                    con.Open();

                    SqlCommand cmdc1 = new SqlCommand(tqry1, con);
                    SqlDataAdapter sd11 = new SqlDataAdapter(cmdc1);
                    DataTable ds1 = new DataTable();
                    sd11.Fill(ds1);
                    comboBox2.DataSource = ds1;
                    comboBox2.DisplayMember = "aircraft";
                    comboBox2.ValueMember = "aircraft";

                    con.Close();
                }
                else
                {
                    MessageBox.Show("No flight for date which you have selected");
                    con.Close();
                }


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            welcompage w1 = new welcompage(nm1);
            w1.Show();
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && comboBox1.SelectedIndex>-1 && comboBox2.SelectedIndex>-1 && comboBox3.SelectedIndex>-1)
            {
                s = textBox1.Text;
                d = textBox2.Text;
                dt = Convert.ToString(comboBox3.SelectedValue);
                a = (string)comboBox1.SelectedValue;
                f = (string)comboBox2.SelectedValue;

                Reservation r1 = new Reservation();
                r1.Show();
            }
            else
            {
                MessageBox.Show("Please insert and  select all required data");
            }


        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {



            con.Close();
            con.Open();
            DateTime dt1 = dateTimePicker1.Value;
            string dt = dt1.ToString();
            //  string m1 = comboBox2.SelectedItem.ToString();
            string tqry = "select seats,flighttime from flight where airline='" + comboBox1.SelectedValue + "'and flighttime>='" + dt + "'and sourc='" + textBox1.Text + "'and destination='" + textBox2.Text + "'and aircraft='" + comboBox2.SelectedValue + "'and delet is null";
            SqlCommand cmdf = new SqlCommand(tqry, con);
            SqlDataReader dr = cmdf.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                //MessageBox.Show("inside flight");
                string s = dr.GetValue(0).ToString();
                textBox3.Text = s;
                con.Close();
                con.Open();

                SqlCommand cmdc = new SqlCommand(tqry, con);
                SqlDataAdapter sd1 = new SqlDataAdapter(cmdc);
                DataTable ds = new DataTable();
                sd1.Fill(ds);
                comboBox3.DataSource = ds;
                comboBox3.DisplayMember = "flighttime";
                comboBox3.ValueMember = "flighttime";



                con.Close();
            }
            else
            {
               // MessageBox.Show("ingfff");
                con.Close();
                con.Open();
                string n1 = comboBox1.SelectedText;
                string tqry1 = "select seats,flighttime from conflight where airline='" + comboBox1.SelectedValue + "'and flighttime>='" + dt + "'and sourc='" + textBox1.Text + "'and destination='" + textBox2.Text + "'and aircraft='" + comboBox2.SelectedValue + "'and delet is null";
                SqlCommand cmdf1 = new SqlCommand(tqry1, con);
                SqlDataReader dr1 = cmdf1.ExecuteReader();
                dr1.Read();
                if (dr1.HasRows)
                {
                    string s = dr1.GetValue(0).ToString();
                    textBox3.Text = s;

                    con.Close();
                    con.Open();

                    SqlCommand cmdc1 = new SqlCommand(tqry1, con);
                    SqlDataAdapter sd11 = new SqlDataAdapter(cmdc1);
                    DataTable ds1 = new DataTable();
                    sd11.Fill(ds1);
                    comboBox3.DataSource = ds1;
                    comboBox3.DisplayMember = "flighttime";
                    comboBox3.ValueMember = "flighttime";

                    con.Close();
                }
                else
                {
                    MessageBox.Show("No flight for  date which you have selected");
                    con.Close();
                }


            }

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
