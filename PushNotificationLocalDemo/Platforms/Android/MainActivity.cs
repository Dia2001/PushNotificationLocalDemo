using Android.App;
using Android.Content.PM;
using Android.OS;

namespace PushNotificationLocalDemo
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Tạo kênh thông báo cho Android
            /* var channel = new NotificationChannel("DefaultChannelId", "Default Channel", NotificationImportance.High)
             {
                 Description = "General notifications"
             };

             var notificationManager = (NotificationManager)GetSystemService(NotificationService);
             notificationManager.CreateNotificationChannel(channel);

             LocalNotificationCenter.NotifyNotificationTapped(Intent);*/
            /* NotificationCenter.CreateNotificationChannel();*/

        }
    }
}
