using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace Study.LabWork1.Features.Task2
{
    public class CsvOrderRepository
    {
        private readonly CsvOrderStorage _adaptee;

        private readonly ConcurrentDictionary<int, Order> _cache = new();

        public CsvOrderRepository(CsvOrderStorage adaptee)
        {
            _adaptee = adaptee;
            LoadCache();
        }

        private void LoadCache()
        {
            foreach (var order in _adaptee.ReadAll())
                _cache.TryAdd(order.Id, order);
        }

        public void Save(Order order)
        {
            _cache.AddOrUpdate(order.Id, order, (_, _) => order);
            _adaptee.Write(order);
        }

        public Order GetById(int id)
        {
            return _cache.TryGetValue(id, out var order) ? order : null;
        }

        public List<Order> GetAll() => _cache.Values.ToList();
    }
}
