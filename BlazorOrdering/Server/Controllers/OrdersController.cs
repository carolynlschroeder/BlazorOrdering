using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using BlazorOrdering.Server.Data;
using BlazorOrdering.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlazorOrdering.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        ApplicationDbContext db;

        public OrdersController(ApplicationDbContext db)
        {
            this.db = db;
        }

        // GET: api/<Order>
        [HttpGet]
        public List<Order> Get()
        {
            //var orders =  db.Order.ToList();
            //return orders;
            return db.Order.Include(x=>x.Customer).ToList();
        }

        // GET api/<Order>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var order = db.Order.Include(x => x.Customer).FirstOrDefault(o => o.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        // POST api/<Order>
        [HttpPost]
        public IActionResult Post([FromBody] Order order)
        {
            if (order == null)
            {
                return BadRequest();
            }

            try
            {
                //_context.Contact.Add(contact);
                //_context.SaveChanges();
                //return CreatedAtRoute("GetContact", new { id = contact.ContactId }, contact);
                db.Order.Add(order);
                db.SaveChanges();
                return CreatedAtRoute("", new {id = order.Id}, order);

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // PUT api/<Order>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Order>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
