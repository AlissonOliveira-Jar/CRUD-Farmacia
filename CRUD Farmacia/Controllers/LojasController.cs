using System.ComponentModel.DataAnnotations;
using CRUD_Farmacia.Models;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<IEnumerable<Loja>>> GetLojas()
        {
            return await _context.Lojas.ToListAsync();
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
            if (await _context.Lojas.AnyAsync(l => l.Nome == loja.Nome))
            {
                return BadRequest("Já existe uma loja com este nome.");
            }

            if (!string.IsNullOrEmpty(loja.Telefone) && !Regex.IsMatch(loja.Telefone, @"^\d+$"))
            {
                return BadRequest("O telefone da loja deve conter apenas números.");
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

            // Validação de regras de negócio
            if (await _context.Lojas.AnyAsync(l => l.Nome == loja.Nome && l.Id != loja.Id))
            {
                return BadRequest("Já existe uma loja com este nome.");
            }

            if (!string.IsNullOrEmpty(loja.Telefone) && !Regex.IsMatch(loja.Telefone, @"^\d+$"))
            {
                return BadRequest("O telefone da loja deve conter apenas números.");
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
