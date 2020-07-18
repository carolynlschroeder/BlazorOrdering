using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorOrdering.Server.Data;
using BlazorOrdering.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorOrdering.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        ApplicationDbContext db;

        public OrderDetailsController(ApplicationDbContext db)
        {
            this.db = db;
        }

        // GET api/<Order>/5
        [HttpGet("{id}")]
        public List<OrderDetail> Get(int id)
        {
            return db.OrderDetail.Include(x=>x.Product).Where(o => o.OrderId == id).ToList();
        }



        [HttpPost]
        public IActionResult Post([FromBody] OrderDetail orderDetail)
        {
            if (orderDetail == null)
            {
                return BadRequest();
            }

            try
            {
                db.OrderDetail.Add(orderDetail);
                db.SaveChanges();
                return new NoContentResult();

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var detail = db.OrderDetail.Find(id);
            if(detail == null)
            {
                return NotFound();
            }

            db.OrderDetail.Remove(detail);
            db.SaveChanges();
            return new NoContentResult();

        }


    }
}
