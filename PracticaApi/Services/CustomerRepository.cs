using Microsoft.EntityFrameworkCore;
using PracticaApi.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaApi.Services
{
    public class CustomerRepository : ICustomerRepository
    {
        private NorthwindContext _context;
        public CustomerRepository(NorthwindContext context)
        {
            _context = context;
        }
        public IEnumerable<Customers> GetCustomers()
        {
            return
                _context.Customers.OrderBy(c => c.CompanyName).ToList();
        }

        public Customers GetCustomers(string customerId, bool includeOrders)
        {
            if (includeOrders)
            {
                return _context.Customers
                    .Include(c => c.Orders)
                    .Where(c => c.CustomerId == customerId)
                    .FirstOrDefault();
            }
            return _context.Customers
                .Where(c => c.CustomerId == customerId)
                .FirstOrDefault();
        }

        public Orders GetOrder(string customerId, int orderId)
        {
            return _context.Orders
                .Where(c => c.CustomerId == customerId &&
                c.OrderId == orderId)
                .FirstOrDefault();
        }

        public IEnumerable<Orders> GetOrders(string customerId)
        {
            return _context.Orders
                .Where(c => c.CustomerId == customerId).ToList();
        }
    }
}
