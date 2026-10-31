namespace Tour_Manager_Data.Entities;
using Tour_Manager_Data.Enums;
public class FavouriteBand: BaseEntity
{
    public User User { get; set; } = null!;
    
    public MusicBand Band { get; set; } = null!;

    public DateTime AddedAt { get; set; } = DateTime.UtcNow;
}