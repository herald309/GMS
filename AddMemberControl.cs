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
using GymManagement.Properties;
using System.IO;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Configuration;

namespace GymManagement
{
    public partial class AddMemberControl : UserControl
    {
        private static AddMemberControl _instance;
        public static AddMemberControl Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AddMemberControl();
                }
                return _instance;
            }
        }
        public AddMemberControl()
        {
            InitializeComponent();
        }

        private void AddMemberControl_Load(object sender, EventArgs e)
        {
            //getemailinfo();
        }

        string constr = ConfigurationManager.ConnectionStrings["GMSDB"].ConnectionString;

        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\projects;Initial Catalog=GMSDataBase;Integrated Security=True");


        //upload Image
        private void profilepicbox_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Profile Picture";
            ofd.Filter = "Image file(*.png; *.jpg; *.gif)|*.png; *.jpg; *.gif";

            if(ofd.ShowDialog() == DialogResult.OK)
            {
                profilepicbox.Image = new Bitmap(ofd.FileName);
                PicLabel.Visible = false;
            }
        }

        //converting images
        private byte[] savephoto()
        {
            MemoryStream ms = new MemoryStream();
            profilepicbox.Image.Save(ms, profilepicbox.Image.RawFormat);
            return ms.ToArray();
        }

        // auto select renewal date depending on membership type
        private void Membershipbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Membershipbox.SelectedIndex == 0)
            {
                renewalDatepicker.Value = todaysDatepicker.Value.AddDays(30);
                
            }
            if(Membershipbox.SelectedIndex == 1)
            {
                renewalDatepicker.Value = todaysDatepicker.Value.AddDays(90);
            }
            if(Membershipbox.SelectedIndex == 2)
            {
                renewalDatepicker.Value = todaysDatepicker.Value.AddDays(160);
            }
            if(Membershipbox.SelectedIndex == 3)
            {
                renewalDatepicker.Value = todaysDatepicker.Value.AddDays(365);
            }
        }



        // validation color controls
        private void fullnametxtbox_TextChanged(object sender, EventArgs e)
        {
            Control ctrl = (Control)sender;
            ctrl.BackColor = Color.White;
        }

        private bool isValid()
        {
            //character validations regex
            //string characterpattern = "[a-zA-Z ]*$";
            string mailpattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            string phonenregex = "^[0-9]{10}";
            string ageregex = "^[0-9]{2}";

            //fullname validation
            if (fullnametxtbox.Text == "")
            {
                fullnametxtbox.BackColor = Color.LightPink;
                fullnametxtbox.Focus();
                MessageBox.Show("FullName field cannot be empty", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            //fathername validation
            if (fathernametxtbox.Text == "")
            {
                fathernametxtbox.BackColor = Color.LightPink;
                fathernametxtbox.Focus();
                MessageBox.Show("FatherName field cannot be empty", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            //email validation
            if (Emailbox.Text == "")
            {
                Emailbox.BackColor = Color.LightPink;
                Emailbox.Focus();
                MessageBox.Show("Email Field Cannot be empty", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (Regex.IsMatch(Emailbox.Text, mailpattern) == false)
            {
                Emailbox.BackColor = Color.LightPink;
                Emailbox.Focus();
                MessageBox.Show("Email ID is badly formatted", "validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                SqlConnection con = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand("Select * from MemberTable Where EmailID = '" + Emailbox.Text + "'", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                int i = ds.Tables[0].Rows.Count;
                if (i > 0)
                {
                    MessageBox.Show("Email ID = " + Emailbox.Text + " found in records", "Duplicate Record Found", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Emailbox.BackColor = Color.LightPink;
                    Emailbox.Focus();
                    return false;
                }
            }

            //age
            if (dobbox.Text == "")
            {
                dobbox.BackColor = Color.LightPink;
                dobbox.Focus();
                MessageBox.Show("Age field cannot be empty", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (Regex.IsMatch(dobbox.Text, ageregex) == false)
            {
                dobbox.BackColor = Color.LightPink;
                dobbox.Focus();
                MessageBox.Show("Age should be in numbers only", "validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            //fees
            if (feebox.Text == "")
            {
                feebox.BackColor = Color.LightPink;
                dobbox.Focus();
                MessageBox.Show("fees field cannot be empty", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (Regex.IsMatch(feebox.Text, ageregex) == false)
            {
                feebox.BackColor = Color.LightPink;
                feebox.Focus();
                MessageBox.Show("fees should be in numbers only", "validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            //phone
            if (phonebox.Text == "")
            {
                phonebox.BackColor = Color.LightPink;
                phonebox.Focus();
                MessageBox.Show("Phone No field cannot be empty", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (Regex.IsMatch(phonebox.Text, phonenregex) == false)
            {
                phonebox.BackColor = Color.LightPink;
                phonebox.Focus();
                MessageBox.Show("invalid PhoneNumber Formatting", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                SqlConnection con = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand("Select * from MemberTable Where PhoneNo = '" + phonebox.Text + "'", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                int i = ds.Tables[0].Rows.Count;
                if (i > 0)
                {
                    MessageBox.Show("Phone Number = " + phonebox.Text + " found in records", "Duplicate Record Found", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Emailbox.BackColor = Color.LightPink;
                    Emailbox.Focus();
                    return false;
                }
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

            //image
            //if (PicLabel.Visible == true)
            //{
            //    MessageBox.Show("A profile pic is required for the registration", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return false;
            //}

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


            return true;
        }

        //save button code
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            // successfull validated code is here
            if(isValid())
            {
                try
                {
                    SqlConnection con = new SqlConnection(constr);
                    SqlCommand cmd = new SqlCommand("Insert into MemberTable Values(@Membername, @fathername, @gender, @age, @phoneNo, @Emailid, @Address, @joiningDate, @renewaldate, @membershiptype, @feepaid, @timings, @photo, @adddatetime)", con);

                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Membername", fullnametxtbox.Text);
                    cmd.Parameters.AddWithValue("@fathername", fathernametxtbox.Text);
                    cmd.Parameters.AddWithValue("@gender", genderbox.Text);
                    cmd.Parameters.AddWithValue("@age", dobbox.Text);
                    cmd.Parameters.AddWithValue("@phoneNo", phonebox.Text);
                    cmd.Parameters.AddWithValue("@Emailid", Emailbox.Text);
                    cmd.Parameters.AddWithValue("@Address", AddressBox.Text);
                    cmd.Parameters.AddWithValue("@joiningDate", todaysDatepicker.Value.Date);
                    cmd.Parameters.AddWithValue("@renewaldate", renewalDatepicker.Value.Date);
                    cmd.Parameters.AddWithValue("@membershiptype", Membershipbox.Text);
                    cmd.Parameters.AddWithValue("@feepaid", feebox.Text);
                    cmd.Parameters.AddWithValue("@timings", GymTimingBox.Text);
                    cmd.Parameters.AddWithValue("@Photo", DBNull.Value);
                    cmd.Parameters.AddWithValue("@adddatetime", DateTime.Now);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    //Amount added to income source
                    ViewMembers viewMembers = new ViewMembers();
                    int existingIncome = viewMembers.GetGYMIncome();
                    SqlCommand cmd2 = new SqlCommand("Update gymincome set amount = @amount where id = 1", con);
                    cmd2.CommandType = CommandType.Text;
                    cmd2.Parameters.AddWithValue("@amount", Convert.ToInt32(feebox.Text) + existingIncome);
                    con.Open();
                    cmd2.ExecuteNonQuery();
                    con.Close();
                    //send a greeting message to client
                    //SendGreetings();
                    // validation message
                    MessageBox.Show("user info saved successfully");

                    //clear all fields
                    resetboxes();

                   
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
               
            }
        }




        private void SendGreetings()
        {
            try
            {
                SmtpClient client = new SmtpClient()
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential()
                    {
                        UserName = emailid,
                        Password = password
                    }
                };
                MailAddress fromEmail = new MailAddress(emailid, gymname);
                MailAddress ToEmail = new MailAddress(Emailbox.Text, fullnametxtbox.Text);
                MailMessage Message = new MailMessage()
                {
                    From = fromEmail,
                    Subject = gymname + "Thankyou for joining our gym",
                    Body = "Hello " + fullnametxtbox.Text + "Thankyou for joininng with us, Your Plan Details are, Joined on " + todaysDatepicker.Text + " And your Renewal Date is " + renewalDatepicker.Text + " And Fee Paid = " + feebox.Text + "Regards " + gymname
                };
                Message.To.Add(ToEmail);
                client.SendCompleted += Client_SendCompleted;
                client.SendMailAsync(Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Client_SendCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show("Error");
            }
            else
            {
                MessageBox.Show("A Mail has Sent Successfully to the user");
            }
        }

        public void resetboxes()
        {
            fullnametxtbox.Clear();
            fathernametxtbox.Clear();
            Emailbox.Clear();
            dobbox.Clear();
            phonebox.Clear();
            AddressBox.Clear();
            feebox.Clear();
            genderbox.SelectedIndex = -1;
            Membershipbox.SelectedIndex = -1;
            profilepicbox.Image = null;
            profilepicbox.Image = Resources.user;
            PicLabel.Visible = true;
            todaysDatepicker.Value = DateTime.Now;
            renewalDatepicker.Value = DateTime.Now;
            GymTimingBox.SelectedIndex = -1;

            fullnametxtbox.Focus();
        }

        private void clearallbtn_Click(object sender, EventArgs e)
        {
            resetboxes();
        }

        string emailid;
        string password;
        string gymname;

        private void getemailinfo()
        {
            SqlCommand cmd = new SqlCommand("Select GymEmailID, Password, GymName from GymDetails", con);

            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                emailid = sdr.GetValue(0).ToString();
                password = sdr.GetValue(1).ToString();
                gymname = sdr.GetValue(2).ToString();
            }
            con.Close();
        }

        private void PicLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
