namespace Tour_Manager_Data.Entities;
using Tour_Manager_Data.Enums;
public class Venue: BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string VenueType { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public int Capacity { get; set; }
    public string? Description { get; set; }
    
    public User Manager { get; set; } = null!;
    public ICollection<ConcertRequest> Requests { get; set; } = new List<ConcertRequest>();
}