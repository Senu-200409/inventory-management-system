﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public interface IPurchaseOrders
    {
        Response AddPurchaseOrdersDetails(PurchaseOrdersModel addPurchaseOrders);
        Response GetAllPurchaseOrders();
        Response GetPurchaseOrdersByPurchaseOrderId(string purchaseorderId);

    }
}

