namespace Marathon
{
    /// <summary>
    /// Control showing the title, number of seasons and number of episodes of a series
    /// </summary>
    partial class TitleControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lTitle = new System.Windows.Forms.Label();
            this.lSeasons = new System.Windows.Forms.Label();
            this.lEpisodes = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lTitle
            // 
            this.lTitle.AutoSize = true;
            this.lTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTitle.Location = new System.Drawing.Point(260, 0);
            this.lTitle.Name = "lTitle";
            this.lTitle.Size = new System.Drawing.Size(66, 31);
            this.lTitle.TabIndex = 0;
            this.lTitle.Text = "Titel";
            // 
            // lSeasons
            // 
            this.lSeasons.AutoSize = true;
            this.lSeasons.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lSeasons.Location = new System.Drawing.Point(254, 31);
            this.lSeasons.Name = "lSeasons";
            this.lSeasons.Size = new System.Drawing.Size(72, 20);
            this.lSeasons.TabIndex = 1;
            this.lSeasons.Text = "Seasons";
            // 
            // lEpisodes
            // 
            this.lEpisodes.AutoSize = true;
            this.lEpisodes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lEpisodes.Location = new System.Drawing.Point(254, 51);
            this.lEpisodes.Name = "lEpisodes";
            this.lEpisodes.Size = new System.Drawing.Size(75, 20);
            this.lEpisodes.TabIndex = 2;
            this.lEpisodes.Text = "Episodes";
            // 
            // TitleControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lEpisodes);
            this.Controls.Add(this.lSeasons);
            this.Controls.Add(this.lTitle);
            this.Name = "TitleControl";
            this.Size = new System.Drawing.Size(589, 79);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lTitle;
        private System.Windows.Forms.Label lSeasons;
        private System.Windows.Forms.Label lEpisodes;

    }
}
