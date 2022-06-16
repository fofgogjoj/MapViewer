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
    }
}