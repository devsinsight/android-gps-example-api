using System.ComponentModel.DataAnnotations;
using System.Spatial;

namespace AndroidGPSExample.Domain
{
    public class GeoLocation
    {
        [Key]
        public int Id { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }

    }
}
