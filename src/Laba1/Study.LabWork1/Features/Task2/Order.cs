using System;
using System.Collections.Generic;
using System.Text;

namespace Study.LabWork1.Features.Task2
{
    public class Order
    {
        public int Id { get; set; }

        public string Customer { get; set; } = string.Empty;

        public decimal Total { get; set; }
    }
}
