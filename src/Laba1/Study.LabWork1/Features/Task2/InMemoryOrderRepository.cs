using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace Study.LabWork1.Features.Task2
{
    public class InMemoryOrderRepository
    {
        private readonly ConcurrentDictionary<int, Order> _orders = new();

        public void Save(Order order)
        {
            _orders.AddOrUpdate(order.Id, order, (_, _) => order);
        }

        public Order GetById(int id)
        {
            return _orders.TryGetValue(id, out var order) ? order : null;
        }

        public List<Order> GetAll() => _orders.Values.ToList();
    }
}
