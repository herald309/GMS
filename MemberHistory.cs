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
    public partial class MemberHistory : Form
    {
        public MemberHistory()
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
                SqlConnection con = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand("Select * from memberentry Where adddatetime >= '" + todaysDatepicker.Value.ToString("yyyy/MM/dd") + "' and adddatetime <= '" + dateTimePicker1.Value.ToString("yyyy/MM/dd") + "' and memberid = '" + Convert.ToInt32(SearchByIDTextbox.Text) + "'", con);

                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                DataTable dtmember = new DataTable();
                dtmember.Load(sdr);
                con.Close();

                MembersDataGridView.DataSource = dtmember;
                labelCount.Text = MembersDataGridView.Rows.Count.ToString();

                if (MembersDataGridView.Rows.Count <= 0)
                {
                    MessageBox.Show("No records found!");
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

        private void resetsearchboxes()
        {
            SearchByIDTextbox.Clear();
            SearchByIDTextbox.ForeColor = Color.DarkGray;
            labelCount.ResetText();
            labelCount.Text = "0";
            todaysDatepicker.ResetText();
            dateTimePicker1.ResetText();
        }
    }
}
