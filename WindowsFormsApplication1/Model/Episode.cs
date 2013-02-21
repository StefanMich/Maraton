using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stufkan.IO;
using System.Runtime.Serialization;

namespace Marathon
{
    /// <summary>
    /// Represents an <see cref="Episode"/> in a <see cref="Season"/>
    /// </summary>
    [Serializable()]
    public class Episode : ISerializable
    {
        private string path;

        /// <summary>
        /// Gets the full path to the episode
        /// </summary>
        public string Path
        {
            get { return path; }
        }

        private string title;

        /// <summary>
        /// Gets the title of the episode
        /// </summary>
        public string Title
        {
            get { return title; }
        }

        /// <summary>
        /// Instantiates an <see cref="Episode"/> with a <paramref name="path"/> and a <paramref name="title"/>
        /// </summary>
        /// <param name="path"></param>
        /// <param name="title"></param>
        public Episode(string path, string title)
        {
            this.path = path;
            this.title = title;
        }

        /// <summary>
        /// Instantiates an <see cref="Episode"/> with the content in the <see cref="SerializationInfo"/>
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public Episode(SerializationInfo info, StreamingContext context)
        {
            this.path = (string)info.GetValue("Path", typeof(string));
            this.title = (string)info.GetValue("Title", typeof(string));

        }

        /// <summary>
        /// Returns the <see cref="Title"/> of the <see cref="Episode"/>
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return title;
        }

        /// <summary>
        /// Saves the content of the <see cref="Episode"/> in the specified <see cref="SerializationInfo"/>
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Path", this.path);
            info.AddValue("Title", this.title);
        }

    }

    /// <summary>
    /// Contains a method to get an <see cref="Episode"/> from a string containing the path to an episode
    /// </summary>
    public static class EpisodeFromString
    {
        /// <summary>
        /// Returns an <see cref="Episode"/> from a string containing the path to an episode
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static Episode returnEpisode(this string s)
        {
            return new Episode(s, s.getFilename());
        }
    }
}