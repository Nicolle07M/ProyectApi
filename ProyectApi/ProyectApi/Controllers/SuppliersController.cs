using ApiRestBilling.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectApi.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProyectApi.Controllers
{
    [Route("api/[controller]")] //Framework de ruteo. Ambito Global
    [ApiController]
    public class SuppliersController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public SuppliersController(ApplicationDbContext context)
        {
<<<<<<< HEAD
            this._context=context;
        }
         
=======
            this._context = context;
        }

>>>>>>> feature/models

        // GET: api/<SuppliersController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Supplier>>> Get()
        {
            if (_context.Suppliers == null)
            {
                return NotFound();
            }
<<<<<<< HEAD
            return await _context.Suppliers.ToListAsync(); 
                
        }

        // GET api/<SuppliersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
=======
            return await _context.Suppliers.ToListAsync();

        }

        // GET api/<SuppliersController>/5
        [HttpGet("{id}")] // Variables de ruta  https://localhost:7030/api/suppliers/5 
        public async Task<ActionResult<Supplier>> Get(int id)
        {

            if (_context.Suppliers == null
)
            {
                return NotFound();
            }

            var supplier = await _context.Suppliers.FindAsync(id);

            if (supplier is null)
            {
                return NotFound();
            }


            return supplier;
>>>>>>> feature/models
        }

        // POST api/<SuppliersController>
        [HttpPost]
<<<<<<< HEAD
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SuppliersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
=======
        public async Task<ActionResult<Supplier>> Post([FromBody] Supplier supplier)
        {
            if (supplier is null)
            {
                return Problem("Entity set 'ApplicationDbContext.Suppliers'  is null.");
            }
            _context.Suppliers.Add(supplier);
            await _context.SaveChangesAsync();
            return CreatedAtAction("Get", new {id = supplier.Id}, supplier);
        }


        // PUT api/<SuppliersController>/5
        [HttpPut("{id}")]
        public async  Task<ActionResult> Put(int id, [FromBody] Supplier supplier)
        {
            if (id!= supplier.Id)
            {
                return BadRequest();
            }
            _context.Entry(supplier).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupplierExists(id))
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

        private bool SupplierExists(int id)
        {
            return (_context.Suppliers?.Any(s=>s.Id == id)).GetValueOrDefault();
>>>>>>> feature/models
        }

        // DELETE api/<SuppliersController>/5
        [HttpDelete("{id}")]
<<<<<<< HEAD
        public void Delete(int id)
        {
=======
        public async Task<IActionResult> Delete(int id)
        {
            if (_context.Suppliers is null)
            {
                return NotFound();
            }
            var supplier = await _context.Suppliers.FirstOrDefaultAsync(s => s.Id==id);
            if (supplier == null){
                return NotFound();
            }
            _context.Suppliers.Remove(supplier);
            await _context.SaveChangesAsync();
            return NoContent();
>>>>>>> feature/models
        }
    }
}
