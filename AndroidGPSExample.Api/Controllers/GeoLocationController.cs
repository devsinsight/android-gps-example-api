using System;
using System.Collections.Generic;
using System.Linq;
using System.Spatial;
using System.Threading.Tasks;
using AndroidGPSExample.Api.Models;
using AndroidGPSExample.Domain;
using AndroidGPSExample.Domain.Contract;
using Microsoft.AspNetCore.Mvc;

namespace AndroidGPSExample.Api.Controllers
{
    [Route("api/geolocation")]
    public class GeoLocationController : Controller
    {
        private IGeoLocationRepository _repository;
        private IUnitOfWork _unitOfWork;

        public GeoLocationController(IGeoLocationRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]LocationModel location)
        {
            GeoLocation geoLocation = new GeoLocation
            {
                Latitude = location.Latitude,
                Longitude = location.Longitude
            };

            _repository.Add(geoLocation);

            await _unitOfWork.CommitAsync();

            return Ok(location);
        }

    }
}
