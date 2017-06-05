namespace FinamFeed.CommandLine.Commands
{
    using System.IO;
    using System.Threading.Tasks;
    using FinamFeed.CommandLine.Options;

    public class UpdateCommand : CommandBase<UpdateCommandOptions>
    {
        public UpdateCommand(UpdateCommandOptions options, TextWriter output, TextWriter error) : base(options, output, error)
        {
        }

        protected override async Task ProcessInternal()
        {
            this.Output.WriteLine("Updating metadata...");
            await this.FeedApi.Update().ConfigureAwait(false);
            this.Output.WriteLine("Metadata updated.");
        }

        public override bool ValidateOptions()
        {
            return base.ValidateOptions();
        }

        public override string GetUsage()
        {
            return this.Options.GetUsage();
        }
    }
}
