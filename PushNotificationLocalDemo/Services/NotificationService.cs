using Plugin.LocalNotification;

namespace PushNotificationLocalDemo.Services
{
    public class NotificationService
    {
        public void ScheduleDailyNotification(string title, string message, TimeSpan time, int notificationId)
        {
            var notifyTime = DateTime.Today.Add(time) < DateTime.Now ? DateTime.Today.AddDays(1).Add(time) : DateTime.Today.Add(time);

            var notification = new NotificationRequest
            {
                BadgeNumber = 1,
                Description = message,
                Title = title,
                ReturningData = "Dummy data",
                NotificationId = notificationId, // Sử dụng ID duy nhất cho mỗi thông báo
                Schedule =
            {
                NotifyTime = notifyTime,
                RepeatType = NotificationRepeat.Daily // Thiết lập thông báo lặp lại hàng ngày
            }
            };


            LocalNotificationCenter.Current.Show(notification);
        }
    }
}
