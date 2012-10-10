using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HangoverHunt
{
    public class LocationRiddle : IRiddle
    {
        private readonly double latitude;
        private readonly double longitude;
        private readonly double accurateTo;

        public LocationRiddle(string question, double latitude, double longitude, double accurateTo)
        {
            this.latitude = latitude;
            this.longitude = longitude;
            this.accurateTo = accurateTo;
            Question = question;
        }

        public string Question { get; private set; }

        public bool CheckAnswer(LocationAnswer answer)
        {
            var distanceDifference = DistanceCalculator.DistanceBetweenPlaces(latitude, longitude, answer.Longitude, answer.Latitude);

            return distanceDifference <= accurateTo;
        }

        public bool CheckAnswer(IAnswer answer)
        {
            if (answer == null)
                throw new ArgumentNullException("answer", "answer is null.");
            if (answer.GetType() != typeof(TextAnswer))
                throw new InvalidOperationException("Location answer required.");

            return CheckAnswer((LocationAnswer)answer);
        }
    }
}
