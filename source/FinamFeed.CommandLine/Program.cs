namespace FinamFeed.CommandLine
{
    using System;
    using System.Threading.Tasks;
    using Nito.AsyncEx;

    public class Program
    {
        public static int Main(string[] args)
        {
            return AsyncContext.Run(() => AsyncMain(args));
        }

        public static async Task<int> AsyncMain(string[] args)
        {
            var processor = new FeedCommandProcessor();
            await processor.Process(args, Console.In, Console.Out, Console.Error).ConfigureAwait(false);
            return 0;
        }
    }
}
