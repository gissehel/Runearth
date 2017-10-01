using Runearth.Lib.Core.Service;
using Runearth.Lib.DomainModel;
using Runearth.Lib.Utils;
using System.Globalization;
using System.Linq;
using System.Xml;

namespace Runearth.Lib.Service
{
    public class KmlWriter : IKmlWriter
    {
        public void Write(string filename, ActivityFolder folder)
        {
            var document = new XmlDocument();
            document.AddXmlDeclaration("1.0", "UTF-8", null);
            document
                .AddSubElement("kml", "http://www.opengis.net/kml/2.2")
                .WithXmlns("gx", "http://www.google.com/kml/ext/2.2")
                .WithXmlns("kml", "http://www.opengis.net/kml/2.2")
                .WithXmlns("atom", "http://www.w3.org/2005/Atom")
                .AppendChild(GetFolderNode(document, folder))
                ;
            document.Save(filename);
        }

        private XmlNode GetFolderNode(XmlDocument document, ActivityFolder folder)
        {
            var folderNode = document.CreateElement("Folder");
            folderNode.AddSubElement("name").WithText(folder.Name);
            folderNode.AddSubElement("open").WithText("1");
            foreach (var activityFolderItem in folder.Items)
            {
                var node = GetFolderOrPlacemarkNode(document, activityFolderItem);
                if (node != null)
                {
                    folderNode.AppendChild(node);
                }
            }
            return folderNode;
        }

        private XmlNode GetPlacemarkNode(XmlDocument document, Activity activity)
        {
            var placemarkNode = document.CreateElement("Placemark");
            placemarkNode.AddSubElement("name").WithText(activity.Name);
            var lineStyleNode = placemarkNode.AddSubElement("Style").AddSubElement("LineStyle");
            lineStyleNode.AddSubElement("color").WithText("ff0000ff");
            lineStyleNode.AddSubElement("width").WithText("5");
            var lineStringNode = placemarkNode.AddSubElement("LineString");
            lineStringNode.AddSubElement("tessellate").WithText("1");
            lineStringNode.AddSubElement("coordinates").WithText(GetCoordinatesText(activity));
            return placemarkNode;
        }

        private string GetCoordinatesText(Activity activity) => string.Join(" ", activity.TrackPoints.Select(GetCoordinatesText));

        private string GetCoordinatesText(TrackPoint trackPoint) => string.Format
            (
                CultureInfo.InvariantCulture,
                "{0},{1},{2}",
                trackPoint.Lon,
                trackPoint.Lat,
                trackPoint.Elevation
            );

        private XmlNode GetFolderOrPlacemarkNode(XmlDocument document, ActivityFolderItem item)
        {
            switch (item)
            {
                case Activity activity:
                    return GetPlacemarkNode(document, activity);

                case ActivityFolder folder:
                    return GetFolderNode(document, folder);

                default:
                    return null;
            }
        }
    }
}