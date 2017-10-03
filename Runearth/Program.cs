using Runearth.Lib.Core.Service;
using Runearth.Lib.Service;

namespace Runearth
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            IGpxReader gpxReader = new GpxReader();
            IKmlWriter kmlWriter = new KmlWriter();
            ICommandLineParserService commandLineParserService = new CommandLineParserService();
            IGpxToKmlConverter gpxToKmlConverter = new GpxToKmlConverter(commandLineParserService, gpxReader, kmlWriter);

            gpxToKmlConverter.Run(args);
        }
    }
}