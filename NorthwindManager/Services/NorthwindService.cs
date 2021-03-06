using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using NorthwindManagerDb;

namespace NorthwindManager.Services
{
    public class NorthwindService
    {
        private readonly NorthwindManagerContext db;

        public NorthwindService(NorthwindManagerContext db)
        {
            this.db = db;
        }
        
        public List<Customer> AllCustomers()
        {
            return db.Customers.ToList();
        }

        public List<Employee> AllEmployees()
        {
            return db.Employees.ToList();
        }

        public List<Order> GetOrdersFromCustomer(string id)
        {
            return db.Orders.Include(x => x.OrderDetails).Where(x => x.CustomerId.Equals(id)).ToList();
        }

        public List<Order> GetOrdersFromEmployee(int id)
        {
            return db.Orders.Include(x => x.OrderDetails).Where(x => x.EmployeeId == id).ToList();
        }

        public List<OrderDetail> GetOrderDetailsFromOrder(int id)
        {
            return db.OrderDetails.Include(x => x.Product).Where(x => x.OrderId == id).ToList();
        }
    }
}
