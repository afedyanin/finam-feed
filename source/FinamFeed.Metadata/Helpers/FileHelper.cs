namespace FinamFeed.Metadata.Helpers
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    public static class FileHelper
    {
        public static void PersistToJsonFile<T>(T item, string filePath)
        {
            var path = GetFullPath(filePath);

            using (var file = File.CreateText(path))
            {
                var serializer = new JsonSerializer();
                serializer.Serialize(file, item);
            }
        }

        public static T LoadFromJsonFile<T>(string filePath)
        {
            var path = GetFullPath(filePath);

            using (StreamReader file = File.OpenText(path))
            {
                var serializer = new JsonSerializer();
                using (var jsonReader = new JsonTextReader(file))
                {
                    return serializer.Deserialize<T>(jsonReader);
                }
            }
        }

        public static async Task<string> LoadString(string filePath)
        {
            var path = GetFullPath(filePath);

            using (var reader = File.OpenText(path))
            {
                return await reader.ReadToEndAsync().ConfigureAwait(false);
            }
        }

        public static async Task SaveString(string value, string filePath)
        {
            var path = GetFullPath(filePath);

            using (var writer = File.CreateText(path))
            {
                await writer.WriteAsync(value).ConfigureAwait(false);
            }
        }

        private static string GetFullPath(string filePath)
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filePath);
        }

    }
}
