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
            
            seriesOverview1.PosterClick += new SeriesControl.PosterClickEventHandler(seriesOverview1_PosterClick);
        }

        void seriesOverview1_PosterClick(object sender, PosterClickEventArgs e)
        {
            manager.CurrentSeries = manager.Series.Find(e.PosterSeries);
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
            if (e.KeyCode == Keys.Left && manager.CurrentSeries != null)
                Previous();
            else if (e.KeyCode == Keys.Right && manager.CurrentSeries != null)
                Next();
            else if (e.KeyCode == Keys.S && manager.CurrentSeries != null)
            {
                manager.PlayCurrent();
                titleControl1.RefreshText();

            }
            else if (e.KeyCode == Keys.A)
            {
                AddSeries();
            }
            else if (e.KeyCode == Keys.Space && manager.CurrentSeries != null)
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
            AddSeries();
        }

        private void AddSeries()
        {

            if (fbdBrowse.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                manager.CurrentSeries = manager.AddSeries(fbdBrowse.SelectedPath);
            }
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
            manager.CurrentSeriesChanged += new SeriesManager.CurrentSeriesChangedHandler(manager_CurrentSeriesChanged);

            if (manager.Series.Count() != 0)
                titleControl1.SetText(manager.CurrentSeries.Value);
        }

        private void seriesOverview1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else e.Effect = DragDropEffects.None;
        }

        private void seriesOverview1_DragDrop(object sender, DragEventArgs e)
        {
            string[] Folder = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            manager.CurrentSeries = manager.AddSeries(Folder[0]);
            seriesOverview1.Select();
        }

    }
}