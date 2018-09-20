using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherStation;

namespace WeatherStationTests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void SafeNotificationOfObservers()
        {
            // If the observer is self-removed during the passage of the list
            // the iterator will be invalid

            WeatherData wd = new WeatherData();

            Display display = new Display();
            wd.RegisterObserver(display);

            StatsDisplay statsDisplay = new StatsDisplay();
            wd.RegisterObserver(statsDisplay);

            SelfRemovableDisplay selfRemovableDisplay = new SelfRemovableDisplay(wd);
            wd.RegisterObserver(selfRemovableDisplay);

            wd.SetMeasurements(3, 0.7, 760);
            wd.SetMeasurements(4, 0.8, 761);
        }
    }
}
