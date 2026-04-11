using System;

namespace Study.LabWork1.Features.Task2
{
    public class NotificationService
    {
        public void SendNotification(string customerName, string message)
        {
            Console.WriteLine($"Уведомление отправлено {customerName}: {message}");
        }
    }
}
