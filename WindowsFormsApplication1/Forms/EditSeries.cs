using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Marathon
{
    /// <summary>
    /// A windows displaying an editable version of a series
    /// </summary>
    public partial class EditSeries : Form
    {
        private Series series;
        private SeriesManager manager;

        FolderBrowserDialog fbd;

        /// <summary>
        /// Instantiates an empty <see cref="EditSeries"/>
        /// </summary>
        public EditSeries()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Instantiates a <see cref="EditSeries"/> with the content of the specified <see cref="Series"/>
        /// </summary>
        /// <param name="series">The <see cref="Series"/> to display</param>
        /// <param name="manager">The <see cref="SeriesManager"/> owning the <see cref="Series"/> to be edited</param>
        public EditSeries(Series series, SeriesManager manager): this()
        {
            this.series = series;
            this.manager = manager;

            tcTitle.SetText(series);
            pbPoster.Image = series.Picture;
            populateTreeView(series);
            fbd = new FolderBrowserDialog();
        }

        private void populateTreeView(Series series)
        {
            tvEditor.Nodes.Clear();
            foreach (Season s in series.Seasons)
            {
                
                TreeNode t = tvEditor.Nodes.Add(s.Title);
                foreach (Episode e in s.Episodes)
                {
                    t.Nodes.Add(e.Title);
                }
            }
        }

        private void btnChangePoster_Click(object sender, EventArgs e)
        {
            OpenFileDialog fbd = new OpenFileDialog();
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                series.Picture.Dispose();
                pbPoster.Image.Dispose();
                File.Replace(fbd.FileName, series.Name, fbd.FileName+".bak");
                series.Picture = Bitmap.FromFile(series.Name);
                pbPoster.Image = series.Picture;
                //TODO crasher nogle gange (ved skift af billede flere gange?)
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            TreeNode n = tvEditor.SelectedNode;
            if (n!= null)
            {
                Season s = series.Seasons.Where(x=>x.Title == n.Text).FirstOrDefault();
                if (s != null)
                {
                    series.Seasons.Remove(s);
                    tvEditor.Nodes.Remove(n);
                }

                foreach (Season season in series.Seasons)
                {
                    Episode ep= season.Episodes.Where(x => x.Title == n.Text).FirstOrDefault();
                    if (ep != null)
                    {
                        season.Episodes.Remove(ep);
                        n.Parent.Nodes.Remove(n);
                        }
                }
            
            }
        }

        private void btnDeleteSeries_Click(object sender, EventArgs e)
        {
            manager.RemoveSeries(series);
            this.Close();
        }

        private void btnAddSeason_Click(object sender, EventArgs e)
        {
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                manager.AddSeasonToSeries(series, fbd.SelectedPath);
                populateTreeView(series);
                
            }
        }

        //TODO ændr rækkefølge på sæsoner
    }
}
