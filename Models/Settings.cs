using System;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace POCDemo.Models
{
    public static class Settings
    {
        private static ISettings AppSettings => CrossSettings.Current;

        public static bool IsUserLogin
        {
            get => AppSettings.GetValueOrDefault(nameof(IsUserLogin), false);

            set => AppSettings.AddOrUpdateValue(nameof(IsUserLogin), value);

        }

        public static string exitUserName
        {
            get => AppSettings.GetValueOrDefault(nameof(exitUserName), null);

            set => AppSettings.AddOrUpdateValue(nameof(exitUserName), value);

        }

        public static string exitUserPicture
        {
            get => AppSettings.GetValueOrDefault(nameof(exitUserPicture), null);

            set => AppSettings.AddOrUpdateValue(nameof(exitUserPicture), value);

        }
    }
}
