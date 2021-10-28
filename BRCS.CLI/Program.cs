using CommandLine;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BRCS.CLI
{
    class Program
    {
        class Options
        {
            [Option('t', Required = true, HelpText = "The torznab endpoint")]
            public string TorznabEndpoint { get; set; }

            [Option('j', Required = true, HelpText = "Jacket API key")]
            public string JacketApiKey { get; set; }

            [Option('b', Required = true, HelpText = "BHD API KEY")]
            public string BhdApiKey { get; set; }

            [Option('r', Required = true, HelpText = "BHD RSS KEY")]
            public string BhdRssKey { get; set; }

            [Option('a', Required = false, Default = 10, HelpText = "Amount of releases to find")]
            public int Amount { get; set; }
        }

        static async Task Main(string[] args)
        {
            await Parser.Default.ParseArguments<Options>(args)
              .WithNotParsed(HandleParseError)
              .WithParsedAsync(RunOptions);
        }

        private static async Task RunOptions(Options options)
        {
            try
            {
                Seeker s = new Seeker(options.TorznabEndpoint, options.JacketApiKey, options.BhdApiKey, options.BhdRssKey);

                var releases = await s.SearchAsync(options.Amount);

                foreach (var option in releases)
                {
                    Console.WriteLine("Match found!");
                    Console.WriteLine($"\t{option.BHDDetails}");
                    Console.WriteLine($"\t{option.PTPDetails}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR!");
                Console.WriteLine(e);
            }
        }

        private static void HandleParseError(IEnumerable<Error> obj)
        {
            Console.WriteLine("Invalid input");

            Environment.Exit(1);
        }
    }
}
