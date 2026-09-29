
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Linq;
using Utilities;
namespace Domains
{
    [FileName("items")]
    public class Item:IHasId
    {
        public int Id { get; set; }
        [IsRequired]
        [MaxLength(50)]
        public string Name { get; set; } = "";
        [IsRequired]
        [InRange(1, 100000)]
        public decimal Price { get; set; }


      
    }
   
 
}
