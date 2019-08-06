using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace CoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        MyAppSettings _appSettings;
        public EmployeesController(IOptions<MyAppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }


        // GET: api/Employees
        //[Route("list")]
        [HttpGet]
        public IEnumerable<string> Get()
        {
           //  throw new NullReferenceException("testing Exception");
           return new string[] { "value1 Employees ", "value2 Employees" , _appSettings.EnvKey };
        }

        // GET: api/Employees/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        /// <summary>
        /// Creates a TodoItem.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Employees
        ///     {
        ///        "id": 1,
        ///        "name": "Item1",
        ///        "isComplete": true
        ///     }
        ///
        /// </remarks>
        /// <param name="value"></param>
        /// <returns>A newly created TodoItem</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response> 
        // POST: api/Employees
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Employees/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        /// <summary>
        /// Deletes a specific Employee.
        /// </summary>
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
