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
    public partial class cancel : Form


    {

        SqlConnection con = new SqlConnection(@"server=LENOVO-PC\SQLEXPRESS;database=airline;Trusted_Connection=True");
        public cancel()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime dt1=DateTime.Now;
            
            dateTimePicker1.Format=DateTimePickerFormat.Short;
            dateTimePicker2.Format = DateTimePickerFormat.Short;

            string db = Convert.ToString(dateTimePicker1.Value);
           string dt2=Convert.ToString(dateTimePicker2.Value);
            if(textBox1.Text=="")
            {

                MessageBox.Show("Please enter passport number");
            }
           if (Convert.ToDateTime(dt2) > DateTime.Now)
           {

               string qry = "select p.p_id,p.passport_no,p.dob,r.cncl from passenger p inner join reservation r on r.p_id=p.p_id where p.passport_no='" + textBox1.Text + "'and (p.dob='" + db + "'and r.traveldate='" + dt2 + "')";
               con.Open();
               SqlCommand cmd = new SqlCommand(qry, con);
               SqlDataReader dr = cmd.ExecuteReader();


               dr.Read();
               if (!dr.HasRows)
               {
                   MessageBox.Show("cancelation is not compelete please enter correct data");
                   con.Close();
               }
               else
               {
                   int id = Convert.ToInt32((dr.GetValue(0).ToString()));

                   con.Close();
                   string qry2 = "update reservation set cncl='cl' where p_id='" + id + "';";
                   SqlCommand cmd2 = new SqlCommand(qry2, con);
                   cmd2.CommandText = qry2;
                   cmd2.CommandType = CommandType.Text;
                   cmd2.Connection = con;
                   con.Open();
                   cmd2.ExecuteNonQuery();
                   con.Close();

                   string adq = "Select f_no,cf_no from Reservation where p_id='" + id + "'";
                   con.Open();
                   SqlCommand cmd1 = new SqlCommand(adq, con);
                   SqlDataReader dr1 = cmd1.ExecuteReader();
                   dr1.Read();
                   string f = Convert.ToString(dr1.GetValue(0).ToString());
                   string cf = Convert.ToString(dr1.GetValue(1).ToString());
                   if (f != null)
                   {
                       con.Close();
                       string fn = "select seats from flight where f_no='" + f + "'";
                       con.Open();
                       SqlCommand cmf = new SqlCommand(fn, con);
                       SqlDataReader df = cmf.ExecuteReader();
                       df.Read();
                       int st = Convert.ToInt32(df.GetValue(0).ToString());
                       st++;
                       con.Close();


                       string qfn = "update flight set seats='" + st + "' where f_no='" + f + "'";
                       SqlCommand cmfn = new SqlCommand(qfn, con);
                       cmfn.CommandText = qfn;
                       cmfn.CommandType = CommandType.Text;
                       cmfn.Connection = con;

                       con.Open();
                       cmfn.ExecuteNonQuery();
                       con.Close();
                       MessageBox.Show("done");

                   }
                   else
                   {
                       con.Close();
                       string fn = "select seat from conflight where cf_no='" + cf + ";";
                       con.Open();
                       SqlCommand cmf = new SqlCommand(fn, con);
                       SqlDataReader df = cmf.ExecuteReader();
                       df.Read();
                       int st = Convert.ToInt32(df.GetValue(0).ToString());
                       st++;
                       con.Close();


                       string qfn = "update conflight set seats='" + st + "' where cf_no='" + cf + "';";
                       SqlCommand cmfn = new SqlCommand(qfn, con);
                       cmfn.CommandText = qfn;
                       cmfn.CommandType = CommandType.Text;
                       cmfn.Connection = con;
                       con.Open();
                       cmfn.ExecuteNonQuery();
                       con.Close();
                       MessageBox.Show("done");

                   }

                   MessageBox.Show("Your cancelation is done ");


               }
           }
           else
           {
               MessageBox.Show("Please select future date to be cancel");
           }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            passengercs p1 = new passengercs();
            p1.Show();
            this.Hide();
        }

        private void cancel_Load(object sender, EventArgs e)
        {
            BackgroundImageLayout = ImageLayout.Stretch;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
        }
    }
}


