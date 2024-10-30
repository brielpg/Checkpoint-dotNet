using Checkpoint1GabrielPescarolli.Models;
using Checkpoint1GabrielPescarolli.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Checkpoint1GabrielPescarolli.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly CheckpointDbContext _context;

        private readonly Repository<Endereco> _enderecoRepository;

        public EnderecoController(CheckpointDbContext context, Repository<Endereco> enderecoRepository)
        {
            _context = context;
            _enderecoRepository = enderecoRepository;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Endereco>> GetEnderecos()
        {
            return Ok(_enderecoRepository.GetAll());
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Endereco>> GetEndereco(int id)
        {
            var endereco = await _context.Enderecos.FindAsync(id);

            if (endereco == null)
            {
                return NotFound();
            }

            return endereco;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutEndereco(int id, Endereco endereco)
        {
            if (id != endereco.Id)
            {
                return BadRequest();
            }

            _context.Entry(endereco).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnderecoExists(id))
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
        

        [HttpPost]
        public async Task<ActionResult<Endereco>> PostEndereco(Endereco endereco)
        {
            _context.Enderecos.Add(endereco);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEndereco", new { id = endereco.Id }, endereco);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEndereco(int id)
        {
            var endereco = await _context.Enderecos.FindAsync(id);
            if (endereco == null)
            {
                return NotFound();
            }

            _context.Enderecos.Remove(endereco);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EnderecoExists(int id)
        {
            return _context.Enderecos.Any(e => e.Id == id);
        }
    }
}