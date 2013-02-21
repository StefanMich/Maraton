using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace Marathon
{
    class SaveLoad
    {

        public static SeriesManager LoadManager(string filename)
        {
            using (Stream file = File.Open(filename, FileMode.Open))
            {
                BinaryFormatter bf = new BinaryFormatter();
                SeriesManager Manager = (SeriesManager) bf.Deserialize(file);

                return Manager;
            }
        }

        public static SeriesManager OnLoad()
        {

            List<string> files = new List<string>();
                
            files.AddRange(Directory.GetFiles(Application.StartupPath, "*.lawl"));

            if (files.Count() == 0)
            {
                return null;
            }
            else if (files.Count() == 1)
            {
                return SaveLoad.LoadManager( files[0]);
            }
            else if (files.Count() > 1)
            {
                if (files.Contains(Application.StartupPath + "\\Data.lawl"))
                {
                    return LoadManager("Data.lawl");
                }
                else
                    return LoadManager(files[0]);

            }

            return null;

        }

        public static void SaveManager(SeriesManager manager, string filename)
        {
            using (Stream file = File.Open(filename, FileMode.Create))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(file, manager);
            }
        }

        public void NewList(SeriesManager manager, ref string currentFile)
        {
            Filename file = new Filename();
            file.ShowDialog();
            currentFile = file.File;
            file.Dispose();
            SaveList(manager, currentFile);
        }

        public static void SaveList(SeriesManager manager, string filename)
        {
            if (filename.Length == 0)
            {
                throw new ArgumentException("Empty filename");
            }
            try
            {
                SaveLoad.SaveManager(manager, filename);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Not a valid file");
            }
            catch (IOException)
            { Console.WriteLine("File being used by another proces"); }

        }

        
    }
}
