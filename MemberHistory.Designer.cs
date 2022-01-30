namespace GymManagement
{
    partial class MemberHistory
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.LoginPanel = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.todaysDatepicker = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SearchByIdBtn = new System.Windows.Forms.PictureBox();
            this.SearchByIDTextbox = new System.Windows.Forms.TextBox();
            this.MembersDataGridView = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.labelCount = new System.Windows.Forms.Label();
            this.LoginPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.bunifuCards1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SearchByIdBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MembersDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // LoginPanel
            // 
            this.LoginPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(41)))), ((int)(((byte)(11)))));
            this.LoginPanel.Controls.Add(this.label7);
            this.LoginPanel.Controls.Add(this.label1);
            this.LoginPanel.Controls.Add(this.label6);
            this.LoginPanel.Controls.Add(this.pictureBox3);
            this.LoginPanel.Controls.Add(this.pictureBox2);
            this.LoginPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.LoginPanel.Location = new System.Drawing.Point(0, 0);
            this.LoginPanel.Name = "LoginPanel";
            this.LoginPanel.Size = new System.Drawing.Size(861, 56);
            this.LoginPanel.TabIndex = 21;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(15, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(190, 16);
            this.label7.TabIndex = 5;
            this.label7.Text = "Fitness Management System";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(336, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 32);
            this.label1.TabIndex = 4;
            this.label1.Text = "Member History";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(12, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 32);
            this.label6.TabIndex = 4;
            this.label6.Text = "Lissa";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox3.Image = global::GymManagement.Properties.Resources.minimize;
            this.pictureBox3.Location = new System.Drawing.Point(779, 10);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(25, 30);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = global::GymManagement.Properties.Resources.closethick;
            this.pictureBox2.Location = new System.Drawing.Point(820, 10);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(25, 30);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // bunifuCards1
            // 
            this.bunifuCards1.BackColor = System.Drawing.SystemColors.Control;
            this.bunifuCards1.BorderRadius = 5;
            this.bunifuCards1.BottomSahddow = true;
            this.bunifuCards1.color = System.Drawing.Color.Tomato;
            this.bunifuCards1.Controls.Add(this.labelCount);
            this.bunifuCards1.Controls.Add(this.label8);
            this.bunifuCards1.Controls.Add(this.dateTimePicker1);
            this.bunifuCards1.Controls.Add(this.label5);
            this.bunifuCards1.Controls.Add(this.todaysDatepicker);
            this.bunifuCards1.Controls.Add(this.label4);
            this.bunifuCards1.Controls.Add(this.label3);
            this.bunifuCards1.Controls.Add(this.SearchByIdBtn);
            this.bunifuCards1.Controls.Add(this.SearchByIDTextbox);
            this.bunifuCards1.LeftSahddow = false;
            this.bunifuCards1.Location = new System.Drawing.Point(0, 53);
            this.bunifuCards1.Name = "bunifuCards1";
            this.bunifuCards1.RightSahddow = true;
            this.bunifuCards1.ShadowDepth = 20;
            this.bunifuCards1.Size = new System.Drawing.Size(861, 83);
            this.bunifuCards1.TabIndex = 22;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd-MM-yyyy";
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(392, 44);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(114, 23);
            this.dateTimePicker1.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label5.Location = new System.Drawing.Point(388, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 19);
            this.label5.TabIndex = 26;
            this.label5.Text = "To Date";
            // 
            // todaysDatepicker
            // 
            this.todaysDatepicker.CustomFormat = "dd-MM-yyyy";
            this.todaysDatepicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.todaysDatepicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.todaysDatepicker.Location = new System.Drawing.Point(258, 44);
            this.todaysDatepicker.Name = "todaysDatepicker";
            this.todaysDatepicker.Size = new System.Drawing.Size(111, 23);
            this.todaysDatepicker.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label4.Location = new System.Drawing.Point(254, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 19);
            this.label4.TabIndex = 24;
            this.label4.Text = "From Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label3.Location = new System.Drawing.Point(11, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(181, 19);
            this.label3.TabIndex = 21;
            this.label3.Text = "Search by Member ID";
            // 
            // SearchByIdBtn
            // 
            this.SearchByIdBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(51)))), ((int)(((byte)(53)))));
            this.SearchByIdBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SearchByIdBtn.Image = global::GymManagement.Properties.Resources.search_3_64__1_;
            this.SearchByIdBtn.Location = new System.Drawing.Point(181, 37);
            this.SearchByIdBtn.Name = "SearchByIdBtn";
            this.SearchByIdBtn.Size = new System.Drawing.Size(40, 23);
            this.SearchByIdBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.SearchByIdBtn.TabIndex = 17;
            this.SearchByIdBtn.TabStop = false;
            this.SearchByIdBtn.Click += new System.EventHandler(this.SearchByIdBtn_Click);
            // 
            // SearchByIDTextbox
            // 
            this.SearchByIDTextbox.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchByIDTextbox.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.SearchByIDTextbox.Location = new System.Drawing.Point(15, 37);
            this.SearchByIDTextbox.Name = "SearchByIDTextbox";
            this.SearchByIDTextbox.Size = new System.Drawing.Size(182, 27);
            this.SearchByIDTextbox.TabIndex = 18;
            // 
            // MembersDataGridView
            // 
            this.MembersDataGridView.AllowUserToAddRows = false;
            this.MembersDataGridView.AllowUserToDeleteRows = false;
            this.MembersDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.MembersDataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(51)))), ((int)(((byte)(53)))));
            this.MembersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.MembersDataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.MembersDataGridView.Location = new System.Drawing.Point(0, 136);
            this.MembersDataGridView.Name = "MembersDataGridView";
            this.MembersDataGridView.ReadOnly = true;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.MembersDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.MembersDataGridView.RowTemplate.Height = 25;
            this.MembersDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.MembersDataGridView.Size = new System.Drawing.Size(858, 320);
            this.MembersDataGridView.TabIndex = 23;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Rockwell", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label8.Location = new System.Drawing.Point(746, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 25);
            this.label8.TabIndex = 28;
            this.label8.Text = "Count";
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Font = new System.Drawing.Font("Rockwell", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCount.ForeColor = System.Drawing.SystemColors.Desktop;
            this.labelCount.Location = new System.Drawing.Point(771, 41);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(24, 25);
            this.labelCount.TabIndex = 29;
            this.labelCount.Text = "0";
            // 
            // MemberHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(51)))), ((int)(((byte)(53)))));
            this.ClientSize = new System.Drawing.Size(861, 459);
            this.Controls.Add(this.MembersDataGridView);
            this.Controls.Add(this.bunifuCards1);
            this.Controls.Add(this.LoginPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MemberHistory";
            this.Text = "MemberHistory";
            this.LoginPanel.ResumeLayout(false);
            this.LoginPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.bunifuCards1.ResumeLayout(false);
            this.bunifuCards1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SearchByIdBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MembersDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel LoginPanel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private Bunifu.Framework.UI.BunifuCards bunifuCards1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox SearchByIdBtn;
        private System.Windows.Forms.TextBox SearchByIDTextbox;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker todaysDatepicker;
        private System.Windows.Forms.DataGridView MembersDataGridView;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.Label label8;
    }
}