using Bookmarks.Data;
using Bookmarks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bookmarks.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookmarksController : ControllerBase
{
    private BookmarkContext _context;
    public BookmarksController(BookmarkContext dbContext)
    {
        _context = dbContext;
    }
    [HttpGet]
    public async Task<ActionResult<List<Bookmark>>> GetAllBookmarks()
    {
        return await _context.Bookmark.ToListAsync();
    }
    
    [HttpGet("{id}", Name = "GetBookmarkById")]
    public async Task<ActionResult<Bookmark>> GetBookmarkById(int id)
    {
        var bookmark =  await _context.Bookmark.FindAsync(id);
        if (bookmark == null)
        {
            return NotFound();
        }
        return Ok(bookmark);
    }

    [HttpPost]
    public async Task<ActionResult<Bookmark>> AddBookmark(Bookmark newBookmark)
    {
        _context.Bookmark.Add(newBookmark);
        var result = await _context.SaveChangesAsync() > 0;
        if (result)
        {
            return CreatedAtRoute("GetBookmarkById", new { Id = newBookmark.Id }, newBookmark);
        }
        return BadRequest();
    }

    [HttpPut]
    public async Task<ActionResult<Bookmark>> UpdateBookmark(Bookmark bookmark)
    {
        _context.Bookmark.Update(bookmark);
        await _context.SaveChangesAsync();
        return Ok(bookmark);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Bookmark>> DeleteBookmark(int id)
    {
        var result = await _context.Bookmark.FindAsync(id);
        if (result == null)
        {
            return NotFound();
          
        }
        _context.Bookmark.Remove(result);
        await _context.SaveChangesAsync();
        return Ok();
    }
}