
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MySportsPlaylist.Domain.Entities;

namespace MySportsPlaylist.Infrastructure.Data;
public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
{
    public DbSet<Match> Matches { get; set; }
    public DbSet<Playlist> Playlists { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Playlist>().HasKey(p => new { p.UserId, p.MatchId });

        builder.Entity<Playlist>()
            .HasOne(p => p.User)
            .WithMany(u => u.Playlists)
            .HasForeignKey(p => p.UserId);

        builder.Entity<Playlist>()
            .HasOne(p => p.Match)
            .WithMany()
            .HasForeignKey(p => p.MatchId);
    }
}

