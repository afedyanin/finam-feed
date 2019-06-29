namespace FinamFeed.CommandLine.Options
{
    using System;
    using FinamFeed.Model.Enums;
    using global::CommandLine;
    using global::CommandLine.Text;

    [Verb("load", HelpText = "Load historical data from feed.")]
    public class LoadCommandOptions
    {
        [Option('s', "symbol", Required = true, HelpText = "SymbolId. Use 'find' command to get SymbolId.")]
        public int SymbolId { get; set; }

        [Option('f', "from", Required = true, HelpText = "Start Date: YYYY-MM-DD")] // TODO: Проверить парсинг на русской версии винды
        public DateTime From { get; set; }

        [Option('t', "to", Required = true, HelpText = "End Date: YYYY-MM-DD")]
        public DateTime To { get; set; }

        [Option('p', "period", Required = true, HelpText = "Period (time frame): T1, M1, M5, M10, M15, M30, H1, D1, W1, MN")]
        public Period Period { get; set; }

        public bool IsValid()
        {
            if (this.Period == Period.Undefined)
            {
                return false;
            }

            if (this.From == DateTime.MinValue)
            {
                return false;
            }

            if (this.To == DateTime.MinValue)
            {
                return false;
            }

            if (this.SymbolId == 0)
            {
                return false;
            }

            return true; ;
        }
    }
}
