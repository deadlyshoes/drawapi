using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DrawApi.Models;
using Microsoft.AspNetCore.Cors;
using NuGet.Versioning;

namespace DrawApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShapeController : ControllerBase
    {
        private readonly ShapeContext _context;

        public ShapeController(ShapeContext context)
        {
            _context = context;
        }

        // GET: api/Shape
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shape>>> Getshapes()
        {
            return await _context.shapes.ToListAsync();
        }

        // GET: api/Shape/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Shape>> GetShape(int id)
        {
            var shape = await _context.shapes.FindAsync(id);

            if (shape == null)
            {
                return NotFound();
            }

            return shape;
        }

        // GET: api/Shape/user/5
        [EnableCors("AnotherPolicy")]
        [HttpGet("user/{id}")]
        public async Task<ActionResult<List<Shape>>> GetUserShapes(int id)
        {
            return await _context.shapes.Where(s => s.userId == id).ToListAsync();
        }

        // PUT: api/Shape/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShape(int id, Shape shape)
        {
            if (id != shape.id)
            {
                return BadRequest();
            }

            _context.Entry(shape).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShapeExists(id))
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

        // POST: api/Shape
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [EnableCors("AnotherPolicy")]
        [HttpPost]
        public async Task<ActionResult<Shape>> PostShape([FromBody] Shape shape)
        {
            var user = await _context.users.FindAsync(shape.userId);
            if (user == null)
            {
                return BadRequest();
            }
            shape.user = user;

            _context.shapes.Add(shape);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShape", new { id = shape.id }, shape);
        }

        // DELETE: api/Shape/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShape(int id)
        {
            var shape = await _context.shapes.FindAsync(id);
            if (shape == null)
            {
                return NotFound();
            }

            _context.shapes.Remove(shape);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ShapeExists(int id)
        {
            return _context.shapes.Any(e => e.id == id);
        }
    }
}
