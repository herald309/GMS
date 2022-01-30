using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GymManagement
{
    public partial class AddEquipmentsControl : UserControl
    {
        private static AddEquipmentsControl _instance;
        public static AddEquipmentsControl Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AddEquipmentsControl();
                }
                return _instance;
            }
        }
        public AddEquipmentsControl()
        {
            InitializeComponent();
        }


        //  dATABASE CONNECTION STRING
        string constr = ConfigurationManager.ConnectionStrings["GMSDB"].ConnectionString;

        

        //key press events for numerical textboxes
        private void EquipmentQuantityTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Equipment Quantity should be in numerical format only", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void EquipmentWeightTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Equipment weights should be in numberical format", "validation error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void EquipmentCostTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Equipment cost should be in numerical format", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }


        // change back color when clicked after validation error
        private void EquipmentNameTextbox_TextChanged(object sender, EventArgs e)
        {
            Control ctrl = (Control)sender;
            ctrl.BackColor = Color.White;
        }

        //validation
        private bool isValid()
        {
            //equipment name
            if (EquipmentNameTextbox.Text == string.Empty)
            {
                EquipmentNameTextbox.BackColor = Color.LightPink;
                EquipmentNameTextbox.Focus();

                MessageBox.Show("Name is a required field", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return false;
              
            }

            //equipment type
            if (EquipmentTypeBox.SelectedIndex == -1)
            {
                EquipmentTypeBox.Focus();
                EquipmentTypeBox.BackColor = Color.LightPink;

                MessageBox.Show("Please select equipment type", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return false;
            }


            //equipment quantity
            if (EquipmentQuantityTextbox.Text == string.Empty)
            {
                EquipmentQuantityTextbox.Focus();
                EquipmentQuantityTextbox.BackColor = Color.LightPink;

                MessageBox.Show("Equipment Quantity is a required field", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return false;
            }


            //equipment cost
            if (EquipmentCostTextbox.Text == string.Empty)
            {
                EquipmentCostTextbox.Focus();
                EquipmentCostTextbox.BackColor = Color.LightPink;

                MessageBox.Show("Equipment cost is a required field", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return false;

            }

            return true;
            
        }

        // save button code with validations
        private void AddEquipmentButton_Click(object sender, EventArgs e)
        {
            if (isValid())
            {

                SqlConnection con = new SqlConnection(constr);

                SqlCommand cmd = new SqlCommand("Insert into EquipmentTable Values(@EquipmentName, @EquipmentType, @EquipmentQuantity, @EquipmentWeight, @EquipmentCost, @PurchasedDate)", con);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@EquipmentName", EquipmentNameTextbox.Text);
                cmd.Parameters.AddWithValue("@EquipmentType", EquipmentTypeBox.Text);
                cmd.Parameters.AddWithValue("@EquipmentQuantity", EquipmentQuantityTextbox.Text);
                cmd.Parameters.AddWithValue("@EquipmentWeight", EquipmentWeightTextbox.Text);
                cmd.Parameters.AddWithValue("@EquipmentCost", EquipmentCostTextbox.Text);
                cmd.Parameters.AddWithValue("@PurchasedDate", dateTimePicker1.Value);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();


                MessageBox.Show("success");
                resetboxes();
            }
        }

        public void resetboxes()
        {
            EquipmentNameTextbox.ResetText();
            EquipmentTypeBox.SelectedIndex = -1;
            EquipmentQuantityTextbox.Clear();
            EquipmentWeightTextbox.Clear();
            EquipmentCostTextbox.Clear();
            dateTimePicker1.Value = DateTime.Now;
            EquipmentNameTextbox.Focus();
        }

        private void clearallbtn_Click(object sender, EventArgs e)
        {
            resetboxes();
        }

        private void AddEquipmentsControl_Load(object sender, EventArgs e)
        {

        }
    }
}
