using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GymManagement
{
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();
        }



        //  DATABASE CONNECTION STRING
        string constr = ConfigurationManager.ConnectionStrings["GMSDB"].ConnectionString;


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }


        public static string User;
        public static string usertype;


        //login 
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            User = UserNameTextBox.Text;
            usertype = UserTypeBox.Text;

            if (UserNameTextBox.Text == string.Empty || PasswordTextBox.Text == string.Empty)
            {
                MessageBox.Show("All Fields Are Required", "Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                SqlConnection con = new SqlConnection(constr);

                SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from Accounts Where UserName = '" + UserNameTextBox.Text + "' And UserPassword = '" + PasswordTextBox.Text + "' And UserType = '"+ UserTypeBox.Text +"' ", con);

                con.Open();
                DataTable dt = new DataTable();
                sda.Fill(dt);
               
                if (dt.Rows[0][0].ToString() == "1")
                {
                    SqlDataAdapter sda1 = new SqlDataAdapter("Select UserType from Accounts Where UserName = '" + UserNameTextBox.Text + "' And UserPassword = '" + PasswordTextBox.Text + "'", con);
                    DataTable dt1 = new DataTable();
                    sda1.Fill(dt1);
                    if(dt1.Rows[0][0].ToString() == "Admin")
                    {
                        GMS main = new GMS();
                        this.Hide();
                        main.Show();
                    }
                    if(dt1.Rows[0][0].ToString() == "User")
                    {
                        GMS foruser = new GMS();
                        this.Hide();
                        foruser.Show();
                    }
                   

                    MessageBox.Show("Welcome " + User, "Login Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Incorrect UserName Or Password", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

       
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
              
                ForgotPasswordPage fpp = new ForgotPasswordPage();
                fpp.Show();
                this.Hide();
            
            
        }

        private void LoginPage_Load(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            MemberEntry entry = new MemberEntry();
            entry.Show();
        }
    }
}
