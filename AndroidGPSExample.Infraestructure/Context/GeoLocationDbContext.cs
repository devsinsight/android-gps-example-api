using AndroidGPSExample.Domain;
using Microsoft.EntityFrameworkCore;

namespace AndroidGPSExample.Repository.Context
{
    public class GeoLocationDbContext : DbContext
    {
        public GeoLocationDbContext(DbContextOptions<GeoLocationDbContext> options)
           : base(options)
        {
        }

        public virtual DbSet<GeoLocation> GeoLocation { get; set; }
    }
}
