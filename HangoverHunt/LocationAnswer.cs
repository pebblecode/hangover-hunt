using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HangoverHunt
{
    public class LocationAnswer : IAnswer
    {
        public LocationAnswer(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public double Latitude { get; private set; }
        public double Longitude { get; private set; }
    }
}
