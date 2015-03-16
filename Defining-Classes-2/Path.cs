namespace Path3D // since there is more than one path-related class, I put them in a namespace
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.IO;

    class Path
    {
        // FIELDS

        private IList<Point3D> sequence;

        // PROPERITES

        public IList<Point3D> PointPath
        {
            get
            {
                return sequence;
            }

            private set
            {
                sequence = value;
            }
        }

        // CONSTRUCTORS

        public Path(params Point3D[] points)
        {
            sequence = new List<Point3D>(points);
        }

        // METHODS

        /// <summary>
        /// Adds a point to the invoking path.
        /// </summary>
        /// <param name="p"></param>
        public void AddPoint(Point3D p)
        {
            sequence.Add(p);
        }

        public override string ToString()
        {
            var path = new StringBuilder();

            foreach (var point in PointPath)
            {
                path.Append(point + "->");
            }

            return path.ToString().TrimEnd('-', '>');
        }
    }

    static class PathStorage
    {
        // FIELDS

        private const string defaultPath = @"..\..\Paths.txt";
        private static string path;

        // PROPERTIES

        public static string DefaultPath
        {
            get
            {
                return defaultPath;
            }
        }

        public static string LastPath
        {
            get
            {
                return path;
            }
            private set
            {
                path = value;
            }
        }

        // METHODS

        /// <summary>
        /// Stores a path of points in a .txt file using a try-catch syntaxix. If an exception is thrown, returns false.
        /// </summary>
        /// <param name="pointPath"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool TryStore(Path pointPath, string path = defaultPath)
        {
            try
            {
                using (var writer = new StreamWriter(path))
                {
                    writer.WriteLine(pointPath);
                }
            }
            catch
            {
                return false;
            }
            LastPath = path;
            return true;
        }
    }

}

