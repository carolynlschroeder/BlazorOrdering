using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorOrdering.Server.Data;
using BlazorOrdering.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorOrdering.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        ApplicationDbContext db;

        public CustomersController(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public List<Customer> Get()
        {
            return db.Customer.ToList();
        }
    }
}
