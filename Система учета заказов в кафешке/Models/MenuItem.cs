using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Система_учета_заказов_в_кафешке.Models
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }

        public string DisplayText
        {
            get { return $"{Name} - {Price} руб."; }
        }
    }
}