using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DeadDog.Movies;
using DeadDog.Movies.IMDB;
using DeadDog;
using System.Net;

namespace Marathon
{
    public partial class NameChooser : Form
    {
        IEnumerable<SearchResult> results;
        private MovieId id;

        /// <summary>
        /// Gets the imdb id of the chosen movie
        /// </summary>
        public MovieId Id
        {
            get { return id; }
        }

        /// <summary>
        /// Instantiates an empty <see cref="NameChooser"/>
        /// </summary>
        public NameChooser()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Instantiates a <see cref="NameChooser"/> from the IEnumerable of <see cref="SearchResult"/>s
        /// </summary>
        /// <param name="results"></param>
        public NameChooser(IEnumerable<SearchResult> results)
            : this()
        {
            this.results = results;
            foreach (var item in results)
            {

                lbResults.Items.Add(item.Title + " (" + item.Year + ")");

            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            id = results.First(x => x.Title == lbResults.SelectedItem.ToString().CutToLast(' ', CutDirection.Right, true)).Id;
            if (id != null)
                DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            WebClient web = new WebClient();
            id = results.First(x => x.Title == lbResults.SelectedItem.ToString().CutToLast(' ', CutDirection.Right, true)).Id;
            IMDBBuffer buffer = new IMDBBuffer();
            MainPage page = buffer.ReadMain(id);
            if (page.PosterURL.Succes == false)
                Properties.Resources.no_photo.Save("temp");
            else web.DownloadFile(page.PosterURL.Data.Address, "temp");
            ImagePreview preview = new ImagePreview("temp");
            Cursor.Current = Cursors.Default;
            preview.ShowDialog();
        }
    }
}
