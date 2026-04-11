using System;

namespace Study.LabWork1.Features.Task2
{
    public class PaymentService
    {
        public bool ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Обработка платежа на сумму {amount} руб.");
            Console.WriteLine("Платеж успешно проведен");
            return true;
        }
    }
}
