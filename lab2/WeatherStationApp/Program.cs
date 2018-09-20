using System;
using WeatherStation;

namespace WeatherStationApp
{
    class Program
    {
        static void Main(string[] args)
        {
            WeatherData wd = new WeatherData();

            Display display = new Display();
            wd.RegisterObserver(display);

            StatsDisplay statsDisplay = new StatsDisplay();
            wd.RegisterObserver(statsDisplay);

            wd.SetMeasurements(3, 0.7, 760);
            wd.SetMeasurements(4, 0.8, 761);

            wd.RemoveObserver(statsDisplay);

            wd.SetMeasurements(10, 0.8, 761);
            wd.SetMeasurements(-10, 0.8, 761);
        }
    }
}
