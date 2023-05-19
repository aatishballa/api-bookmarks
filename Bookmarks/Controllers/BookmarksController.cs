using Bookmarks.Data;
using Bookmarks.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bookmarks.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookmarksController : ControllerBase
{

    private BookmarkContext _db;

    public BookmarksController(BookmarkContext dbContext)
    {
        _db = dbContext;
    }

    [HttpGet]
    public IEnumerable<Bookmark?> Get()
    {
        return _db.Bookmark;
    }
    
    [HttpGet("{id}")]
    public Bookmark Get(int id)
    {
        return _db.Bookmark.Find(id);
    }
    
    [HttpPost]
    public IEnumerable<Bookmark> Post([FromBody] Bookmark newValue)
    {
        _db.Bookmark.Add(newValue);
        _db.SaveChanges();
        return _db.Bookmark;
    }
}