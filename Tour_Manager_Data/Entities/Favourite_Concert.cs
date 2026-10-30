namespace Tour_Manager_Data.Entities;

public class Favourite_Concert: BaseEntity
{
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public Guid ConcertId { get; set; }
    public Concert Concert { get; set; } = null!;

    public DateTime AddedAt { get; set; } = DateTime.UtcNow;
}