namespace Prototype
{
    using System;
    /// <summary>
    /// The WeatherReport class is instantiated server side and is the same for all users.
    /// </summary>
    public class WeatherReport : ICloneable
    {

        public int Temparature { get; private set; }

        public bool IsCloudy { get; private set; }

        public bool WillRain { get; private set; }

        public WeatherReport(int temp, bool cloudy, bool rainy)
        {
            this.Temparature = temp;
            this.IsCloudy = cloudy;
            this.WillRain = rainy;
        }

        // since getting a weather report from the server is slow
        // and every user has the same weather report, it's more convininet just to copy it
        // instead of requesting the same report from the server
        public object Clone()
        {
            return new WeatherReport(this.Temparature, this.IsCloudy, this.WillRain);
        }

        public override string ToString()
        {
            return "Temp: " + this.Temparature + "\nCloudy: " + this.IsCloudy + "\nRainy: " + this.WillRain;
        }
    }
}
