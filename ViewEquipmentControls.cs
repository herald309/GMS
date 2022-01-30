using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GymManagement
{
    public partial class ViewEquipmentControls : UserControl
    {
        private static ViewEquipmentControls _instance;
        public static ViewEquipmentControls Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ViewEquipmentControls();
                }
                return _instance;
            }
        }
        public ViewEquipmentControls()
        {
            InitializeComponent();
        }


        //  DATABASE CONNECTION STRING
        string constr = ConfigurationManager.ConnectionStrings["GMSDB"].ConnectionString;


        string characterpattern = @"^[a-zA-Z\s]+$";
        string phonenregex = "^[0-9]{1}";


       

        //placeholder code
        private void SearchbyID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (SearchbyID.Text == "Search by ID")
            {
                SearchbyID.Text = "";
                SearchbyID.ForeColor = Color.Black;
            }
        }
        private void SearchbyEquipName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(SearchbyEquipName.Text == "Search by Name")
            {
                SearchbyEquipName.Text = "";
                SearchbyEquipName.ForeColor = Color.Black;
            }
        }

        private void resetsearchboxes()
        {
            SearchbyID.Clear();
            SearchbyID.Text = "Search by ID";
            SearchbyID.ForeColor = Color.DarkGray;

            SearchbyEquipName.Clear();
            SearchbyEquipName.Text = "Search by Name";
            SearchbyEquipName.ForeColor = Color.DarkGray;
        }

        //clear all code
        private void clearall()
        {
            EquipID.Clear();
            EquipName.Clear();
            EquipmentTypeBox.SelectedIndex = -1;
            EquipWeightBox.Clear();
            EquipCostbox.Clear();
            EquipQuantityBox.Clear();
            PurchasedPicked.Value = DateTime.Now;
        }

        //validations 
        private bool isValid()
        {

            //equipment name
            if (EquipName.Text == string.Empty)
            {
                MessageBox.Show("Fields cannot be empty", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return false;

            }
            else if (Regex.IsMatch(EquipName.Text, characterpattern) == false)
            {
                MessageBox.Show("Name field cannot be Symbols or numbers", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return false;
            }


            //equipment type
            if (EquipmentTypeBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select equipment type", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return false;
            }
            

            //equipment quantity
            if (EquipQuantityBox.Text == string.Empty)
            {
               MessageBox.Show("Fields cannot be empty", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return false;
            }
            else if (Regex.IsMatch(EquipQuantityBox.Text, phonenregex) == false)
            {
                MessageBox.Show("Equipment Quantity cannot be in characters", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return false;
            }


            //equipment weight
            if (Regex.IsMatch(EquipWeightBox.Text, phonenregex) == false)
            {
                MessageBox.Show("Equipment Weights cannot be in characters", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return false;
            }


            //equipment cost
            if (EquipCostbox.Text == string.Empty)
            {
                MessageBox.Show("Fields cannot be empty", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return false;

            }
            else if (Regex.IsMatch(EquipCostbox.Text, phonenregex) == false)
            {
                MessageBox.Show("Equipment Cost cannot be in characters", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return false;
            }

            return true;

        }

        //update code
        private void Updatebtn_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                SqlConnection con = new SqlConnection(constr);

                SqlCommand cmd = new SqlCommand("Update EquipmentTable Set EquipmentName = @EquipmentName, EquipmentType = @EquipmentType, Equipmentquantity = @EquipmentQuantity, EquipmentWeight = @EquipmentWeight, EquipmentCost = @EquipmentCost, PurchasedDate = @PurchasedDate Where EquipmentID = @EquipmentID", con);

                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@EquipmentName", EquipName.Text);
                    cmd.Parameters.AddWithValue("@EquipmentType", EquipmentTypeBox.Text);
                    cmd.Parameters.AddWithValue("@EquipmentQuantity", EquipQuantityBox.Text);
                    cmd.Parameters.AddWithValue("@EquipmentWeight", EquipWeightBox.Text);
                    cmd.Parameters.AddWithValue("@EquipmentCost", EquipCostbox.Text);
                    cmd.Parameters.AddWithValue("@PurchasedDate", PurchasedPicked.Value);
                    cmd.Parameters.AddWithValue("@EquipmentID", EquipID.Text);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("updated Successfully","Updated",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    clearall();
                GetEquipmentData();

            }
        }
        // delete code
        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                //delete from records

                SqlConnection con = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand("Delete From EquipmentTable Where EquipmentID = @EquipmentID", con);

                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@EquipmentID", EquipID.Text);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                MessageBox.Show("Successfully deleted", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearall();
                GetEquipmentData();
            }
        }


        // on form load
        private void ViewEquipmentControls_Load(object sender, EventArgs e)
        {
            GetEquipmentData();
            EquipmentDataGridView.BorderStyle = BorderStyle.None;
            EquipmentDataGridView.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#DAE0E2");
            EquipmentDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            EquipmentDataGridView.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#2F363F");
            EquipmentDataGridView.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            EquipmentDataGridView.BackgroundColor = ColorTranslator.FromHtml("#EAF0F1");

            EquipmentDataGridView.EnableHeadersVisualStyles = false;
            EquipmentDataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            EquipmentDataGridView.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#2F363F");
            EquipmentDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }


     
        // select data from db and show on datagridview
        private void GetEquipmentData()
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("Select * from EquipmentTable", con);

            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            
            dt.Load(sdr);
            con.Close();

            EquipmentDataGridView.DataSource = dt;

            decimal Total = 0;

            for (int i = 0; i < EquipmentDataGridView.Rows.Count; i++)
            {
                Total += Convert.ToDecimal(EquipmentDataGridView.Rows[i].Cells[5].Value);
            }


            totalspentlabel.Text = Total.ToString();

            string sql = "Select * from EquipmentTable";

            con.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.Fill(ds);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            EquipmentDataGridView.DataSource = ds.Tables[0];

            totalequiplabel.Text = ds.Tables[0].Rows.Count.ToString();
        }


        //to select data from gridview
        private void EquipmentDataGridView_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            EquipID.Text = EquipmentDataGridView.SelectedRows[0].Cells[0].Value.ToString();
            EquipName.Text = EquipmentDataGridView.SelectedRows[0].Cells[1].Value.ToString();
            EquipmentTypeBox.Text = EquipmentDataGridView.SelectedRows[0].Cells[2].Value.ToString();
            EquipWeightBox.Text = EquipmentDataGridView.SelectedRows[0].Cells[4].Value.ToString();
            EquipCostbox.Text = EquipmentDataGridView.SelectedRows[0].Cells[5].Value.ToString();
            EquipQuantityBox.Text = EquipmentDataGridView.SelectedRows[0].Cells[3].Value.ToString();
            PurchasedPicked.Text = EquipmentDataGridView.SelectedRows[0].Cells[6].Value.ToString();
        }


        //refresh button to refresh data
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            GetEquipmentData();
            clearall();
            resetsearchboxes();
        }



        //search by id
        private void SearchbyIdBtn_Click(object sender, EventArgs e)
        {
            if (SearchbyID.Text == "Search by ID" || SearchbyID.Text == "")
            {
                MessageBox.Show("Please enter a ID to search", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (Regex.IsMatch(SearchbyID.Text, characterpattern) == true)
            {
                MessageBox.Show("Should Be In Numberical format", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //find by id
            else
            {
                SqlConnection con = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand("Select * from EquipmentTable Where EquipmentID LIKE '%" + SearchbyID.Text + "%'", con);

                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                DataTable dtmember = new DataTable();
                dtmember.Load(sdr);
                con.Close();
                EquipmentDataGridView.DataSource = dtmember;
            }
        }
        //search by name
        private void searchbynameBtn_Click(object sender, EventArgs e)
        {
            if (SearchbyEquipName.Text == "Search by Name" || SearchbyEquipName.Text == "")
            {
                MessageBox.Show("Please enter a Name to search", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (Regex.IsMatch(SearchbyEquipName.Text, characterpattern) == false)
            {
                MessageBox.Show("Should Be In Characters", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                SqlConnection con = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand("Select * from EquipmentTable Where EquipmentName LIKE '%" + SearchbyEquipName.Text + "%'", con);

                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                DataTable dtmember = new DataTable();
                dtmember.Load(sdr);
                con.Close();
                EquipmentDataGridView.DataSource = dtmember;
            }
        }

       
    }
}
