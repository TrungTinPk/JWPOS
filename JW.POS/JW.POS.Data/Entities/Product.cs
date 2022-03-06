using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JW.POS.Core.Entities
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; }

        public decimal WholeSalePrice { get; set; }

        public decimal SalesPrice { get; set; }
        public decimal ImportPrice { get; set; }
    }
}
