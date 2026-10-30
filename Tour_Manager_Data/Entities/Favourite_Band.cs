namespace Tour_Manager_Data.Entities;
using Tour_Manager_Data.Enums;
public class Favourite_Band: BaseEntity
{
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public Guid BandId { get; set; }
    public Music_Band Band { get; set; } = null!;

    public DateTime AddedAt { get; set; } = DateTime.UtcNow;
}