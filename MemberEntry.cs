using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymManagement
{
    public partial class MemberEntry : Form
    {
        public MemberEntry()
        {
            InitializeComponent();
        }

        string constr = ConfigurationManager.ConnectionStrings["GMSDB"].ConnectionString;

        private void SearchByIdBtn_Click(object sender, EventArgs e)
        {
            if (SearchByIDTextbox.Text == string.Empty)
            {
                MessageBox.Show("Please enter Member ID to Search");
            }
            else
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(constr))
                    {
                        using (SqlCommand cmd = new SqlCommand("Select MemberId, Name, RenewalDate from MemberTable Where MemberID LIKE '%" + SearchByIDTextbox.Text + "%'"))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Connection = con;
                            con.Open();
                            using (SqlDataReader sdr = cmd.ExecuteReader())
                            {
                                DateTime todayDate = DateTime.Now.Date;
                                sdr.Read();
                                MemberIDLabel.Text = sdr["MemberId"].ToString();
                                MemberNameLabel.Text = sdr["Name"].ToString();
                                DateTime renewalDate = Convert.ToDateTime(sdr["renewaldate"]);
                                ExpiredDaysLabel.Text = Convert.ToString((renewalDate - todayDate).TotalDays);
                            }
                            con.Close();
                        }
                    }
                }
                catch(Exception ex)
                {
                    if(ex.Message == "Invalid attempt to read when no data is present.")
                    {
                        MessageBox.Show("No Member data found!");
                    }
                    else
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
               
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void InButton_Click(object sender, EventArgs e)
        {
            if (MemberIDLabel.Text == string.Empty)
            {
                MessageBox.Show("Please enter Member ID or Phone Number to Search");
            }
            else
            {
                SqlConnection con2 = new SqlConnection(constr);

                SqlDataAdapter sda1 = new SqlDataAdapter("Select id from memberentry Where memberid = '" + Convert.ToInt32( MemberIDLabel.Text) + "' and [status] in (1,2) and adddatetime = '" + DateTime.Now.Date + "'", con2);

                con2.Open();
                DataTable dt1 = new DataTable();
                sda1.Fill(dt1);
                con2.Close();

                if (dt1.Rows.Count == 1)
                {
                    MessageBox.Show("You Already Check In");
                    resetsearchboxes();
                }
                else
                {
                    try
                    {
                        SqlConnection con = new SqlConnection(constr);
                        SqlCommand cmd = new SqlCommand("Insert into MemberEntry Values(@memberid, @status, @adddatetime, @intime, @outtime)", con);

                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@memberid", Convert.ToInt32(MemberIDLabel.Text));
                        cmd.Parameters.AddWithValue("@status", 1);
                        cmd.Parameters.AddWithValue("@adddatetime", DateTime.Now.Date);
                        cmd.Parameters.AddWithValue("@intime", Convert.ToString( DateTime.Now.TimeOfDay));
                        cmd.Parameters.AddWithValue("@outtime","");

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();

                        MessageBox.Show("Check In successfully");
                        resetsearchboxes();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void OutButton_Click(object sender, EventArgs e)
        {
            if (MemberIDLabel.Text == string.Empty)
            {
                MessageBox.Show("Please enter Member ID or Phone Number to Search");
            }
            else
            {
                SqlConnection con1 = new SqlConnection(constr);

                SqlDataAdapter sda = new SqlDataAdapter("Select id, status from memberentry Where memberid LIKE '%" + MemberIDLabel.Text + "%' and [status] in (1,2) and adddatetime = '" + DateTime.Now.Date + "'", con1);

                con1.Open();
                DataTable dt = new DataTable();
                sda.Fill(dt);
                con1.Close();

                int status = 0;
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Please make CheckIn First");
                }
                else
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        status = Convert.ToInt32(row.ItemArray[1]);
                    }

                    if (status == 2)
                    {
                        MessageBox.Show("You Already Check Out");
                        resetsearchboxes();
                    }
                    else
                    {
                        try
                        {
                            SqlConnection con = new SqlConnection(constr);
                            SqlCommand cmd = new SqlCommand("Update memberentry set outtime = @outtime, status = @status Where MemberID = @memberid  and adddatetime = '" + DateTime.Now.Date + "'", con);
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@memberid", Convert.ToInt32(MemberIDLabel.Text));
                            cmd.Parameters.AddWithValue("@status", 2);
                            cmd.Parameters.AddWithValue("@outtime", Convert.ToString(DateTime.Now.TimeOfDay));

                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();

                            MessageBox.Show("Check Out successfully");
                            resetsearchboxes();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
        }

        private void resetsearchboxes()
        {
            SearchByIDTextbox.Clear();
            //SearchByIDTextbox.Text = "Search by ID";
            SearchByIDTextbox.ForeColor = Color.DarkGray;
            MemberIDLabel.ResetText();
            MemberNameLabel.ResetText();
            ExpiredDaysLabel.ResetText();
            SearchByPhoneTextbox.Clear();
            //SearchByPhoneTextbox.Text = "Search by PhoneNo";
            SearchByPhoneTextbox.ForeColor = Color.DarkGray;
        }

        private void MemberIDLabel_Click(object sender, EventArgs e)
        {

        }

        private void SearchByPhoneBtn_Click(object sender, EventArgs e)
        {
            if (SearchByPhoneTextbox.Text == string.Empty)
            {
                MessageBox.Show("Please enter PhoneNo to Search");
            }
            else
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(constr))
                    {
                        using (SqlCommand cmd = new SqlCommand("Select MemberId, Name, RenewalDate from MemberTable Where phoneno = '" + SearchByPhoneTextbox.Text + "'"))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Connection = con;
                            con.Open();
                            using (SqlDataReader sdr = cmd.ExecuteReader())
                            {
                                DateTime todayDate = DateTime.Now.Date;
                                sdr.Read();
                                MemberIDLabel.Text = sdr["MemberId"].ToString();
                                MemberNameLabel.Text = sdr["Name"].ToString();
                                DateTime renewalDate = Convert.ToDateTime(sdr["renewaldate"]);
                                ExpiredDaysLabel.Text = Convert.ToString((renewalDate - todayDate).TotalDays);
                            }
                            con.Close();
                        }
                    }
                }
                catch(Exception ex)
                {
                    if (ex.Message == "Invalid attempt to read when no data is present.")
                    {
                        MessageBox.Show("No Member data found!");
                    }
                    else
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
