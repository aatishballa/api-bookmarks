using Bookmarks.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookmarks.Data;

public class BookmarkContext : DbContext
{
    public BookmarkContext(DbContextOptions<BookmarkContext> options) : base(options)
    {
    }
    
    public DbSet<Bookmark?> Bookmark { get; set; }
}