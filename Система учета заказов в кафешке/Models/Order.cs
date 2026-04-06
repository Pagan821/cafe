using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Система_учета_заказов_в_кафешке.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int OrderNumber { get; set; }
        public List<OrderItem> Items { get; set; }
        public string Status { get; set; }
        public DateTime OrderTime { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? ReadyTime { get; set; }
        public decimal Total { get; set; }
        public int? CookId { get; set; }

        public Order()
        {
            Items = new List<OrderItem>();
        }
    }
}