using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using baseapi.Models;
using Newtonsoft.Json;
using System.Text.Json;

namespace baseapi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class SelectionsController : ControllerBase
  {
    private readonly BaseapiContext _context;

    public SelectionsController(BaseapiContext context)
    {
      _context = context;
    }

    // GET: api/Selections
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Selection>>> GetSelections()
    {
      var data = await _context.Selections.ToListAsync();

      // return Json(data);

      string json = JsonConvert.SerializeObject(data, Formatting.Indented);

      return new JsonResult(
        data,
        new JsonSerializerOptions { PropertyNamingPolicy = null });
    }

    // GET: api/Selections/trending
    [HttpGet("trending")]
    public async Task<ActionResult<IEnumerable<Selection>>> GetTrendingSelections()
    {
      var data = await _context.Selections.Where(Selection => Selection.IsTrending)
      .Include(Thumb => Thumb.Thumbnail)
        .ThenInclude(Trend => Trend.Trending)
      .ToListAsync();
      return data;
    }

    // GET: api/Selections/recommended
    [HttpGet("recommended")]
    public async Task<ActionResult<IEnumerable<Selection>>> GetRecommendedSelections()
    {
      var data = await _context.Selections.Where(Selection => !Selection.IsTrending)
      .Include(Thumb => Thumb.Thumbnail)
        .ThenInclude(Reg => Reg.Regular)
      .ToListAsync();
      return data;
    }

    // GET: api/Selections/series
    [HttpGet("series")]
    public async Task<ActionResult<IEnumerable<Selection>>> GetSeries()
    {
      var data = await _context.Selections.Where(Selection => Selection.Category == "TV Series")
      .Include(Thumb => Thumb.Thumbnail)
        .ThenInclude(Reg => Reg.Regular)
      .ToListAsync();
      return data;
    }

    // GET: api/Selections/movies
    [HttpGet("movies")]
    public async Task<ActionResult<IEnumerable<Selection>>> GetMovies()
    {
      var data = await _context.Selections.Where(Selection => Selection.Category == "Movie")
      .Include(Thumb => Thumb.Thumbnail)
        .ThenInclude(Reg => Reg.Regular)
      .ToListAsync();
      return data;
    }

    // GET: api/Selections/bookmarks
    [HttpGet("bookmarks")]
    public async Task<ActionResult<IEnumerable<Selection>>> GetBookmarks()
    {
      var data = await _context.Selections.Where(Selection => Selection.IsBookmarked)
      .Include(Thumb => Thumb.Thumbnail)
        .ThenInclude(Reg => Reg.Regular)
      .ToListAsync();
      return data;
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
