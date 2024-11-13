using Examen3P.Data;
using Examen3P.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace Examen3P.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculaController : Controller
    {
        private readonly PeliculaContext _context;

        public PeliculaController(PeliculaContext context)
        {
            _context = context;
        }

        //GET
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pelicula>>> GetPeliculas()
        {
            return await _context.peliculas.ToListAsync();
        }

        //GET por id
        [HttpGet("{id}")]
        public async Task<ActionResult<Pelicula>> GetPeliculas(int id)
        {
            var peli = await _context.peliculas.FindAsync(id);
            if (peli == null)
            {
                return NotFound();
            }
            return peli;
        }

        //POST
        [HttpPost]
        public async Task<ActionResult<Pelicula>> PostPeliculas(Pelicula peli)
        {
            _context.peliculas.Add(peli);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetPeliculas", new { id = peli.Id }, peli);
        }

        //PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPelicula(int id, Pelicula peli)
        {
            if (id != peli.Id)
            {
                return BadRequest();
            }
            _context.Entry(peli).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.peliculas.Any(e => e.Id == id))
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

        //DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePelicula(int id)
        {
            var peli = await _context.peliculas.FindAsync(id);
            if (peli == null)
            {
                return NotFound();
            }
            _context.peliculas.Remove(peli);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
