namespace GUI.View.viewslogin
{
    partial class EmailVerifyForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmailVerifyForm));
            lb_verifyEmail = new Label();
            txt_emailvery = new TextBox();
            label1 = new Label();
            label2 = new Label();
            txtEmailOTP = new TextBox();
            lb_OTP = new Label();
            lb_timeOTP = new Label();
            btn_Continue = new Button();
            btn_Back = new Button();
            pn_Emailvery = new Panel();
            timer1 = new System.Windows.Forms.Timer(components);
            pn_Emailvery.SuspendLayout();
            SuspendLayout();
            // 
            // lb_verifyEmail
            // 
            lb_verifyEmail.AutoSize = true;
            lb_verifyEmail.Font = new Font("Times New Roman", 22.2F, FontStyle.Bold, GraphicsUnit.Point);
            lb_verifyEmail.Location = new Point(102, 11);
            lb_verifyEmail.Name = "lb_verifyEmail";
            lb_verifyEmail.Size = new Size(283, 42);
            lb_verifyEmail.TabIndex = 0;
            lb_verifyEmail.Text = "Xác Thực Email ";
            // 
            // txt_emailvery
            // 
            txt_emailvery.Location = new Point(195, 98);
            txt_emailvery.Multiline = true;
            txt_emailvery.Name = "txt_emailvery";
            txt_emailvery.PlaceholderText = "  Email";
            txt_emailvery.Size = new Size(252, 31);
            txt_emailvery.TabIndex = 1;
            txt_emailvery.TextChanged += txt_emailvery_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(3, 104);
            label1.Name = "label1";
            label1.Size = new Size(162, 25);
            label1.TabIndex = 2;
            label1.Text = "Email của bạn:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(3, 172);
            label2.Name = "label2";
            label2.Size = new Size(147, 25);
            label2.TabIndex = 3;
            label2.Text = "Mã xác thực:";
            // 
            // txtEmailOTP
            // 
            txtEmailOTP.Location = new Point(195, 172);
            txtEmailOTP.Multiline = true;
            txtEmailOTP.Name = "txtEmailOTP";
            txtEmailOTP.PlaceholderText = "  OTP";
            txtEmailOTP.Size = new Size(154, 31);
            txtEmailOTP.TabIndex = 4;
            // 
            // lb_OTP
            // 
            lb_OTP.AutoSize = true;
            lb_OTP.Enabled = false;
            lb_OTP.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lb_OTP.Location = new Point(289, 243);
            lb_OTP.Name = "lb_OTP";
            lb_OTP.Size = new Size(115, 23);
            lb_OTP.TabIndex = 5;
            lb_OTP.Text = "Mã xác thực";
            lb_OTP.Click += lb_OTP_Click;
            // 
            // lb_timeOTP
            // 
            lb_timeOTP.AutoSize = true;
            lb_timeOTP.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            lb_timeOTP.Location = new Point(419, 246);
            lb_timeOTP.Name = "lb_timeOTP";
            lb_timeOTP.Size = new Size(60, 17);
            lb_timeOTP.TabIndex = 6;
            lb_timeOTP.Text = "Time otp";
            lb_timeOTP.Visible = false;
            lb_timeOTP.Click += lb_timeOTP_Click;
            // 
            // btn_Continue
            // 
            btn_Continue.BackColor = SystemColors.MenuHighlight;
            btn_Continue.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            btn_Continue.ForeColor = SystemColors.ActiveCaptionText;
            btn_Continue.Location = new Point(98, 328);
            btn_Continue.Name = "btn_Continue";
            btn_Continue.Size = new Size(118, 40);
            btn_Continue.TabIndex = 7;
            btn_Continue.Text = "Tiếp tục";
            btn_Continue.UseVisualStyleBackColor = false;
            btn_Continue.Click += btn_Continue_Click;
            // 
            // btn_Back
            // 
            btn_Back.BackColor = SystemColors.MenuHighlight;
            btn_Back.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            btn_Back.Location = new Point(281, 328);
            btn_Back.Name = "btn_Back";
            btn_Back.Size = new Size(118, 40);
            btn_Back.TabIndex = 8;
            btn_Back.Text = "Quay lại";
            btn_Back.UseVisualStyleBackColor = false;
            btn_Back.Click += btn_Back_Click;
            // 
            // pn_Emailvery
            // 
            pn_Emailvery.BackColor = SystemColors.InactiveCaption;
            pn_Emailvery.Controls.Add(lb_verifyEmail);
            pn_Emailvery.Controls.Add(btn_Back);
            pn_Emailvery.Controls.Add(label1);
            pn_Emailvery.Controls.Add(btn_Continue);
            pn_Emailvery.Controls.Add(label2);
            pn_Emailvery.Controls.Add(lb_timeOTP);
            pn_Emailvery.Controls.Add(txt_emailvery);
            pn_Emailvery.Controls.Add(lb_OTP);
            pn_Emailvery.Controls.Add(txtEmailOTP);
            pn_Emailvery.Location = new Point(36, 12);
            pn_Emailvery.Name = "pn_Emailvery";
            pn_Emailvery.Size = new Size(493, 372);
            pn_Emailvery.TabIndex = 9;
            // 
            // EmailVerifyForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(948, 391);
            Controls.Add(pn_Emailvery);
            Name = "EmailVerifyForm";
            Text = "EmailVerifyForm";
            pn_Emailvery.ResumeLayout(false);
            pn_Emailvery.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lb_verifyEmail;
        private TextBox txt_emailvery;
        private Label label1;
        private Label label2;
        private TextBox txtEmailOTP;
        private Label lb_OTP;
        private Label lb_timeOTP;
        private Button btn_Continue;
        private Button btn_Back;
        private Panel pn_Emailvery;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Timer timer1;
    }
}