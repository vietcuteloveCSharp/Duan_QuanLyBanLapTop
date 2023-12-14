namespace GUI.View
{
    partial class DangNhap
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DangNhap));
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            chk_ShowPassword = new CheckBox();
            btn_username = new Guna.UI2.WinForms.Guna2HtmlLabel();
            btn_Login = new Guna.UI2.WinForms.Guna2Button();
            txt_Password = new Guna.UI2.WinForms.Guna2TextBox();
            txt_UseName = new Guna.UI2.WinForms.Guna2TextBox();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2Panel1.SuspendLayout();
            SuspendLayout();
            // 
            // guna2Panel1
            // 
            guna2Panel1.BackgroundImageLayout = ImageLayout.Zoom;
            guna2Panel1.BorderRadius = 10;
            guna2Panel1.Controls.Add(chk_ShowPassword);
            guna2Panel1.Controls.Add(btn_username);
            guna2Panel1.Controls.Add(btn_Login);
            guna2Panel1.Controls.Add(txt_Password);
            guna2Panel1.Controls.Add(txt_UseName);
            guna2Panel1.Controls.Add(guna2HtmlLabel1);
            guna2Panel1.CustomizableEdges = customizableEdges7;
            guna2Panel1.Location = new Point(88, 55);
            guna2Panel1.Margin = new Padding(3, 2, 3, 2);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges8;
            guna2Panel1.Size = new Size(298, 346);
            guna2Panel1.TabIndex = 0;
            // 
            // chk_ShowPassword
            // 
            chk_ShowPassword.AutoSize = true;
            chk_ShowPassword.Location = new Point(164, 220);
            chk_ShowPassword.Margin = new Padding(3, 2, 3, 2);
            chk_ShowPassword.Name = "chk_ShowPassword";
            chk_ShowPassword.Size = new Size(103, 20);
            chk_ShowPassword.TabIndex = 4;
            chk_ShowPassword.Text = "Hiện mật khẩu";
            chk_ShowPassword.UseVisualStyleBackColor = true;
            chk_ShowPassword.CheckedChanged += chk_ShowPassword_CheckedChanged;
            // 
            // btn_username
            // 
            btn_username.BackColor = Color.Transparent;
            btn_username.Font = new Font("Segoe UI", 9F, FontStyle.Italic | FontStyle.Underline, GraphicsUnit.Point);
            btn_username.ForeColor = Color.DeepSkyBlue;
            btn_username.Location = new Point(49, 220);
            btn_username.Margin = new Padding(3, 2, 3, 2);
            btn_username.Name = "btn_username";
            btn_username.Size = new Size(86, 17);
            btn_username.TabIndex = 3;
            btn_username.Text = "Quên mật khẩu";
            btn_username.Click += btn_username_Click;
            // 
            // btn_Login
            // 
            btn_Login.CustomizableEdges = customizableEdges1;
            btn_Login.DisabledState.BorderColor = Color.DarkGray;
            btn_Login.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_Login.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_Login.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_Login.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btn_Login.ForeColor = Color.White;
            btn_Login.Location = new Point(65, 258);
            btn_Login.Margin = new Padding(3, 2, 3, 2);
            btn_Login.Name = "btn_Login";
            btn_Login.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btn_Login.Size = new Size(179, 45);
            btn_Login.TabIndex = 2;
            btn_Login.Text = "đăng nhập";
            btn_Login.Click += btn_Login_Click;
            // 
            // txt_Password
            // 
            txt_Password.CustomizableEdges = customizableEdges3;
            txt_Password.DefaultText = "";
            txt_Password.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txt_Password.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txt_Password.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txt_Password.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txt_Password.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txt_Password.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txt_Password.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txt_Password.Location = new Point(49, 170);
            txt_Password.Margin = new Padding(3, 2, 3, 2);
            txt_Password.Name = "txt_Password";
            txt_Password.PasswordChar = '\0';
            txt_Password.PlaceholderText = "Mật khẩu";
            txt_Password.SelectedText = "";
            txt_Password.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txt_Password.Size = new Size(219, 36);
            txt_Password.TabIndex = 1;
            // 
            // txt_UseName
            // 
            txt_UseName.CustomizableEdges = customizableEdges5;
            txt_UseName.DefaultText = "";
            txt_UseName.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txt_UseName.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txt_UseName.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txt_UseName.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txt_UseName.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txt_UseName.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txt_UseName.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txt_UseName.Location = new Point(49, 106);
            txt_UseName.Margin = new Padding(3, 2, 3, 2);
            txt_UseName.Name = "txt_UseName";
            txt_UseName.PasswordChar = '\0';
            txt_UseName.PlaceholderText = "Tên đăng nhập";
            txt_UseName.SelectedText = "";
            txt_UseName.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txt_UseName.Size = new Size(219, 36);
            txt_UseName.TabIndex = 1;
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            guna2HtmlLabel1.Location = new Point(82, 38);
            guna2HtmlLabel1.Margin = new Padding(3, 2, 3, 2);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(150, 35);
            guna2HtmlLabel1.TabIndex = 0;
            guna2HtmlLabel1.Text = "ĐĂNG NHẬP";
            // 
            // DangNhap
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(903, 495);
            Controls.Add(guna2Panel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "DangNhap";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DangNhap";
            Load += Form_Load;
            guna2Panel1.ResumeLayout(false);
            guna2Panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel btn_username;
        private Guna.UI2.WinForms.Guna2Button btn_Login;
        private Guna.UI2.WinForms.Guna2TextBox txt_Password;
        private Guna.UI2.WinForms.Guna2TextBox txt_UseName;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private CheckBox chk_ShowPassword;
    }
}