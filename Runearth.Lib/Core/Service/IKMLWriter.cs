using Runearth.Lib.DomainModel;

namespace Runearth.Lib.Core.Service
{
    public interface IKmlWriter
    {
        void Write(string filename, ActivityFolder folder, Configuration configuration);
    }
}