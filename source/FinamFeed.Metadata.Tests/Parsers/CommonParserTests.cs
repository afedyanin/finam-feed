namespace FinamFeed.Metadata.Tests.Parsers
{
    using System;
    using FinamFeed.Metadata.Parsers;
    using NUnit.Framework;

    [TestFixture]
    public class CommonParserTests
    {
        [Test]
        public void GetNamesFromNullThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => {
                CommonParser.GetNames(null);
            });
        }

        [Test]
        public void GetNamesFromEmptyStringReturnsEmptyArray()
        {
            var res = CommonParser.GetNames(string.Empty);
            Assert.AreEqual(0, res.Length);
        }

        [TestCase(13, @"'MetLife, Inc.','MetLife, Inc.  ind','Mexico Index','Micron Technology, Inc.','Micron Technology, Inc.  ind','Microsoft Corp','Mxn/Usd','N225Jap*','NASDAQ 100**','NASDAQ**','NATP','NEWMONT MINING CORPORATION','NEWMONT MINING CORPORATION  ind'")]
        [TestCase(29, @"'!AK1M','!ATE1','!CMLZ','!CMPZ','!DCNU','!DTMR','!GBKL','!GKCN','!HL56','!INEC','!INST','!KFKR','!KOSM','!LMLK','!MMSP','!MZHK','!PPRT','!RFRT','!TGMK','!TISH','!ZDMP','!ZMLK','#BRUT','#KVAS','#KVASG','#PYRA','#PYRAG','#RTSX','#TEST'")]
        [TestCase(4, @"'Dkk/Usd','Dr. Reddy\'s Laboratories Ltd','Dr. Reddy\'s Laboratories Ltd  ind','DuPont'")]
        public void GetNamesFromStringReturnsArray(int count, string namesString)
        {
            var res = CommonParser.GetNames(namesString);
            Assert.AreEqual(count, res.Length);
        }

        [TestCase("'aaa'")]
        [TestCase("ddd")]
        public void CanRemoveNotExistingFirstAnLastChars(string source)
        {
            var res = CommonParser.RemoveFirstAndLast(source, '\'', '\'');
            Assert.False(string.IsNullOrEmpty(res));
            Assert.False(res.Contains("'"));
        }
    }
}
