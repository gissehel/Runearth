using Runearth.Lib.Core.Service;
using Runearth.Lib.DomainModel;

namespace Runearth.Lib.Service
{
    public class CommandLineParserService : ICommandLineParserService
    {
        public Configuration ParseCommandLine(string[] args)
        {
            var configuration = new Configuration();
            CommandLine.Parser.Default.ParseArgumentsStrict(args, configuration);
            return configuration;
        }
    }
}