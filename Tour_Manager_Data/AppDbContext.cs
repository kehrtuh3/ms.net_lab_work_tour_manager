namespace Tour_Manager_Data;
using Microsoft.EntityFrameworkCore;
using Tour_Manager_Data.Entities;
public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users => Set<User>();
    public DbSet<MusicBand> Bands => Set<MusicBand>();
    public DbSet<Venue> Venues => Set<Venue>();
    public DbSet<Concert> Concerts => Set<Concert>();
    public DbSet<ConcertRequest> ConcertRequests => Set<ConcertRequest>();
    public DbSet<FavouriteConcert> FavouriteConcerts => Set<FavouriteConcert>();
    public DbSet<FavouriteBand> FavouriteBands => Set<FavouriteBand>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder
            .Entity<User>()
            .ToTable("Users");
        modelBuilder
            .Entity<User>()
            .Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(255);
        modelBuilder
            .Entity<User>()
            .Property(x => x.Name)
            .HasMaxLength(100);
        modelBuilder
            .Entity<User>()
            .Property(x => x.Surname)
            .HasMaxLength(100);
        modelBuilder
            .Entity<User>()
            .Property(x => x.Role)
            .HasConversion<string>()
            .HasMaxLength(20);
        modelBuilder
            .Entity<User>()
            .HasIndex(x => x.Email)
            .IsUnique();
        
        modelBuilder
            .Entity<MusicBand>()
            .ToTable("Bands");
        modelBuilder
            .Entity<MusicBand>()
            .Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(150);
        modelBuilder
            .Entity<MusicBand>()
            .Property(x => x.Genre)
            .HasMaxLength(100);
        modelBuilder
            .Entity<MusicBand>()
            .Property(x => x.PopularityLvl)
            .HasConversion<string>()
            .HasMaxLength(20);
        modelBuilder.Entity<MusicBand>()
            .HasOne(b => b.Manager)
            .WithMany(u => u.ManagedBands)
            .HasForeignKey("ManagerId")
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder
            .Entity<Venue>()
            .ToTable("Venues", t => t.HasCheckConstraint("CK_Venue_Capacity", "\"Capacity\" > 0"));
        modelBuilder
            .Entity<Venue>()
            .Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(150);
        modelBuilder
            .Entity<Venue>()
            .Property(x => x.City)
            .IsRequired()
            .HasMaxLength(100);
        modelBuilder
            .Entity<Venue>()
            .Property(x => x.Address)
            .HasMaxLength(255);
        modelBuilder
            .Entity<Venue>()
            .HasOne(v => v.Manager)
            .WithMany(u => u.ManagedVenues)
            .HasForeignKey("ManagerId")
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder
            .Entity<ConcertRequest>()
            .ToTable("ConcertRequests");
        modelBuilder
            .Entity<ConcertRequest>()
            .Property(x => x.Status)
            .HasConversion<string>()
            .HasMaxLength(20);
        
        modelBuilder
            .Entity<ConcertRequest>()
            .HasOne(r => r.Band)
            .WithMany(b => b.Requests)
            .HasForeignKey("BandId")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder
            .Entity<ConcertRequest>()
            .HasOne(r => r.Venue)
            .WithMany(v => v.Requests)
            .HasForeignKey("VenueId")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder
            .Entity<ConcertRequest>()
            .HasOne(r => r.RequestedBy)
            .WithMany(u => u.SentRequests)
            .HasForeignKey("RequestedById")
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder
            .Entity<Concert>()
            .ToTable("Concerts", t => t.HasCheckConstraint("CK_Concert_Price", "\"TicketPrice\" >= 0"));
        modelBuilder
            .Entity<Concert>()
            .Property(x => x.Name)
            .IsRequired().HasMaxLength(200);
        modelBuilder
            .Entity<Concert>()
            .Property(x => x.TicketPrice)
            .HasPrecision(10, 2);
        modelBuilder
            .Entity<Concert>()
            .Property(x => x.Status)
            .HasConversion<string>().
            HasMaxLength(20);
        
        modelBuilder
            .Entity<Concert>()
            .HasOne(c => c.Request)
            .WithOne(r => r.Concert)
            .HasForeignKey<Concert>("RequestId")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder
            .Entity<Concert>()
            .HasOne(c => c.CancelledByUser)
            .WithMany(u => u.CancelledConcerts)
            .HasForeignKey("CancelledByUserId")
            .OnDelete(DeleteBehavior.SetNull);
        
        modelBuilder
            .Entity<FavouriteConcert>()
            .ToTable("FavouriteConcerts");
        modelBuilder
            .Entity<FavouriteConcert>()
            .HasIndex("UserId", "ConcertId")
            .IsUnique();
        modelBuilder
            .Entity<FavouriteConcert>()
            .HasOne(fc => fc.User)
            .WithMany(u => u.FavouriteConcerts)
            .HasForeignKey("UserId")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder
            .Entity<FavouriteConcert>()
            .HasOne(fc => fc.Concert)
            .WithMany(c => c.FavouritedBy)
            .HasForeignKey("ConcertId")
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder
            .Entity<FavouriteBand>()
            .ToTable("FavouriteBands");
        modelBuilder
            .Entity<FavouriteBand>()
            .HasIndex("UserId", "BandId")
            .IsUnique();
        modelBuilder
            .Entity<FavouriteBand>()
            .HasOne(fb => fb.User)
            .WithMany(u => u.FavouriteBands)
            .HasForeignKey("UserId")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder
            .Entity<FavouriteBand>()
            .HasOne(fb => fb.Band)
            .WithMany(b => b.FavouritedBy)
            .HasForeignKey("BandId")
            .OnDelete(DeleteBehavior.Cascade);
    }
}

