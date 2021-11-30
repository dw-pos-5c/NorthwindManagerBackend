using Microsoft.AspNetCore.Mvc;
using NorthwindManager.Dtos;
using NorthwindManagerDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

using NorthwindManager.Services;

namespace NorthwindManager.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NorthwindController : ControllerBase
    {
        private readonly NorthwindService northwindService;

        public NorthwindController(NorthwindService northwindService)
        {
            this.northwindService = northwindService;
        }

        [HttpGet("Customers")]
        public IActionResult GetCustomers()
        {
            return Ok(northwindService.AllCustomers().Select(x => new CustomerDto{
                Id = x.CustomerId,
                City = x.City,
                CompanyName = x.CompanyName,
                ContactName = x.ContactName,
                Country = x.Country,
            }));
        }


        [HttpGet("Employees")]
        public IActionResult GetEmployees()
        {
            return Ok(northwindService.AllEmployees().Select(x => new EmployeeDto()
            {
                Id = x.EmployeeId,
                City = x.City,
                Country = x.Country,
                Name = $"{x.FirstName} {x.LastName}",
            }));
        }

        [HttpGet("OrdersFromCustomer/{id}")]
        public IActionResult GetOrders(string id)
        {
            return Ok(northwindService.GetOrdersFromCustomer(id).Select(x => new OrderDto
            {
                Id = x.OrderId,
                NrOrderDetails = x.OrderDetails.Count,
                OrderDate = x.OrderDate,
                RequiredDate = x.RequiredDate,
                ShippedDate = x.ShippedDate,
            }));
        }

        [HttpGet("OrdersFromEmployee/{id}")]
        public IActionResult GetOrders(int id)
        {
            return Ok(northwindService.GetOrdersFromEmployee(id).Select(x => new OrderDto {
                Id = x.OrderId,
                NrOrderDetails = x.OrderDetails.Count,
                OrderDate = x.OrderDate,
                RequiredDate = x.RequiredDate,
                ShippedDate = x.ShippedDate,
            }));
        }

        [HttpGet("OrderDetails/{id}")]
        public IActionResult GetOrderDetails(int id)
        {
            return Ok(northwindService.GetOrderDetailsFromOrder(id).Select(x => new OrderDetailsDto
            {
                OrderId = x.OrderId,
                ProductName = x.Product.ProductName,
                Quantity = x.Quantity,
                UnitPrice = x.UnitPrice,
            }));
        }
    }
}
