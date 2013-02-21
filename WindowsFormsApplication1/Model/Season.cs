using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Stufkan.IO;
using System.Runtime.Serialization;

namespace Marathon
{
    /// <summary>
    /// Represents a <see cref="Season"/> in a <see cref="Series"/>
    /// </summary>
    [Serializable()]
    public class Season : ISerializable
    {
        private string title;
        private EpisodeCollection episodes;
        private Series parent;
        private string path;

        /// <summary>
        /// Gets the path to the <see cref="Season"/>
        /// </summary>
        public string Path
        {
            get { return path; }
        }

        /// <summary>
        /// Gets the Parent of the <see cref="Season"/>
        /// </summary>
        public Series Parent
        {
            get { return parent; }
        }

        /// <summary>
        /// Gets or sets the title of the <see cref="Season"/>
        /// </summary>
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        /// <summary>
        /// Gets the <see cref="EpisodeCollection"/> of the <see cref="Season"/>
        /// </summary>
        public EpisodeCollection Episodes
        {
            get { return episodes; }
        }

        /// <summary>
        /// Instantiates a <see cref="Season"/> with the specified <paramref name="title"/>, <paramref name="parent"/> and <paramref name="path"/>
        /// </summary>
        /// <param name="title"></param>
        /// <param name="parent"></param>
        /// <param name="path"></param>
        public Season(string title, Series parent, string path)
        {
            episodes = new EpisodeCollection();
            this.parent = parent;
            this.title = title;
            this.path = path;
        }

        /// <summary>
        /// Instantiates a new <see cref="Season"/> with the content of the specified <see cref="SerializationInfo"/>
        /// </summary>
        /// <param name="info"></param>
        /// <param name="ctxt"></param>
        public Season(SerializationInfo info, StreamingContext ctxt)
        {
            this.episodes = (EpisodeCollection)info.GetValue("Episodes", typeof(EpisodeCollection));
            this.parent = (Series)info.GetValue("Parent", typeof(Series));
            this.path = (string)info.GetValue("Path", typeof(string));
            this.title = (string)info.GetValue("Title", typeof(string));
        }

        /// <summary>
        /// Populates the <see cref="Season"/> with the files in the specified <paramref name="path"/>
        /// </summary>
        /// <param name="path"></param>
        public void PopulateSeason(string path)
        {
            this.path = path;
            string[] files = Directory.GetFiles(path);

            foreach (var file in files)
            {
                episodes.Enqueue(file.returnEpisode());
            }
        }

        /// <summary>
        /// Adds the data of the <see cref="Season"/> to the specified <see cref="SerializationInfo"/> object
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Parent", this.parent);
            info.AddValue("Title", this.title);
            info.AddValue("Path", this.path);
            info.AddValue("Episodes", this.episodes);
        }

        /// <summary>
        /// Contains a collection of <see cref="Stufkan.IO.Episode"/>s
        /// </summary>
        [Serializable()]
        public class EpisodeCollection : ISerializable, IEnumerable<Episode>
        {
            private List<Episode> episodes;

            /// <summary>
            /// Instantiates a new <see cref="EpisodeCollection"/> with an enpty queue
            /// </summary>
            public EpisodeCollection()
            {
                episodes = new List<Episode>();
            }

            /// <summary>
            /// Instantiates a new <see cref="EpisodeCollection"/> with the data from the specified <see cref="SerializationInfo"/>
            /// </summary>
            /// <param name="info"></param>
            /// <param name="context"></param>
            public EpisodeCollection(SerializationInfo info, StreamingContext context)
            {
                episodes = (List<Episode>)info.GetValue("Episodes", typeof(List<Episode>));
            }

            /// <summary>
            /// Enqueues the specified <paramref name="episode"/> in the queue
            /// </summary>
            /// <param name="episode">The <see cref="Stufkan.IO.Episode"/> to enqueue</param>
            public void Enqueue(Episode episode)
            {
                episodes.Add(episode);
            }

            /// <summary>
            /// Dequeues the <see cref="Episode"/> in the beginning of the queue
            /// </summary>
            /// <returns>The dequeued <see cref="Episode"/></returns>
            public Episode Dequeue()
            {
                Episode e = episodes[0];
                episodes.RemoveAt(0);
                return e;
            }

            /// <summary>
            /// Removes the specified <see cref="Episode"/> from the queue
            /// </summary>
            /// <param name="e">The <see cref="Episode"/> to remove</param>
            public void Remove(Episode e)
            {
                episodes.Remove(e);
            }

            /// <summary>
            /// Returns the number of <see cref="Stufkan.IO.Episode"/>s in the queue
            /// </summary>
            /// <returns>The number of <see cref="Stufkan.IO.Episode"/>s in the queue</returns>
            public int Count()
            {
                return episodes.Count();
            }

            /// <summary>
            /// Adds the data of the <see cref="Season"/> to the specified <see cref="SerializationInfo"/>
            /// </summary>
            /// <param name="info"></param>
            /// <param name="context"></param>
            public void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                info.AddValue("Episodes", this.episodes);
            }

            /// <summary>
            /// Returns the enumrator of the list
            /// </summary>
            /// <returns>The enumerator of the list</returns>
            public IEnumerator<Episode> GetEnumerator()
            {
                return episodes.GetEnumerator();
            }

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return episodes.GetEnumerator();
            }
        }


    }
}
