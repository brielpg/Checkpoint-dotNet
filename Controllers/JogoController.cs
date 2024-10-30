using Checkpoint1GabrielPescarolli.Models;
using Checkpoint1GabrielPescarolli.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Checkpoint1GabrielPescarolli.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JogoController : ControllerBase
    {
        private readonly CheckpointDbContext _context;

        private readonly Repository<Jogo> _jogoRepository;

        public JogoController(CheckpointDbContext context, Repository<Jogo> jogoRepository)
        {
            _context = context;
            _jogoRepository = jogoRepository;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Jogo>> GetJogos()
        {
            return Ok(_jogoRepository.GetAll());
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Jogo>> GetJogo(int id)
        {
            var jogo = await _context.Jogos.FindAsync(id);

            if (jogo == null)
            {
                return NotFound();
            }

            return jogo;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutJogo(int id, Jogo jogo)
        {
            if (id != jogo.Id)
            {
                return BadRequest();
            }

            _context.Entry(jogo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JogoExists(id))
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
        public async Task<ActionResult<Jogo>> PostJogo(Jogo jogo)
        {
            _context.Jogos.Add(jogo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJogo", new { id = jogo.Id }, jogo);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJogo(int id)
        {
            var jogo = await _context.Jogos.FindAsync(id);
            if (jogo == null)
            {
                return NotFound();
            }

            _context.Jogos.Remove(jogo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JogoExists(int id)
        {
            return _context.Jogos.Any(e => e.Id == id);
        }
    }
}