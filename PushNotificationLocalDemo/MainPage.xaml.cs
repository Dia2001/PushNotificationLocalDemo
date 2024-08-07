using Plugin.LocalNotification;

namespace PushNotificationLocalDemo
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        public MainPage()
        {
            InitializeComponent();
        }
        private void OnCounterClicked(object sender, EventArgs e)
        {
            var medicationName = medicationNameEntry.Text;
            var reminderTime = reminderTimePicker.Time;
            var notifyTime = DateTime.Today.Add(reminderTime) < DateTime.Now ? DateTime.Today.AddDays(1).Add(reminderTime) : DateTime.Today.Add(reminderTime);
            DisplayAlert("Thông báo", reminderTime.ToString() + " " + DateTime.Now, "OK");
            var request = new NotificationRequest
            {
                NotificationId = Guid.NewGuid().GetHashCode(),
                Title = "Hẹn giờ uống thuốc",
                Subtitle = "Đã đến h uống thuốc",
                Description = "Stay Tuned",
                BadgeNumber = 42,
                /*Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = DateTime.Now.AddSeconds(5),
                    NotifyRepeatInterval = TimeSpan.FromDays(1)
                }*/
                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = notifyTime,
                    RepeatType = NotificationRepeat.Daily // Thiết lập thông báo lặp lại hàng ngày
                }
            };
            LocalNotificationCenter.Current.Show(request);
        }
    }

}
