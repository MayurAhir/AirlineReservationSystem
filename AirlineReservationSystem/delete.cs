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
    public partial class delete : Form
    {

        SqlConnection con = new SqlConnection(@"server=LENOVO-PC\SQLEXPRESS;database=airline;Trusted_Connection=True");
        public delete()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {

                string q1 = "select * from flight where f_no='" + textBox1.Text + "'";

                con.Open();
                SqlCommand cmd = new SqlCommand(q1, con);

                SqlDataReader dr1 = cmd.ExecuteReader();
                dr1.Read();
                if (!dr1.HasRows)
                {
                    con.Close();
                    con.Open();

                    string q2 = "select * from conflight where cf_no='" + textBox1.Text + "'";

                    SqlCommand cmd2 = new SqlCommand(q2, con);

                    SqlDataReader dr2 = cmd2.ExecuteReader();
                    dr2.Read();
                    if (!dr2.HasRows)
                    {
                        con.Close();
                        con.Open();
                        string q3 = "select * from destflight where df_no='" + textBox1.Text + "'";

                        SqlCommand cmd3 = new SqlCommand(q3, con);

                        SqlDataReader dr3 = cmd3.ExecuteReader();
                        dr3.Read();

                        if (!dr3.HasRows)
                        {
                            con.Close();


                        }
                        else
                        {
                            con.Close();
                            con.Open();
                            SqlCommand cmdc3 = new SqlCommand("select * from destflight where df_no='" + textBox1.Text + "'", con);
                            SqlDataAdapter sd3 = new SqlDataAdapter(cmdc3);
                            DataTable dt3 = new DataTable();
                            sd3.Fill(dt3);
                            dataGridView1.DataSource = dt3;
                            con.Close();



                        }


                    }

                    else
                    {
                        con.Close();
                        con.Open();
                        SqlCommand cmdc2 = new SqlCommand("select * from conflight where cf_no='" + textBox1.Text + "'", con);
                        SqlDataAdapter sd2 = new SqlDataAdapter(cmdc2);
                        DataTable dt2 = new DataTable();
                        sd2.Fill(dt2);
                        dataGridView1.DataSource = dt2;
                        con.Close();


                    }

                }
                else
                {
                    con.Close();
                    con.Open();
                    SqlCommand cmdc1 = new SqlCommand("select * from flight where f_no='" + textBox1.Text + "'", con);
                    SqlDataAdapter sd1 = new SqlDataAdapter(cmdc1);
                    DataTable dt1 = new DataTable();
                    sd1.Fill(dt1);
                    dataGridView1.DataSource = dt1;
                    con.Close();

                }
            }

            else
                MessageBox.Show("Enter Details ");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                string q1 = "select * from flight where f_no='" + textBox1.Text + "'";
                con.Open();
                SqlCommand cmd = new SqlCommand(q1, con);
                SqlDataReader dr1 = cmd.ExecuteReader();
                dr1.Read();
                if (!dr1.HasRows)
                {
                    con.Close();
                    con.Open();
                    string q2 = "select * from conflight where f_no='" + textBox1.Text + "'";
                    SqlCommand cmd2 = new SqlCommand(q2, con);
                    SqlDataReader dr2 = cmd.ExecuteReader();
                    dr2.Read();
                    if (!dr2.HasRows)
                    {
                        con.Close();
                        con.Open();
                        string q3 = "select * from destflight where df_no='" + textBox1.Text + "'";
                        SqlCommand cmd3 = new SqlCommand(q3, con);
                        SqlDataReader dr3 = cmd.ExecuteReader();
                        dr3.Read();

                        if (!dr3.HasRows)
                        {
                            MessageBox.Show("No Flight Exist With This Flight Number");
                            con.Close();


                        }
                        else
                        {

                            string quupdate = "update destflight set delet='y' where df_no='" + textBox1.Text + "'";
                            string reg = "update conflight set delet='y' where cf_no='" + textBox1.Text + "'";



                            con.Close();
                            cmd3.CommandText = reg;
                            cmd3.CommandType = CommandType.Text;
                            cmd3.Connection = con;
                            con.Open();
                            cmd3.ExecuteNonQuery();
                            con.Close();

                            con.Close();
                            cmd3.CommandText = quupdate;
                            cmd3.CommandType = CommandType.Text;
                            cmd3.Connection = con;
                            con.Open();
                            cmd3.ExecuteNonQuery();
                            con.Close();
                            MessageBox.Show("flight data is deleted");



                        }


                    }

                    else
                    {
                        string quupdate = "update conflight set updat='y' where cf_no='" + textBox1.Text + "'";
                        /*string reg = "delete  from reservation where cf_no='" + textBox1.Text + "'";

                        con.Close();
                        cmd2.CommandText = reg;
                        cmd2.CommandType = CommandType.Text;
                        cmd2.Connection = con;
                        con.Open();
                        cmd2.ExecuteNonQuery();*/
                        con.Close();




                        cmd2.CommandText = quupdate;
                        cmd2.CommandType = CommandType.Text;
                        cmd2.Connection = con;
                        con.Open();
                        cmd2.ExecuteNonQuery();
                        con.Close();

                        MessageBox.Show("flight data is deleted");

                    }

                }
                else
                {
                    string quupdate = "update flight set delet='y' where f_no='" + textBox1.Text + "'";
                    /*   string reg = "delete  from reservation where f_no='" + textBox1.Text + "'";

                       con.Close();
                       cmd.CommandText = reg;
                       cmd.CommandType = CommandType.Text;
                       cmd.Connection = con;
                       con.Open();
                       cmd.ExecuteNonQuery();*/
                    con.Close();
                    cmd.CommandText = quupdate;
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();


                    MessageBox.Show("flight data is deleted");

                }





            }
            else
                MessageBox.Show("Please enter details");
        }
        private void delete_Load(object sender, EventArgs e)
        {
            BackgroundImageLayout = ImageLayout.Stretch;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            admin a1 = new admin("name");
            a1.Show();
            this.Hide();
        }
    }
}
