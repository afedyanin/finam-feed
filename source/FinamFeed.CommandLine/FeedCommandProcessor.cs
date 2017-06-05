namespace FinamFeed.CommandLine
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using FinamFeed.CommandLine.Commands;
    using FinamFeed.CommandLine.Options;
    using global::CommandLine;

    public class FeedCommandProcessor
    {
        protected TextWriter Error { get; set; }
        protected TextReader Input { get; set; }
        protected TextWriter Output { get; set; }

        protected FeedVerbOptions Options { get; set; }
        protected ICommand Command { get; set; }

        public async Task Process(string[] args, TextReader input, TextWriter output, TextWriter error)
        {
            this.Error = error;
            this.Output = output;
            this.Input = input;

            this.ParseOptions(args);

            var isValidArguments = this.ValidateArguments();

            if (isValidArguments)
            {
                await this.PreProcess().ConfigureAwait(false);
                await this.Process().ConfigureAwait(false);
                await this.PostProcess().ConfigureAwait(false);
            }
            else
            {
                this.Error.WriteLine(this.Command.GetUsage());
            }
        }

        private void ParseOptions(string[] args)
        {
            this.Options = new FeedVerbOptions();

            if (args == null || args.Length <=0)
            {
                this.Error.WriteLine(this.Options.GetUsage(string.Empty));
                Environment.Exit(Parser.DefaultExitCodeFail);
            }

            if (!Parser.Default.ParseArgumentsStrict(args, this.Options, this.OnVerb, this.OnFail))
            {
                Environment.Exit(Parser.DefaultExitCodeFail);
            }
        }

        protected virtual bool ValidateArguments()
        {
            return this.Command.ValidateOptions();
        }

        protected virtual Task PreProcess()
        {
            return Task.FromResult(0);
        }

        protected virtual async Task Process()
        {
            await this.Command.Process().ConfigureAwait(false);
        }

        protected virtual Task PostProcess()
        {
            return Task.FromResult(0);
        }

        protected virtual void OnFail()
        {
        }

        protected virtual void OnVerb(string verbName, object verbSubOptions)
        {
            this.Command = CommandFactory.Create(verbName, verbSubOptions, this.Output, this.Error);
        }
    }
}
