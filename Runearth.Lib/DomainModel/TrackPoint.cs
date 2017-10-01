using System;

namespace Runearth.Lib.DomainModel
{
    public class TrackPoint
    {
        public double Lat { get; set; }
        public double Lon { get; set; }
        public double Elevation { get; set; }
        public DateTime DateTime { get; set; }
    }
}