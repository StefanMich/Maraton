namespace Marathon
{
    partial class SeriesControl
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
            this.pbSeriesPicture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbSeriesPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // pbSeriesPicture
            // 
            this.pbSeriesPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pbSeriesPicture.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pbSeriesPicture.Location = new System.Drawing.Point(0, 0);
            this.pbSeriesPicture.Name = "pbSeriesPicture";
            this.pbSeriesPicture.Size = new System.Drawing.Size(150, 150);
            this.pbSeriesPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbSeriesPicture.TabIndex = 0;
            this.pbSeriesPicture.TabStop = false;
            // 
            // SeriesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.pbSeriesPicture);
            this.Name = "SeriesControl";
            ((System.ComponentModel.ISupportInitialize)(this.pbSeriesPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbSeriesPicture;
    }
}
