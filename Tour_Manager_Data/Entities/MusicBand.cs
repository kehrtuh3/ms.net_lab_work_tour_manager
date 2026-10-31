namespace Tour_Manager_Data.Entities;
using Tour_Manager_Data.Enums;
public class MusicBand: BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Genre { get; set; } = string.Empty;
    public string? Description { get; set; }
    public PopularityLvl PopularityLvl { get; set; } = PopularityLvl.Low;
    public bool AcceptsVenueInvitations { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    
    public User Manager { get; set; } = null!;

    public ICollection<ConcertRequest> Requests { get; set; } = new List<ConcertRequest>();
    public ICollection<FavouriteBand> FavouritedBy { get; set; } = new List<FavouriteBand>();
}