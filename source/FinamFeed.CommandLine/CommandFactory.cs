namespace FinamFeed.CommandLine
{
    using System.IO;
    using FinamFeed.CommandLine.Commands;
    using FinamFeed.CommandLine.Options;

    public static class CommandFactory
    {
        public static ICommand Create(string verbName, object verbOptions, TextWriter output, TextWriter error)
        {
            if (string.IsNullOrWhiteSpace(verbName))
            {
                return null;
            }

            if (verbOptions == null)
            {
                return null;
            }

            switch (verbName)
            {
                case "list":
                    return new ListCommand(verbOptions as ListCommandOptions, output, error);
                case "find":
                    return new FindCommand(verbOptions as FindCommandOptions, output, error);
                case "load":
                    return new LoadCommand(verbOptions as LoadCommandOptions, output, error);
                case "update":
                    return new UpdateCommand(verbOptions as UpdateCommandOptions, output, error);
            }

            return null;
        }
    }
}
