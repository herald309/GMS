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
        static string constr = ConfigurationManager.ConnectionStrings["GMSDB"].ConnectionString;
        SqlConnection con = new SqlConnection(constr);

        public MemberEntry()
        {
            InitializeComponent();
        }


        private void pictureBox3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void resetsearchboxes()
        {
            SearchByIDTextbox.Clear();
           
            SearchByIDTextbox.ForeColor = Color.DarkGray;
            SearchByPhoneTextbox.Clear();
            SearchByPhoneTextbox.ForeColor = Color.DarkGray;
        }

        private void MemberIDLabel_Click(object sender, EventArgs e)
        {

        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        public void SearchbyID()
        {
            if (SearchByIDTextbox.Text == string.Empty)
            {
                msgBox.ForeColor = Color.Yellow;
                msgBox.Text = "Please enter Member ID to Search";
                //MessageBox.Show("Please enter Member ID to Search");
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
                catch (Exception ex)
                {
                    if (ex.Message == "Invalid attempt to read when no data is present.")
                    {
                        msgBox.ForeColor = Color.Yellow;
                        msgBox.Text = "No Member data found!";
                        //MessageBox.Show("No Member data found!");
                    }
                    else
                    {
                        msgBox.ForeColor = Color.Red;
                        msgBox.Text = ex.Message;
                        //MessageBox.Show(ex.Message);
                    }
                }

            }
        }

        public void MemberCheckIN()
        {
            int status = 0;
            SqlDataAdapter sda = new SqlDataAdapter("Select status from memberentry Where memberid = '" + Convert.ToInt32(MemberIDLabel.Text) + "' and adddatetime = '" + DateTime.Now.Date + "'", con);

            con.Open();
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();

            if (dt.Rows.Count == 1)
            {
                foreach (DataRow row in dt.Rows)
                {
                    status = Convert.ToInt32(row.ItemArray[0]);
                }
            }

            if (status == 2)
            {
                msgBox.ForeColor = Color.Green;
                msgBox.Text = "Your entries are already captured for the day!";
                //MessageBox.Show("Your entries are already captured for the day!");
            }
            else if (status == 1)
            {
                MemberCheckOut();
            }
            else
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("Insert into MemberEntry Values(@memberid, @status, @adddatetime, @intime, @outtime)", con);

                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@memberid", Convert.ToInt32(MemberIDLabel.Text));
                    cmd.Parameters.AddWithValue("@status", 1);
                    cmd.Parameters.AddWithValue("@adddatetime", DateTime.Now.Date);
                    cmd.Parameters.AddWithValue("@intime", Convert.ToString(DateTime.Now.TimeOfDay));
                    cmd.Parameters.AddWithValue("@outtime", "");

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    //MessageBox.Show("Check In successfully");
                    msgBox.ForeColor = Color.Green;
                    msgBox.Text = "Check In successfully";
                    resetsearchboxes();
                }
                catch (Exception ex)
                {
                    msgBox.ForeColor = Color.Red;
                    msgBox.Text = ex.Message;
                    //MessageBox.Show(ex.Message);
                }
            }
        } 

        public void MemberCheckOut()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Update memberentry set outtime = @outtime, status = @status Where MemberID = @memberid  and adddatetime = '" + DateTime.Now.Date + "'", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@memberid", Convert.ToInt32(MemberIDLabel.Text));
                cmd.Parameters.AddWithValue("@status", 2);
                cmd.Parameters.AddWithValue("@outtime", Convert.ToString(DateTime.Now.TimeOfDay));

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                //MessageBox.Show("Check Out successfully");
                msgBox.ForeColor = Color.Green;
                msgBox.Text = "Check Out successfully";
                resetsearchboxes();
            }
            catch (Exception ex)
            {
                msgBox.ForeColor = Color.Red;
                msgBox.Text = ex.Message;
                MessageBox.Show(ex.Message);
            }
        }

        private void MemberEntry_Enter(object sender, EventArgs e)
        {
          
        }

        private void MemberEntry_Load(object sender, EventArgs e)
        {
            this.ActiveControl = SearchByIDTextbox;
        }

        private void SearchByIDTextbox_Enter(object sender, EventArgs e)
        {
           
        }

        private void SearchByIDTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                SearchbyID();
                MemberCheckIN();
            }
        }

        private void SearchByPhoneTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SearchByPhoneNo();
            }
        }

        public void SearchByPhoneNo()
        {
            if (SearchByPhoneTextbox.Text == string.Empty)
            {
                msgBox.ForeColor = Color.Yellow;
                msgBox.Text = "Please enter PhoneNo to Search";
                //MessageBox.Show("Please enter PhoneNo to Search");
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
                    msgBox.Text = "";
                }
                catch (Exception ex)
                {
                    if (ex.Message == "Invalid attempt to read when no data is present.")
                    {
                        //MessageBox.Show("No Member data found!");
                        msgBox.ForeColor = Color.Yellow;
                        msgBox.Text = "No Member data found!";
                    }
                    else
                    {
                        msgBox.ForeColor = Color.Red;
                        msgBox.Text = ex.Message;
                        //MessageBox.Show(ex.Message);
                    }
                }

            }
        }
    }
}
