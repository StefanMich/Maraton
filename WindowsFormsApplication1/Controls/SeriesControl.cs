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
    /// <summary>
    /// Control displaying a <see cref="Series"/>
    /// </summary>
    public partial class SeriesControl : UserControl
    {
        private Series series;

        /// <summary>
        /// Gets or sets the <see cref="Series"/> that is displayed
        /// </summary>
        public Series Series
        {
            get { return series; }
            set { series = value; }
        }
        
        /// <summary>
        /// Instantiates a new <see cref="SeriesControl"/> with no <see cref="Series"/> assigned
        /// </summary>
        public SeriesControl()
        {
            InitializeComponent();
            pbSeriesPicture.Click += new EventHandler(pbSeriesPicture_Click);
        }

        void pbSeriesPicture_Click(object sender, EventArgs e)
        {
            if (PosterClick != null)
                PosterClick(this, new PosterClickEventArgs(this.series));
        }

        /// <summary>
        /// Instantiates a new <see cref="SeriesControl"/> displaying the specified <see cref="Series"/>
        /// </summary>
        /// <param name="series">The <see cref="Series"/> to display</param>
        public SeriesControl(Series series)
            : this()
        {
            this.series = series;
            this.pbSeriesPicture.Image = series.Picture;
        }

        /// <summary>
        /// Sets the displayed <see cref="Series"/> of the <see cref="SeriesControl"/> to the specified <see cref="Series"/>
        /// </summary>
        /// <param name="series">The <see cref="Series"/> to display</param>
        public void setSeries(Series series)
        {
            this.series = series;
            this.pbSeriesPicture.Image = series.Picture;
        }


        public delegate void PosterClickEventHandler(object sender, PosterClickEventArgs e);
        /// <summary>
        /// Occurs when the poster is clicked.
        /// </summary>
        public event PosterClickEventHandler PosterClick;
        

    }

    public class PosterClickEventArgs : EventArgs
    {
        private Series posterSeries;

        /// <summary>
        /// Gets the poster series.
        /// </summary>
        /// <value>
        /// The poster series.
        /// </value>
        public Series PosterSeries
        {
            get { return posterSeries; }
            internal set { posterSeries = value; }
        }
        public PosterClickEventArgs(Series posterSeries)
        {
            this.posterSeries = posterSeries;
        }
        
    }
}
