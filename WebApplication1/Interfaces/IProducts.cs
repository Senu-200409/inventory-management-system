using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Controllers;
using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public interface IProducts
    {
        Response AddProductsDetails(ProductsModel addProducts);
        Response GetAllProducts();
        Response GetProductsByProductId(string productId);

    }
}