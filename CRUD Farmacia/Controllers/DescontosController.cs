using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CRUD_Farmacia.Models;
using static CRUD_Farmacia.DataAccess.DataAccess;

namespace CRUD_Farmacia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DescontosController : ControllerBase
    {
        private readonly FarmaciaContext _context;

        public DescontosController(FarmaciaContext context)
        {
            _context = context;
        }

        // GET: api/Descontos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Desconto>>> GetDescontos()
        {
            return await _context.Descontos.ToListAsync();
        }

        // GET: api/Descontos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Desconto>> GetDesconto(int id)
        {
            var desconto = await _context.Descontos.FindAsync(id);

            if (desconto == null)
            {
                return NotFound();
            }

            return desconto;
        }

        // PUT: api/Descontos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDesconto(int id, Desconto desconto)
        {
            if (id != desconto.Id)
            {
                return BadRequest();
            }

            _context.Entry(desconto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DescontoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Descontos
        [HttpPost]
        public async Task<ActionResult<Desconto>> PostDesconto(Desconto desconto)
        {
            _context.Descontos.Add(desconto);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDesconto), new { id = desconto.Id }, desconto);
        }

        // DELETE: api/Descontos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDesconto(int id)
        {
            var desconto = await _context.Descontos.FindAsync(id);

            if (desconto == null)
            {
                return NotFound();
            }

            _context.Descontos.Remove(desconto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DescontoExists(int id)
        {
            return _context.Descontos.Any(e => e.Id == id);
        }

        // GET: api/Descontos/AplicarDesconto/{idProduto}/{idUsuario}
        [HttpGet("AplicarDesconto/{idProduto}/{idUsuario}")]
        public async Task<ActionResult<decimal>> AplicarDesconto(int idProduto, int idUsuario)
        {
            var desconto = await _context.Descontos
                .Where(d => d.Ativo && d.DataInicio <= DateTime.Now && d.DataFim >= DateTime.Now)
                .Include(d => d.Usuario)
                .FirstOrDefaultAsync(d => d.UsuarioId == idUsuario || d.UsuarioId == null);

            if (desconto == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos.FindAsync(idProduto);

            if (produto == null)
            {
                return NotFound();
            }

            decimal valorFinal = produto.Preco.Valor;

            if (desconto.Tipo == TipoDesconto.Porcentagem)
            {
                valorFinal -= (valorFinal * desconto.Valor / 100);
            }
            else if (desconto.Tipo == TipoDesconto.ValorFixo)
            {
                valorFinal -= desconto.Valor;
            }

            return valorFinal;
        }
    }
}
