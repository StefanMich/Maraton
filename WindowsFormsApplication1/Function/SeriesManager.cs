using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Stufkan.IO;
using DeadDog.Movies.IMDB;
using System.Drawing;
using System.Net;
using System.Windows.Forms;
using System.Runtime.Serialization;


namespace Marathon
{
    /*
    /// <summary>
    /// Enum describing the two addmodes for the addmethods
    /// </summary>
    public enum AddMode
    {
        /// <summary>
        /// Adds directly to the root
        /// </summary>
        AddSeries,
        /// <summary>
        /// Appends to the selected node
        /// </summary>
        AddSeason,
        AddEpisode
    }
    */
    /// <summary>
    /// Class managing the collection of <see cref="Series"/>
    /// </summary>
    [Serializable()]
    public class SeriesManager : ISerializable
    {
        static List<string> exclude = new List<string>() { "srt", "db", "nfo" };

        private LinkedListNode<Series> currentSeries;
        private SeriesCollection series;
        private Series recentlyWatched;

        /// <summary>
        /// Sets or gets the most recently watched series
        /// </summary>
        public Series RecentlyWatched
        {
            get { return recentlyWatched; }
            set { recentlyWatched = value; }
        }
        
        /// <summary>
        /// Gets the <see cref="SeriesCollection"/> of the <see cref="SeriesManager"/>
        /// </summary>
        public SeriesCollection Series
        {
            get { return series; }
        }

        /// <summary>
        /// Instantiates a new <see cref="SeriesManager"/> with an empty <see cref="SeriesCollection"/>
        /// </summary>
        public SeriesManager()
        {
            series = new SeriesCollection();
        }

        /// <summary>
        /// Instantiates a <see cref="SeriesManager"/> with the content from the specified <see cref="SerializationInfo"/>
        /// </summary>
        /// <param name="info"></param>
        /// <param name="ctxt"></param>
        public SeriesManager(SerializationInfo info, StreamingContext ctxt)
        {
            this.series = (SeriesCollection)info.GetValue("Series", typeof(SeriesCollection));
            this.currentSeries = series.Find((Series)info.GetValue("CurrentSeries", typeof(Series)));
            this.recentlyWatched = (Series)info.GetValue("RecentlyWatched", typeof(Series));
        }

        /// <summary>
        /// Gets the current node of the <see cref="SeriesManager"/>
        /// </summary>
        public LinkedListNode<Series> CurrentSeries
        {
            get
            {
                if (currentSeries == null && series.Count() != 0)
                {
                    currentSeries = series.Find(series.First());
                    return currentSeries;
                }
                else return currentSeries;
            }
            set { currentSeries = value; OnCurrentSeriesChanged(EventArgs.Empty); }
        }

        /// <summary>
        /// Delegate method for the CurrentSeriesChanged event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void CurrentSeriesChangedHandler(object sender, EventArgs e);

        /// <summary>
        /// When the current series is changed.
        /// </summary>
        public event CurrentSeriesChangedHandler CurrentSeriesChanged;
        /// <summary>
        /// Firing the CurrentSeriesChanged event properly
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnCurrentSeriesChanged(EventArgs e)
        {
            if (CurrentSeriesChanged != null)
                CurrentSeriesChanged(this, e);
        }

        /// <summary>
        /// Gets the next <see cref="Series"/> of the <see cref="SeriesCollection"/> and assigns this <see cref="Series"/> as the currentSeries
        /// </summary>
        public LinkedListNode<Series> NextSeries
        {
            get
            {
                LinkedListNode<Series> temp = CurrentSeries.NextOrFirst();
                currentSeries = CurrentSeries.NextOrFirst();
                return temp;
            }
        }

        /// <summary>
        /// Gets the previous <see cref="Series"/> of the <see cref="SeriesCollection"/> and assigns this <see cref="Series"/> as the currentSeries
        /// </summary>
        public LinkedListNode<Series> PreviousSeries
        {
            get
            {
                LinkedListNode<Series> temp = CurrentSeries.PreviousOrLast();
                currentSeries = CurrentSeries.PreviousOrLast();
                return temp;
            }
        }

