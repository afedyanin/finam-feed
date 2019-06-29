namespace FinamFeed.CommandLine.Commands
{
    using System.IO;
    using FinamFeed.CommandLine.Options;

    public class UpdateCommand : CommandBase<UpdateCommandOptions>
    {
        public UpdateCommand(UpdateCommandOptions options, TextWriter output, TextWriter error) : base(options, output, error)
        {
        }

        protected override void ProcessInternal()
        {
            this.Output.WriteLine("Updating metadata...");
            this.FeedApi.Update();
            this.Output.WriteLine("Metadata updated.");
        }

        public override bool ValidateOptions()
        {
            return base.ValidateOptions();
        }
    }
}
