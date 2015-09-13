namespace Prototype
{
    using System;
    using System.Threading;

    public class Server
    {
        private static WeatherReport weatherReport = new WeatherReport(10, true, false);

        // lets say that getting the weather report from the server is slow, because of connection or whatever
        public static WeatherReport GetWeatherReport()
        {
            Thread.Sleep(2000);

            return weatherReport;
        }
    }
}