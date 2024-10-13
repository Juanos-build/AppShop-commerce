namespace AppShop.Services.Helpers.Settings
{
    public class AppSettings
    {
        private static AppSettings settings;
        public static AppSettings Settings { get => settings; set => settings = value; }
        public string Connection { get; set; }
    }
}
