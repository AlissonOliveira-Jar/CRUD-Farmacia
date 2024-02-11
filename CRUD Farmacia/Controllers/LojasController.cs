using Microsoft.AspNetCore.Mvc;
using CRUD_Farmacia.Models;
using Microsoft.EntityFrameworkCore;
using static CRUD_Farmacia.DataAccess.DataAccess;

namespace CRUD_Farmacia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LojaController : Controller
    {
        private readonly FarmaciaContext _context;

        public LojaController(FarmaciaContext context)
        {
            _context = context;
        }

        // GET: api/Loja
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Loja>>> GetLojas(
          [FromQuery] int page = 1,
          [FromQuery] int pageSize = 10,
          [FromQuery] string? sort = null)
        {
            var query = _context.Lojas.AsQueryable();

            // Ordenação
            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort)
                {
                    case "nome":
                        query = query.OrderBy(l => l.Nome);
                        break;
                    case "telefone":
                        query = query.OrderBy(l => l.Telefone);
                        break;
                }
            }

            // Paginação
            var lojas = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            return Ok(lojas);
        }

        // GET: api/Loja/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Loja>> GetLoja(int id)
        {
            var loja = await _context.Lojas.FindAsync(id);

            if (loja == null)
            {
                return NotFound();
            }

            return loja;
        }

        // POST: api/Loja
        [HttpPost]
        public async Task<ActionResult<Loja>> PostLoja(Loja loja)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Lojas.Add(loja);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetLoja), new { id = loja.Id }, loja);
        }

        // PUT: api/Loja/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoja(int id, Loja loja)
        {
            if (id != loja.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(loja).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Loja/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoja(int id)
        {
            var loja = await _context.Lojas.FindAsync(id);

            if (loja == null)
            {
                return NotFound();
            }

            _context.Lojas.Remove(loja);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // GET: api/Loja/BuscarPorNome?nome=...
        [HttpGet("BuscarPorNome")]
        public async Task<ActionResult<IEnumerable<Loja>>> BuscarPorNome(string nome)
        {
            return await _context.Lojas.Where(l => l.Nome.Contains(nome)).ToListAsync();
        }

        // GET: api/Loja/ObterProdutos/5
        [HttpGet("{id}/ObterProdutos")]
        public async Task<ActionResult<IEnumerable<Produto>>> ObterProdutos(int id)
        {
            var loja = await _context.Lojas.Include(l => l.Produtos).FirstOrDefaultAsync(l => l.Id == id);

            if (loja == null)
            {
                return NotFound();
            }

            return loja.Produtos;
        }
    }
}
