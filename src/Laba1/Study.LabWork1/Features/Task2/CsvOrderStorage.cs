using System;
using System.Collections.Generic;
using System.Text;

namespace Study.LabWork1.Features.Task2
{
    public class CsvOrderStorage
    {
        private readonly string _filePath;

        public CsvOrderStorage(string filePath)
        {
            _filePath = filePath;
            EnsureFileExists();
        }

        private void EnsureFileExists()
        {
            if (!File.Exists(_filePath))
                File.WriteAllText(_filePath, "Id,Customer,Total\r\n");
        }

        public void Write(Order order)
        {
            var line = $"{order.Id},{order.Customer},{order.Total:F2}";
            File.AppendAllText(_filePath, line + Environment.NewLine);
        }

        public List<Order> ReadAll()
        {
            if (!File.Exists(_filePath)) return new List<Order>();

            var lines = File.ReadAllLines(_filePath)
                .Skip(1)
                .Where(l => !string.IsNullOrWhiteSpace(l));

            var orders = new List<Order>();
            foreach (var line in lines)
            {
                var parts = line.Split(',');
                if (parts.Length >= 3 && int.TryParse(parts[0], out int id))
                {
                    orders.Add(new Order
                    {
                        Id = id,
                        Customer = parts[1],
                        Total = decimal.TryParse(parts[2], out decimal total) ? total : 0
                    });
                }
            }
            return orders;
        }
    }
}
