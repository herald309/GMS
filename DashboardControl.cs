using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace GymManagement
{
    public partial class DashboardControl : UserControl
    {
        private static DashboardControl _instance;

        public static DashboardControl Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new DashboardControl();
                }
                return _instance;
            }
        }
        public DashboardControl()
        {
            InitializeComponent();
        }


        //  DATABASE CONNECTION STRING
        string constr = ConfigurationManager.ConnectionStrings["GMSDB"].ConnectionString;


        private void DashboardControl_Load(object sender, EventArgs e)
        {
            totalclients();
            totalclientsFee();
            totalstaff();
            totalequipments();

            //load all epirying accounts data
            loadExpiryingAccounts();
            loadExpiredAccounts();
            // add styles to datagirdview
            datagridviewstyle();

        }

        private void datagridviewstyle()
        {
            // for expirying accounts
            ExpiryDates.BorderStyle = BorderStyle.None;
            ExpiryDates.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#DAE0E2");
            ExpiryDates.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            ExpiryDates.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#2F363F");
            ExpiryDates.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            ExpiryDates.BackgroundColor = ColorTranslator.FromHtml("#EAF0F1");

            ExpiryDates.EnableHeadersVisualStyles = false;
            ExpiryDates.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            ExpiryDates.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#2F363F");
            ExpiryDates.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            //for expired yesterday accounts
            ExpiredAccountsList.BorderStyle = BorderStyle.None;
            ExpiredAccountsList.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#DAE0E2");
            ExpiredAccountsList.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            ExpiredAccountsList.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#2F363F");
            ExpiredAccountsList.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            ExpiredAccountsList.BackgroundColor = ColorTranslator.FromHtml("#EAF0F1");

            ExpiredAccountsList.EnableHeadersVisualStyles = false;
            ExpiredAccountsList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            ExpiredAccountsList.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#2F363F");
            ExpiredAccountsList.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

        }

        //get total clients fee data
        private void totalclientsFee()
        {
            //SqlConnection con = new SqlConnection(constr);
            //SqlCommand cmd = new SqlCommand("Select * from MemberTable", con);

            //con.Open();
            //SqlDataReader sdr = cmd.ExecuteReader();

            //DataTable dtclients = new DataTable();
            //dtclients.Load(sdr);
            //con.Close();
            //EarningsDGV.DataSource = dtclients;

            //decimal Total = 0;

            //for (int i = 0; i < EarningsDGV.Rows.Count; i++)
            //{
            //    Total += Convert.ToDecimal(EarningsDGV.Rows[i].Cells["FeePaid"].Value);
            //}

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
           
            TotalEarnedLabel.Text = "₹" + income.ToString();
        }

        //get total clients number
        private void totalclients()
        {
            SqlConnection con = new SqlConnection(constr);
            string sql = "Select * from MemberTable";

            con.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.Fill(ds);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            totalclientsDGV.DataSource = ds.Tables[0];

            totalclientslabel.Text = ds.Tables[0].Rows.Count.ToString();
        }
        // get total staff numbers
        private void totalstaff()
        {
            SqlConnection con = new SqlConnection(constr);
            string sql = "Select * from StaffTable";

            con.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.Fill(ds);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            totalstaffDGV.DataSource = ds.Tables[0];

            totalstafflabel.Text = ds.Tables[0].Rows.Count.ToString();
        }
        // get total equipments data
        private void totalequipments()
        {
            SqlConnection con = new SqlConnection(constr);
            string sql = "Select * from EquipmentTable";

            con.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.Fill(ds);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            TotalequipmentsDGV.DataSource = ds.Tables[0];

            totalequiplabel.Text = ds.Tables[0].Rows.Count.ToString();
        }







        //load expiry dates members
        private void loadExpiryingAccounts()
        {
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("Select MemberID, Name, JoiningDate, RenewalDate from MemberTable Where RenewalDate Between '" + dateTime.Value.ToString("yyyy/MM/dd") + "' And '" + dateTime.Value.AddDays(7).ToString("yyyy/MM/dd") + "'", con);

            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            DataTable dtclients = new DataTable();
            dtclients.Load(sdr);
            con.Close();
            ExpiryDates.DataSource = dtclients;
        }

        string yesterday = DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd");
        
        
        private void loadExpiredAccounts()
        {
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("Select MemberID, Name, JoiningDate, RenewalDate from MemberTable Where RenewalDate =  '"+yesterday+"' ", con);


            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            DataTable dtclients = new DataTable();
            dtclients.Load(sdr);
            con.Close();
            ExpiredAccountsList.DataSource = dtclients;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MusicPlayerWindow.URL = paths[songslist.SelectedIndex];
        }
        string[] paths, files;

        private void Reset_Click(object sender, EventArgs e)
        {
            songslist.Items.Clear();
            AddMusic.Enabled = true;
            label1.Visible = false;
        }

        private void RefreshDashBoard_Click(object sender, EventArgs e)
        {
            totalclients();
            totalclientsFee();
            totalstaff();
            totalequipments();

            loadExpiryingAccounts();
            loadExpiredAccounts();
        }


        private void AddMusic_Click(object sender, EventArgs e)
        {
            
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Multiselect = true;
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    files = ofd.SafeFileNames;
                    paths = ofd.FileNames;

                    for (int i = 0; i < files.Length; i++)
                    {
                        songslist.Items.Add(files[i]);
                    }
                }

            AddMusic.Enabled = false;

            if(AddMusic.Enabled == false)
            {
                label1.Visible = true;
            }
        }
    }
}
