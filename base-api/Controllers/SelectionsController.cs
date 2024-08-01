using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using baseapi.Models;

namespace base_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SelectionsController : ControllerBase
    {
        private readonly SelectionContext _context;

        public SelectionsController(SelectionContext context)
        {
            _context = context;
        }

        // GET: api/Selections
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Selection>>> GetSelections()
        {
            return await _context.Selections.ToListAsync();
        }

        // GET: api/Selections/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Selection>> GetSelection(string id)
        {
            var selection = await _context.Selections.FindAsync(id);

            if (selection == null)
            {
                return NotFound();
            }

            return selection;
        }

        // PUT: api/Selections/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSelection(string id, Selection selection)
        {
            if (id != selection.Id)
            {
                return BadRequest();
            }

            _context.Entry(selection).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SelectionExists(id))
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

        // POST: api/Selections
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Selection>> PostSelection(Selection selection)
        {
            _context.Selections.Add(selection);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SelectionExists(selection.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction(nameof(GetSelection), new { id = selection.Id }, selection);
        }

        // DELETE: api/Selections/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSelection(string id)
        {
            var selection = await _context.Selections.FindAsync(id);
            if (selection == null)
            {
                return NotFound();
            }

            _context.Selections.Remove(selection);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SelectionExists(string id)
        {
            return _context.Selections.Any(e => e.Id == id);
        }
    }
}
