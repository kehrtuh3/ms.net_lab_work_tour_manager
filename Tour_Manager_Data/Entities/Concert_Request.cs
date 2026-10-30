namespace Tour_Manager_Data.Entities;
using Tour_Manager_Data.Enums;
public class Concert_Request: BaseEntity
{
    public Request_Status Status { get; set; } = Request_Status.Waiting;
    public DateTime ProposedDate { get; set; }
    public string? Message { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? AnswerDate { get; set; }
    public string? AnswerMessage { get; set; }

    public Guid BandId { get; set; }
    public Music_Band Band { get; set; } = null!;

    public Guid VenueId { get; set; }
    public Venue Venue { get; set; } = null!;
    
    public Guid RequestedById { get; set; }
    public User RequestedBy { get; set; } = null!;
    
    public Concert? Concert { get; set; }
}