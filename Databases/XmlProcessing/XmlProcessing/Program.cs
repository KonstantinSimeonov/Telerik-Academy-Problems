using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using System.Xml.Xsl;
using System.Xml.Schema;

namespace XmlProcessing
{
    class Program
    {
        static Program()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void Main()
        {
            var doc = new XmlDocument();
            doc.Load("../../catalog.xml");

            // Problem 2 - DOM
            var artistsDom = GetArtistsXPath(doc);
            Console.WriteLine("\nArtists DOM:");
            artistsDom.ForEach(x => Console.WriteLine(x));

            // Problem 3 - XPath
            var artistsXPath = GetArtistsXPath(doc);
            Console.WriteLine("\nArtists XPath");
            artistsXPath.ForEach(x => Console.WriteLine(x));

            // Problem 4 - Deletion
            FilterAlbumsOnPrice(doc, 20.0);

            // Problem 5 - Song Titles
            Console.WriteLine("\n\nTitles XmlReader:");
            GetAllSongTitlesReader(doc).ForEach(title => Console.WriteLine(title));

            // Problem 6 - Titles with XDoc
            Console.WriteLine("\n\nTitles XDocument:");
            GetAllSongTitlesXDoc(doc).ForEach(title => Console.WriteLine(title));

            // Problem 7 - Txt to xml
            var gosho = GetPersonFromTxt("../../Gosho.txt");
            PersonDictionatyToXElement(gosho).Save("../../Gosho.xml");

            // Problem 8 - Extract albums from xml to xml
            PluckAlbumsFromCatalog(doc);

            // Problem 9 - Tarverse directories and and write them to XML
            var path = Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.IndexOf("XmlProcessing"));

            using (var writer = new XmlTextWriter("../../directories.xml", Encoding.UTF8))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = ' ';
                writer.Indentation = 2;

                writer.WriteStartDocument();
                writer.WriteStartElement("Directories");
                WriteDirectoriesToXml(path, writer);
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }

            // Problem 10 - Directories with XDoc
            var xdoc = new XDocument(new XElement("Directories", GetDirectoriesAsXmlTree(path)));

            using (var writer = new XmlTextWriter("../../xdocDirectories.xml", Encoding.UTF8))
            {
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 2;
                writer.IndentChar = ' ';

                xdoc.Save(writer);
            }

            // Problem 11 - Prices with xpath
            Console.WriteLine("\n\nPrices for latest albums:");
            doc.Load("../../catalog.xml");
            GetPricesForLatestAlbums(doc).ForEach(x => x.PrintTrimmed());

            // Problem 11 - Prices with Linq
            Console.WriteLine("\n\nPrices for lates albums LINQ:");
            GetPricesForLatestAlbumsLINQ(doc).ForEach(x => x.PrintTrimmed());

            // Transformation
            Console.WriteLine("\n\n");
            Transform();

