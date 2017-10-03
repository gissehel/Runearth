using CommandLine;

namespace Runearth.Lib.DomainModel
{
    public class Configuration
    {
        [Option('f', "gpx-folder", Required = true, HelpText = "Folder for gpx files")]
        public string GpxFolder { get; set; }

        [Option('k', "kml-output", Required = true, HelpText = "Filename for kml output")]
        public string KmlFilename { get; set; }

        [Option('w', "line-width", Required = false, HelpText = "Line width of activity lines", DefaultValue = "2")]
        public string KmlLineWidth { get; set; }
    }
}