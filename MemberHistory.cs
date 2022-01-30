using DGVPrinterHelper;
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
            try
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
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

       
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
#pragma warning disable CS0436 // Type conflicts with imported type
            DGVPrinter printer = new DGVPrinter();
#pragma warning restore CS0436 // Type conflicts with imported type

            printer.Title = "Member History - Generated on " + DateTime.Now.ToString();

            printer.SubTitle = "Member ID: " + SearchByIDTextbox.Text + "  From  " + todaysDatepicker.Text + "  to  " + dateTimePicker1.Text + ", Count: " + labelCount.Text;

            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit |

                                          StringFormatFlags.NoClip;

            printer.PageNumbers = true;

            printer.PageNumberInHeader = false;

            printer.PorportionalColumns = false;

            printer.HeaderCellAlignment = StringAlignment.Near;

            printer.Footer = "Lisa Fitness, Sriram nagar, Karaikudi";

            printer.FooterSpacing = 15;

            printer.HideColumns.Add("memberid");

            printer.PrintDataGridView(MembersDataGridView);
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            
        }
    }
}
