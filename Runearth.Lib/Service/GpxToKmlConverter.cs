using Runearth.Lib.Core.Service;
using Runearth.Lib.DomainModel;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Runearth.Lib.Service
{
    public class GpxToKmlConverter : IGpxToKmlConverter
    {
        private ICommandLineParserService CommandLineParserService { get; set; }
        private IGpxReader GpxReader { get; set; }

        private IKmlWriter KmlWriter { get; set; }

        public GpxToKmlConverter(ICommandLineParserService commandLineParserService, IGpxReader gpxReader, IKmlWriter kmlWriter)
        {
            CommandLineParserService = commandLineParserService;
            GpxReader = gpxReader;
            KmlWriter = kmlWriter;
        }

        public void Convert(Configuration configuration)
        {
            var filenames = Directory.EnumerateFiles(configuration.GpxFolder);
            var folder = new ActivityFolder("Activities");
            var subFolders = new Dictionary<string, ActivityFolder>();
            foreach (var filename in filenames.OrderBy(x => x))
            {
                if (filename.EndsWith(".gpx"))
                {
                    var activity = GpxReader.Read(filename);
                    if (activity != null)
                    {
                        var monthId = GetMonthId(activity);
                        if (monthId != null)
                        {
                            if (!subFolders.ContainsKey(monthId))
                            {
                                subFolders[monthId] = new ActivityFolder(monthId);
                            }
                            subFolders[monthId].AddItem(activity);
                        }
                    }
                }
            }
            foreach (var activityFolderName in subFolders.Keys.OrderBy(x => x))
            {
                folder.AddItem(subFolders[activityFolderName]);
            }
            KmlWriter.Write(configuration.KmlFilename, folder, configuration);
        }

        private string GetMonthId(Activity activity)
        {
            if (!activity.StartDateTime.HasValue)
            {
                return null;
            }
            return activity.StartDateTime.Value.ToString("yyyy-MM", CultureInfo.InvariantCulture);
        }

        public void Run(string[] args)
        {
            var configuration = CommandLineParserService.ParseCommandLine(args);
            Convert(configuration);
        }
    }
}