namespace Tour_Manager_Data.Entities;

public class FavouriteConcert: BaseEntity
{
    public User User { get; set; } = null!;
    
    public Concert Concert { get; set; } = null!;

    public DateTime AddedAt { get; set; } = DateTime.UtcNow;
}