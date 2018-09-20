using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherStation;

namespace WeatherStationTests
{
    [TestClass]
    public class UnitTest1 //���������� �����������
    {
        [TestMethod]
        public void TestMethod1()
        {
            // �������� � ���, ��� 
            // ����������� ����� ������������� �� ����� ����������� ������ 
            CWeatherData wd = new CWeatherData();

            CDisplay display = new CDisplay();
            wd.RegisterObserver(display);

            CStatsDisplay statsDisplay = new CStatsDisplay();
            wd.RegisterObserver(statsDisplay);

            CSelfRemovableDisplay selfRemovableDisplay = new CSelfRemovableDisplay();
            wd.RegisterObserver(selfRemovableDisplay);

            wd.SetMeasurements(3, 0.7, 760);
            wd.SetMeasurements(4, 0.8, 761);


            //wd.RemoveObserver(statsDisplay);

        }
    }
}
