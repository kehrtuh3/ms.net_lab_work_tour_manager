using Tour_Manager_Data.Enums;
namespace Tour_Manager_Data.Entities;

public class User: BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string? Patronymic { get; set; }
    public string Nickname { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public User_Role Role { get; set; } = User_Role.User;
    public bool IsBlocked { get; set; }
    public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;
    public DateTime? LastVisitAt { get; set; }

    public ICollection<Music_Band> ManagedBands { get; set; } = new List<Music_Band>();
    public ICollection<Venue> ManagedVenues { get; set; } = new List<Venue>();
    public ICollection<Concert_Request> SentRequests { get; set; } = new List<Concert_Request>();
    public ICollection<Concert> CancelledConcerts { get; set; } = new List<Concert>();
    public ICollection<Favourite_Concert> FavouriteConcerts { get; set; } = new List<Favourite_Concert>();
    public ICollection<Favourite_Band> FavouriteBands { get; set; } = new List<Favourite_Band>();
}