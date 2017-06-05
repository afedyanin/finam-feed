namespace FinamFeed.Model.Enums
{
    public class FileExtension
    {
        public static readonly FileExtension Csv = new FileExtension(".csv");
        public static readonly FileExtension Txt = new FileExtension(".txt");

        public string Value { get;  }

        private FileExtension(string value)
        {
            this.Value = value;
        }
    }
}
