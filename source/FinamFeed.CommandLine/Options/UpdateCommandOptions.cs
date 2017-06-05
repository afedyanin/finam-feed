namespace FinamFeed.CommandLine.Options
{
    using global::CommandLine;
    using global::CommandLine.Text;

    public class UpdateCommandOptions
    {
        [HelpOption]
        public string GetUsage()
        {
            return HelpText.AutoBuild(this, (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
        }
    }
}
