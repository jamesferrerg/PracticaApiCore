using PracticaApi.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaApi.Services
{
    public interface ICustomerRepository
    {
        IEnumerable<Customers> GetCustomers();
        Customers GetCustomers(string customerId, bool includeOrders);
        IEnumerable<Orders> GetOrders(string customerId);
        Orders GetOrder(string customerId, int orderId);
    }
}
