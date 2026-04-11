using System;
using System.Collections.Generic;

namespace Study.LabWork1.Features.Task2
{
    public class InventoryService
    {
        private HashSet<string> availableProducts = new HashSet<string>
        {
            "Ноутбук", "Мышь", "Клавиатура", "Монитор", "Наушники"
        };

        public bool CheckAvailability(List<string> products)
        {
            foreach (var product in products)
            {
                if (!availableProducts.Contains(product))
                {
                    Console.WriteLine($"Товар '{product}' отсутствует на складе");
                    return false;
                }
            }
            Console.WriteLine("Все товары есть в наличии");
            return true;
        }

        public void ReserveProducts(List<string> products)
        {
            Console.WriteLine($"Товары зарезервированы: {string.Join(", ", products)}");
        }
    }
}
