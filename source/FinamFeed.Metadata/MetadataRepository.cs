namespace FinamFeed.Metadata
{
    using System.Collections.Generic;
    using System.Linq;
    using FinamFeed.Model.Entities;

    public class MetadataRepository
    {
        private IList<Market> markets;
        private IList<Symbol> symbols;

        public MetadataRepository(IList<Market> markets, IList<Symbol> symbols)
        {
            this.markets = markets ?? new List<Market>();
            this.symbols = symbols ?? new List<Symbol>();
        }

        public IList<Market> GetAllMarkets()
        {
            return this.markets.OrderBy(m => m.Id).ToList();
        }

        public IDictionary<int, Market> GetMarketsDictionary()
        {
            var res = new Dictionary<int, Market>();

            foreach(var market in this.markets)
            {
                res.Add(market.Id, market);
            }

            return res;
        }

        public Symbol GetSymbolById(int symbolId)
        {
            return this.symbols.FirstOrDefault(s => s.Id == symbolId);
        }

        public IList<Symbol> GetAllSymbols()
        {
            return this.symbols.OrderBy(s => s.Code).ToList();
        }

        public IList<Symbol> FindSymbolByName(string name, bool strictSearch = false)
        {
            if (string.IsNullOrEmpty(name))
            {
                return new List<Symbol>();
            }

            if (strictSearch)
            {
                return this.symbols.
                    Where(s => string.Compare(s.Name, name, true) == 0)
                    .ToList();
            }

            var upperName = name.ToUpper();

            return this.symbols
                .Where(s => s.Name.ToUpper().Contains(upperName))
                .OrderBy(s => s.Name)
                .ToList();
        }

        public IList<Symbol> FindSymbolByCode(string code, bool strictSearch = false)
        {
            if (string.IsNullOrEmpty(code))
            {
                return new List<Symbol>();
            }

            if (strictSearch)
            {
                return this.symbols.
                    Where(s => string.Compare(s.Code, code, true) == 0)
                    .ToList();
            }

            var upperCode = code.ToUpper();

            return this.symbols
                .Where(s => s.Code.ToUpper().Contains(upperCode))
                .OrderBy(s=> s.Code)
                .ToList();
        }
    }
}
