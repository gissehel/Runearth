using Runearth.Lib.DomainModel;

namespace Runearth.Lib.Core.Service
{
    public interface IGpxReader
    {
        Activity Read(string filename);
    }
}