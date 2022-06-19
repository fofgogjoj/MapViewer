using MapViewer.Models;
using Microsoft.EntityFrameworkCore;

namespace MapViewer
{
    public class MapViewerContext : DbContext
    {
        public MapViewerContext(DbContextOptions<MapViewerContext> options)
            : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Place> Places { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Place>().HasData(
                    new Place { ID = 1, Text = "Библиотека имени Ленина", Longitude = 37.610489, Latitude = 55.752308 },
                    new Place { ID = 2, Text = "Александровский сад", Longitude = 37.608644, Latitude = 55.75226 },
                    new Place { ID = 3, Text = "Боровицкая", Longitude = 37.609073, Latitude = 55.750509 },
                    new Place { ID = 4, Text = "Казанский собор", Longitude = 37.619327, Latitude = 55.755451 },
                    new Place { ID = 5, Text = "Дом Пашкова", Longitude = 37.608711, Latitude = 55.749679 }
            );
        }
    }
}