using System.Configuration;

namespace MapPresentor
{
    public class AppSettings
    {
        public static string HubUrl => ConfigurationManager.AppSettings["HubUrl"];
        public static string SetMissionMapUrl => ConfigurationManager.AppSettings["SetMissionMapUrl"];
        public static string DeleteMapUrl => ConfigurationManager.AppSettings["DeleteMapUrl"];
        public static string GetAllMapsUrl => ConfigurationManager.AppSettings["GetAllMapsUrl"];
        public static string GetCurrentMissionMapUrl => ConfigurationManager.AppSettings["GetCurrentMissionMapUrl"];
    }
}
