using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.IO;
using GymManagement.Properties;
using System.Configuration;

namespace GymManagement
{
    public partial class ViewMembers : UserControl
    {
        private static ViewMembers _instance;
        public static ViewMembers Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ViewMembers();
                }
                return _instance;
            }
        }

        public DateTime renewalDate;
        public int oldAmount = 0;
        public ViewMembers()
        {
            InitializeComponent();
        }


        //  DATABASE CONNECTION STRING
        string constr = ConfigurationManager.ConnectionStrings["GMSDB"].ConnectionString;


        //search by ID number
        private void SearchByIDTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (SearchByIDTextbox.Text == "Search by ID")
            {
                SearchByIDTextbox.Text = "";
                SearchByIDTextbox.ForeColor = Color.Black;
            }
        }

        //search by phone number
        private void SearchByPhoneTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (SearchByPhoneTextbox.Text == "Search by PhoneNo")
            {
                SearchByPhoneTextbox.Text = "";
                SearchByPhoneTextbox.ForeColor = Color.Black;
            }
        }

        //reset search boxes
        private void resetsearchboxes()
        {
            SearchByIDTextbox.Clear();
            SearchByIDTextbox.Text = "Search by ID";
            SearchByIDTextbox.ForeColor = Color.DarkGray;

            SearchByPhoneTextbox.Clear();
            SearchByPhoneTextbox.Text = "Search by PhoneNo";
            SearchByPhoneTextbox.ForeColor = Color.DarkGray;
        }

        //load image
        private void UserProfileImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Profile Picture";
            ofd.Filter = "Image file(*.png; *.jpg; *.gif)|*.png; *.jpg; *.gif";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                UserProfileImage.Image = new Bitmap(ofd.FileName);
            }
        }

        //save photo
        private byte[] savephoto()
        {
            MemoryStream ms = new MemoryStream();
            UserProfileImage.Image.Save(ms, UserProfileImage.Image.RawFormat);
            return ms.GetBuffer();
        }


        //search by id button
        private void SearchByIdBtn_Click(object sender, EventArgs e)
        {
            if (SearchByIDTextbox.Text == "Search by ID" || SearchByIDTextbox.Text == string.Empty)
            {
                MessageBox.Show("Please enter Member ID to Search");
            }
            else
            {
                SqlConnection con = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand("Select * from MemberTable Where MemberID LIKE '%" + SearchByIDTextbox.Text + "%'", con);

                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                DataTable dtmember = new DataTable();
                dtmember.Load(sdr);
                con.Close();
                MembersDataGridView.DataSource = dtmember;
            }
        }

        // search by phone number button
        private void SearchByPhoneBtn_Click(object sender, EventArgs e)
        {
            if (SearchByPhoneTextbox.Text == "Search by PhoneNo" || SearchByPhoneTextbox.Text == string.Empty)
            {
                MessageBox.Show("Please enter Member's Phone.No to Search");
            }
            else
            {
                SqlConnection con = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand("Select * from MemberTable Where PhoneNo LIKE '%" + SearchByPhoneTextbox.Text + "%'", con);

                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                DataTable dtmember = new DataTable();
                dtmember.Load(sdr);
                con.Close();
                MembersDataGridView.DataSource = dtmember;
            }

        }

        //validations
        private bool isValid()
        {
            //character validations regex
            //string characterpattern = "[a-zA-Z ]*$";
            string mailpattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            string phonenregex = "^[0-9]{10}";
            string ageregex = "^[0-9]{2}";

            //fullname validation
            if (MemberName.Text == "")
            {
                MemberName.BackColor = Color.LightPink;
                MemberName.Focus();
                MessageBox.Show("Name field cannot be empty", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            //fathername validation
            if (FatherName.Text == "")
            {
                FatherName.BackColor = Color.LightPink;
                FatherName.Focus();
                MessageBox.Show("FatherName field cannot be empty", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            //email validation
            if (EmailID.Text == "")
            {
                EmailID.BackColor = Color.LightPink;
                EmailID.Focus();
                MessageBox.Show("Email Field Cannot be empty", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (Regex.IsMatch(EmailID.Text, mailpattern) == false)
            {
                EmailID.BackColor = Color.LightPink;
                EmailID.Focus();
                MessageBox.Show("Email ID is badly formatted", "validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            //age
            if (Age.Text == "")
            {
                Age.BackColor = Color.LightPink;
                Age.Focus();
                MessageBox.Show("Age field cannot be empty", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (Regex.IsMatch(Age.Text, ageregex) == false)
            {
                Age.BackColor = Color.LightPink;
                Age.Focus();
                MessageBox.Show("Age should be in numbers only", "validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            //fees
            if (Feebox.Text == "")
            {
                Feebox.BackColor = Color.LightPink;
                Feebox.Focus();
                MessageBox.Show("Fees field cannot be empty", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (Regex.IsMatch(Feebox.Text, ageregex) == false)
            {
                Feebox.BackColor = Color.LightPink;
                Feebox.Focus();
                MessageBox.Show("Fees should be in numbers only", "validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            //phone
            if (PhoneNo.Text == "")
            {
                PhoneNo.BackColor = Color.LightPink;
                PhoneNo.Focus();
                MessageBox.Show("Phone No field cannot be empty", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (Regex.IsMatch(PhoneNo.Text, phonenregex) == false)
            {
                PhoneNo.BackColor = Color.LightPink;
                PhoneNo.Focus();
                MessageBox.Show("invalid PhoneNumber Formatting", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            //address
            if (AddressBox.Text == "")
            {
                AddressBox.BackColor = Color.LightPink;
                AddressBox.Focus();
                MessageBox.Show("Address field cannot be empty", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            //joining
            if (todaysDatepicker.Value == renewalDatepicker.Value || renewalDatepicker.Value == todaysDatepicker.Value)
            {
                todaysDatepicker.Focus();
                MessageBox.Show("Todays date cannot be same as renewal date", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // ending
            if (renewalDatepicker.Value == todaysDatepicker.Value)
            {
                renewalDatepicker.Focus();
                MessageBox.Show("renewal date cannot be same as current date", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            //genderbox 
            if (genderbox.SelectedIndex == -1)
            {
                genderbox.BackColor = Color.LightPink;
                genderbox.Focus();
                MessageBox.Show("Please select your gender", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }

            //membership 
            if (Membershipbox.SelectedIndex == -1)
            {
                Membershipbox.BackColor = Color.LightPink;
                Membershipbox.Focus();
                MessageBox.Show("Please Select your MemberShip Type", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }

            //timings
            if (GymTimingBox.SelectedIndex == -1)
            {
                GymTimingBox.BackColor = Color.LightPink;
                GymTimingBox.Focus();
                MessageBox.Show("Please select gym timings", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }


            return true;
        }

        private void clear()
        {
            MemberID.Clear();
            MemberName.Clear();
            FatherName.Clear();
            genderbox.SelectedIndex = -1;
            Age.Clear();
            PhoneNo.Clear();
            EmailID.Clear();
            AddressBox.Clear();
            todaysDatepicker.Value = DateTime.Now;
            renewalDatepicker.Value = DateTime.Now;
            Membershipbox.SelectedIndex = -1;
            Feebox.Clear();
            GymTimingBox.SelectedIndex = -1;
            UserProfileImage.Image = Resources.DefaultImage;
        }

        //update user data button
        private void updatebtn_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                SqlConnection con = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand("Update MemberTable set Name = @Membername, FatherName = @fathername, Gender = @gender, Age = @age, PhoneNo = @phoneNo, EmailID = @Emailid, Address = @Address, JoiningDate = @joiningDate, RenewalDate = @renewaldate, MemberShipType = @membershiptype, FeePaid = @feepaid, Timings = @timings, Photo = @photo Where MemberID = @memberid", con);

                int amount = Convert.ToInt32(Feebox.Text);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Membername", MemberName.Text);
                cmd.Parameters.AddWithValue("@fathername", FatherName.Text);
                cmd.Parameters.AddWithValue("@gender", genderbox.Text);
                cmd.Parameters.AddWithValue("@age", Age.Text);
                cmd.Parameters.AddWithValue("@phoneNo", PhoneNo.Text);
                cmd.Parameters.AddWithValue("@Emailid", EmailID.Text);
                cmd.Parameters.AddWithValue("@Address", AddressBox.Text);
                cmd.Parameters.AddWithValue("@joiningDate", todaysDatepicker.Value.Date);
                cmd.Parameters.AddWithValue("@renewaldate", renewalDatepicker.Value.Date);
                cmd.Parameters.AddWithValue("@membershiptype", Membershipbox.Text);
                cmd.Parameters.AddWithValue("@feepaid", Feebox.Text);
                cmd.Parameters.AddWithValue("@timings", GymTimingBox.Text);
                cmd.Parameters.AddWithValue("@photo", DBNull.Value);
                cmd.Parameters.AddWithValue("@memberid", MemberID.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

               
                if (oldAmount != amount)
                {
                    int existingIncome = GetGYMIncome();
                    SqlCommand cmd2 = new SqlCommand("Update gymincome set amount = @amount where id = 1", con);
                    cmd2.CommandType = CommandType.Text;
                    cmd2.Parameters.AddWithValue("@amount", amount + existingIncome);
                    con.Open();
                    cmd2.ExecuteNonQuery();
                    con.Close();
                }

                MessageBox.Show("Member Details Updated Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                resetsearchboxes();
                clear();
                GetMembersData();
            }
        }

        //delete button
        private void removebtn_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                SqlConnection con = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand("Delete From MemberTable Where MemberID = @memberid", con);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@memberid", MemberID.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Member Reocrd Deleted Successfully", "Delete Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clear();
                resetsearchboxes();
                GetMembersData();
            }
        }

        //auto select renewal date depending on membership type
        private void Membershipbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int days = 0;
          
            if (Membershipbox.SelectedIndex == 0)
            {
                days = 30;
                //renewalDatepicker.Value = todaysDatepicker.Value.AddDays(30);
            }
            if (Membershipbox.SelectedIndex == 1)
            {
                days = 90;
            }
            if (Membershipbox.SelectedIndex == 2)
            {
                days = 160;
            }
            if (Membershipbox.SelectedIndex == 3)
            {
                days = 365;
            }

            DateTime todayDate = DateTime.Now.Date;
            int remainingDays = Convert.ToInt32((renewalDate - todayDate).TotalDays);
            if (remainingDays < 0)
            {
                int extraDays = Math.Abs(remainingDays);
                int totalDays = days - extraDays;
                renewalDatepicker.Value = renewalDate.AddDays(totalDays);
            }
            else
            {
                int totalDays = days;
                renewalDatepicker.Value = renewalDate.AddDays(totalDays);
            }
        }


        private void ViewMembers_Load(object sender, EventArgs e)
        {
            GetMembersData();
            MembersDataGridView.BorderStyle = BorderStyle.None;
            MembersDataGridView.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#DAE0E2");
            MembersDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            MembersDataGridView.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#2F363F");
            MembersDataGridView.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            MembersDataGridView.BackgroundColor = ColorTranslator.FromHtml("#EAF0F1");

            MembersDataGridView.EnableHeadersVisualStyles = false;
            MembersDataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            MembersDataGridView.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#2F363F");
            MembersDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

        }

        // load data
        private void GetMembersData()
        {
            SqlConnection con = new SqlConnection(constr);
            //SqlCommand cmd = new SqlCommand("Select * from MemberTable", con);

            //con.Open();
            //SqlDataReader sdr = cmd.ExecuteReader();

            //DataTable dtclients = new DataTable();
            //dtclients.Load(sdr);
            //con.Close();
            //MembersDataGridView.DataSource = dtclients;

            //decimal Total = 0;

            //for (int i = 0; i < MembersDataGridView.Rows.Count; i++)
            //{
            //    Total += Convert.ToDecimal(MembersDataGridView.Rows[i].Cells["FeePaid"].Value);
            //}


            //totallabel.Text = Total.ToString();


            string sql = "Select * from MemberTable";

            con.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.Fill(ds);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            MembersDataGridView.DataSource = ds.Tables[0];

            totalmemberslabel.Text = ds.Tables[0].Rows.Count.ToString();
        }

        //text change
        private void MemberName_TextChanged(object sender, EventArgs e)
        {
            Control ctrl = (Control)sender;
            ctrl.BackColor = Color.White;
        }

        //select from datagridview
        private void MembersDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.MembersDataGridView.Rows[e.RowIndex];
                renewalDate = Convert.ToDateTime(row.Cells["RenewalDate"].Value);
                MemberID.Text = row.Cells["MemberID"].Value.ToString();
                MemberName.Text = row.Cells["Name"].Value.ToString();
                FatherName.Text = row.Cells["FatherName"].Value.ToString();
                genderbox.Text = row.Cells["Gender"].Value.ToString();
                Age.Text = row.Cells["Age"].Value.ToString();
                PhoneNo.Text = row.Cells["PhoneNo"].Value.ToString();
                EmailID.Text = row.Cells["EmailID"].Value.ToString();
                AddressBox.Text = row.Cells["Address"].Value.ToString();
                todaysDatepicker.Text = row.Cells["JoiningDate"].Value.ToString();
                renewalDatepicker.Text = row.Cells["RenewalDate"].Value.ToString();
                Membershipbox.Text = row.Cells["MemberShipType"].Value.ToString();
                Feebox.Text = row.Cells["FeePaid"].Value.ToString();
                GymTimingBox.Text = row.Cells["Timings"].Value.ToString();
                //var data = (Byte[])(row.Cells["Photo"].Value);
                //var stream = new MemoryStream(data);
                //UserProfileImage.Image = Image.FromStream(stream);
                oldAmount = Convert.ToInt32(row.Cells["FeePaid"].Value);
               
            }
        }

        private void Refreshbox_Click(object sender, EventArgs e)
        {
            GetMembersData();
            clear();
            resetsearchboxes();
        }

        private void MemberPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        public int GetGYMIncome()
        {
            SqlConnection con1 = new SqlConnection(constr);

            SqlDataAdapter sda = new SqlDataAdapter("Select amount from gymincome where id = 1 ", con1);
            int income = 0;
            con1.Open();
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con1.Close();

            foreach (DataRow row in dt.Rows)
            {
                income = Convert.ToInt32(row.ItemArray[0]);
            }
            return income;
        }

       
    }
}
