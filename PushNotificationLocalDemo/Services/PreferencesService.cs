using PushNotificationLocalDemo.Model;
using System.Text.Json;

namespace PushNotificationLocalDemo.Services
{
    public class PreferencesService
    {
        private const string RemindersKey = "reminders_key";

        public List<Reminder> GetReminders()
        {
            var remindersJson = Preferences.Get(RemindersKey, string.Empty);
            if (string.IsNullOrEmpty(remindersJson))
            {
                return new List<Reminder>();
            }

            return JsonSerializer.Deserialize<List<Reminder>>(remindersJson);
        }

        public void SaveReminder(Reminder reminder)
        {
            var reminders = GetReminders();
            reminders.Add(reminder);
            var remindersJson = JsonSerializer.Serialize(reminders);
            Preferences.Set(RemindersKey, remindersJson);
        }
    }
}
