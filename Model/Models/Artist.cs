using Model.DB;

namespace Model.Models;

public partial class Artist : DbEntity
{
    public int ArtistId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Album> Albums { get; set; } = new List<Album>();
}
