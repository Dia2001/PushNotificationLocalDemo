using Plugin.LocalNotification;
using PushNotificationLocalDemo.Model;
using PushNotificationLocalDemo.Services;

namespace PushNotificationLocalDemo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        private NotificationService _notificationService;
        private PreferencesService _preferencesService;

        public MainPage()
        {
            InitializeComponent();
            _notificationService = new NotificationService();
            _preferencesService = new PreferencesService();

            LoadReminders();
            LocalNotificationCenter.Current.NotificationActionTapped += Current_NotificationActionTapped;
        }
        private void Current_NotificationActionTapped(Plugin.LocalNotification.EventArgs.NotificationActionEventArgs e)
        {
            if (e.IsDismissed)
            {
            }
            else if (e.IsTapped)
            {
            }
        }
        private void LoadReminders()
        {
            var reminders = _preferencesService.GetReminders();
            foreach (var reminder in reminders)
            {
                _notificationService.ScheduleDailyNotification(
                    "Nhắc nhở uống thuốc",
                    $"Đã đến giờ uống thuốc: {reminder.MedicationName}",
                    reminder.ReminderTime,
                    reminder.NotificationId); // ID duy nhất cho mỗi thông báo
            }
        }

        void OnAddReminderClicked(object sender, EventArgs e)
        {
            var medicationName = medicationNameEntry.Text;
            var reminderTime = reminderTimePicker.Time;

            var reminder = new Reminder
            {
                MedicationName = medicationName,
                ReminderTime = reminderTime,
                NotificationId = GenerateUniqueNotificationId(reminderTime) // Tạo ID duy nhất
            };

            _preferencesService.SaveReminder(reminder);
            _notificationService.ScheduleDailyNotification(
                "Nhắc nhở uống thuốc",
                $"Đã đến giờ uống thuốc: {medicationName}",
                reminderTime,
                reminder.NotificationId);

            DisplayAlert("Thông báo", "Nhắc nhở đã được thiết lập", "OK");
        }

        private int GenerateUniqueNotificationId(TimeSpan time)
        {
            // Tạo ID duy nhất dựa trên thời gian thông báo
            return (int)(time.TotalSeconds + DateTime.Now.DayOfYear * 86400);
        }
    }

}
