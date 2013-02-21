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

        /// <summary>
        /// Rotates the visual representation of the series queue, one to the right
        /// </summary>
        public void Next()
        {
            seriesOverview1.SetSeriesDisplayed(manager.NextSeries);
            setText();
        }

        /// <summary>
        /// Rotates the visual representation of the series queue, one to the left
        /// </summary>
        public void Previous()
        {
            seriesOverview1.SetSeriesDisplayed(manager.PreviousSeries);
            setText();
        }

        private void seriesOverview1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
                Previous();
            else if (e.KeyCode == Keys.Right)
                Next();
            else if (e.KeyCode == Keys.Enter)
                Play(manager.CurrentSeries.Value);
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

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            pictureBox1.Focus();
            
            if (fbdBrowse.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                manager.AddSeries(fbdBrowse.SelectedPath);
                Previous();
                setToCurrent();
            }
            seriesOverview1.Select();
        }

        private void setToCurrent()
        {
            seriesOverview1.SetSeriesDisplayed(manager.CurrentSeries);
            setText();
        }

        private void Play(Series series)
        {
            Process P = new Process();
            Episode episode = series.Seasons.Peek().Episodes.Dequeue();


            P.StartInfo.FileName = series.Seasons.Peek().Path + "\\" + episode.Path;
            P.Start();
            

            if (series.Seasons.Peek().Episodes.Count() == 0)
                series.Seasons.Dequeue();

            if (series.Seasons.Count() == 0)
            {
                Next();
                manager.Series.Remove(series);

            }

            setToCurrent();
            SaveLoad.SaveManager(manager, "data.lawl");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveLoad.SaveManager(manager, "data.lawl");
        }

        private void GUI_Load(object sender, EventArgs e)
        {
            if ((manager = SaveLoad.OnLoad()) != null)
                setToCurrent();
            else manager = new SeriesManager();
            //config.OnLoad();
        }


       


        
    }
}