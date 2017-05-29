using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using DataCollectApi.Data;

namespace DataCollectApi.Controllers
{
    [RoutePrefix("api/Heartrate")]
    public class HeartrateController : ApiController
    {
        private HeartrateRep _repo;

        public HeartrateController()
        {
            Initilization = InitializeAsync();
        }

        public Task Initilization { get; private set; }

        private async Task InitializeAsync()
        {
            _repo = new HeartrateRep();
            await _repo.Initilization;
        }
        /// <summary>
        /// Get all collections
        /// </summary>
        /// <returns>All collections</returns>
        // GET: api/HeartdataList
        [Route("AllCollections")]
        public async Task<IHttpActionResult> Get()
        {
            await Initilization;
            var heartdata = await _repo.GetHeartrateAsync();
            return Ok(heartdata);
        }

        /// <summary>
        /// Get all collections of an owner
        /// </summary>
        /// <param name="owner">Specify owner</param>
        /// <returns>All collections of an owner</returns>
        // GET: api/Heartdata/5
        [Route("UserCollections")]
        public async Task<IHttpActionResult> GetCollByOwner(string owner)
        {
            await Initilization;
            var heartdata = await _repo.GetHeartrateByOwnerAsync(owner);
            if (heartdata != null)
                return Ok(heartdata);
            return NotFound();
        }

        /// <summary>
        /// Get a collection by ID
        /// </summary>
        /// <param name="id">Specify collection ID</param>
        /// <returns>A collection</returns>
        // GET: api/Heartdata/5
        [Route("CollectionById")]
        public async Task<IHttpActionResult> GetCollById(string id)
        {
            await Initilization;
            var heartdata = await _repo.GetHeartrateByIdAsync(id);
            if (heartdata != null)
                return Ok(heartdata);
            return NotFound();
        }


        /// <summary>
        /// Post a collection
        /// </summary>
        /// <param name="heartdata"></param>
        /// <returns>Status code</returns>
        // POST: api/Heartdata
        [Route("PostCollection")]
        public async Task<IHttpActionResult> Post(HeartrateData heartdata)
        {
            await Initilization;
            var response = await _repo.CreateHeartrate(heartdata);
            return Ok(response.Resource);
        }


        /// <summary>
        /// Update a collection
        /// </summary>
        /// <param name="heartdata"></param>
        /// <returns>Status code</returns>
        // PUT: api/Heartdata
        [Route("UpdateCollection")]
        public async Task<IHttpActionResult> Put(HeartrateData heartdata)
        {
            await Initilization;
            var response = await _repo.UpdateHeartrateAsync(heartdata);
            return Ok(response.Resource);
        }

        /// <summary>
        /// Delete a collection by ID
        /// </summary>
        /// <param name="id">Specify collection ID</param>
        /// <returns>Status code</returns>
        // Delete: api/Heartdata
        [Route("DeleteCollection")]
        public async Task<IHttpActionResult> Delete(string id)
        {
            await Initilization;
            var response = await _repo.DeleteHeartrateAsync(id);
            return Ok();
        }
    }
}