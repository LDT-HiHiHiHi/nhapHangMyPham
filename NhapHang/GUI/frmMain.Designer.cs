namespace GUI
{
    partial class frmMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.chứcNăngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xemPhiếuNhậpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xemSảnPhẩmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lậpPhiếuNhậpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chứcNăngToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1482, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // chứcNăngToolStripMenuItem
            // 
            this.chứcNăngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xemPhiếuNhậpToolStripMenuItem,
            this.xemSảnPhẩmToolStripMenuItem,
            this.lậpPhiếuNhậpToolStripMenuItem});
            this.chứcNăngToolStripMenuItem.Image = global::GUI.Properties.Resources.tsbProcess;
            this.chứcNăngToolStripMenuItem.Name = "chứcNăngToolStripMenuItem";
            this.chứcNăngToolStripMenuItem.Size = new System.Drawing.Size(107, 24);
            this.chứcNăngToolStripMenuItem.Text = "Chức năng";
            // 
            // xemPhiếuNhậpToolStripMenuItem
            // 
            this.xemPhiếuNhậpToolStripMenuItem.Image = global::GUI.Properties.Resources.fileprint_11__Custom_;
            this.xemPhiếuNhậpToolStripMenuItem.Name = "xemPhiếuNhậpToolStripMenuItem";
            this.xemPhiếuNhậpToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.xemPhiếuNhậpToolStripMenuItem.Text = "Phiếu nhập";
            this.xemPhiếuNhậpToolStripMenuItem.Click += new System.EventHandler(this.xemPhiếuNhậpToolStripMenuItem_Click);
            // 
            // xemSảnPhẩmToolStripMenuItem
            // 
            this.xemSảnPhẩmToolStripMenuItem.Image = global::GUI.Properties.Resources.printer;
            this.xemSảnPhẩmToolStripMenuItem.Name = "xemSảnPhẩmToolStripMenuItem";
            this.xemSảnPhẩmToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.xemSảnPhẩmToolStripMenuItem.Text = "Xem sản phẩm";
            this.xemSảnPhẩmToolStripMenuItem.Click += new System.EventHandler(this.xemSảnPhẩmToolStripMenuItem_Click);
            // 
            // lậpPhiếuNhậpToolStripMenuItem
            // 
            this.lậpPhiếuNhậpToolStripMenuItem.Image = global::GUI.Properties.Resources.tsbAddNew;
            this.lậpPhiếuNhậpToolStripMenuItem.Name = "lậpPhiếuNhậpToolStripMenuItem";
            this.lậpPhiếuNhậpToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.lậpPhiếuNhậpToolStripMenuItem.Text = "Lập phiếu nhập";
            this.lậpPhiếuNhậpToolStripMenuItem.Click += new System.EventHandler(this.lậpPhiếuNhậpToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1482, 953);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem chứcNăngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xemPhiếuNhậpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xemSảnPhẩmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lậpPhiếuNhậpToolStripMenuItem;
    }
}