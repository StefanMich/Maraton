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
            tvEditor.NodeMouseClick += (sender, args) => tvEditor.SelectedNode = args.Node;
        }

        /// <summary>
        /// Instantiates a <see cref="EditSeries"/> with the content of the specified <see cref="Series"/>
        /// </summary>
        /// <param name="series">The <see cref="Series"/> to display</param>
        /// <param name="manager">The manager containing the <see cref="Series"/></param>
        public EditSeries(Series series, SeriesManager manager)
            : this()
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
                File.Replace(fbd.FileName, series.Name, fbd.FileName + ".bak");
                series.Picture = Bitmap.FromFile(series.Name);
                pbPoster.Image = series.Picture;
                //TODO crasher nogle gange (ved skift af billede flere gange?)
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            TreeNode n = tvEditor.SelectedNode;
            if (n != null)
            {
                Season s = series.Seasons.Where(x => x.Title == n.Text).FirstOrDefault();
                if (s != null)
                {
                    series.Seasons.Remove(s);
                    tvEditor.Nodes.Remove(n);
                }

                foreach (Season season in series.Seasons)
                {
                    Episode ep = season.Episodes.Where(x => x.Title == n.Text).FirstOrDefault();
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

        private void EditSeries_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void addFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tvEditor.SelectedNode != null)
            {
                Season s = series.Seasons.Where(x => x.Title == tvEditor.SelectedNode.Text).FirstOrDefault();
                if (s is Season)
                {
                    OpenFileDialog fd = new OpenFileDialog();
                    if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        s.Episodes.Add(fd.FileName.returnEpisode());
                    tvEditor.SelectedNode.Nodes.Add(fd.FileName);
                }
                else
                    MessageBox.Show("You can only add files to seasons");
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deleteSelectedNode();
        }

        private void deleteSelectedNode()
        {
            if (tvEditor.SelectedNode != null)
            {
                Season s = series.Seasons.Where(x => x.Title == tvEditor.SelectedNode.Text).FirstOrDefault();
                if (s is Season)
                {
                    series.Seasons.Remove(s);
                }
                else
                {
                    s = series.Seasons.Where(x => x.Title == tvEditor.SelectedNode.Parent.Text).FirstOrDefault();
                    Episode ep = s.Episodes.Where(x => x.Title == tvEditor.SelectedNode.Text).FirstOrDefault();
                    s.Episodes.Remove(ep);
                }
                tvEditor.SelectedNode.Remove();
            }
        }

        private void tvEditor_KeyUp(object sender, KeyEventArgs e)
        {
            if (tvEditor.SelectedNode != null)
            {
                if (e.KeyCode == Keys.Delete)
                    deleteSelectedNode();

                else if (e.KeyCode == Keys.Enter)
                {
                    Season s = series.Seasons.Where(x => x.Title == tvEditor.SelectedNode.Text).FirstOrDefault();
                    if (s != null)
                    {
                        manager.Play(s, s.Episodes.Remove());
                        tvEditor.SelectedNode.Nodes[0].Remove();
                    }
                    else
                    {
                        s = series.Seasons.Where(x => x.Title == tvEditor.SelectedNode.Parent.Text).FirstOrDefault();
                        Episode ep = s.Episodes.Where(x => x.Title == tvEditor.SelectedNode.Text).FirstOrDefault();
                        manager.Play(s, ep);
                        tvEditor.SelectedNode.Remove();
                    }
                }
            }
        }

        private void tvEditor_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void tvEditor_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void tvEditor_DragDrop(object sender, DragEventArgs e)
        {
            TreeNode newNode;

            if(e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false))
            {
                Point p = ((TreeView)sender).PointToClient(new Point(e.X,e.Y));
                TreeNode destinationNode = ((TreeView)sender).GetNodeAt(p);
                newNode = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");
                //if(destinationNode.TreeView != newNode.TreeView)
                
                
                int indexDestination = ((TreeView)sender).Nodes.IndexOf(destinationNode);
                int indexNewNode = ((TreeView)sender).Nodes.IndexOf(newNode);
                ((TreeView)sender).Nodes.Remove(newNode);
                ((TreeView)sender).Nodes.Remove(destinationNode);
                ((TreeView)sender).Nodes.Insert(indexDestination, newNode);
                ((TreeView)sender).Nodes.Insert(indexNewNode, destinationNode);
            }
        }
    }
}
