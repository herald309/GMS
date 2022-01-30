using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace GymManagement
{
    public partial class GMS : Form
    {
        public GMS()
        {
            InitializeComponent();

            if (!this.Controls.Contains(DashboardControl.Instance))
            {
                this.Controls.Add(DashboardControl.Instance);
                DashboardControl.Instance.Dock = DockStyle.Fill;
                DashboardControl.Instance.BringToFront();
            }
            else
            {
                DashboardControl.Instance.BringToFront();
            }
            //dashboardControl1 = new DashboardControl();
            //dashboardControl1.BringToFront();
            dashboardbtn.BackColor = ColorTranslator.FromHtml("#E8290B");
        }

        // x (close button)
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // minimizing button
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }



        // dashboard button
        private void dashboardbtn_Click(object sender, EventArgs e)
        {
            if (!this.Controls.Contains(DashboardControl.Instance))
            {
                this.Controls.Add(DashboardControl.Instance);
                DashboardControl.Instance.Dock = DockStyle.Fill;
                DashboardControl.Instance.BringToFront();
            }
            else
            {
                DashboardControl.Instance.BringToFront();
            }
            //dashboardControl1.BringToFront();
            NavTitle.Text = "DashBoard";
     
        }

        // add members button
        private void addmembersbtn_Click(object sender, EventArgs e)
        {
            if (!this.Controls.Contains(AddMemberControl.Instance))
            {
                this.Controls.Add(AddMemberControl.Instance);
                AddMemberControl.Instance.Dock = DockStyle.Fill;
                AddMemberControl.Instance.BringToFront();
            }
            else
            {
                AddMemberControl.Instance.BringToFront();
            }
            //addMemberControl1.BringToFront();
            NavTitle.Text = "Add Members";
        }

        // add equipment button
        private void AddEquipmentsbtn_Click(object sender, EventArgs e)
        {
            if (!this.Controls.Contains(AddEquipmentsControl.Instance))
            {
                this.Controls.Add(AddEquipmentsControl.Instance);
                AddEquipmentsControl.Instance.Dock = DockStyle.Fill;
                AddEquipmentsControl.Instance.BringToFront();
            }
            else
            {
                AddEquipmentsControl.Instance.BringToFront();
            }
            NavTitle.Text = "Add Equipments";
        }

        // view members button
        private void ViewMembersBtn_Click(object sender, EventArgs e)
        {
            if (!this.Controls.Contains(ViewMembers.Instance))
            {
                this.Controls.Add(ViewMembers.Instance);
                ViewMembers.Instance.Dock = DockStyle.Fill;
                ViewMembers.Instance.BringToFront();
            }
            else
            {
                ViewMembers.Instance.BringToFront();
            }
            //viewMembers1.BringToFront();
            NavTitle.Text = "View Members";
        }

        // view equipments button
        private void ViewEquipmentBtn_Click(object sender, EventArgs e)
        {
            if (!this.Controls.Contains(ViewEquipmentControls.Instance))
            {
                this.Controls.Add(ViewEquipmentControls.Instance);
                ViewEquipmentControls.Instance.Dock = DockStyle.Fill;
                ViewEquipmentControls.Instance.BringToFront();
            }
            else
            {
                ViewEquipmentControls.Instance.BringToFront();
            }
            NavTitle.Text = "View Equipments";
        }

        //edit members button
        private void RemoveMemberBtn_Click(object sender, EventArgs e)
        {
            addstaff1.BringToFront();
            NavTitle.Text = "Add Staff";
        }

        //gym staff button
        private void GymStaffRecord_Click(object sender, EventArgs e)
        {
            gymStaffControls1.BringToFront();
            NavTitle.Text = "Gym Staff";
        }


        // on load GMS form or application
        private void GMS_Load(object sender, EventArgs e)
        {
            namelabel.Text = "Welcome back " + username;
        }

        string username = LoginPage.User;
        string usertype = LoginPage.usertype;


        // jump into admin settings
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if(usertype == "Admin")
            {
                AdminSettings ads = new AdminSettings();
                ads.Show();
            }
            else if(usertype == "User")
            {
                MessageBox.Show("Only Admins Can Login this page, Please Login As Admin", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
           
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            LoginPage lp = new LoginPage();
            this.Hide();
            lp.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            MemberHistory memberHistory = new MemberHistory();
            memberHistory.Show();
        }
    }
}
