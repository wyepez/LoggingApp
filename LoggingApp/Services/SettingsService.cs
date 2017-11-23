using System;

namespace LoggingApp.Services
{
    public class SettingsService
    {
        public static SettingsService Instance { get; set; } = new SettingsService();

        public Uri WebApiUri { get; set; }

        private SettingsService() { }
    }
}
