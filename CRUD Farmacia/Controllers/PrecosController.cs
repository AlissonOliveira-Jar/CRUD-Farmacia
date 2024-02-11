using CRUD_Farmacia.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CRUD_Farmacia.DataAccess.DataAccess;

namespace CRUD_Farmacia.Controllers
{
    public class PrecoController : Controller
    {
        private readonly FarmaciaContext _context;

        public PrecoController(FarmaciaContext context)
        {
            _context = context;
        }

        // GET: api/Preco
        public async Task<ActionResult<IEnumerable<Preco>>> GetPrecos()
        {
            return await _context.Precos.ToListAsync();
        }

        // GET: api/Preco/5
        public async Task<ActionResult<Preco>> GetPreco(int id)
        {
            var preco = await _context.Precos.FindAsync(id);

            if (preco == null)
            {
                return NotFound();
            }

            return preco;
        }

        // POST: api/Preco
        public async Task<ActionResult<Preco>> PostPreco(Preco preco)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Precos.Add(preco);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPreco), new { id = preco.Id }, preco);
        }

        // PUT: api/Preco/5
        public async Task<IActionResult> PutPreco(int id, Preco preco)
        {
            if (id != preco.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(preco).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Preco/5
        public async Task<IActionResult> DeletePreco(int id)
        {
            var preco = await _context.Precos.FindAsync(id);

            if (preco == null)
            {
                return NotFound();
            }

            _context.Precos.Remove(preco);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }

}
