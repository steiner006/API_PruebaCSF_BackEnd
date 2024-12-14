using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaCSF.Data;
using PruebaCSF.Models;

namespace PruebaCSF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoresController : ControllerBase
    {
        private readonly DataContext _context;

        public AutoresController(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpPost]
        public async Task<ActionResult<Autores>> CrearAutor(Autores autor)
        {
            //_context.Autores.Add(autor);
            //await _context.SaveChangesAsync();
            //return CreatedAtAction("GetAutor", new { id = autor.Id }, autor);

            if (autor == null)
            {
                return BadRequest();
            }

            _context.Autores.Add(autor);
            await _context.SaveChangesAsync();

            // Devuelves el autor creado, incluyendo el Id generado automáticamente
            return CreatedAtAction(nameof(GetAutores), new { id = autor.Id }, autor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarAutor(int id, Autores autor)
        {
            if (id != autor.Id) return BadRequest();

            _context.Entry(autor).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Autores>> GetAutor(int id)
        {
            var autor = await _context.Autores.FindAsync(id);
            if (autor == null)
            {
                return NotFound();
            }
            return autor;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Autores>>> GetAutores()
        {
            return await _context.Autores.ToListAsync();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarAutor(int Id)
        {
            var autor = await _context.Autores.FindAsync(Id);
            if (autor == null)
            {
                return NotFound();
            }

            _context.Autores.Remove(autor);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
