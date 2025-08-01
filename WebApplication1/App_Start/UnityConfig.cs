using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using WebApplication1.DataAccess;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // Register your interfaces and implementations
            //container.RegisterType<ITest, DATest>();
            //container.RegisterType<IUser, DAUser>();

            container.RegisterType<ICategories, DACategories>();
            container.RegisterType<IUnits, DAUnits>();
            container.RegisterType<IProducts, DAProducts>();
            container.RegisterType<ISuppliers, DASuppliers>();
            container.RegisterType<ICustomers, DACustomers>();
            container.RegisterType<IPurchaseOrders, DAPurchaseOrders>();

            // Set the dependency resolver for MVC
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}
