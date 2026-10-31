namespace Tour_Manager_Data.Entities;
using Tour_Manager_Data.Enums;
public class Concert: BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime Date { get; set; }
    public decimal TicketPrice { get; set; }
    public ConcertStatus Status { get; set; } = ConcertStatus.Planned;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public string? CancellationCause { get; set; }
    public DateTime? CancelledAt { get; set; }
    
    public User? CancelledByUser { get; set; }
    
    public ConcertRequest Request { get; set; } = null!;

    public ICollection<FavouriteConcert> FavouritedBy { get; set; } = new List<FavouriteConcert>();
}