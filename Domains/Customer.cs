
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Linq;
using Utilities;
namespace Domains
{
    [FileName("customers")]
    public class Customer:IHasId
    {
        public int Id { get; set; }
        [IsRequired]
        [MaxLength(50)]
        public string Name { get; set; } = "";
        [IsRequired]
        [MaxLength(80)]
        public string Email { get; set; } = "";
        [IsRequired]
        [Phone]
        public string Phone { get; set; } = "";
    }
   
   
}
