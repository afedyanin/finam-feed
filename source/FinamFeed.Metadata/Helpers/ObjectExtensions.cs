namespace FinamFeed.Metadata.Helpers
{
    using Newtonsoft.Json;

    public static class ObjectExtensions
    {
        public static string ToJson(this object entity)
        {
            if (entity == null)
            {
                return string.Empty;
            }

            return JsonConvert.SerializeObject(entity);
        }

        public static int GetInt(this string stringValue, int defaultValue = 0)
        {
            if (string.IsNullOrEmpty(stringValue))
            {
                return defaultValue;
            }

            return int.TryParse(stringValue, out int res) ? res : defaultValue;
        }
    }
}
