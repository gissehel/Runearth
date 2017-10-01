namespace Runearth.Lib.Core.Service
{
    public interface IGpxToKmlConverter
    {
        void Convert(string gpxPath, string kmlFilename);
    }
}