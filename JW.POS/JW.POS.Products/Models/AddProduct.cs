using JW.POS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JW.POS.Product.Models
{
    public class AddProduct
    {
        public class Request
        {
            public string Name { get; set; }
            public decimal WholeSalePrice { get; set; }
            public decimal SalesPrice { get; set; }
            public decimal ImportSale { get; set; }
        }

        public class Response
        {
            public long Id { get; set; }
            public StatusCode StatusCode { get; set; }
        }
    }
}
