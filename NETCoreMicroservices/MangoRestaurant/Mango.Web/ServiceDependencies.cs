namespace Mango.Web
{
    public static class ServiceDependencies
    {
        public static string ProductAPIBase { get; set; }

        public enum APIType
        {
            GET,
            POST,
            PUT,
            DELETE,
        }
    }
}
