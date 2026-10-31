using Tour_Manager_Data.Enums;
namespace Tour_Manager_Data.Entities;

public class User: BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string? Patronymic { get; set; }
    public string Nickname { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public UserRole Role { get; set; } = UserRole.User;
    public bool IsBlocked { get; set; }
    public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;
    public DateTime? LastVisitAt { get; set; }

    public ICollection<MusicBand> ManagedBands { get; set; } = new List<MusicBand>();
    public ICollection<Venue> ManagedVenues { get; set; } = new List<Venue>();
    public ICollection<ConcertRequest> SentRequests { get; set; } = new List<ConcertRequest>();
    public ICollection<Concert> CancelledConcerts { get; set; } = new List<Concert>();
    public ICollection<FavouriteConcert> FavouriteConcerts { get; set; } = new List<FavouriteConcert>();
    public ICollection<FavouriteBand> FavouriteBands { get; set; } = new List<FavouriteBand>();
}