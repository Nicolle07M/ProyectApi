using ApiRestBilling.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectApi.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProyectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {

            this._context = context;
        }

        // GET: api/<OrdersController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> Get()
        {
            if (_context.Orders == null)
            {
                return NotFound();
            }

            return await _context.Orders.Include(io=>io.OrderItems).ToListAsync();

        }



        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> Get(int id)
        {

            if (_context.Orders == null
)
            {
                return NotFound();
            }

            //var order = await _context.Orders.FindAsync(id);

            var order = await _context.Orders.Include(oi=> oi.OrderItems).FirstOrDefaultAsync(o => o.Id == id);

            if (order is null)
            {
                return NotFound();
            }
            return order;
        }



        // POST api/<OrdersController>
        [HttpPost]
        public async Task<ActionResult<Order>> Post([FromBody] Order order)
        {
            if (_context.Orders == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Orders'  is null.");
            }

            //Calcular el total de la orden de Compra 

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetOrder", new { id = order.Id }, order);
        }



        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Order order)
        {

            if (id != order.Id)
            {
                return BadRequest();
            }
            _context.Entry(order).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

                if (!OrdersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    return BadRequest();
                }
            }
            return NoContent();
        }

        private bool OrdersExists(int id)
        {
            return (_context.Suppliers?.Any(o => o.Id == id)).GetValueOrDefault();
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (_context.Orders is null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return NoContent();

        }
    }
}
