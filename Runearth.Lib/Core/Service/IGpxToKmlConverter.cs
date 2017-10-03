using Runearth.Lib.DomainModel;

namespace Runearth.Lib.Core.Service
{
    public interface IGpxToKmlConverter
    {
        void Convert(Configuration configuration);

        void Run(string[] args);
    }
}