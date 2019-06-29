namespace FinamFeed.CommandLine
{
    using System;
    using FinamFeed.CommandLine.Commands;
    using FinamFeed.CommandLine.Options;
    using global::CommandLine;

    public class Program
    {
        public static int Main(string[] args)
        {
            Parser.Default.ParseArguments<
                FindCommandOptions, 
                ListCommandOptions, 
                LoadCommandOptions, 
                UpdateCommandOptions>(args)
                .MapResult(
                (FindCommandOptions opts) => new FindCommand(opts, Console.Out, Console.Error).Process(),
                (ListCommandOptions opts) => new ListCommand(opts, Console.Out, Console.Error).Process(),
                (LoadCommandOptions opts) => new LoadCommand(opts, Console.Out, Console.Error).Process(),
                (UpdateCommandOptions opts) => new UpdateCommand(opts, Console.Out, Console.Error).Process(),

                err => 1);

            return 0;
        }
    }
}
