using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public interface ISalesOrders
    {
        Response AddSalesOrdersDetails(SalesOrdersModel addSalesOrders);
        Response GetAllSalesOrders();
        Response GetSalesOrdersBySalesOrderId(string SalesOrderId);

    }
}

