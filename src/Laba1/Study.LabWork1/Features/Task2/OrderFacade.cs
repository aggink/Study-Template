using System;

namespace Study.LabWork1.Features.Task2
{
    public class OrderFacade
    {
        private InventoryService inventory;
        private PaymentService payment;
        private ShippingService shipping;
        private NotificationService notification;

        public OrderFacade()
        {
            inventory = new InventoryService();
            payment = new PaymentService();
            shipping = new ShippingService();
            notification = new NotificationService();
        }

        public void PlaceOrder(Order order)
        {
            Console.WriteLine($"\n--- Оформление заказа #{order.Id} ---");

            if (!inventory.CheckAvailability(order.Products))
            {
                Console.WriteLine("Оформление заказа отменено: товары отсутствуют");
                return;
            }

            inventory.ReserveProducts(order.Products);
            order.IsReserved = true;

            if (!payment.ProcessPayment(order.TotalPrice))
            {
                Console.WriteLine("Оформление заказа отменено: ошибка платежа");
                return;
            }
            order.IsPaid = true;

            shipping.CreateShippingLabel(order);
            shipping.PrintLabel();
            order.IsShipped = true;

            notification.SendNotification(order.CustomerName,
                $"Ваш заказ #{order.Id} оформлен и отправлен!");

            Console.WriteLine($"Заказ #{order.Id} успешно оформлен!");
        }
    }
}
