using Runearth.Lib.Core.Service;
using Runearth.Lib.DomainModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Runearth.Lib.Service
{
    public class GpxToKmlConverter : IGpxToKmlConverter
    {
        private IGpxReader GpxReader { get; set; }

        private IKmlWriter KmlWriter { get; set; }

        public GpxToKmlConverter(IGpxReader gpxReader, IKmlWriter kmlWriter)
        {
            GpxReader = gpxReader;
            KmlWriter = kmlWriter;
        }

        public void Convert(string gpxPath, string kmlFilename)
        {
            var filenames = Directory.EnumerateFiles(gpxPath);
            var folder = new ActivityFolder("Activities");
            var subFolders = new Dictionary<string, ActivityFolder>();
            foreach (var filename in filenames.OrderBy(x => x))
            {
                if (filename.EndsWith(".gpx"))
                {
                    // Console.WriteLine(filename);
                    var activity = GpxReader.Read(filename);
                    if (activity != null)
                    {
                        var monthId = GetMonthId(activity);
                        if (!subFolders.ContainsKey(monthId))
                        {
                            subFolders[monthId] = new ActivityFolder(monthId);
                        }
                        subFolders[monthId].Items.Add(activity);
                        Console.WriteLine(activity);
                    }
                }
            }
            foreach (var activityFolderName in subFolders.Keys.OrderBy(x => x))
            {
                folder.Items.Add(subFolders[activityFolderName]);
            }
            KmlWriter.Write(kmlFilename, folder);
        }

        private string GetMonthId(Activity activity)
        {
            if (!activity.StartDateTime.HasValue)
            {
                return null;
            }
            return activity.StartDateTime.Value.ToString("yyyy-MM", CultureInfo.InvariantCulture);
        }
    }
}
