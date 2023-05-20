using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookmarks.Models;

[Table("Bookmark")]
public class Bookmark
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set;}
    public string Url { get; set; }
    public string Created { get; set; }
}