        /// <summary>
        /// Adds a file to the specified <see cref="Season"/>
        /// </summary>
        /// <param name="season">The <see cref="Season"/> to add the file to </param>
        /// <param name="filename">The path to the file to add</param>
        /// <returns></returns>
        public void AddEpisodetoSeason(Season season, string filename)
        {
            season.Episodes.Add(filename.returnEpisode());
        }
        /// <summary>
        /// Appends a list of files to the specified <see cref="Season"/>
        /// </summary>
        /// <param name="season">The season to add the <see cref="Episode"/>s to</param>
        /// <param name="Files">The list of files to add</param>
        private static void addEpisodesToSeason(Season season, List<string> Files)
        {

            for (int i = 0; i < Files.Count; i++)
            {
                season.Episodes.Add(Files[i].returnEpisode());
            }
        }

        /// <summary>
        /// Adds the content of the path to the <see cref="Series"/> as a <see cref="Season"/>
        /// </summary>
        /// <param name="series">The series to add to</param>
        /// <param name="path">The path to the content to add</param>
        public void AddSeasonToSeries(Series series, string path)
        {
            List<string> SubFolders = new List<string>();
            string foldername = path.getFilename();

            Season thisSeason = new Season(foldername, series, path);

            List<string> seasonEpisodes = new List<string>();

            GetFiles(seasonEpisodes, path);
            removeOtherFileTypes(seasonEpisodes, exclude);

            addEpisodesToSeason(thisSeason, seasonEpisodes);
            series.Seasons.Add(thisSeason);
        }

        /// <summary>
        /// Adds the path to the SeriesManager as a <see cref="Series"/>
        /// </summary>
        /// <param name="path"></param>
        public LinkedListNode<Series> AddSeries(string path)
        {
            List<string> Seasons = new List<string>();
            string Name = path.getFilename();
            if (!File.Exists(Name))
                if ((Name = getPicture(Name)) == string.Empty)
                    return null; //this is possibly a bad solution. This happens when the users aborts the search for a poster from the series

            Series thisSeries = new Series(Name, Bitmap.FromFile(Name));

            //find subfolders in path
            Seasons.AddRange(Directory.GetDirectories(path, "*", SearchOption.TopDirectoryOnly));
            //Stufkan.IO.Filename.stripPath(Seasons);

            foreach (string seasonDir in Seasons)
            {
                Season thisSeason = new Season(seasonDir, thisSeries, seasonDir);
                List<string> seasonEpisodes = new List<string>();

                GetFiles(seasonEpisodes, seasonDir);
                removeOtherFileTypes(seasonEpisodes, exclude);

                addEpisodesToSeason(thisSeason, seasonEpisodes);
                thisSeries.Seasons.Add(thisSeason);

            }

            series.Add(thisSeries);
            if (currentSeries == null)
                currentSeries = series.Find(thisSeries);

            SaveLoad.SaveManager(this, "data.lawl");

            return series.Find(thisSeries);

        }

        /// <summary>
        /// Removes the specified <see cref="Series"/> from the list of <see cref="Series"/>
        /// </summary>
        /// <param name="s">The <see cref="Series"/> to remove</param>
        public void RemoveSeries(Series s)
        {
            currentSeries = NextSeries;
            series.Remove(s);
            
        }

        /// <summary>
        /// Removes files containing the strings in ExcludeTypes
        /// </summary>
        /// <param name="Files"></param>
        /// <param name="ExcludeTypes"></param>
        private void removeOtherFileTypes(List<string> Files, List<string> ExcludeTypes)
        {
            List<string> removeList = new List<string>();

            foreach (string s in Files)
            {
                foreach (string ex in ExcludeTypes)
                    if (s.Contains(ex))
                    {
                        removeList.Add(s);
                    }
            }

            foreach (string s in removeList)
            {
                Files.Remove(s);
            }

        }

        /// <summary>
        /// Finds all files in dir and 
        /// </summary>
        /// <param name="files"></param>
        /// <param name="path"></param>
        /// 
        private void GetFiles(List<string> files, string path)
        {
            files.AddRange(Directory.GetFiles(path, "*", SearchOption.TopDirectoryOnly));
            Stufkan.IO.Filename.stripPath(files);

        }

