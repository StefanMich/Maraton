using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using Stufkan.IO;

namespace Marathon
{
    /// <summary>
    /// Main windows of the application
    /// </summary>
    public partial class MainWindow : Form
    {
        private SeriesManager manager;
        FolderBrowserDialog fbdBrowse = new FolderBrowserDialog();

        /// <summary>
        /// Instantiates a <see cref="MainWindow"/>
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();


#if DEBUG
            
            #region testdata
            /*
            Series test = new Series("HIMYM", Properties.Resources.himym);
            Season s1 = new Season("s1", test);
            Season s2 = new Season("s2", test);
            s1.EpisodeCollection.Enqueue(new Stufkan.IO.Episode(null, "S1E1"));
            s1.EpisodeCollection.Enqueue(new Stufkan.IO.Episode(null, "S1E2"));
            s1.EpisodeCollection.Enqueue(new Stufkan.IO.Episode(null, "S1E3"));
            s2.EpisodeCollection.Enqueue(new Stufkan.IO.Episode(null, "S2E1"));
            s2.EpisodeCollection.Enqueue(new Stufkan.IO.Episode(null, "S2E2"));
            s2.EpisodeCollection.Enqueue(new Stufkan.IO.Episode(null, "S2E3"));
            test.Seasons.Enqueue(s1);
            test.Seasons.Enqueue(s2);
            Manager.Series.Add(test);

            Series test2 = new Series("BBT", Properties.Resources.bbt);
            Season bs1 = new Season("s1", test2);
            Season bs2 = new Season("s2", test2);
            bs1.EpisodeCollection.Enqueue(new Stufkan.IO.Episode(null, "S1E1"));
            bs1.EpisodeCollection.Enqueue(new Stufkan.IO.Episode(null, "S1E2"));
            bs1.EpisodeCollection.Enqueue(new Stufkan.IO.Episode(null, "S1E3"));
            bs2.EpisodeCollection.Enqueue(new Stufkan.IO.Episode(null, "S2E1"));
            test2.Seasons.Enqueue(bs1);
            test2.Seasons.Enqueue(bs2);
            Manager.Series.Add(test2);

            Series test3 = new Series("Modern Family", Properties.Resources.modern);
            Season ms1 = new Season("s1", test3);
            ms1.EpisodeCollection.Enqueue(new Stufkan.IO.Episode(null, "S1E1"));
            ms1.EpisodeCollection.Enqueue(new Stufkan.IO.Episode(null, "S1E2"));
            ms1.EpisodeCollection.Enqueue(new Stufkan.IO.Episode(null, "S1E3"));
            test3.Seasons.Enqueue(ms1);
            Manager.Series.Add(test3);

            setToCurrent();
            */
            #endregion

            Manager.AddSeries(@"C:\Testfilm\30 Rock");
            Manager.AddSeries(@"C:\Testfilm\Big Bang Theory");
            Manager.AddSeries(@"C:\Testfilm\How i met your mother");
            setToCurrent();
           
#endif
        }

        void manager_CurrentSeriesChanged(object sender, EventArgs e)
        {
            setToCurrent();
        }

        /// <summary>
        /// Rotates the visual representation of the series queue, one to the right
        /// </summary>
        public void Next()
        {
            manager.CurrentSeries = manager.NextSeries;
        }

        /// <summary>
        /// Rotates the visual representation of the series queue, one to the left
        /// </summary>
        public void Previous()
        {
            manager.CurrentSeries = manager.PreviousSeries;
        }

        private void seriesOverview1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
                Previous();
            else if (e.KeyCode == Keys.Right)
                Next();
            else if (e.KeyCode == Keys.Enter)
                manager.PlayCurrent();
            else if (e.KeyCode == Keys.R)
            {
                manager.CurrentSeries = manager.Series.Find(manager.RecentlyWatched);
                setToCurrent();
            }
            else if (e.KeyCode == Keys.Space)
            {
                EditSeries es = new EditSeries(manager.CurrentSeries.Value, manager);
                es.ShowDialog();
                SaveLoad.SaveManager(manager, "data.lawl");
                setToCurrent();
            }

        }

        private void setText()
        {
            titleControl1.SetText(manager.CurrentSeries.Value);
        }

        private void AddSeries_MouseClick(object sender, MouseEventArgs e)
        {
            pictureBox1.Focus();

            if (fbdBrowse.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                manager.CurrentSeries = manager.AddSeries(fbdBrowse.SelectedPath);
            }
            seriesOverview1.Select();
        }

        private void setToCurrent()
        {
            if (manager.Series.Count() > 0)
            {
                seriesOverview1.SetSeriesDisplayed(manager.CurrentSeries);
                setText();
            }
        }

        private void GUI_Load(object sender, EventArgs e)
        {
            if ((manager = SaveLoad.OnLoad()) != null)
                setToCurrent();
            else manager = new SeriesManager();
            //config.OnLoad();
            manager.CurrentSeriesChanged += new SeriesManager.CurrentSeriesChangedHandler(manager_CurrentSeriesChanged);
        }

        private void seriesOverview1_DragEnter(object sender, DragEventArgs e)
        {
            if(e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else e.Effect = DragDropEffects.None;
        }

        private void seriesOverview1_DragDrop(object sender, DragEventArgs e)
        {
            string[] Folder = (string[])e.Data.GetData(DataFormats.FileDrop,false);

            manager.AddSeries(Folder[0]);
        }
    }
}