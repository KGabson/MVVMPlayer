using SimpleMVVMExample.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleMVVMExample
{
    public class XML
    {
        System.Xml.Linq.XElement xelement;

        public void Load(String filename)
        {
            try
            {
                xelement = System.Xml.Linq.XElement.Load(filename);
            }
            catch (Exception)
            {
                xelement = new System.Xml.Linq.XElement("Medias");
            }
        }

        public bool HasMedia(String path)
        {
            try
            {
                var medias = from media in xelement.Elements() where (string)media.Element("Path").Value == path select media;

                foreach (var media in medias)
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
        }

        public System.Collections.ObjectModel.ObservableCollection<Media> GetMedias()
        {
            IEnumerable<System.Xml.Linq.XElement> medias = xelement.Elements();
            System.Collections.ObjectModel.ObservableCollection<Media> mediasList = new System.Collections.ObjectModel.ObservableCollection<Media>();
            //List<Media> mediasList = new List<Media>();
 
            try
            {
                foreach (var media in medias)
                {
                    mediasList.Add(new Media(media.Element("Path").Value, media.Element("Path").Value));
                    Console.WriteLine(media.Element("Path"));
                }
            }
            catch { }

            return mediasList;
        }

        public void Add(String filename, Boolean stream)
        {
            try
            {
                if (HasMedia(filename) == false)
                    xelement.Add(new System.Xml.Linq.XElement("Media", new System.Xml.Linq.XElement("Path", filename), new System.Xml.Linq.XElement("Stream", stream)));
            }
            catch { }
        }

        public void Remove(String filename)
        {
            try
            {
                var medias = from media in xelement.Elements() where (string)media.Element("Path").Value == filename select media;

                foreach (var media in medias)
                    media.Remove();
            }
            catch { }
        }

        public void WriteInFile(String filename)
        {
            try
            {
                System.Xml.Linq.XDocument xDoc = new System.Xml.Linq.XDocument(new System.Xml.Linq.XDeclaration("1.0", "UTF-16", null), xelement);

                System.IO.StringWriter sw = new System.IO.StringWriter();
                System.Xml.XmlWriter xWrite = System.Xml.XmlWriter.Create(sw);
                xDoc.Save(xWrite);
                xWrite.Close();
                xDoc.Save(filename);
            }
            catch { }
        }
    }
}
