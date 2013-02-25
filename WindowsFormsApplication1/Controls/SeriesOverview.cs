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
    /// Displays 5 series with their respective pictures
    /// </summary>
    public partial class SeriesOverview : UserControl
    {
        private int unit;
        private static Dictionary<int, int> X = new Dictionary<int, int>() { { 0, 0 }, { 1, 5 }, { 2, 14 }, { 3, 27 }, { 4, 36 } };

        SeriesControl p0, p1, p2, p3, p4;

        /// <summary>
        /// Instantiates a <see cref="SeriesOverview"/>
        /// </summary>
        public SeriesOverview()
        {
            InitializeComponent();
            p0 = new SeriesControl();
            p1 = new SeriesControl();
            p2 = new SeriesControl();
            p3 = new SeriesControl();
            p4 = new SeriesControl();
            //p0.pbSeriesPicture.MouseClick += new MouseEventHandler(p0_MouseClick);
            //p0.pbSeriesPicture.MouseUp += new MouseEventHandler(p0_MouseUp);
            setSizes();
            Controls.AddRange(new Control[] { p0, p1, p2, p3, p4 });
            DoubleBuffered = true;

        }

        /// <summary>
        /// Sets the Series to display on the <see cref="TitleControl"/>
        /// </summary>
        /// <param name="series">The <see cref="Series"/> to display</param>
        public void SetSeriesDisplayed(LinkedListNode<Series> series)
        {
            if (series != null)
            {
                p0.setSeries(series.PreviousOrLast().PreviousOrLast().Value);
                p1.setSeries(series.PreviousOrLast().Value);
                p2.setSeries(series.Value);
                p3.setSeries(series.NextOrFirst().Value);
                p4.setSeries(series.NextOrFirst().NextOrFirst().Value);
            }
            this.Invalidate();
        }

        private void setSizes()
        {
            unit = this.Width / 40;
            p0.Width = 4 * unit;
            p0.Height = 3 * p0.Width;
            p0.Location = new Point(X[0] * unit, this.Height / 2 - p0.Height / 2);

            p1.Width = 8 * unit;
            p1.Height = 3 * p1.Width;
            p1.Location = new Point(X[1] * unit, this.Height / 2 - p1.Height / 2);

            p2.Width = 12 * unit;
            p2.Height = 3 * p2.Width;
            p2.Location = new Point(X[2] * unit, this.Height / 2 - p2.Height / 2);

            p3.Width = 8 * unit;
            p3.Height = 3 * p3.Width;
            p3.Location = new Point(X[3] * unit, (this.Height / 2) - (p3.Height / 2));

            p4.Width = 4 * unit;
            p4.Height = 3 * p4.Width;
            p4.Location = new Point(X[4] * unit, this.Height / 2 - p4.Height / 2);

        }

        /// <summary>
        /// Sets the sizes of the <see cref="SeriesControl"/>s when resizing
        /// </summary>
        /// <param name="e"></param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (p0 != null)
                setSizes();
            this.Invalidate();
            this.Focus();
        }
    }
}
