using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Marathon
{
    public partial class TitleControl : UserControl
    {
        private Series series;

        /// <summary>
        /// Instantiates a <see cref="TitleControl"/> with a default text
        /// </summary>
        public TitleControl()
        {
            InitializeComponent();
            this.series = new Series("Add series with the button on the left", null);
        }

       
        

        /// <summary>
        /// Sets the content of the <see cref="TitleControl"/> to the content of the <see cref="Series"/>
        /// </summary>
        /// <param name="series"></param>
        public void SetText(Series series)
        {
            if (series != null)
            {

                lTitle.Text = series.Name;
                lTitle.Location = new Point(this.Width / 2 - lTitle.Width / 2, lTitle.Location.Y);

                lSeasons.Text = series.NumberOfSeasons() + " season" + (series.NumberOfSeasons() > 1 ? "s" : "");
                lSeasons.Location = new Point(this.Width / 2 - lSeasons.Width / 2, lSeasons.Location.Y);

                lEpisodes.Text = series.NumberOfEpisodes() + " episode" + (series.NumberOfEpisodes() > 1 ? "s" : "");
                lEpisodes.Location = new Point(this.Width / 2 - lEpisodes.Width / 2, lEpisodes.Location.Y);
            }
        }

        /// <summary>
        /// Makes sure <see cref="TitleControl"/> is updated when the control is resized.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            SetText(series);
            this.Invalidate();
        }

    }
}