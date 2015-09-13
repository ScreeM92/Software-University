namespace MusicAlbumsCatalog
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.XPath;

    public class MusicCatalogParser
    {
        private const string CatalogPath = @"..\..\catalog.xml";

        public static void ExtractAlbumNames()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(CatalogPath);

            var albumNames = doc.SelectNodes("albums/album/name");

            if (albumNames != null)
            {
                foreach (XmlElement albumName in albumNames)
                {
                    Console.WriteLine("  - {0}", albumName.InnerText);
                }
            }
        }

        public static void ExtractArtistsAlphabetically()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(CatalogPath);
            var artists = doc.SelectNodes("albums/album/artist");
            var sortedArtists = new SortedSet<string>();

            if (artists == null)
            {
                return;
            }

            foreach (XmlElement artist in artists)
            {
                sortedArtists.Add(artist.InnerText);
            }

            foreach (var artist in sortedArtists)
            {
                Console.WriteLine("  - {0}", artist);
            }
        }

        public static void ExtractArtistsWithAlbumsCount()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(CatalogPath);

            var albums = doc.DocumentElement;

            if (albums != null)
            {
                var artists = albums.Cast<XmlElement>().ToList()
                    .GroupBy(a => a["artist"].InnerText)
                    .ToDictionary(t => t.Key, t => t.Count());

                foreach (var artist in artists)
                {
                    Console.WriteLine("  - {0} : {1} albums", artist.Key, artist.Value);
                }
            }
        }

        public static void ExtractArtistsWithAlbumsCountXPath()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(CatalogPath);

            var albums = doc.SelectNodes("albums/album");

            if (albums != null)
            {
                var artists = albums.Cast<XmlElement>().ToList()
                    .GroupBy(a => a["artist"].InnerText)
                    .ToDictionary(t => t.Key, t => t.Count());

                foreach (var artist in artists)
                {
                    Console.WriteLine("  - {0} : {1} albums", artist.Key, artist.Value);
                }
            }
        }

        public static void DeleteAlbumWithPriceGreateThan(decimal price)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(CatalogPath);

            var albums = doc.SelectNodes("albums/album");
            if (albums != null)
            {
                albums.Cast<XmlNode>()
                .Where(a => decimal.Parse(a["price"].InnerText) > price).ToList()
                .ForEach(a => a.ParentNode.RemoveChild(a));

                doc.Save(@"..\..\cheap-albums-catalog.xml");
            }
        }

        public static void ExtractAlbumlsOlderThan(int years)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(CatalogPath);

            var oldAlbums = doc.SelectNodes("albums/album[year <= " + (DateTime.Now.Year - years) + "]");

            if (oldAlbums != null)
            {
                foreach (XmlElement oldAlbum in oldAlbums)
                {
                    Console.WriteLine("Title: {0}, Price: {1}", oldAlbum["name"].InnerText, oldAlbum["price"].InnerText);
                }
            }
        }

        public static void LinqExtractAlbumsOlderThan(int years)
        {
            var doc = XDocument.Load(CatalogPath);
            doc.Descendants("album")
                .Where(a => int.Parse(a.Element("year").Value) <= (DateTime.Now.Year - years))
                .ToList()
                .ForEach(s => { Console.WriteLine("Title: {0}: Price: {1}", s.Element("name").Value, s.Element("price").Value); });
        }

        public static void GetDirectoryContent()
        {
            var path = @"C:\test\";

            var document = new XDocument(
                new XDeclaration("1.0", "UTF-8", null),
                new XElement("root-dir",
                    new XAttribute("path", path)));

            var files = Directory.EnumerateFiles(path, "*.*", SearchOption.AllDirectories);

            foreach (var file in files)
            {
                var fileDirectories = file.Replace(path, "")
                    .Split(new [] { '\\' }, StringSplitOptions.RemoveEmptyEntries);
                var len = fileDirectories.Length;
                var root = document.Element("root-dir");
                XElement dir = root;

                for (int i = 0; i < len - 1; i++)
                {
                    dir = document.XPathSelectElement(String.Format("//dir[@name = '{0}']", fileDirectories[i]));
                    if (dir == null)
                    {
                        if (i < 1)
                        {
                            dir = root;
                        }
                        else
                        {
                            dir = document.XPathSelectElement(String.Format("//dir[@name = '{0}']", fileDirectories[i - 1]));
                        }

                        var newDir = new XElement("dir",
                            new XAttribute("name", fileDirectories[i]));
                        dir.Add(newDir);
                        dir = newDir;
                    }
                }

                dir.Add(new XElement("file",
                    new XAttribute("name", fileDirectories[len - 1])));
            }

            Console.WriteLine(document.Declaration);
            Console.WriteLine(document);

            document.Save(@"..\..\directory-traversal.xml");
        }
    }
}