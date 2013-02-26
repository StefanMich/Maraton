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
        private string title;
        private int seasons;
        private int episodes;

        /// <summary>
        /// Instantiates a <see cref="TitleControl"/> with a default text
        /// </summary>
        public TitleControl()
        {
            InitializeComponent();
            this.title = "Add series with the button on the left";
        }

        /// <summary>
        /// Sets the text of the <see cref="TitleControl"/> to the specified <paramref name="title"/>, <paramref name="seasons"/> and <paramref name="episodes"/>
        /// </summary>
        /// <param name="title">The title to set the <see cref="TitleControl"/> to</param>
        /// <param name="seasons">The numver of <see cref="Season"/>s to display on the <see cref="TitleControl"/></param>
        /// <param name="episodes">The number of <see cref="Stufkan.IO.Episode"/>s to display on the <see cref="TitleControl"/></param>
        public void SetText(string title, int seasons, int episodes)
        {
            this.title = title;
            this.seasons = seasons;
            this.episodes = episodes;

            lTitle.Text = title;
            lTitle.Location = new Point(this.Width / 2 - lTitle.Width / 2, lTitle.Location.Y);

            lSeasons.Text = seasons + " season" + (seasons > 1 ? "s" : "");
            lSeasons.Location = new Point(this.Width / 2 - lSeasons.Width / 2, lSeasons.Location.Y);

            lEpisodes.Text = episodes + " episode" + (episodes > 1 ? "s" : "");
            lEpisodes.Location = new Point(this.Width / 2 - lEpisodes.Width / 2, lEpisodes.Location.Y);
        }

        /// <summary>
        /// Sets the content of the <see cref="TitleControl"/> to the content of the <see cref="Series"/>
        /// </summary>
        /// <param name="series"></param>
        public void SetText(Series series)
        {
            SetText(series.Name, series.NumberOfSeasons(), series.NumberOfEpisodes());
        }

        /// <summary>
        /// Makes sure <see cref="TitleControl"/> is updated when the control is resized.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            SetText(title, seasons, episodes);
            this.Invalidate();
        }

    }
}