        private string getPicture(string title)
        {
            if (title == string.Empty)
                return string.Empty;

            Cursor.Current = Cursors.WaitCursor;

            MainPage page;
            IMDBBuffer buffer = new IMDBBuffer();
            var searchResults = buffer.SearchTitle(title).Results;
            if (searchResults != null && searchResults.Count() != 0)
            {
                var parsed = searchResults.Where(x=>x.Type == MediaType.TVSeries);
                if (parsed.Count() > 1 )
                {
                    NameChooser result = new NameChooser(parsed);

                    if (result.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        page = buffer.ReadMain(result.Id);
                    }
                    else page = null;
                }
                
                else
                {
                    page = buffer.ReadMain(parsed.First().Id);
                }


                if (page != null && page.PosterURL.Succes != false)
                {
                    WebClient web = new WebClient();
                    web.DownloadFile(page.PosterURL.Data.Address, title);
                }
                else Properties.Resources.no_photo.Save(title);
                Cursor.Current = Cursors.Default;
            }

            else
            {
                EditSearch edit = new EditSearch(title);
                if (edit.ShowDialog() == DialogResult.OK)
                    return getPicture(edit.EditedTitle);
                else return string.Empty;

            }
            return title;

        }

        /// <summary>
        /// Adds data of the <see cref="SeriesManager"/> to the specified <see cref="SerializationInfo"/>
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("CurrentSeries", this.currentSeries.Value);
            info.AddValue("Series", this.series);
            info.AddValue("RecentlyWatched", this.recentlyWatched);
        }
        /// <summary>
        /// Contains a collection of <see cref="Series"/>
        /// </summary>
        [Serializable()]
        public class SeriesCollection : ISerializable
        {
            private LinkedList<Series> Series;

            /// <summary>
            /// Instantiates a new <see cref="SeriesCollection"/>
            /// </summary>
            public SeriesCollection()
            {
                Series = new LinkedList<Series>();
            }

            /// <summary>
            /// Instantiates a <see cref="SeriesCollection"/> from the content in the specified <see cref="SerializationInfo"/>
            /// </summary>
            /// <param name="info"></param>
            /// <param name="ctxt"></param>
            public SeriesCollection(SerializationInfo info, StreamingContext ctxt)
            {
                this.Series = (LinkedList<Series>)info.GetValue("Series", typeof(LinkedList<Series>));
            }

            /// <summary>
            /// Adds the specified <see cref="Series"/> to the LinkedList
            /// </summary>
            /// <param name="series">The <see cref="Series"/> to add</param>
            public void Add(Series series)
            {
                Series.AddLast(series);
            }

            /// <summary>
            /// Removes the specified <see cref="Series"/> from the LinkedList
            /// </summary>
            /// <param name="series">The <see cref="Series"/> to remove</param>
            /// <returns>If the specified <see cref="Series"/> was removed</returns>
            public bool Remove(Series series)
            {
                return Series.Remove(series);
            }

            /// <summary>
            /// Returns the number of elements in the <see cref="SeriesCollection"/>
            /// </summary>
            /// <returns></returns>
            public int Count()
            {
                return Series.Count();
            }

            /// <summary>
            /// Returns the first <see cref="Series"/> in the LinkedList
            /// </summary>
            /// <returns>The first <see cref="Series"/> in the LinkedList</returns>
            public Series First()
            {
                return Series.First();
            }

            /// <summary>
            /// Returns the last <see cref="Series"/> in the LinkedList
            /// </summary>
            /// <returns>The last <see cref="Series"/> in the LinkedList</returns>
            public Series Last()
            {
                return Series.Last();
            }
            
            /// <summary>
            /// Finds the first node that contains the specified <see cref="Series"/>
            /// </summary>
            /// <param name="series">The <see cref="Series"/> to find</param>
            /// <returns>The first node that contains the specified <see cref="Series"/></returns>
            public LinkedListNode<Series> Find(Series series)
            {
                return Series.Find(series);
            }

            /// <summary>
            /// Gets the object data to be saved when closing the application
            /// </summary>
            /// <param name="info"></param>
            /// <param name="context"></param>
            public void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                info.AddValue("Series", this.Series);
            }
        }


    }
}
