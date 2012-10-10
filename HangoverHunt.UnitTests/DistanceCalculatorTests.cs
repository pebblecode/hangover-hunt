using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HangoverHunt.UnitTests
{
    [TestClass]
    public class DistanceCalculatorTests
    {
        [TestMethod]
        public void DistanceBetweenPlaces_LondonToNewYork_5570()
        {
            double londonLat = 51.5073346;
            double londonLong = -0.1276831;
            double nyLat = 40.7143528;
            double nyLong = -74.0059731;

            var distance = DistanceCalculator.DistanceBetweenPlaces(londonLong, londonLat, nyLong, nyLat);

            Assert.AreEqual(5570, distance, 10);
        }

        [TestMethod]
        public void DistanceBetweenPlaces_PorterhouseToEndOfRoad_100m()
        {
            double pubLat = 51.5104404;
            double pubLong = -0.1235989;
            double diviceLat = 51.5102695;
            double diviceLong = -0.1223249;

            var distance = DistanceCalculator.DistanceBetweenPlaces(pubLong, pubLat, diviceLong, diviceLat);

            Assert.AreEqual(0.1, distance, 0.01);
        }
    }
}
