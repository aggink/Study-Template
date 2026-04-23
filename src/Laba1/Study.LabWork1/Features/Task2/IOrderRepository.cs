using System;
using System.Collections.Generic;
using System.Text;

namespace Study.LabWork1.Features.Task2
{
    public interface IOrderRepository
    {
        void Save(Order order);

        Order GetById(int id);

        List<Order> GetAll();
    }
}
