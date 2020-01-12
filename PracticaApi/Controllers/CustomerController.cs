using Microsoft.AspNetCore.Mvc;
using PracticaApi.Models;
using PracticaApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaApi.Controllers
{
    [Route("api/customers")]
    public class CustomerController : Controller
    {
        private ICustomerRepository _customerRepository;
        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public IActionResult GetCustomers()
        {
            var customers = _customerRepository.GetCustomers();
            var result = new List<CustomerWithOutOrders>();
            foreach(var item in customers)
            {
                result.Add(new CustomerWithOutOrders() 
                { 
                    CustomerID=item.CustomerId,
                    CompanyName=item.CompanyName,
                    ContactName=item.ContactName,
                    ContactTitle=item.ContactTitle,
                    Address=item.Address,
                    City=item.City,
                    Region=item.Region,
                    PostalCode=item.PostalCode,
                    Country=item.Country,
                    Phone=item.Phone,
                    Fax=item.Fax

                });
            }
            return new JsonResult(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetResult(int id)
        {
            var result =
                Repository.Instance.Customers
                .FirstOrDefault(c => c.Id == id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
            //return new JsonResult(result);
        }
    }
}
