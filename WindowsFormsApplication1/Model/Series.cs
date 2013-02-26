using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Runtime.Serialization;
using System.Collections;
using System.IO;

namespace Marathon
{
    /// <summary>
    /// Represents a series with a name, a picture and a collection of seasons
    /// </summary>
    [Serializable()]
    public class Series : ISerializable
    {
        private SeasonsCollection seasons;
        private string name;
        private Image picture;

        /// <summary>
        /// The the <see cref="SeasonsCollection"/> of the <see cref="Series"/>
        /// </summary>
        public SeasonsCollection Seasons
        {
            get { return seasons; }
        }

        /// <summary>
        /// Gets or sets the name of the <see cref="Series"/>
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// Gets or sets the picture of the <see cref="Series"/>
        /// </summary>
        public Image Picture
        {
            get { return picture; }
            set { picture = value; }
        }

        /// <summary>
        /// Instantiates a new <see cref="Series"/> with the specified <paramref name="name"/> and <paramref name="picture"/>
        /// </summary>
        /// <param name="name"></param>
        /// <param name="picture"></param>
        public Series(string name, Image picture)
        {
            seasons = new SeasonsCollection();
            this.name = name;
            this.picture = picture;
        }

        /// <summary>
        /// Instantiates a <see cref="Series"/> from the content in the specified <see cref="SerializationInfo"/>
        /// </summary>
        /// <param name="info"></param>
        /// <param name="ctxt"></param>
        public Series(SerializationInfo info, StreamingContext ctxt)
        {
            //this.picture = (Image)info.GetValue("Picture", typeof(Image));

            this.name = (string)info.GetValue("Name", typeof(string));
            if (File.Exists(name))
                this.picture = Bitmap.FromFile(name);
            else
            {
                Properties.Resources.no_photo.Save(name);
                this.picture = Properties.Resources.no_photo;
            }
            
            this.seasons = (SeasonsCollection)info.GetValue("Seasons", typeof(SeasonsCollection));
        }

        /// <summary>
        /// Returns the number of <see cref="Season"/>s in the <see cref="Series"/>
        /// </summary>
        /// <returns></returns>
        public int NumberOfSeasons()
        {
            return seasons.Count();
        }

        /// <summary>
        /// Returns the total number of <see cref="Stufkan.IO.Episode"/>s in the <see cref="Series"/>
        /// </summary>
        /// <returns>The total number of <see cref="Stufkan.IO.Episode"/> in the <see cref="Series"/></returns>
        public int NumberOfEpisodes()
        {
            int count = 0;
            foreach (var s in seasons)
            {
                count += s.Episodes.Count();
            }
            return count;
        }

        /// <summary>
        /// Adds the data of the <see cref="Series"/> to the specified <see cref="SerializationInfo"/> object
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Seasons", this.seasons);
            info.AddValue("Name", this.name);
            //info.AddValue("Picture", this.picture);
        }

        /// <summary>
        /// Contains a number of <see cref="Season"/>s
        /// </summary>
        [Serializable()]
        public class SeasonsCollection : ISerializable, IEnumerable<Season>
        {
            private List<Season> seasons;

            /// <summary>
            /// Instantiates a new <see cref="SeasonsCollection"/> with an empty queue of seasons
            /// </summary>
            public SeasonsCollection()
            {
                seasons = new List<Season>();
            }

            /// <summary>
            /// Instantiates a <see cref="SeasonsCollection"/> from the content in the specified <see cref="SerializationInfo"/>
            /// </summary>
            /// <param name="info"></param>
            /// <param name="ctxt"></param>
            public SeasonsCollection(SerializationInfo info, StreamingContext ctxt)
            {
                this.seasons = (List<Season>)info.GetValue("Seasons", typeof(List<Season>));
            }

            /// <summary>
            /// Enqueues a <see cref="Season"/> in the <see cref="SeasonsCollection"/>
            /// </summary>
            /// <param name="season">The <see cref="Season"/> to enqueue</param>
            public void Add(Season season)
            {
                seasons.Add(season);
            }

            /// <summary>
            /// Removes the specified <see cref="Season"/> from the queue
            /// </summary>
            /// <param name="s">The <see cref="Season"/> to remove</param>
            public void Remove(Season s)
            {
                seasons.Remove(s);
            }

            /// <summary>
            /// "Dequeues" the <see cref="Season"/> in the beginning of the list
            /// </summary>
            /// <returns>The dequeued <see cref="Season"/></returns>
            public void Dequeue()
            {
                seasons.RemoveAt(0);
            }

            /// <summary>
            /// Returns the <see cref="Season"/> at the top of the queue
            /// </summary>
            /// <returns>The <see cref="Season"/> at the top of the queue</returns>
            public Season Peek()
            {
                return seasons[0];
            }

            /// <summary>
            /// Returns the number of <see cref="Season"/>s in the queue
            /// </summary>
            /// <returns></returns>
            public int Count()
            {
                return seasons.Count();
                
            }

            /// <summary>
            /// Adds the data of the <see cref="SeasonsCollection"/> to the <see cref="SerializationInfo"/> object
            /// </summary>
            /// <param name="info"></param>
            /// <param name="context"></param>
            public void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                info.AddValue("Seasons", this.seasons);
            }

            /// <summary>
            /// Returns the enumerator of the list
            /// </summary>
            /// <returns></returns>
            public IEnumerator<Season> GetEnumerator()
            {
                return seasons.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }


    }
}
