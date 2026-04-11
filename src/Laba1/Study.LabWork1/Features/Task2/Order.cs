using System;
using System.Collections.Generic;

namespace Study.LabWork1.Features.Task2
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public List<string> Products { get; set; } = new List<string>();
        public decimal TotalPrice { get; set; }
        public bool IsPaid { get; set; }
        public bool IsReserved { get; set; }
        public bool IsShipped { get; set; }

        public override string ToString()
        {
            return $"Заказ #{Id}: {CustomerName}, товаров: {Products.Count}, сумма: {TotalPrice} руб.";
        }
    }
}
