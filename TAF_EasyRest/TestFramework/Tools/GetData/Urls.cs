namespace TestFramework.Tools.deserialization
{
    public class Urls
    {
        public string Url { get; private set; }
        public string PageName { get; private set; }

        public Urls(string PageName, string Url)
        {
            this.Url = Url;
            this.PageName = PageName;
        }
    }
}
