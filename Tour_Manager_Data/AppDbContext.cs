namespace Tour_Manager_Data;
using Microsoft.EntityFrameworkCore;
using Tour_Manager_Data.Entities;
public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users => Set<User>();
    public DbSet<Music_Band> Bands => Set<Music_Band>();
    public DbSet<Venue> Venues => Set<Venue>();
    public DbSet<Concert> Concerts => Set<Concert>();
    public DbSet<Concert_Request> ConcertRequests => Set<Concert_Request>();
    public DbSet<Favourite_Concert> FavouriteConcerts => Set<Favourite_Concert>();
    public DbSet<Favourite_Band> FavouriteBands => Set<Favourite_Band>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasIndex(x => x.Email).IsUnique();

        modelBuilder.Entity<Concert>().Property(x => x.TicketPrice).HasPrecision(10, 2);

        modelBuilder.Entity<Favourite_Concert>()
            .HasIndex(x => new { x.UserId, x.ConcertId }).IsUnique();

        modelBuilder.Entity<Favourite_Band>()
            .HasIndex(x => new { x.UserId, x.BandId }).IsUnique();
    }
    
}