using System;
using System.Collections.Generic;

namespace Runearth.Lib.DomainModel
{
    public class Activity : ActivityFolderItem
    {
        public string ActivityType { get; set; }

        public List<TrackPoint> TrackPoints { get; private set; } = new List<TrackPoint>();

        public override string ToString() => string.Format("Activity [{0}] ({1})", Name, TrackPoints.Count);

        public DateTime? StartDateTime => TrackPoints.Count == 0 ? null : new DateTime?(TrackPoints[0].DateTime);

        public DateTime? StopDateTime => TrackPoints.Count == 0 ? null : new DateTime?(TrackPoints[TrackPoints.Count - 1].DateTime);
    }
}