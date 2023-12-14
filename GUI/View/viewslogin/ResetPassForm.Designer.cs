namespace GUI.View.viewslogin
{
    partial class ResetPassForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResetPassForm));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txt_newpass = new TextBox();
            txt_passagain = new TextBox();
            btn_Continue = new Button();
            btn_Back = new Button();
            pn_ResetPass = new Panel();
            checkPassReset = new CheckBox();
            pn_ResetPass.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(178, 9);
            label1.Name = "label1";
            label1.Size = new Size(216, 31);
            label1.TabIndex = 0;
            label1.Text = "Cập nhật mật khẩu";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(19, 99);
            label2.Name = "label2";
            label2.Size = new Size(176, 23);
            label2.TabIndex = 1;
            label2.Text = "Nhập mật khẩu mới:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(3, 177);
            label3.Name = "label3";
            label3.Size = new Size(192, 23);
            label3.TabIndex = 2;
            label3.Text = "Xác nhận lại mật khẩu:";
            // 
            // txt_newpass
            // 
            txt_newpass.Location = new Point(212, 98);
            txt_newpass.Name = "txt_newpass";
            txt_newpass.Size = new Size(295, 27);
            txt_newpass.TabIndex = 3;
            // 
            // txt_passagain
            // 
            txt_passagain.Location = new Point(212, 173);
            txt_passagain.Name = "txt_passagain";
            txt_passagain.Size = new Size(295, 27);
            txt_passagain.TabIndex = 4;
            // 
            // btn_Continue
            // 
            btn_Continue.BackColor = SystemColors.Info;
            btn_Continue.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            btn_Continue.Location = new Point(138, 280);
            btn_Continue.Name = "btn_Continue";
            btn_Continue.Size = new Size(94, 29);
            btn_Continue.TabIndex = 5;
            btn_Continue.Text = "Tiếp tục";
            btn_Continue.UseVisualStyleBackColor = false;
            btn_Continue.Click += btn_Continue_Click;
            // 
            // btn_Back
            // 
            btn_Back.BackColor = SystemColors.Info;
            btn_Back.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            btn_Back.Location = new Point(347, 280);
            btn_Back.Name = "btn_Back";
            btn_Back.Size = new Size(94, 29);
            btn_Back.TabIndex = 6;
            btn_Back.Text = "Quay lại";
            btn_Back.UseVisualStyleBackColor = false;
            btn_Back.Click += btn_Back_Click;
            // 
            // pn_ResetPass
            // 
            pn_ResetPass.Controls.Add(checkPassReset);
            pn_ResetPass.Controls.Add(label1);
            pn_ResetPass.Controls.Add(btn_Continue);
            pn_ResetPass.Controls.Add(btn_Back);
            pn_ResetPass.Controls.Add(txt_newpass);
            pn_ResetPass.Controls.Add(txt_passagain);
            pn_ResetPass.Controls.Add(label3);
            pn_ResetPass.Controls.Add(label2);
            pn_ResetPass.Location = new Point(1, 12);
            pn_ResetPass.Name = "pn_ResetPass";
            pn_ResetPass.Size = new Size(653, 328);
            pn_ResetPass.TabIndex = 7;
            // 
            // checkPassReset
            // 
            checkPassReset.AutoSize = true;
            checkPassReset.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            checkPassReset.Location = new Point(369, 227);
            checkPassReset.Name = "checkPassReset";
            checkPassReset.Size = new Size(138, 23);
            checkPassReset.TabIndex = 7;
            checkPassReset.Text = "Hiện mật khẩu";
            checkPassReset.UseVisualStyleBackColor = true;
            checkPassReset.CheckedChanged += checkPassReset_CheckedChanged;
            // 
            // ResetPassForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(1177, 450);
            Controls.Add(pn_ResetPass);
            Name = "ResetPassForm";
            Text = "ResetPassForm";
            Load += ResetPassForm_Load;
            pn_ResetPass.ResumeLayout(false);
            pn_ResetPass.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txt_newpass;
        private TextBox txt_passagain;
        private Button btn_Continue;
        private Button btn_Back;
        private Panel pn_ResetPass;
        private CheckBox checkPassReset;
    }
}