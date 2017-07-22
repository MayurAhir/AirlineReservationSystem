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
    public partial class admin : Form
    {
        SqlConnection conn =new SqlConnection(@"server=LENOVO-PC\SQLEXPRESS;database=airline;Trusted_Connection=True");
        string nm;
        public admin( string nm)
        {
            this.nm=nm;
            InitializeComponent();
        }

        private void admin_Load(object sender, EventArgs e)
        {

            BackgroundImageLayout = ImageLayout.Stretch;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            DialogResult r;
            panel1.Visible = false;
            button2.Visible = false;

            int flg = 0;
            r = MessageBox.Show("do you want to add connecting flight data ?","my message",MessageBoxButtons.YesNoCancel);
            if (r == DialogResult.Yes)
            {
                panel1.Visible = true;
                button2.Visible = true;
                button1.Visible = false;
                conn.Open();
                string cf = "select max(cf_no) from conflight where delet is null";
                SqlCommand ccmd = new SqlCommand(cf, conn);
                SqlDataReader cdr = ccmd.ExecuteReader();
                cdr.Read();
                int cn = Convert.ToInt32(cdr.GetValue(0).ToString()) + 1;
                textBox1.Text = cn.ToString();
                conn.Close();
                conn.Open();
                string df = "select max(df_no) from destflight where delet is null";
                SqlCommand dcmd = new SqlCommand(df, conn);
                SqlDataReader dcdr = dcmd.ExecuteReader();
                dcdr.Read();
                int dcn = Convert.ToInt32(dcdr.GetValue(0).ToString()) + 1;
                textBox10.Text = dcn.ToString();
                conn.Close();
                flg = 1;
            }
            if (flg != 1)
            {
                conn.Open();
                string sf = "select max(f_no) from flight where delet is null";

                SqlCommand cmd = new SqlCommand(sf, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                int n = Convert.ToInt32(dr.GetValue(0).ToString()) + 1;
                textBox1.Text = n.ToString();
                conn.Close();
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (validation())
            {


                string insf = "insert into flight(f_no,aircraft,sourc,destination,airline,flighttime,seats,departure,arrival,travel_hours) values('" + Convert.ToInt32(textBox1.Text) + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + dateTimePicker1.Value.ToShortDateString() + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "');";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = insf;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                conn.Open();

                cmd.ExecuteNonQuery();
                MessageBox.Show("flight detail stored");
                conn.Close();
            }


        }
        public bool validation()
        {
            int f = 0;
            if(textBox1.Text!="")
            {
                if(textBox2.Text!="")
                {
                    if(textBox3.Text!="")
                    {
                       if( textBox4.Text !="")
                        {
                            if(textBox5.Text!="")
                            {
                                if(textBox6.Text!="")
                                {
                                    if(textBox7.Text!="")
                                    {
                                        if(textBox8.Text!="")
                                        {
                                            if(textBox9.Text!="")
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (validation2() && validation())
            {
                DateTime ct = DateTime.Now;
                int dflg = 0;
                if (dateTimePicker2.Value >= ct)
                {
                    string insf = "insert into destflight(df_no,aircraft,sourc,destination,airline,flighttime,seats,departure,arrival,travel_hours) values('" + Convert.ToInt32(textBox10.Text) + "','" + textBox11.Text + "','" + textBox12.Text + "','" + textBox13.Text + "','" + textBox14.Text + "','" + dateTimePicker2.Value.ToShortDateString() + "','" + textBox15.Text + "','" + textBox16.Text + "','" + textBox17.Text + "','" + textBox18.Text + "');";

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = insf;
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = conn;
                    conn.Open();

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("flight detail stored");
                    conn.Close();
                    dflg = 1;

                }
                else
                {
                    MessageBox.Show("select future date");
                    dateTimePicker2.Value = DateTime.Now;
                }
                if (dflg == 1)
                {


                    if (dateTimePicker1.Value >= ct)
                    {


                        conn.Open();
                        string qry = "select df_no,destination from destflight where df_no='" + textBox10.Text + "'and delet is null";
                        SqlCommand deti = new SqlCommand(qry, conn);
                        SqlDataReader dtr = deti.ExecuteReader();
                        dtr.Read();
                        int dcn = Convert.ToInt32(dtr.GetValue(0).ToString());
                        //  string conf_no = dcn.ToString();
                        string desti = dtr.GetValue(1).ToString();

                        conn.Close();



                        string insf = "insert into conflight(cf_no,aircraft,sourc,destination,airline,flighttime,seats,departure,arrival,travel_hours,con_detination,df_no) values('" + Convert.ToInt32(textBox1.Text) + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + dateTimePicker1.Value.ToShortDateString() + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + desti + "','" + dcn + "');";

                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandText = insf;
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = conn;
                        conn.Open();

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("flight detail stored");
                        conn.Close();


                    }
                    else
                    {
                        MessageBox.Show("select future date");
                        dateTimePicker2.Value = DateTime.Now;
                    }
                }

            }
        }

        public bool validation2()
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

        private void button3_Click(object sender, EventArgs e)
        {
            welcompage w1 = new welcompage(nm);
            w1.Show();
            this.Hide();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            updateflight up = new updateflight();
            up.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            delete d1 = new delete();
            d1.Show();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if(textBox2.Text=="")
            {
                textBox2.Text = "Required Field";
            }

        }


        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel1.Hide();
        }

       
    }
}
