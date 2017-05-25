using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using DataCollectApi.Data;
using System.Threading.Tasks;
using System.Web.Http;

namespace DataCollectApi.Controllers
{
    [RoutePrefix("api/Accelerometer")]
    public class AccelerometerController : ApiController
    {
        private AccelerometerRep _repo;

        public AccelerometerController()
        {
            Initilization = InitializeAsync();
        }

        public Task Initilization { get; private set; }

        private async Task InitializeAsync()
        {
            _repo = new AccelerometerRep();
            await _repo.Initilization;
        }
        /// <summary>
        /// Get all collections
        /// </summary>
        /// <returns>All collections</returns>
        // GET: api/AccdataList
        [Route("AllCollections")]
        public async Task<IHttpActionResult> Get()
        {
            await Initilization;
            var accdata = await _repo.GetAccDataAsync();
            return Ok(accdata);
        }

        /// <summary>
        /// Get all collections of an owner
        /// </summary>
        /// <param name="owner">Specify owner</param>
        /// <returns>All collections of an owner</returns>
        // GET: api/Accdata/5
        [Route("UserCollections")]
        public async Task<IHttpActionResult> GetCollByOwner(string owner)
        {
            await Initilization;
            var accdata = await _repo.GetAccDataByOwnerAsync(owner);
            if (accdata != null)
                return Ok(accdata);
            return NotFound();
        }

        /// <summary>
        /// Get a collection by ID
        /// </summary>
        /// <param name="id">Specify collection ID</param>
        /// <returns>A collection</returns>
        // GET: api/Accdata/5
        [Route("CollectionById")]
        public async Task<IHttpActionResult> GetCollById(string id)
        {
            await Initilization;
            var accdata = await _repo.GetAccDataByIdAsync(id);
            if (accdata != null)
                return Ok(accdata);
            return NotFound();
        }


        /// <summary>
        /// Post a collection
        /// </summary>
        /// <param name="accdata"></param>
        /// <returns>Status code</returns>
        // POST: api/Accdata
        [Route("PostCollection")]
        public async Task<IHttpActionResult> Post(AccelerometerData accdata)
        {
            await Initilization;
            var response = await _repo.CreateAccData(accdata);
            return Ok(response.Resource);
        }


        /// <summary>
        /// Update a collection
        /// </summary>
        /// <param name="accdata"></param>
        /// <returns>Status code</returns>
        // PUT: api/Accdata
        [Route("UpdateCollection")]
        public async Task<IHttpActionResult> Put(AccelerometerData accdata)
        {
            await Initilization;
            var response = await _repo.UpdateAccDataAsync(accdata);
            return Ok(response.Resource);
        }

        /// <summary>
        /// Delete a collection by ID
        /// </summary>
        /// <param name="id">Specify collection ID</param>
        /// <returns>Status code</returns>
        // Delete: api/Accdata
        [Route("DeleteCollection")]
        public async Task<IHttpActionResult> Delete(string id)
        {
            await Initilization;
            var response = await _repo.DeleteAccDataAsync(id);
            return Ok();
        }
    }
}