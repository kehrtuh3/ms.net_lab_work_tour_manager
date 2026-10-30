namespace Tour_Manager_Data.Entities;
using Tour_Manager_Data.Enums;
public class Concert: BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime Date { get; set; }
    public decimal TicketPrice { get; set; }
    public Concert_Status Status { get; set; } = Concert_Status.Planned;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public string? CancellationCause { get; set; }
    public DateTime? CancelledAt { get; set; }

    public Guid? CancelledByUserId { get; set; }
    public User? CancelledByUser { get; set; }

    // концерт создаётся только из принятой заявки
    public Guid RequestId { get; set; }
    public Concert_Request Request { get; set; } = null!;

    public Guid BandId { get; set; }
    public Music_Band Band { get; set; } = null!;

    public Guid VenueId { get; set; }
    public Venue Venue { get; set; } = null!;

    public ICollection<Favourite_Concert> FavouritedBy { get; set; } = new List<Favourite_Concert>();
}