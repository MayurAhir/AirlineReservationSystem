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
    public partial class updateflight : Form
    {

        SqlConnection conn = new SqlConnection(@"server=LENOVO-PC\SQLEXPRESS;database=airline;Trusted_Connection=True");
        public updateflight()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (validation())
            {
                int f = 0;
                conn.Open();
                string qry1 = "select f_no from flight where f_no='" + textBox10.Text + "'";

                string qry2 = "select cf_no from conflight where cf_no='" + textBox10.Text + "'";
                string qry3 = "select df_no from destflight where df_no='" + textBox10.Text + "'";

                SqlCommand cmd1 = new SqlCommand(qry1, conn);
                SqlCommand cmd2 = new SqlCommand(qry2, conn);
                SqlCommand cmd3 = new SqlCommand(qry3, conn);
                DateTime dt1 = dateTimePicker2.Value;
                string dt = dt1.ToString();

                SqlDataReader dr1 = cmd1.ExecuteReader();
                dr1.Read();
                if (!dr1.HasRows)
                {
                    MessageBox.Show("data is not updated");
                    conn.Close();
                }
                else
                {
                    string quupdate = "update flight set aircraft='" + textBox11.Text + "',sourc='" + textBox12.Text + "',destination='" + textBox13.Text + "',airline='" + textBox14.Text + "',flighttime='" + dt + "',seats='" + textBox15.Text + "',departure='" + textBox16.Text + "',arrival='" + textBox17.Text + "',travel_hours='" + textBox18.Text + "',updat='y'where f_no='" + textBox10.Text + "'";
                    conn.Close();
                    cmd1.CommandText = quupdate;
                    cmd1.CommandType = CommandType.Text;
                    cmd1.Connection = conn;
                    conn.Open();
                    cmd1.ExecuteNonQuery();
                    conn.Close();
                    f = 1;
                    //all flight else part remain
                }
                conn.Open();
                SqlDataReader dr2 = cmd2.ExecuteReader();
                dr2.Read();
                if (!dr2.HasRows)
                {
                    MessageBox.Show("data is not updated");
                    conn.Close();
                }
                else
                {
                    string quupdate = "update conflight set aircraft='" + textBox11.Text + "',sourc='" + textBox12.Text + "',destination='" + textBox13.Text + "',airline='" + textBox14.Text + "',flighttime='" + dt + "',seats='" + textBox15.Text + "',departure='" + textBox16.Text + "',arrival='" + textBox17.Text + "',travel_hours='" + textBox18.Text + "',updat='y'where cf_no='" + textBox10.Text + "'";

                    conn.Close();
                    cmd2.CommandText = quupdate;
                    cmd2.CommandType = CommandType.Text;
                    cmd2.Connection = conn;
                    conn.Open();
                    cmd2.ExecuteNonQuery();
                    conn.Close();
                    f = 1;
                }

                conn.Open();
                SqlDataReader dr3 = cmd3.ExecuteReader();
                dr3.Read();
                if (!dr3.HasRows)
                {

                    conn.Close();
                }

                else
                {
                    string quupdate = "update destflight set aircraft='" + textBox11.Text + "',sourc='" + textBox12.Text + "',destination='" + textBox13.Text + "',airline='" + textBox14.Text + "',flighttime='" + dt + "',seats='" + textBox15.Text + "',departure='" + textBox16.Text + "',arrival='" + textBox17.Text + "',travel_hours='" + textBox18.Text + "',updat='y' where df_no='" + textBox10.Text + "'";


                    conn.Close();
                    cmd3.CommandText = quupdate;
                    cmd3.CommandType = CommandType.Text;
                    cmd3.Connection = conn;
                    conn.Open();
                    cmd3.ExecuteNonQuery();
                    conn.Close();
                    f = 1;
                }



                if (f != 1)
                {
                    MessageBox.Show("Data is not Update yet");
                }

            }
            else
                MessageBox.Show("Please enter full details");
        }
        public bool validation()
        {
            int f = 0;
            if (textBox10.Text != "")
            {
                if (textBox11.Text != "")
                {
                    if (textBox12.Text != "")
                    {
                        if (textBox13.Text != "")
                        {
                            if (textBox14.Text != "")
                            {
                                if (textBox15.Text != "")
                                {
                                    if (textBox16.Text != "")
                                    {
                                        if (textBox17.Text != "")
                                        {
                                            if (textBox18.Text != "")
                                            {
                                                
                                                f = 1;
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


        private void updateflight_Load(object sender, EventArgs e)
        {
            BackgroundImageLayout = ImageLayout.Stretch;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            dateTimePicker2.Format = DateTimePickerFormat.Short;
            conn.Open();
            SqlCommand cmdf = new SqlCommand("select * from flight", conn);
            SqlDataAdapter adf = new SqlDataAdapter(cmdf);
            DataTable ds = new DataTable();
            adf.Fill(ds);
            dataGridView1.DataSource = ds;
            conn.Close();
            conn.Open();
            SqlCommand cmdc = new SqlCommand("select * from conflight", conn);
            SqlDataAdapter adc = new SqlDataAdapter(cmdc);
            DataTable dsc = new DataTable();
            adc.Fill(dsc);
            dataGridView2.DataSource = dsc;
            conn.Close();

            conn.Open();
            SqlCommand cmdd = new SqlCommand("select * from destflight", conn);
            SqlDataAdapter add = new SqlDataAdapter(cmdd);
            DataTable dsd = new DataTable();
            add.Fill(dsd);
            dataGridView3.DataSource = dsd;
            conn.Close();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            admin a1 = new admin("name");
            a1.Show();
            this.Hide();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
