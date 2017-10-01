using Runearth.Lib.Core.Service;
using Runearth.Lib.DomainModel;
using Runearth.Lib.Utils;
using System.Linq;
using System.Xml;

namespace Runearth.Lib.Service
{
    public class GpxReader : IGpxReader
    {
        public Activity Read(string filename)
        {
            var activity = new Activity();
            var document = new XmlDocument();

            document.Load(filename);
            if (filename.Contains(".gpx"))
            {
                var index = filename.LastIndexOf(".gpx");
                var filenameParts = filename.Substring(0, index).Split(' ');
                if (filenameParts.Length == 4)
                {
                    activity.ActivityType = filenameParts[3];
                }
            }

            if (activity.ActivityType == null)
            {
                activity.ActivityType = "None";
            }

            foreach (var trackPointNodeObject in document.GetElementsByTagName("trkpt"))
            {
                var trackPointNode = trackPointNodeObject as XmlNode;
                if (trackPointNode != null)
                {
                    var trackPoint = new TrackPoint();
                    trackPoint.Lon = trackPointNode.ReadAttributeAsDouble("lon");
                    trackPoint.Lat = trackPointNode.ReadAttributeAsDouble("lat");

                    var eleNode = trackPointNode.GetChildsByName("ele").FirstOrDefault();
                    if (eleNode != null)
                    {
                        trackPoint.Elevation = eleNode.GetInnerTextAsDouble();
                    }

                    var timeNode = trackPointNode.GetChildsByName("time").FirstOrDefault();
                    if (timeNode != null)
                    {
                        trackPoint.DateTime = timeNode.GetInnerTextAsDateTime();
                    }

                    activity.TrackPoints.Add(trackPoint);
                }
                if (activity.StartDateTime.HasValue)
                {
                    activity.Name = string.Format("{0} - {1} ({2})", activity.StartDateTime.Value.ToString("yyyy-MM-dd HH:mm:ss"), activity.StopDateTime.Value.ToString("yyyy-MM-dd HH:mm:ss"), activity.ActivityType);
                }
            }

            if (activity.TrackPoints.Count == 0)
            {
                return null;
            }

            return activity;
        }
    }
}