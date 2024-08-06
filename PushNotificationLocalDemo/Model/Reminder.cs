namespace PushNotificationLocalDemo.Model
{
    public class Reminder
    {
        public string MedicationName { get; set; }
        public TimeSpan ReminderTime { get; set; }
        public int NotificationId { get; set; }
    }
}
