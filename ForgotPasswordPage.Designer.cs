namespace GymManagement
{
    partial class ForgotPasswordPage
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ForgotPasswordPage));
            this.Head = new System.Windows.Forms.Panel();
            this.closebox = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.EmailTextbox = new System.Windows.Forms.TextBox();
            this.OTPTextbox = new System.Windows.Forms.TextBox();
            this.SendOtpBtn = new Bunifu.Framework.UI.BunifuFlatButton();
            this.VerifyOTPBtn = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.Head.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.closebox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // Head
            // 
            this.Head.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(41)))), ((int)(((byte)(11)))));
            this.Head.Controls.Add(this.closebox);
            this.Head.Controls.Add(this.label6);
            this.Head.Dock = System.Windows.Forms.DockStyle.Top;
            this.Head.Location = new System.Drawing.Point(0, 0);
            this.Head.Name = "Head";
            this.Head.Size = new System.Drawing.Size(588, 55);
            this.Head.TabIndex = 0;
            // 
            // closebox
            // 
            this.closebox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closebox.Image = global::GymManagement.Properties.Resources.exit;
            this.closebox.Location = new System.Drawing.Point(549, 10);
            this.closebox.Name = "closebox";
            this.closebox.Size = new System.Drawing.Size(27, 26);
            this.closebox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.closebox.TabIndex = 0;
            this.closebox.TabStop = false;
            this.closebox.Click += new System.EventHandler(this.closebox_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(3, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(187, 23);
            this.label6.TabIndex = 6;
            this.label6.Text = "Recover Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(28, 183);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Enter Your Email ID :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(38, 241);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Enter OTP Code :";
            // 
            // EmailTextbox
            // 
            this.EmailTextbox.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmailTextbox.Location = new System.Drawing.Point(214, 180);
            this.EmailTextbox.Name = "EmailTextbox";
            this.EmailTextbox.Size = new System.Drawing.Size(176, 23);
            this.EmailTextbox.TabIndex = 0;
            // 
            // OTPTextbox
            // 
            this.OTPTextbox.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OTPTextbox.Location = new System.Drawing.Point(214, 238);
            this.OTPTextbox.Name = "OTPTextbox";
            this.OTPTextbox.Size = new System.Drawing.Size(176, 23);
            this.OTPTextbox.TabIndex = 2;
            // 
            // SendOtpBtn
            // 
            this.SendOtpBtn.Active = false;
            this.SendOtpBtn.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.SendOtpBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(41)))), ((int)(((byte)(11)))));
            this.SendOtpBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SendOtpBtn.BorderRadius = 7;
            this.SendOtpBtn.ButtonText = "Send OTP Code";
            this.SendOtpBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SendOtpBtn.DisabledColor = System.Drawing.Color.Gray;
            this.SendOtpBtn.Iconcolor = System.Drawing.Color.Transparent;
            this.SendOtpBtn.Iconimage = null;
            this.SendOtpBtn.Iconimage_right = null;
            this.SendOtpBtn.Iconimage_right_Selected = null;
            this.SendOtpBtn.Iconimage_Selected = null;
            this.SendOtpBtn.IconMarginLeft = 0;
            this.SendOtpBtn.IconMarginRight = 0;
            this.SendOtpBtn.IconRightVisible = true;
            this.SendOtpBtn.IconRightZoom = 0D;
            this.SendOtpBtn.IconVisible = true;
            this.SendOtpBtn.IconZoom = 90D;
            this.SendOtpBtn.IsTab = false;
            this.SendOtpBtn.Location = new System.Drawing.Point(432, 177);
            this.SendOtpBtn.Name = "SendOtpBtn";
            this.SendOtpBtn.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(41)))), ((int)(((byte)(11)))));
            this.SendOtpBtn.OnHovercolor = System.Drawing.Color.Red;
            this.SendOtpBtn.OnHoverTextColor = System.Drawing.Color.White;
            this.SendOtpBtn.selected = false;
            this.SendOtpBtn.Size = new System.Drawing.Size(120, 26);
            this.SendOtpBtn.TabIndex = 1;
            this.SendOtpBtn.Text = "Send OTP Code";
            this.SendOtpBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.SendOtpBtn.Textcolor = System.Drawing.Color.White;
            this.SendOtpBtn.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SendOtpBtn.Click += new System.EventHandler(this.SendOtpBtn_Click);
            // 
            // VerifyOTPBtn
            // 
            this.VerifyOTPBtn.Active = false;
            this.VerifyOTPBtn.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.VerifyOTPBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(41)))), ((int)(((byte)(11)))));
            this.VerifyOTPBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.VerifyOTPBtn.BorderRadius = 7;
            this.VerifyOTPBtn.ButtonText = "Verify OTP Code";
            this.VerifyOTPBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.VerifyOTPBtn.DisabledColor = System.Drawing.Color.Gray;
            this.VerifyOTPBtn.Iconcolor = System.Drawing.Color.Transparent;
            this.VerifyOTPBtn.Iconimage = null;
            this.VerifyOTPBtn.Iconimage_right = null;
            this.VerifyOTPBtn.Iconimage_right_Selected = null;
            this.VerifyOTPBtn.Iconimage_Selected = null;
            this.VerifyOTPBtn.IconMarginLeft = 0;
            this.VerifyOTPBtn.IconMarginRight = 0;
            this.VerifyOTPBtn.IconRightVisible = true;
            this.VerifyOTPBtn.IconRightZoom = 0D;
            this.VerifyOTPBtn.IconVisible = true;
            this.VerifyOTPBtn.IconZoom = 90D;
            this.VerifyOTPBtn.IsTab = false;
            this.VerifyOTPBtn.Location = new System.Drawing.Point(432, 235);
            this.VerifyOTPBtn.Name = "VerifyOTPBtn";
            this.VerifyOTPBtn.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(41)))), ((int)(((byte)(11)))));
            this.VerifyOTPBtn.OnHovercolor = System.Drawing.Color.Red;
            this.VerifyOTPBtn.OnHoverTextColor = System.Drawing.Color.White;
            this.VerifyOTPBtn.selected = false;
            this.VerifyOTPBtn.Size = new System.Drawing.Size(120, 26);
            this.VerifyOTPBtn.TabIndex = 3;
            this.VerifyOTPBtn.Text = "Verify OTP Code";
            this.VerifyOTPBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.VerifyOTPBtn.Textcolor = System.Drawing.Color.White;
            this.VerifyOTPBtn.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VerifyOTPBtn.Click += new System.EventHandler(this.VerifyOTPBtn_Click);
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.Head;
            this.bunifuDragControl1.Vertical = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::GymManagement.Properties.Resources.gmail;
            this.pictureBox2.Location = new System.Drawing.Point(249, 61);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(90, 66);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // ForgotPasswordPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(51)))), ((int)(((byte)(53)))));
            this.ClientSize = new System.Drawing.Size(588, 320);
            this.Controls.Add(this.VerifyOTPBtn);
            this.Controls.Add(this.SendOtpBtn);
            this.Controls.Add(this.OTPTextbox);
            this.Controls.Add(this.EmailTextbox);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Head);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ForgotPasswordPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ForgotPasswordPage";
            this.Load += new System.EventHandler(this.ForgotPasswordPage_Load);
            this.Head.ResumeLayout(false);
            this.Head.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.closebox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Head;
        private System.Windows.Forms.PictureBox closebox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox EmailTextbox;
        private System.Windows.Forms.TextBox OTPTextbox;
        private Bunifu.Framework.UI.BunifuFlatButton SendOtpBtn;
        private Bunifu.Framework.UI.BunifuFlatButton VerifyOTPBtn;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
    }
}