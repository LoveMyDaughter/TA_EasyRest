using System.Text.Json;

namespace TestFramework.Tools.deserialization
{
    public class GetUrls
    {
        private static string _urls = Directory.GetParent(path: @"../../") + "Urls.json";

        public static void Serialize(List<Urls> data)
        {
            using (FileStream fs = new FileStream(_urls, FileMode.OpenOrCreate))
            {
                JsonSerializer.Serialize(fs, data);
            }
        }

        private static List<Urls> getListUrls()
        {
            List<Urls> urls;
            using (FileStream fs = new FileStream(_urls, FileMode.OpenOrCreate))
            {
                urls = JsonSerializer.Deserialize<List<Urls>>(fs);
            }

            return urls;
        }

        public static Urls getUrl(string pageName)
        {
            return getListUrls().Find(url=> url.PageName == pageName);
        }
    }
}
