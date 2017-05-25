using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using DataCollectApi.Data;
using System.Threading.Tasks;
using System.Web.Http;

namespace DataCollectApi.Controllers
{
    [RoutePrefix("api/Location")]
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

        /// <summary>
        /// Get all collections
        /// </summary>
        /// <returns>All collections</returns>
        // GET: api/LocationList
        [Route("AllCollections")]
        public async Task<IHttpActionResult> Get()
        {
            await Initilization;
            var people = await _repo.GetLocationAsync();
            return Ok(people);
        }

        /// <summary>
        /// Get all collections of an owner
        /// </summary>
        /// <param name="owner">Specify owner</param>
        /// <returns>All collections of an owner</returns>
        // GET: api/Location/5
        [Route("UserCollections")]
        public async Task<IHttpActionResult> GetCollByOwner(string owner)
        {
            await Initilization;
            var location = await _repo.GetLocationByOwnerAsync(owner);
            if (location != null)
                return Ok(location);
            return NotFound();
        }

        /// <summary>
        /// Get a collection by ID
        /// </summary>
        /// <param name="id">Specify collection ID</param>
        /// <returns>A collection</returns>
        // GET: api/Location/5
        [Route("CollectionsById")]
        public async Task<IHttpActionResult> GetCollById(string id)
        {
            await Initilization;
            var location = await _repo.GetLocationByIdAsync(id);
            if (location != null)
                return Ok(location);
            return NotFound();
        }

       


        /// <summary>
        /// Post a collection
        /// </summary>
        /// <param name="location"></param>
        /// <returns>Status code</returns>
        // POST: api/Location
        [Route("PostCollection")]
        public async Task<IHttpActionResult> Post(LocationData location)
        {
            await Initilization;
            var response = await _repo.CreateLocation(location);
            return Ok(response.Resource);
        }

        /// <summary>
        /// Update a collection
        /// </summary>
        /// <param name="location"></param>
        /// <returns>Status code</returns>
        // PUT: api/Location
        [Route("UpdateCollection")]
        public async Task<IHttpActionResult> Put(LocationData location)
        {
            await Initilization;
            var response = await _repo.UpdateLocationAsync(location);
            return Ok(response.Resource);
        }

        /// <summary>
        /// Delete a collection by ID 
        /// </summary>
        /// <param name="id">Specify collection ID</param>
        /// <returns>Status code</returns>
        // Delete: api/Location
        [Route("DeleteCollection")]
        public async Task<IHttpActionResult> Delete(string id)
        {
            await Initilization;
            var response = await _repo.DeleteLocationAsync(id);
            return Ok();
        }
    }
}