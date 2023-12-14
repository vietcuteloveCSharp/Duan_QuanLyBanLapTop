namespace GUI.View
{
    partial class Hang1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Hang1));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            btn_Update = new Guna.UI2.WinForms.Guna2Button();
            btn_Clear = new Guna.UI2.WinForms.Guna2Button();
            btn_Add = new Guna.UI2.WinForms.Guna2Button();
            tbt_Search = new TextBox();
            label1 = new Label();
            label12 = new Label();
            label14 = new Label();
            tbt_Name = new TextBox();
            tbt_TrangThai = new TextBox();
            panel1 = new Panel();
            dtg_ShowHang = new Guna.UI2.WinForms.Guna2DataGridView();
            guna2GroupBox1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtg_ShowHang).BeginInit();
            SuspendLayout();
            // 
            // guna2GroupBox1
            // 
            guna2GroupBox1.Controls.Add(btn_Update);
            guna2GroupBox1.Controls.Add(btn_Clear);
            guna2GroupBox1.Controls.Add(btn_Add);
            guna2GroupBox1.Controls.Add(tbt_Search);
            guna2GroupBox1.Controls.Add(label1);
            guna2GroupBox1.CustomizableEdges = customizableEdges7;
            guna2GroupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            guna2GroupBox1.ForeColor = Color.FromArgb(125, 137, 149);
            guna2GroupBox1.Location = new Point(6, 9);
            guna2GroupBox1.Name = "guna2GroupBox1";
            guna2GroupBox1.ShadowDecoration.CustomizableEdges = customizableEdges8;
            guna2GroupBox1.Size = new Size(1243, 112);
            guna2GroupBox1.TabIndex = 16;
            // 
            // btn_Update
            // 
            btn_Update.BorderRadius = 10;
            btn_Update.CustomizableEdges = customizableEdges1;
            btn_Update.DisabledState.BorderColor = Color.DarkGray;
            btn_Update.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_Update.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_Update.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_Update.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btn_Update.ForeColor = Color.White;
            btn_Update.Location = new Point(127, 54);
            btn_Update.Name = "btn_Update";
            btn_Update.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btn_Update.Size = new Size(94, 58);
            btn_Update.TabIndex = 6;
            btn_Update.Text = "Sửa";
            btn_Update.Click += btn_Update_Click;
            // 
            // btn_Clear
            // 
            btn_Clear.BorderRadius = 10;
            btn_Clear.BorderStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot;
            btn_Clear.CustomImages.Image = (Image)resources.GetObject("resource.Image");
            btn_Clear.CustomImages.ImageAlign = HorizontalAlignment.Left;
            btn_Clear.CustomImages.ImageSize = new Size(25, 25);
            btn_Clear.CustomizableEdges = customizableEdges3;
            btn_Clear.DisabledState.BorderColor = Color.DarkGray;
            btn_Clear.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_Clear.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_Clear.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_Clear.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btn_Clear.ForeColor = Color.White;
            btn_Clear.Location = new Point(260, 54);
            btn_Clear.Name = "btn_Clear";
            btn_Clear.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btn_Clear.Size = new Size(95, 58);
            btn_Clear.TabIndex = 0;
            btn_Clear.Text = "Hủy";
            btn_Clear.TextOffset = new Point(15, 0);
            btn_Clear.Click += btn_Clear_Click;
            // 
            // btn_Add
            // 
            btn_Add.BorderRadius = 10;
            btn_Add.BorderStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot;
            btn_Add.CustomImages.Image = (Image)resources.GetObject("resource.Image1");
            btn_Add.CustomImages.ImageAlign = HorizontalAlignment.Left;
            btn_Add.CustomImages.ImageSize = new Size(25, 25);
            btn_Add.CustomizableEdges = customizableEdges5;
            btn_Add.DisabledState.BorderColor = Color.DarkGray;
            btn_Add.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_Add.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_Add.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_Add.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btn_Add.ForeColor = Color.White;
            btn_Add.Location = new Point(3, 54);
            btn_Add.Name = "btn_Add";
            btn_Add.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btn_Add.Size = new Size(95, 56);
            btn_Add.TabIndex = 0;
            btn_Add.Text = "Thêm";
            btn_Add.TextOffset = new Point(15, 0);
            btn_Add.Click += btn_Add_Click;
            // 
            // tbt_Search
            // 
            tbt_Search.Location = new Point(780, 56);
            tbt_Search.Multiline = true;
            tbt_Search.Name = "tbt_Search";
            tbt_Search.Size = new Size(435, 36);
            tbt_Search.TabIndex = 5;
            tbt_Search.TextChanged += tbt_Search_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(691, 59);
            label1.Name = "label1";
            label1.Size = new Size(70, 20);
            label1.TabIndex = 4;
            label1.Text = "Tìm kiếm";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            label12.Location = new Point(287, 162);
            label12.Name = "label12";
            label12.Size = new Size(86, 25);
            label12.TabIndex = 17;
            label12.Text = "Tên Hãng";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            label14.Location = new Point(287, 223);
            label14.Name = "label14";
            label14.Size = new Size(92, 25);
            label14.TabIndex = 19;
            label14.Text = "Trạng Thái";
            // 
            // tbt_Name
            // 
            tbt_Name.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            tbt_Name.Location = new Point(438, 162);
            tbt_Name.Name = "tbt_Name";
            tbt_Name.Size = new Size(479, 31);
            tbt_Name.TabIndex = 21;
            // 
            // tbt_TrangThai
            // 
            tbt_TrangThai.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            tbt_TrangThai.Location = new Point(438, 224);
            tbt_TrangThai.Name = "tbt_TrangThai";
            tbt_TrangThai.Size = new Size(479, 31);
            tbt_TrangThai.TabIndex = 23;
            // 
            // panel1
            // 
            panel1.Controls.Add(dtg_ShowHang);
            panel1.Controls.Add(tbt_TrangThai);
            panel1.Controls.Add(tbt_Name);
            panel1.Controls.Add(label14);
            panel1.Controls.Add(label12);
            panel1.Controls.Add(guna2GroupBox1);
            panel1.Location = new Point(6, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1262, 621);
            panel1.TabIndex = 0;
            // 
            // dtg_ShowHang
            // 
            dataGridViewCellStyle1.BackColor = Color.White;
            dtg_ShowHang.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dtg_ShowHang.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dtg_ShowHang.ColumnHeadersHeight = 4;
            dtg_ShowHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dtg_ShowHang.DefaultCellStyle = dataGridViewCellStyle3;
            dtg_ShowHang.GridColor = Color.FromArgb(231, 229, 255);
            dtg_ShowHang.Location = new Point(9, 420);
            dtg_ShowHang.Name = "dtg_ShowHang";
            dtg_ShowHang.RowHeadersVisible = false;
            dtg_ShowHang.RowHeadersWidth = 51;
            dtg_ShowHang.RowTemplate.Height = 29;
            dtg_ShowHang.Size = new Size(1240, 198);
            dtg_ShowHang.TabIndex = 24;
            dtg_ShowHang.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dtg_ShowHang.ThemeStyle.AlternatingRowsStyle.Font = null;
            dtg_ShowHang.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dtg_ShowHang.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dtg_ShowHang.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dtg_ShowHang.ThemeStyle.BackColor = Color.White;
            dtg_ShowHang.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dtg_ShowHang.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dtg_ShowHang.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dtg_ShowHang.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dtg_ShowHang.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dtg_ShowHang.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dtg_ShowHang.ThemeStyle.HeaderStyle.Height = 4;
            dtg_ShowHang.ThemeStyle.ReadOnly = false;
            dtg_ShowHang.ThemeStyle.RowsStyle.BackColor = Color.White;
            dtg_ShowHang.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dtg_ShowHang.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dtg_ShowHang.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dtg_ShowHang.ThemeStyle.RowsStyle.Height = 29;
            dtg_ShowHang.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dtg_ShowHang.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dtg_ShowHang.CellClick += dtg_ShowHang_CellClick;
            dtg_ShowHang.CellContentClick += dtg_ShowHang_CellContentClick;
            // 
            // Hang1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1280, 665);
            Controls.Add(panel1);
            Name = "Hang1";
            Text = "Hang";
            Load += Hang_Load;
            guna2GroupBox1.ResumeLayout(false);
            guna2GroupBox1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtg_ShowHang).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private Guna.UI2.WinForms.Guna2Button btn_Update;
        private Guna.UI2.WinForms.Guna2Button btn_Clear;
        private Guna.UI2.WinForms.Guna2Button btn_Add;
        private TextBox tbt_Search;
        private Label label1;
        private Label label12;
        private Label label14;
        private TextBox tbt_Name;
        private TextBox tbt_TrangThai;
        private Panel panel1;
        private Guna.UI2.WinForms.Guna2DataGridView dtg_ShowHang;
    }
}