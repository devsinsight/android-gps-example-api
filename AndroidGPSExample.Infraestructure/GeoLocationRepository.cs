using AndroidGPSExample.Domain;
using AndroidGPSExample.Domain.Contract;
using AndroidGPSExample.Repository.Configuration;
using AndroidGPSExample.Repository.Context;

namespace AndroidGPSExample.Repository
{
    public class GeoLocationRepository : Repository<GeoLocation>, IGeoLocationRepository
    {
        public GeoLocationRepository(GeoLocationDbContext context) : base(context) { }
    }
}
