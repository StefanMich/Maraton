namespace Marathon
{
    partial class MainWindow
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.titleControl1 = new Marathon.TitleControl();
            this.seriesOverview1 = new Marathon.SeriesOverview();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
            this.splitContainer1.Panel1.Controls.Add(this.titleControl1);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.seriesOverview1);
            this.splitContainer1.Panel2.Enabled = false;
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Size = new System.Drawing.Size(814, 403);
            this.splitContainer1.SplitterDistance = 71;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 1;
            this.splitContainer1.TabStop = false;
            this.splitContainer1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.seriesOverview1_KeyUp);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Marathon.Properties.Resources.png;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(33, 34);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.AddSeries_MouseClick);
            // 
            // titleControl1
            // 
            this.titleControl1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.titleControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.titleControl1.Location = new System.Drawing.Point(0, 0);
            this.titleControl1.Name = "titleControl1";
            this.titleControl1.Size = new System.Drawing.Size(814, 71);
            this.titleControl1.TabIndex = 0;
            this.titleControl1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.seriesOverview1_KeyUp);
            // 
            // seriesOverview1
            // 
            this.seriesOverview1.AllowDrop = true;
            this.seriesOverview1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.seriesOverview1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seriesOverview1.Location = new System.Drawing.Point(0, 0);
            this.seriesOverview1.Name = "seriesOverview1";
            this.seriesOverview1.Size = new System.Drawing.Size(814, 331);
            this.seriesOverview1.TabIndex = 0;
            this.seriesOverview1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.seriesOverview1_KeyUp);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 403);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainWindow";
            this.Text = "Maraton";
            this.Load += new System.EventHandler(this.GUI_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.seriesOverview1_KeyUp);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private TitleControl titleControl1;
        private SeriesOverview seriesOverview1;
        private System.Windows.Forms.PictureBox pictureBox1;






    }
}