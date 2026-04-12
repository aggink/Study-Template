using System;
using System.Collections.Generic;
using System.Text;

namespace Study.LabWork1.Features.Task2
{
    public class PurchaseProcessor
    {
        // Проверка наличия товара
        public void CheckAvailability()
        {
            Console.WriteLine("Проверка наличия товара на складе");
        }

        // Резервирование товара
        public void ReserveItem()
        {
            Console.WriteLine("Товар зарезервирован");
        }

        // Оформление платежа
        public void ProcessPayment()
        {
            Console.WriteLine("Платеж успешно оформлен");
        }
    }
}
