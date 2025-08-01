using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ProductsModel
    {
        public string P_ProductID { get; set; }
        public string P_ProductName { get; set; }
        public string P_CategoryID { get; set; }
        public string P_UnitID { get; set; }
        public string P_UnitPrice { get; set; }
        public string P_ReorderLevel { get; set; }
        public string P_ProductImage { get; set; }
    }
}