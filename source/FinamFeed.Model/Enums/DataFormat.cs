namespace FinamFeed.Model.Enums
{
    public enum DataFormat
    {
        Undefined = 0,
        TPDTOHLCV = 1,  // TICKER, PER, DATE, TIME, OPEN, HIGH, LOW, CLOSE, VOL
        TPDTOHLC = 2,   // TICKER, PER, DATE, TIME, OPEN, HIGH, LOW, CLOSE
        TPDTCV = 3,     // TICKER, PER, DATE, TIME, CLOSE, VOL
        TPDTC = 4,      // TICKER, PER, DATE, TIME, CLOSE
        DTOHLCV = 5,    // DATE, TIME, OPEN, HIGH, LOW, CLOSE, VOL
        TPDTLV = 6,     // TICKER, PER, DATE, TIME, LAST, VOL
        TDTLV = 7,      // TICKER, DATE, TIME, LAST, VOL
        TDTL = 8,       // TICKER, DATE, TIME, LAST
        DTLV = 9,       // DATE, TIME, LAST, VOL
        DTL = 10,       // DATE, TIME, LAST
        DTLVI = 11      // DATE, TIME, LAST, VOL, ID 
    }
}
