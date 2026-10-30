namespace Tour_Manager_Data.Entities;
using Tour_Manager_Data.Enums;
public class Music_Band: BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Genre { get; set; } = string.Empty;
    public string? Description { get; set; }
    public Popularity_Lvl PopularityLvl { get; set; } = Popularity_Lvl.Low;
    public bool AcceptsVenueInvitations { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }

    public Guid ManagerId { get; set; }
    public User Manager { get; set; } = null!;

    public ICollection<Concert> Concerts { get; set; } = new List<Concert>();
    public ICollection<Concert_Request> Requests { get; set; } = new List<Concert_Request>();
    public ICollection<Favourite_Band> FavouritedBy { get; set; } = new List<Favourite_Band>();
}