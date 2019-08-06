using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using CoreAPI.DatabaseModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientUserController : ControllerBase
    {
        MyAppSettings _appSettings;

        CoreAPI.DatabaseModels.MyDbContext _context;
        public ClientUserController(IOptions<MyAppSettings> appSettings, CoreAPI.DatabaseModels.MyDbContext context)
        {
            _appSettings = appSettings.Value;
            _context = context;
        }


        // GET: api/Employees
        [Route("list")]
        [HttpGet]
        public List<DatabaseModels.Clientuser> GetClientUserFromEFCore()
        {
            var clientUserList = _context.Clientuser.ToList();


            //var clientUserListgroupBy = _context.Clientuser.GroupBy(ee => ee.Nclientlocationid).FirstOrDefault().ToList();
            //var clistSP = _context.Clientuser.FromSql("---Store procedure Name--").ToList();
            //var clistSPOnlyRequiredField = _context.Clientuser.FromSql("---StoreprocedureName_WITH_required--").ToList(); // with required

            var clistSPJoin = _context.Clientuser.FromSql("---StoreprocedureName_WITH_JOIN--").ToList(); // with join

            return clientUserList;
        }

        //// GET: api/Employees/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Employees
        [HttpPost]
        public bool AddClientUserFromDBEntityCore(Clientuser clientUser)
        {
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@nclinetuserid", clientUser.Nclientuserid),
                new SqlParameter("@Nclientlocationid", clientUser.Nclientlocationid),
            };

            //calling sp
            var result = _context.Database.ExecuteSqlCommand("Sp_NameHere @nclinetuserid @Nclientlocationid", parameters);

            return result > 0;
        }

        // PUT: api/Employees/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
