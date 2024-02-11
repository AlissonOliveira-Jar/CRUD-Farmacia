using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CRUD_Farmacia.DataAccess.DataAccess;

namespace CRUD_Farmacia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly FarmaciaContext _context;

        public ProdutoController(FarmaciaContext context)
        {
            _context = context;
        }

        // GET: api/Produto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProdutos()
        {
            return await GetProdutosListAsync();
        }

        // GET: api/Produto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> GetProduto(int id)
        {
            var produto = await GetProdutoByIdAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            return Ok(produto);
        }

        // POST: api/Produto
        [HttpPost]
        public async Task<ActionResult<Produto>> PostProduto(Produto produto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduto), new { id = produto.Id }, produto);
        }

        // PUT: api/Produto/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduto(int id, Produto produto)
        {
            return await UpdateProdutoAsync(id, produto);
        }

        // DELETE: api/Produto/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduto(int id)
        {
            return await DeleteProdutoAsync(id);
        }

        private async Task<ActionResult<IEnumerable<Produto>>> GetProdutosListAsync()
        {
            return Ok(await _context.Produtos.ToListAsync());
        }

        private async Task<ActionResult<Produto>> GetProdutoByIdAsync(int id)
        {
            var produtoTask = _context.Produtos.FindAsync(id);
            var produto = await Task.Run(() => produtoTask.Result);
            if (produto == null)
            {
                return NotFound();
            }
            return Ok(produto);
        }

        private async Task<IActionResult> CreateProdutoAsync(Produto produto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetProduto), new { id = produto.Id }, produto);
        }

        private async Task<IActionResult> UpdateProdutoAsync(int id, Produto produto)
        {
            if (id != produto.Id)
            {
                return BadRequest();
            }
            _context.Entry(produto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private async Task<IActionResult> DeleteProdutoAsync(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
