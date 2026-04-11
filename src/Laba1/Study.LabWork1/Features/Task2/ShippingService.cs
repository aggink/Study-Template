using System;

namespace Study.LabWork1.Features.Task2
{
    public class ShippingService
    {
        public void CreateShippingLabel(Order order)
        {
            Console.WriteLine($"Создана этикетка доставки для заказа #{order.Id}");
            Console.WriteLine($"Адрес: {order.CustomerName}");
        }

        public void PrintLabel()
        {
            Console.WriteLine("Этикетка распечатана");
        }
    }
}
