﻿namespace Marathon
{
    partial class EditSeries
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
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.pbPoster = new System.Windows.Forms.PictureBox();
            this.btnChangePoster = new System.Windows.Forms.Button();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.tvEditor = new System.Windows.Forms.TreeView();
            this.btnAddSeason = new System.Windows.Forms.Button();
            this.btnDeleteSeries = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.tcTitle = new Marathon.TitleControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPoster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tcTitle);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(507, 333);
            this.splitContainer1.SplitterDistance = 77;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer4);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(507, 252);
            this.splitContainer2.SplitterDistance = 193;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.pbPoster);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.btnChangePoster);
            this.splitContainer4.Size = new System.Drawing.Size(193, 252);
            this.splitContainer4.SplitterDistance = 218;
            this.splitContainer4.TabIndex = 0;
            // 
            // pbPoster
            // 
            this.pbPoster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbPoster.Location = new System.Drawing.Point(0, 0);
            this.pbPoster.Name = "pbPoster";
            this.pbPoster.Size = new System.Drawing.Size(193, 218);
            this.pbPoster.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPoster.TabIndex = 0;
            this.pbPoster.TabStop = false;
            // 
            // btnChangePoster
            // 
            this.btnChangePoster.Location = new System.Drawing.Point(2, 2);
            this.btnChangePoster.Name = "btnChangePoster";
            this.btnChangePoster.Size = new System.Drawing.Size(172, 23);
            this.btnChangePoster.TabIndex = 1;
            this.btnChangePoster.Text = "Change Poster";
            this.btnChangePoster.UseVisualStyleBackColor = true;
            this.btnChangePoster.Click += new System.EventHandler(this.btnChangePoster_Click);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.tvEditor);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.btnAddSeason);
            this.splitContainer3.Panel2.Controls.Add(this.btnDeleteSeries);
            this.splitContainer3.Panel2.Controls.Add(this.btnDelete);
            this.splitContainer3.Size = new System.Drawing.Size(310, 252);
            this.splitContainer3.SplitterDistance = 218;
            this.splitContainer3.TabIndex = 1;
            // 
            // tvEditor
            // 
            this.tvEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvEditor.Location = new System.Drawing.Point(0, 0);
            this.tvEditor.Name = "tvEditor";
            this.tvEditor.Size = new System.Drawing.Size(310, 218);
            this.tvEditor.TabIndex = 0;
            // 
            // btnAddSeason
            // 
            this.btnAddSeason.Location = new System.Drawing.Point(151, 2);
            this.btnAddSeason.Name = "btnAddSeason";
            this.btnAddSeason.Size = new System.Drawing.Size(75, 23);
            this.btnAddSeason.TabIndex = 4;
            this.btnAddSeason.Text = "Add Season";
            this.btnAddSeason.UseVisualStyleBackColor = true;
            this.btnAddSeason.Click += new System.EventHandler(this.btnAddSeason_Click);
            // 
            // btnDeleteSeries
            // 
            this.btnDeleteSeries.Location = new System.Drawing.Point(3, 2);
            this.btnDeleteSeries.Name = "btnDeleteSeries";
            this.btnDeleteSeries.Size = new System.Drawing.Size(89, 23);
            this.btnDeleteSeries.TabIndex = 3;
            this.btnDeleteSeries.Text = "Delete Series";
            this.btnDeleteSeries.UseVisualStyleBackColor = true;
            this.btnDeleteSeries.Click += new System.EventHandler(this.btnDeleteSeries_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(232, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // tcTitle
            // 
            this.tcTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcTitle.Location = new System.Drawing.Point(0, 0);
            this.tcTitle.Name = "tcTitle";
            this.tcTitle.Size = new System.Drawing.Size(507, 77);
            this.tcTitle.TabIndex = 0;
            // 
            // EditSeries
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 333);
            this.Controls.Add(this.splitContainer1);
            this.Name = "EditSeries";
            this.Text = "Edit Series";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbPoster)).EndInit();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private TitleControl tcTitle;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.PictureBox pbPoster;
        private System.Windows.Forms.TreeView tvEditor;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Button btnChangePoster;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.Button btnDeleteSeries;
        private System.Windows.Forms.Button btnAddSeason;
    }
}