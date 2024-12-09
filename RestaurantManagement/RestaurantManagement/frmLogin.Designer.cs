using Guna.UI2.WinForms;

namespace RestaurantManagement
{
    partial class LoginForm
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
            this.guna2AnimateWindow1 = new Guna.UI2.WinForms.Guna2AnimateWindow(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.txtLoginUsername = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtLoginPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLogin = new Guna.UI2.WinForms.Guna2Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbnExit = new Guna.UI2.WinForms.Guna2Button();
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.Pic = new Guna.UI2.WinForms.Guna2PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Register_label = new System.Windows.Forms.Label();
            this.Pic2 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.Login_showPass = new System.Windows.Forms.CheckBox();
            this.InvalidU = new System.Windows.Forms.Label();
            this.InvalidP = new System.Windows.Forms.Label();
            this.guna2GradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pic2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(26, 283);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Username";
            // 
            // txtLoginUsername
            // 
            this.txtLoginUsername.BackColor = System.Drawing.Color.Black;
            this.txtLoginUsername.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(96)))), ((int)(((byte)(0)))));
            this.txtLoginUsername.BorderThickness = 2;
            this.txtLoginUsername.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtLoginUsername.DefaultText = "";
            this.txtLoginUsername.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtLoginUsername.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtLoginUsername.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtLoginUsername.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtLoginUsername.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtLoginUsername.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F);
            this.txtLoginUsername.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtLoginUsername.Location = new System.Drawing.Point(30, 309);
            this.txtLoginUsername.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtLoginUsername.Name = "txtLoginUsername";
            this.txtLoginUsername.PasswordChar = '\0';
            this.txtLoginUsername.PlaceholderText = "";
            this.txtLoginUsername.SelectedText = "";
            this.txtLoginUsername.Size = new System.Drawing.Size(376, 47);
            this.txtLoginUsername.TabIndex = 2;
            this.txtLoginUsername.TextChanged += new System.EventHandler(this.Login_Username_TextChanged);
            // 
            // txtLoginPassword
            // 
            this.txtLoginPassword.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(96)))), ((int)(((byte)(0)))));
            this.txtLoginPassword.BorderThickness = 2;
            this.txtLoginPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtLoginPassword.DefaultText = "";
            this.txtLoginPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtLoginPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtLoginPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtLoginPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtLoginPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtLoginPassword.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F);
            this.txtLoginPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtLoginPassword.Location = new System.Drawing.Point(32, 397);
            this.txtLoginPassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtLoginPassword.Name = "txtLoginPassword";
            this.txtLoginPassword.PasswordChar = '.';
            this.txtLoginPassword.PlaceholderText = "";
            this.txtLoginPassword.SelectedText = "";
            this.txtLoginPassword.Size = new System.Drawing.Size(376, 47);
            this.txtLoginPassword.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(29, 369);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password";
            // 
            // btnLogin
            // 
            this.btnLogin.AutoRoundedCorners = true;
            this.btnLogin.BackColor = System.Drawing.Color.Transparent;
            this.btnLogin.BorderColor = System.Drawing.Color.Transparent;
            this.btnLogin.BorderRadius = 24;
            this.btnLogin.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLogin.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLogin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLogin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLogin.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(96)))), ((int)(((byte)(0)))));
            this.btnLogin.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(32, 503);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(136, 50);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "LOGIN";
            this.btnLogin.UseTransparentBackground = true;
            this.btnLogin.Click += new System.EventHandler(this.Login_User_Click_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(96)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(19, 239);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(405, 29);
            this.label3.TabIndex = 1;
            this.label3.Text = "Restaurant Management System";
            // 
            // tbnExit
            // 
            this.tbnExit.AutoRoundedCorners = true;
            this.tbnExit.BackColor = System.Drawing.Color.Transparent;
            this.tbnExit.BorderColor = System.Drawing.Color.Transparent;
            this.tbnExit.BorderRadius = 24;
            this.tbnExit.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.tbnExit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.tbnExit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.tbnExit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.tbnExit.FillColor = System.Drawing.Color.White;
            this.tbnExit.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbnExit.ForeColor = System.Drawing.Color.Black;
            this.tbnExit.Location = new System.Drawing.Point(269, 502);
            this.tbnExit.Name = "tbnExit";
            this.tbnExit.Size = new System.Drawing.Size(137, 50);
            this.tbnExit.TabIndex = 6;
            this.tbnExit.Text = "EXIT";
            this.tbnExit.UseTransparentBackground = true;
            this.tbnExit.Click += new System.EventHandler(this.tbnExit_Click);
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.Controls.Add(this.Pic);
            this.guna2GradientPanel1.FillColor = System.Drawing.Color.Black;
            this.guna2GradientPanel1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.guna2GradientPanel1.Location = new System.Drawing.Point(443, -7);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.Size = new System.Drawing.Size(641, 666);
            this.guna2GradientPanel1.TabIndex = 7;
            // 
            // Pic
            // 
            this.Pic.Image = global::RestaurantManagement.Properties.Resources.PAPWET;
            this.Pic.ImageRotate = 0F;
            this.Pic.Location = new System.Drawing.Point(16, 19);
            this.Pic.Name = "Pic";
            this.Pic.Size = new System.Drawing.Size(614, 628);
            this.Pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Pic.TabIndex = 8;
            this.Pic.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(48, 588);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(180, 19);
            this.label4.TabIndex = 9;
            this.label4.Text = "Have no account yet?";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(500, 299);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 23);
            this.label5.TabIndex = 10;
            // 
            // Register_label
            // 
            this.Register_label.AutoSize = true;
            this.Register_label.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Register_label.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Register_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(96)))), ((int)(((byte)(0)))));
            this.Register_label.Location = new System.Drawing.Point(234, 588);
            this.Register_label.Name = "Register_label";
            this.Register_label.Size = new System.Drawing.Size(115, 19);
            this.Register_label.TabIndex = 11;
            this.Register_label.Text = "Register here";
            this.Register_label.Click += new System.EventHandler(this.Register_label_Click);
            // 
            // Pic2
            // 
            this.Pic2.Image = global::RestaurantManagement.Properties.Resources.tttt;
            this.Pic2.ImageRotate = 0F;
            this.Pic2.Location = new System.Drawing.Point(-3, -7);
            this.Pic2.Name = "Pic2";
            this.Pic2.Size = new System.Drawing.Size(440, 242);
            this.Pic2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Pic2.TabIndex = 8;
            this.Pic2.TabStop = false;
            // 
            // Login_showPass
            // 
            this.Login_showPass.AutoSize = true;
            this.Login_showPass.BackColor = System.Drawing.Color.Transparent;
            this.Login_showPass.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Login_showPass.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.Login_showPass.Location = new System.Drawing.Point(33, 451);
            this.Login_showPass.Name = "Login_showPass";
            this.Login_showPass.Size = new System.Drawing.Size(158, 23);
            this.Login_showPass.TabIndex = 12;
            this.Login_showPass.Text = "Show Password";
            this.Login_showPass.UseVisualStyleBackColor = false;
            this.Login_showPass.CheckedChanged += new System.EventHandler(this.Login_showPass_CheckedChanged);
            // 
            // InvalidU
            // 
            this.InvalidU.AutoSize = true;
            this.InvalidU.ForeColor = System.Drawing.Color.Red;
            this.InvalidU.Location = new System.Drawing.Point(110, 284);
            this.InvalidU.Name = "InvalidU";
            this.InvalidU.Size = new System.Drawing.Size(142, 23);
            this.InvalidU.TabIndex = 13;
            this.InvalidU.Text = "Invalid Username";
            // 
            // InvalidP
            // 
            this.InvalidP.AutoSize = true;
            this.InvalidP.ForeColor = System.Drawing.Color.Red;
            this.InvalidP.Location = new System.Drawing.Point(110, 371);
            this.InvalidP.Name = "InvalidP";
            this.InvalidP.Size = new System.Drawing.Size(135, 23);
            this.InvalidP.TabIndex = 14;
            this.InvalidP.Text = "Invalid Password";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1084, 652);
            this.Controls.Add(this.InvalidP);
            this.Controls.Add(this.InvalidU);
            this.Controls.Add(this.Login_showPass);
            this.Controls.Add(this.Register_label);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Pic2);
            this.Controls.Add(this.guna2GradientPanel1);
            this.Controls.Add(this.tbnExit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtLoginPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLoginUsername);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoginForm";
            this.guna2GradientPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Pic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pic2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2AnimateWindow guna2AnimateWindow1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox txtLoginUsername;
        private Guna.UI2.WinForms.Guna2TextBox txtLoginPassword;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button btnLogin;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2Button tbnExit;
        private Guna2GradientPanel guna2GradientPanel1;
        private Guna2PictureBox Pic;
        private Guna2PictureBox Pic2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label Register_label;
        private System.Windows.Forms.CheckBox Login_showPass;
        private System.Windows.Forms.Label InvalidU;
        private System.Windows.Forms.Label InvalidP;

        public Guna2PictureBox guna2PictureBox1 { get; private set; }
    }
}

