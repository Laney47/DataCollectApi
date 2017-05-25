using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataCollectApi.Data;
using System.Threading.Tasks;
using System.Web.Http;

namespace DataCollectApi.Controllers
{
    public class LocationController : ApiController
    {
        private LocationRep _repo;

        public LocationController()
        {
            Initilization = InitializeAsync();
        }

        public Task Initilization { get; private set; }

        private async Task InitializeAsync()
        {
            _repo = new LocationRep();
            await _repo.Initilization;
        }

        // GET: api/LocationList
        public async Task<IHttpActionResult> Get()
        {
            await Initilization;
            var people = await _repo.GetLocationAsync();
            return Ok(people);
        }

        // GET: api/Location/5
        public async Task<IHttpActionResult> Get(string owner)
        {
            await Initilization;
            var location = await _repo.GetLocationByOwnerAsync(owner);
            if (location != null)
                return Ok(location);
            return NotFound();
        }



        // POST: api/Location
        public async Task<IHttpActionResult> Post(LocationData location)
        {
            await Initilization;
            var response = await _repo.CreateLocation(location);
            return Ok(response.Resource);
        }

        // PUT: api/Location
        public async Task<IHttpActionResult> Put(LocationData location)
        {
            await Initilization;
            var response = await _repo.UpdateLocationAsync(location);
            return Ok(response.Resource);
        }

        // Delete: api/Location
        public async Task<IHttpActionResult> Delete(string id)
        {
            await Initilization;
            var response = await _repo.DeleteLocationAsync(id);
            return Ok();
        }
    }
}