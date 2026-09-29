using System;
using System.Collections.Generic;
using System.Text;

namespace Domains.Reports_Class
{
    public class SalesByItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public int OrderCount { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
