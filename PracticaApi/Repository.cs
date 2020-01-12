using Foundation.ObjectHydrator;
using PracticaApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaApi
{
    public class Repository
    {
        public static Repository Instance { get; } = new Repository();
        public IList<CustomerDTO> Customers { get; set; }
        public Repository()
        {
            Hydrator<CustomerDTO> hydrator = new Hydrator<CustomerDTO>();
            Customers = hydrator.GetList(5);

            Random random = new Random();
            Hydrator<OrdersDTO> ordersHydrator = new Hydrator<OrdersDTO>();
            foreach(var item in Customers)
            {
                item.Orders = ordersHydrator.GetList(random.Next(1, 10));
            }
        }
    }
}
