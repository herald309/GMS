namespace GymManagement
{
    partial class AddEquipmentsControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.EquipmentTypeBox = new System.Windows.Forms.ComboBox();
            this.EquipmentQuantityTextbox = new System.Windows.Forms.TextBox();
            this.EquipmentWeightTextbox = new System.Windows.Forms.TextBox();
            this.EquipmentCostTextbox = new System.Windows.Forms.TextBox();
            this.AddEquipmentButton = new Bunifu.Framework.UI.BunifuFlatButton();
            this.label7 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.clearallbtn = new Bunifu.Framework.UI.BunifuFlatButton();
            this.EquipmentNameTextbox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(224, 126);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Equipment Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(473, 126);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Equipment Type";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(224, 208);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Equipment Quantity";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(473, 208);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Equipment Weight";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(224, 287);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Equipment Cost";
            // 
            // EquipmentTypeBox
            // 
            this.EquipmentTypeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EquipmentTypeBox.FormattingEnabled = true;
            this.EquipmentTypeBox.Items.AddRange(new object[] {
            "Machines",
            "Weights",
            "Bars",
            "Others"});
            this.EquipmentTypeBox.Location = new System.Drawing.Point(476, 155);
            this.EquipmentTypeBox.Name = "EquipmentTypeBox";
            this.EquipmentTypeBox.Size = new System.Drawing.Size(153, 24);
            this.EquipmentTypeBox.TabIndex = 1;
            this.EquipmentTypeBox.TextChanged += new System.EventHandler(this.EquipmentNameTextbox_TextChanged);
            // 
            // EquipmentQuantityTextbox
            // 
            this.EquipmentQuantityTextbox.Location = new System.Drawing.Point(227, 228);
            this.EquipmentQuantityTextbox.MaxLength = 6;
            this.EquipmentQuantityTextbox.Name = "EquipmentQuantityTextbox";
            this.EquipmentQuantityTextbox.Size = new System.Drawing.Size(153, 24);
            this.EquipmentQuantityTextbox.TabIndex = 2;
            this.EquipmentQuantityTextbox.TextChanged += new System.EventHandler(this.EquipmentNameTextbox_TextChanged);
            this.EquipmentQuantityTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EquipmentQuantityTextbox_KeyPress);
            // 
            // EquipmentWeightTextbox
            // 
            this.EquipmentWeightTextbox.Location = new System.Drawing.Point(476, 228);
            this.EquipmentWeightTextbox.Name = "EquipmentWeightTextbox";
            this.EquipmentWeightTextbox.Size = new System.Drawing.Size(153, 24);
            this.EquipmentWeightTextbox.TabIndex = 3;
            this.EquipmentWeightTextbox.TextChanged += new System.EventHandler(this.EquipmentNameTextbox_TextChanged);
            this.EquipmentWeightTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EquipmentWeightTextbox_KeyPress);
            // 
            // EquipmentCostTextbox
            // 
            this.EquipmentCostTextbox.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.EquipmentCostTextbox.Location = new System.Drawing.Point(227, 307);
            this.EquipmentCostTextbox.Name = "EquipmentCostTextbox";
            this.EquipmentCostTextbox.Size = new System.Drawing.Size(153, 24);
            this.EquipmentCostTextbox.TabIndex = 4;
            this.EquipmentCostTextbox.TextChanged += new System.EventHandler(this.EquipmentNameTextbox_TextChanged);
            this.EquipmentCostTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EquipmentCostTextbox_KeyPress);
            // 
            // AddEquipmentButton
            // 
            this.AddEquipmentButton.Active = false;
            this.AddEquipmentButton.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.AddEquipmentButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(206)))), ((int)(((byte)(48)))));
            this.AddEquipmentButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AddEquipmentButton.BorderRadius = 7;
            this.AddEquipmentButton.ButtonText = "Add Equipment Details";
            this.AddEquipmentButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddEquipmentButton.DisabledColor = System.Drawing.Color.Gray;
            this.AddEquipmentButton.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddEquipmentButton.Iconcolor = System.Drawing.Color.Transparent;
            this.AddEquipmentButton.Iconimage = global::GymManagement.Properties.Resources.save_64;
            this.AddEquipmentButton.Iconimage_right = null;
            this.AddEquipmentButton.Iconimage_right_Selected = null;
            this.AddEquipmentButton.Iconimage_Selected = null;
            this.AddEquipmentButton.IconMarginLeft = 35;
            this.AddEquipmentButton.IconMarginRight = 0;
            this.AddEquipmentButton.IconRightVisible = true;
            this.AddEquipmentButton.IconRightZoom = 0D;
            this.AddEquipmentButton.IconVisible = true;
            this.AddEquipmentButton.IconZoom = 50D;
            this.AddEquipmentButton.IsTab = false;
            this.AddEquipmentButton.Location = new System.Drawing.Point(217, 390);
            this.AddEquipmentButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AddEquipmentButton.Name = "AddEquipmentButton";
            this.AddEquipmentButton.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(206)))), ((int)(((byte)(48)))));
            this.AddEquipmentButton.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(190)))), ((int)(((byte)(49)))));
            this.AddEquipmentButton.OnHoverTextColor = System.Drawing.Color.White;
            this.AddEquipmentButton.selected = false;
            this.AddEquipmentButton.Size = new System.Drawing.Size(175, 48);
            this.AddEquipmentButton.TabIndex = 6;
            this.AddEquipmentButton.Text = "Add Equipment Details";
            this.AddEquipmentButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AddEquipmentButton.Textcolor = System.Drawing.Color.White;
            this.AddEquipmentButton.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddEquipmentButton.Click += new System.EventHandler(this.AddEquipmentButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(473, 287);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 17);
            this.label7.TabIndex = 5;
            this.label7.Text = "Purchased On";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(476, 307);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(153, 24);
            this.dateTimePicker1.TabIndex = 5;
            // 
            // clearallbtn
            // 
            this.clearallbtn.Active = false;
            this.clearallbtn.Activecolor = System.Drawing.Color.Red;
            this.clearallbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(41)))), ((int)(((byte)(11)))));
            this.clearallbtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.clearallbtn.BorderRadius = 7;
            this.clearallbtn.ButtonText = "Cancel";
            this.clearallbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clearallbtn.DisabledColor = System.Drawing.Color.Gray;
            this.clearallbtn.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearallbtn.Iconcolor = System.Drawing.Color.Transparent;
            this.clearallbtn.Iconimage = global::GymManagement.Properties.Resources.disapprove_64;
            this.clearallbtn.Iconimage_right = null;
            this.clearallbtn.Iconimage_right_Selected = null;
            this.clearallbtn.Iconimage_Selected = null;
            this.clearallbtn.IconMarginLeft = 30;
            this.clearallbtn.IconMarginRight = 0;
            this.clearallbtn.IconRightVisible = true;
            this.clearallbtn.IconRightZoom = 0D;
            this.clearallbtn.IconVisible = true;
            this.clearallbtn.IconZoom = 45D;
            this.clearallbtn.IsTab = false;
            this.clearallbtn.Location = new System.Drawing.Point(461, 390);
            this.clearallbtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.clearallbtn.Name = "clearallbtn";
            this.clearallbtn.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(41)))), ((int)(((byte)(11)))));
            this.clearallbtn.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(47)))), ((int)(((byte)(22)))));
            this.clearallbtn.OnHoverTextColor = System.Drawing.Color.White;
            this.clearallbtn.selected = false;
            this.clearallbtn.Size = new System.Drawing.Size(175, 48);
            this.clearallbtn.TabIndex = 7;
            this.clearallbtn.Text = "Cancel";
            this.clearallbtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.clearallbtn.Textcolor = System.Drawing.Color.White;
            this.clearallbtn.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearallbtn.Click += new System.EventHandler(this.clearallbtn_Click);
            // 
            // EquipmentNameTextbox
            // 
            this.EquipmentNameTextbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EquipmentNameTextbox.FormattingEnabled = true;
            this.EquipmentNameTextbox.Items.AddRange(new object[] {
            "Adjustable bench ",
            "Barbell stand",
            "Cable Crossover or Functional Trainer",
            "Dumbbells stand",
            "Decline Bench press:",
            "Exercise ball",
            "Flat bench press",
            "Indoor Rower",
            "Incline bench press",
            "Lat Pulling Down",
            "LKey Dumbbells",
            "Leg Press Hack Squad hammer",
            "Leg Curl Extension",
            "Olympic bar",
            "Preacher Curl bench",
            "Rubber coated Premium weight",
            "Smith machine",
            "Weight plate stand",
            "Treadmill",
            "Gym bike",
            "Elliptical trainer",
            "Capsule pipe",
            "Machines with pulley",
            "Cable cross",
            "Functional Trainer",
            "Smith machine with a functional trainer",
            "Hack squat",
            "Hammer single station",
            "Plates",
            "Dumbbells",
            "Gym accessories"});
            this.EquipmentNameTextbox.Location = new System.Drawing.Point(227, 155);
            this.EquipmentNameTextbox.Name = "EquipmentNameTextbox";
            this.EquipmentNameTextbox.Size = new System.Drawing.Size(153, 24);
            this.EquipmentNameTextbox.TabIndex = 8;
            // 
            // AddEquipmentsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.Controls.Add(this.EquipmentNameTextbox);
            this.Controls.Add(this.clearallbtn);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.EquipmentTypeBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.AddEquipmentButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.EquipmentCostTextbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.EquipmentQuantityTextbox);
            this.Controls.Add(this.EquipmentWeightTextbox);
            this.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "AddEquipmentsControl";
            this.Size = new System.Drawing.Size(852, 559);
            this.Load += new System.EventHandler(this.AddEquipmentsControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox EquipmentTypeBox;
        private System.Windows.Forms.TextBox EquipmentQuantityTextbox;
        private System.Windows.Forms.TextBox EquipmentWeightTextbox;
        private System.Windows.Forms.TextBox EquipmentCostTextbox;
        private Bunifu.Framework.UI.BunifuFlatButton AddEquipmentButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private Bunifu.Framework.UI.BunifuFlatButton clearallbtn;
        private System.Windows.Forms.ComboBox EquipmentNameTextbox;
    }
}
