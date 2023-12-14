namespace GUI.View.viewslogin
{
    partial class MainLoginForm
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
            data_Show = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)data_Show).BeginInit();
            SuspendLayout();
            // 
            // data_Show
            // 
            data_Show.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            data_Show.Location = new Point(0, -1);
            data_Show.Name = "data_Show";
            data_Show.RowHeadersWidth = 51;
            data_Show.RowTemplate.Height = 29;
            data_Show.Size = new Size(798, 451);
            data_Show.TabIndex = 0;
            // 
            // MainLoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(data_Show);
            Name = "MainLoginForm";
            Text = "MainLoginForm";
            ((System.ComponentModel.ISupportInitialize)data_Show).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView data_Show;
    }
}