            // Validator
            Console.WriteLine("\n\nValidations:");
            ValidateXmlAgainstXsd("../../catalog.xml");
            ValidateXmlAgainstXsd("../../invalidCatalogue.xml");
        }

        /// <summary>
        /// Write program that extracts all different artists which are found in the catalog.xml
        /// Use the DOM parser and a hash-table.
        /// </summary>
        /// <param name="catalog"></param>
        /// <returns></returns>
        internal static IDictionary<string, int> GetArtistsDom(XmlDocument catalog)
        {
            var result = catalog
                            .GetElementsByTagName("Artist")
                            .Cast<XmlNode>()
                            .GroupBy(x => x.InnerText)
                            .ToDictionary(grouping => grouping.Key, grouping => grouping.Count());

            return result;
        }

        /// <summary>
        /// Write program that extracts all different artists which are found in the catalog.xml.
        /// Implement using XPath.
        /// </summary>
        /// <param name="catalog"></param>
        /// <returns></returns>
        internal static IDictionary<string, int> GetArtistsXPath(XmlDocument catalog)
        {
            var artistDict = catalog
                                .SelectNodes("Catalog/Albums/Album/Artist")
                                .Cast<XmlNode>()
                                .GroupBy(x => x.InnerText)
                                .ToDictionary(grouping => grouping.Key.Trim(), grouping => grouping.Count());

            return artistDict;
        }

        /// <summary>
        /// Using the DOM parser write a program to delete from catalog.xml all albums having price > 20.
        /// </summary>
        /// <param name="catalog"></param>
        /// <param name="maxCost"></param>
        internal static void FilterAlbumsOnPrice(XmlDocument catalog, double maxCost)
        {
            var albums = catalog.GetElementsByTagName("Album");

            Console.WriteLine("\nBefore deletion:");
            albums.Cast<XmlNode>()
                .ForEach(album => Console.WriteLine(album["Name"].InnerText.Trim()));

            for (int i = 0, length = albums.Count; i < length; i++)
            {
                var priceAsText = albums[i]["Price"].InnerText.Replace('.', ',');
                if (double.Parse(priceAsText) > maxCost)
                {
                    catalog.DocumentElement.FirstChild.RemoveChild(albums[i]);

                    i--;
                    length--;
                }
            }

            Console.WriteLine("\nAfter deletion:");
            catalog.GetElementsByTagName("Album").Cast<XmlNode>().ForEach(album => Console.WriteLine(album["Name"].InnerText.Trim() + " " + album["Price"].InnerText.Trim()));
        }

        /// <summary>
        /// Write a program, which using XmlReader extracts all song titles from catalog.xml.
        /// </summary>
        /// <param name="catalog"></param>
        /// <returns></returns>
        internal static IList<string> GetAllSongTitlesReader(XmlDocument catalog)
        {
            var songNames = new List<string>();

            using (var reader = new XmlTextReader("../../catalog.xml"))
            {
                while (reader.Read())
                {
                    bool isXmlElement = reader.NodeType == XmlNodeType.Element;
                    bool isSongName = reader.Name == "Title";

                    if (isXmlElement && isSongName)
                    {
                        var title = reader.ReadElementContentAsString();
                        songNames.Add(title.Trim());
                    }
                }
            }

            return songNames.Distinct().ToList();
        }

        /// <summary>
        /// Write a program, which using XmlReader extracts all song titles from catalog.xml.
        /// Rewrite the same task using LINQ & XDocument.
        /// </summary>
        /// <param name="catalog"></param>
        /// <returns></returns>
        internal static IList<string> GetAllSongTitlesXDoc(XmlDocument catalog)
        {
            var songNames = XDocument
                                .Load("../../catalog.xml")
                                .Descendants("Title")
                                .Select(x => x.Value.Trim())
                                .Distinct()
                                .ToList();

            return songNames;
        }

        /// <summary>
        /// In a text file we are given the name, address and phone number of given person (each at a single line).
        /// Write a program, which creates new XML document, which contains these data in structured XML format.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        internal static IDictionary<string, string> GetPersonFromTxt(string filePath)
        {
            var person = new Dictionary<string, string>();

            using (var reader = new StreamReader(filePath))
            {
                for (var line = reader.ReadLine(); line != null; line = reader.ReadLine())
                {
                    var splitRow = line.Split(new char[] { ' ', ':' }, StringSplitOptions.RemoveEmptyEntries);
                    person.Add(splitRow[0], splitRow[1]);
                }
            }

            return person;
        }

        /// <summary>
        /// Converts a person represented as a dictionary to a XElement.
        /// </summary>
        /// <param name="personDict"></param>
        /// <returns></returns>
        internal static XElement PersonDictionatyToXElement(IDictionary<string, string> personDict)
        {
            var personAsXml = new XElement("person",
                                                new XElement("name", personDict["name"]),
                                                new XElement("adress", personDict["adress"]),
                                                new XElement("tel", personDict["tel"]));

            return personAsXml;
        }

        internal static void PluckAlbumsFromCatalog(XmlDocument catalog)
        {
            using (var writer = new XmlTextWriter("../../albums.xml", Encoding.UTF8))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Albums");

                writer.Formatting = Formatting.Indented;
                writer.IndentChar = ' ';
                writer.Indentation = 2;

                using (var reader = XmlReader.Create("../../catalog.xml"))
                {
                    while (reader.Read())
                    {
                        bool isXmlElement = reader.NodeType == XmlNodeType.Element;
                        bool isAlbumName = reader.Name == "Name";
                        bool isArtistName = reader.Name == "Artist";

                        if (isXmlElement)
                        {
                            if (isAlbumName)
                            {
                                writer.WriteStartElement("Album");
                                writer.WriteElementString("Name", reader.ReadElementContentAsString());
                            }

                            if (isArtistName)
                            {
                                writer.WriteElementString("Artist", reader.ReadElementContentAsString());
                                writer.WriteEndElement();
                            }
                        }
                    }
                }

                writer.WriteEndDocument();
            }
        }

        /// <summary>
        /// Write a program to traverse given directory and write to a XML file its contents together with all subdirectories and files.
        /// Use tags <file> and <dir> with appropriate attributes.
        /// For the generation of the XML document use the class XmlWriter.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="writer"></param>
        internal static void WriteDirectoriesToXml(string path, XmlWriter writer)
        {
            var directories = Directory.GetDirectories(path);

            foreach (var dir in directories)
            {
                writer.WriteStartElement("Directory");
                writer.WriteElementString("path", dir);
                WriteDirectoriesToXml(dir, writer);
                writer.WriteEndElement();
            }

            var files = Directory.GetFiles(path);

            foreach (var fileName in files)
            {
                writer.WriteStartElement("file");
                writer.WriteElementString("name", fileName);
                writer.WriteEndElement();
            }
        }

        /// <summary>
        /// Directory traversal with XElement and XDocument.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        internal static XElement GetDirectoriesAsXmlTree(string path)
        {
            var directories = Directory.GetDirectories(path);
            var resultingElement = new XElement("Directory", new XAttribute("path", path));

            foreach (var dir in directories)
            {
                resultingElement.Add(GetDirectoriesAsXmlTree(dir));
            }

            var files = Directory.GetFiles(path);

            foreach (var fileName in files)
            {
                resultingElement.Add(new XElement("File", new XAttribute("name", fileName)));
            }

            return resultingElement;
        }

        /// <summary>
        /// Write a program, which extract from the file catalog.xml the prices for all albums, published 5 years ago or earlier.
        /// Use XPath query.
        /// </summary>
        /// <param name="catalog"></param>
        /// <returns></returns>
        internal static IList<string> GetPricesForLatestAlbums(XmlDocument catalog)
        {
            var year = (DateTime.Now.Year - 5);
            var prices = catalog
                                .SelectNodes("Catalog/Albums/Album/Price[../Year>{0}]".Formatted(year))
                                .Cast<XmlElement>()
                                .Select(x => x.InnerText)
                                .ToList();

            return prices;
        }

        /// <summary>
        /// Write a program, which extract from the file catalog.xml the prices for all albums, published 5 years ago or earlier.
        /// Rewrite the previous using LINQ query.
        /// </summary>
        /// <param name="catalog"></param>
        /// <returns></returns>
        internal static IList<string> GetPricesForLatestAlbumsLINQ(XmlDocument catalog)
        {
            var year = (DateTime.Now.Year - 5);

            var prices = catalog
                           .SelectNodes("//Album")
                           .Cast<XmlElement>()
                           .Where(element => int.Parse(element["Year"].InnerText) > year)
                           .Select(element => element["Price"].InnerText)
                           .ToList();
            return prices;
        }

        /// <summary>
        /// Create an XSL stylesheet, which transforms the file catalog.xml into HTML document, formatted for viewing in a standard Web-browser.
        /// Write a C# program to apply the XSLT stylesheet transformation on theC:\Users\Pc\Desktop\Telerik Academy Homework Solutions\Databases\XmlProcessing\XmlProcessing\Program.cs file catalog.xml using the class XslTransform.
        /// </summary>
        internal static void Transform()
        {
            var xslt = new XslCompiledTransform();
            xslt.Load("../../CatalogueStyles.xslt");
            xslt.Transform("../../catalog.xml", "../../catalog.html");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Transformation complete(catalog.xml -> catalog.html)");
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Using Visual Studio generate an XSD schema for the file catalog.xml.
        /// </summary>
        /// <param name="xmlPath"></param>
        internal static void ValidateXmlAgainstXsd(string xmlPath)
        {
            var schemas = new XmlSchemaSet();

            schemas.Add("", "../../catalog.xsd");

            var xdoc = XDocument.Load(xmlPath);
            var errors = false;

            Console.ForegroundColor = ConsoleColor.DarkRed;

            xdoc.Validate(schemas, (s, a) => { a.Message.PrintTrimmed(); errors = true; });

            if(!errors)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                "Documenta with path {0} is valid".Formatted(xmlPath).PrintTrimmed();
            }

            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
