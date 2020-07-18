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
    public class ProductsController : ControllerBase
    {
        ApplicationDbContext db;

        public ProductsController(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public List<Product> Get()
        {
            return db.Product.ToList();
        }
    }
}
