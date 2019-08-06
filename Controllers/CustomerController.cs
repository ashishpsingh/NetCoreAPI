using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using CoreAPI.DatabaseModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        MyAppSettings _appSettings;
        CoreAPI.DatabaseModels.MyDbContext _context;
        public CustomerController(IOptions<MyAppSettings> appSettings, CoreAPI.DatabaseModels.MyDbContext context)
        {
            _appSettings = appSettings.Value;
            _context = context;
        }


        // GET: api/Customer
        [Route("list")]
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return _context.Customer.ToList();
        }

        // GET: api/Customer/5
        [HttpGet("{id}", Name = "Get")]
        public Customer Get(int id)
        {
            return _context.Customer.Where(c => c.Customerid == id).FirstOrDefault();
        }


        /// <summary>
        /// Creates a Customer.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Customer
        ///     {
        ///        "name": "Item1",
        ///        "address": true
        ///     }
        ///
        /// </remarks>
        /// <param name="customer"></param>
        /// <returns>A newly created TodoItem</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response> 
        // POST: api/Employees
        // POST: api/Customer
        [HttpPost]
        public bool Post(Customer customer)
        {
            try
            {
                _context.Customer.Add(customer);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // PUT: api/Customer/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Customer customer)
        {
            _context.Update(customer);
            _context.SaveChanges();        
        }

        /// <summary>
        /// Deletes a specific Customer.
        /// </summary>
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            try
            {
                //Clientuser user = _context.Clientuser.Find(id);
                //_context.Clientuser.Remove(user);
                //_context.SaveChanges();

                // Faster
                Customer customer = new Customer() { Customerid = id };
                _context.Entry(customer).State = EntityState.Deleted;
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
