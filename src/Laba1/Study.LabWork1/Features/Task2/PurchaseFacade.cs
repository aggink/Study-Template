using System;
using System.Collections.Generic;
using System.Text;

namespace Study.LabWork1.Features.Task2
{
    public class PurchaseFacade
    {
        private PurchaseProcessor purchaseProcessor;
        private ShippingService shippingService;
        private BuyerNotificationService buyerNotificationService;

        public PurchaseFacade()
        {
            purchaseProcessor = new PurchaseProcessor();
            shippingService = new ShippingService();
            buyerNotificationService = new BuyerNotificationService();
        }

        // Один общий метод, который скрывает все шаги оформления заказа
        public void ProcessOrder()
        {
            purchaseProcessor.CheckAvailability();
            purchaseProcessor.ReserveItem();
            purchaseProcessor.ProcessPayment();

            shippingService.CreateLabel();
            shippingService.PrintLabel();

            buyerNotificationService.SendNotification();
        }
    }
}
