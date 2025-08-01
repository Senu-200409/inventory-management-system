using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.DataAccess;
using WebApplication1.Models;
using Response = WebApplication1.Models.Response;

namespace WebApplication1.Interfaces
{
    public interface ICategories
    {
        Response AddCategoriesDetails(Categories addCategories);
        Response GetAllCategories();
        Response GetCategoriesByCategoryId(string categoryId);
        
    }
}
