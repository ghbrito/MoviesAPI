using Microsoft.EntityFrameworkCore;
using MoviesAPI.Models;

namespace MoviesAPI.Data
{
    public class MovieContext : DbContext
    {

        public MovieContext(DbContextOptions<MovieContext> opts) : base(opts)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Session>()
                .HasKey(session => new { session.MovieId, session.TheaterId });

            builder.Entity<Session>()
                .HasOne(session => session.Theater)
                .WithMany(theater => theater.Sessions)
                .HasForeignKey(session => session.TheaterId);

            builder.Entity<Session>()
                .HasOne(session => session.Movie)
                .WithMany(movie => movie.Sessions)
                .HasForeignKey(session => session.MovieId);

            builder.Entity<Address>()
                .HasOne(address => address.Theater)
                .WithOne(theater => theater.Address)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Theater>()
                .HasOne(theater => theater.Address)
                .WithOne(address => address.Theater)
                .OnDelete(DeleteBehavior.Restrict);

        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Theater> Theaters { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Session> Sessions { get; set; }
    }
}
