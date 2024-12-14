using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaCSF.Data;
using PruebaCSF.Models;

namespace PruebaCSF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        private readonly DataContext _context;

        public LibrosController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Libros>> CrearLibro(Libros libro)
        {
            _context.Libros.Add(libro);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetLibro", new { id = libro.Id }, libro);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarLibro(int id, Libros libro)
        {
            if (id != libro.Id) return BadRequest();

            _context.Entry(libro).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarLibro(int id)
        {
            var libro = await _context.Libros.FindAsync(id);
            if (libro == null) return NotFound();

            _context.Libros.Remove(libro);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Libros>> GetLibro(int id)
        {
            var libro = await _context.Libros.FindAsync(id);
            if (libro == null) return NotFound();
            return libro;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Libros>>> GetLibros()
        {
            return await _context.Libros.ToListAsync();
        }

        [HttpGet("porAutor/{autor}")]
        public async Task<ActionResult<IEnumerable<Libros>>> GetLibrosPorAutor(string autor)
        {
            var libros = await _context.Libros
                .Where(l => l.Autores.Contains(autor))
                .ToListAsync();
            return libros;
        }
    }
}
