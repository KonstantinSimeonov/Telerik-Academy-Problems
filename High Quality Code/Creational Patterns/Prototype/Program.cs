namespace Prototype
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var someActivities = new string[] { 
                "Pesho beshe na more",
                "Boil ima novo kuche",
                "Neli chete GoT"
            };

            var rng = new Random();

            var newsFeedList = new List<UserNewsFeed>();

            // slow operation simulation
            Console.WriteLine("Request weather report from the server");
            var weatherReport = Server.GetWeatherReport();
            Console.WriteLine("Report reveceived for: " + 2000 + " miliseconds");

            // cloning proves a lot faster in that case
            for (int i = 0; i < 4; i++)
            {
                var activity = someActivities[rng.Next() % 3];
                newsFeedList.Add(new UserNewsFeed(activity, (WeatherReport)weatherReport.Clone()));
            }

            foreach (var item in newsFeedList)
            {
                Console.WriteLine("\n" + item + "\n ");
            }
        }
    }
}