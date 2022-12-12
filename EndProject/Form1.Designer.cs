namespace EndProject
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Menu = new System.Windows.Forms.MenuStrip();
            this.MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DifficultMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EasyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NormalMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HardMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.QuitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RestartMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // Menu
            // 
            this.Menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem,
            this.RestartMenuItem});
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            this.Menu.Size = new System.Drawing.Size(914, 30);
            this.Menu.TabIndex = 0;
            this.Menu.Text = "menuStrip1";
            // 
            // MenuItem
            // 
            this.MenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DifficultMenuItem,
            this.QuitMenuItem});
            this.MenuItem.Name = "MenuItem";
            this.MenuItem.Size = new System.Drawing.Size(60, 24);
            this.MenuItem.Text = "Menu";
            // 
            // DifficultMenuItem
            // 
            this.DifficultMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EasyMenuItem,
            this.NormalMenuItem,
            this.HardMenuItem});
            this.DifficultMenuItem.Name = "DifficultMenuItem";
            this.DifficultMenuItem.Size = new System.Drawing.Size(187, 26);
            this.DifficultMenuItem.Text = "Difficulty level";
            // 
            // EasyMenuItem
            // 
            this.EasyMenuItem.Name = "EasyMenuItem";
            this.EasyMenuItem.Size = new System.Drawing.Size(142, 26);
            this.EasyMenuItem.Text = "Easy";
            this.EasyMenuItem.Click += new System.EventHandler(this.EasyMenuItem_Click);
            // 
            // NormalMenuItem
            // 
            this.NormalMenuItem.Name = "NormalMenuItem";
            this.NormalMenuItem.Size = new System.Drawing.Size(142, 26);
            this.NormalMenuItem.Text = "Normal";
            this.NormalMenuItem.Click += new System.EventHandler(this.NormalMenuItem_Click);
            // 
            // HardMenuItem
            // 
            this.HardMenuItem.Name = "HardMenuItem";
            this.HardMenuItem.Size = new System.Drawing.Size(142, 26);
            this.HardMenuItem.Text = "Hard";
            this.HardMenuItem.Click += new System.EventHandler(this.HardMenuItem_Click);
            // 
            // QuitMenuItem
            // 
            this.QuitMenuItem.Name = "QuitMenuItem";
            this.QuitMenuItem.Size = new System.Drawing.Size(187, 26);
            this.QuitMenuItem.Text = "Quit";
            this.QuitMenuItem.Click += new System.EventHandler(this.QuitMenuItem_Click);
            // 
            // RestartMenuItem
            // 
            this.RestartMenuItem.Name = "RestartMenuItem";
            this.RestartMenuItem.Size = new System.Drawing.Size(69, 24);
            this.RestartMenuItem.Text = "Restart";
            this.RestartMenuItem.Click += new System.EventHandler(this.RestartMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cyan;
            this.ClientSize = new System.Drawing.Size(914, 600);
            this.Controls.Add(this.Menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.Menu;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Minefield";
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip Menu;
        private System.Windows.Forms.ToolStripMenuItem MenuItem;
        private System.Windows.Forms.ToolStripMenuItem DifficultMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EasyMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NormalMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HardMenuItem;
        private System.Windows.Forms.ToolStripMenuItem QuitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RestartMenuItem;
    }
}
