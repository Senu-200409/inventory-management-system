using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public interface ICustomers
    {
        Response AddCustomersDetails(CustomersModel addCustomers);
        Response GetAllCustomers();
        Response GetCustomersByCustomerId(string customersId);

    }
}

