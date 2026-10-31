namespace Tour_Manager_Data.Entities;
using Tour_Manager_Data.Enums;
public class ConcertRequest: BaseEntity
{
    public RequestStatus Status { get; set; } = RequestStatus.Waiting;
    public DateTime ProposedDate { get; set; }
    public string? Message { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? AnswerDate { get; set; }
    public string? AnswerMessage { get; set; }
    
    public MusicBand Band { get; set; } = null!;
    
    public Venue Venue { get; set; } = null!;
    
    public User RequestedBy { get; set; } = null!;
    
    public Concert? Concert { get; set; }
}