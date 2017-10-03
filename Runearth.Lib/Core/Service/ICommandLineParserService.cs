using Runearth.Lib.DomainModel;

namespace Runearth.Lib.Core.Service
{
    public interface ICommandLineParserService
    {
        Configuration ParseCommandLine(string[] args);
    }
}