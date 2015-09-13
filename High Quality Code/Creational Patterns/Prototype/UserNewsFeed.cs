namespace Prototype
{
    // i created this class just for the sake of the example
    public class UserNewsFeed
    {
        public string FriendsActivities { get; private set; }

        public WeatherReport WeatherReport { get; private set; }

        public UserNewsFeed(string friendsActivities, WeatherReport weatherReport)
        {
            this.FriendsActivities = friendsActivities;
            this.WeatherReport = weatherReport;
        }

        public override string ToString()
        {
            return "News feed: \n" + this.FriendsActivities + '\n' + this.WeatherReport;
        }
    }
}