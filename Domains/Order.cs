
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Linq;
using Utilities;
namespace Domains
{
    [FileName("orders")]
    public class Order:IHasId
    {

        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        [IsRequired]
        public string Name { get; set; } = "";
        [IsRequired]
        public int ItemId { get; set; }
        [IsRequired]
        [InRange(1, 100)]
        public int Quantity { get; set; }

        [IsRequired]
        public DateTime OrderDate { get; set; } = DateTime.Now;
        [IsRequired]
        [InRange(1,50000)]
        public decimal Price { get; set; }
        [IsRequired]
        [InRange(1, 50000)]
        public decimal TotalPrice { get; set; }

        [IsRequired]
        public int CustomerId { get; set; } 
        [IsRequired]
        public string CustomerName { get; set; } = "";


        

    }
  
    }
