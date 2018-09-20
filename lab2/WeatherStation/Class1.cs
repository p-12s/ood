using System;
using System.Collections.Generic;

namespace WeatherStation
{
    public interface IObserver<T>
    {
        void Update(T data);
    }

    public interface IObservable<T>
    {
        void RegisterObserver(IObserver<T> observer);
        void NotifyObservers();
        void RemoveObserver(IObserver<T> observer);
    };

    public class Observable<T> : IObservable<T>
    {
        public void RegisterObserver(IObserver<T> observer)
        {
            observers.Add(observer);
        }

        public void NotifyObservers()
        {
            T data = GetChangedData();

            var observersClone = new List<IObserver<T>>(observers);
            foreach (var observer in observersClone)
            {
                observer.Update(data);
            }
        }

        public void RemoveObserver(IObserver<T> observer)
        {
            observers.Remove(observer);
        }

        protected virtual T GetChangedData()
        {
            return default(T);
        }

        private List<IObserver<T>> observers = new List<IObserver<T>>();
    }

    public struct SWeatherInfo
    {
        public double temperature, humidity, pressure;
    };

    // самоудаляющийся наблюдатель
    public class SelfRemovableDisplay : IObserver<SWeatherInfo>
    {
        private WeatherData subject;
        public SelfRemovableDisplay(WeatherData weatherData)
        {
            subject = weatherData;
        }

        public void Update(SWeatherInfo data)
        {
            subject.RemoveObserver(this);
        }
    };

    public class Display : IObserver<SWeatherInfo>
    {
        public void Update(SWeatherInfo data)
        {
            Console.WriteLine("Current:\n Temp {0}\n Hum {1}\n Pressure {2}\n",
                data.temperature, data.humidity, data.pressure);
        }
    };

    public class StatsDisplay : IObserver<SWeatherInfo>
    {
        public void Update(SWeatherInfo data)
        {
            m_temperatureStatistics.AddValue(data.temperature);
            m_presureStatistics.AddValue(data.pressure);
            m_humidityStatistics.AddValue(data.humidity);

            Console.WriteLine("----Stat.----");
            PrintStatistics("Temp", m_temperatureStatistics);
            PrintStatistics("Presure", m_presureStatistics);
            PrintStatistics("Humidity", m_humidityStatistics);
            Console.WriteLine();
        }

        private void PrintStatistics(string statisticName, Statistics statistics)
        {
            Console.WriteLine("{0} Max: {1} Min: {2} Average: {3}",
                statisticName,
                Math.Round(statistics.MaxValue(), 1),
                Math.Round(statistics.MinValue(), 1),
                Math.Round(statistics.Averrage(), 1));
        }

        private Statistics m_temperatureStatistics = new Statistics();
        private Statistics m_presureStatistics = new Statistics();
        private Statistics m_humidityStatistics = new Statistics();
    };

    class Statistics
    {
        public void AddValue(double value)
        {
            if (m_minValue > value)
            {
                m_minValue = value;
            }
            if (m_maxValue < value)
            {
                m_maxValue = value;
            }
            m_accValue += value;
            ++m_countAcc;
        }

        public double MinValue()
        {
            return m_minValue;
        }

        public double MaxValue()
        {
            return m_maxValue;
        }

        public double Averrage()
        {
            return (m_countAcc != 0) ? m_accValue / m_countAcc : 0;
        }

        private double m_minValue = double.MaxValue;
        private double m_maxValue = -double.MaxValue;
        private double m_accValue = 0;
        private double m_countAcc = 0;
    };

    public class WeatherData : Observable<SWeatherInfo>
    {
        public double GetTemperature()
        {
            return m_temperature;
        }

        public double GetHumidity()
        {
            return m_humidity;
        }

        public double GetPressure()
        {
            return m_pressure;
        }

        public void MeasurementsChanged()
        {
            NotifyObservers();
        }

        public void SetMeasurements(double temp, double humidity, double pressure)
        {
            m_humidity = humidity;
            m_temperature = temp;
            m_pressure = pressure;

            MeasurementsChanged();
        }

        protected override SWeatherInfo GetChangedData()
        {
            return new SWeatherInfo
            {
                temperature = GetTemperature(),
                humidity = GetHumidity(),
                pressure = GetPressure()
            };
        }

        private double m_temperature = 0;
        private double m_humidity = 0;
        private double m_pressure = 760;
    }

}
