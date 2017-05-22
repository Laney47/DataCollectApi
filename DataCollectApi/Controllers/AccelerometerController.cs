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

        // GET: api/AccdataList
        public async Task<IHttpActionResult> Get()
        {
            await Initilization;
            var accdata = await _repo.GetAccDataAsync();
            return Ok(accdata);
        }

        // GET: api/Accdata/5
        public async Task<IHttpActionResult> Get(string id)
        {
            await Initilization;
            var accdata = await _repo.GetAccDataByIdAsync(id);
            if (accdata != null)
                return Ok(accdata);
            return NotFound();
        }



        // POST: api/Accdata
        public async Task<IHttpActionResult> Post(AccelerometerData accdata)
        {
            await Initilization;
            var response = await _repo.CreateAccData(accdata);
            return Ok(response.Resource);
        }

        // PUT: api/Accdata
        public async Task<IHttpActionResult> Put(AccelerometerData accdata)
        {
            await Initilization;
            var response = await _repo.UpdateAccDataAsync(accdata);
            return Ok(response.Resource);
        }

        // Delete: api/Accdata
        public async Task<IHttpActionResult> Delete(string id)
        {
            await Initilization;
            var response = await _repo.DeleteAccDataAsync(id);
            return Ok();
        }
    }
}