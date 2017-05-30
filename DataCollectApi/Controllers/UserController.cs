using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using DataCollectApi.Data;
using System.Threading.Tasks;

namespace DataCollectApi.Controllers
{
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        private RegisterUserRep _repo;

        public UserController()
        {
            Initilization = InitializeAsync();
        }

        public Task Initilization { get; private set; }

        private async Task InitializeAsync()
        {
            _repo = new RegisterUserRep();
            await _repo.Initilization;
        }
        /// <summary>
        /// Get all collections
        /// </summary>
        /// <returns>All collections</returns>
        // GET: api/UserList
        [Route("AllCollections")]
        public async Task<IHttpActionResult> Get()
        {
            await Initilization;
            var users = await _repo.GetUsersAsync();
            return Ok(users);
        }

        /// <summary>
        /// Get all collections of an owner
        /// </summary>
        /// <param name="owner">Specify owner</param>
        /// <returns>All collections of an owner</returns>
        // GET: api/User/5
        [Route("Login")]
        public async Task<IHttpActionResult> GetCollByEmail(string mail, string password)
        {
            await Initilization;
            var users = await _repo.GetUserByMailAsync(mail,password);
            if (users != null)
                return Ok(users);
            return NotFound();
        }

        /// <summary>
        /// Get a collection by ID
        /// </summary>
        /// <param name="id">Specify collection ID</param>
        /// <returns>A collection</returns>
        // GET: api/User/5
        [Route("CollectionById")]
        public async Task<IHttpActionResult> GetCollById(string id)
        {
            await Initilization;
            var accdata = await _repo.GetUserByIdAsync(id);
            if (accdata != null)
                return Ok(accdata);
            return NotFound();
        }


        /// <summary>
        /// Post a collection
        /// </summary>
        /// <param name="users"></param>
        /// <returns>Status code</returns>
        // POST: api/User
        [Route("Register")]
        public async Task<IHttpActionResult> Post(RegisterUserData users)
        {
            await Initilization;
            
            var user = await _repo.CheckIfUserExistAsync(users.email);
            if (user != null)
                return BadRequest();
            
            var response = await _repo.ReigsterUser(users);
            
            return Ok(response.Resource);
        }


        /// <summary>
        /// Update a collection
        /// </summary>
        /// <param name="users"></param>
        /// <returns>Status code</returns>
        // PUT: api/User
        [Route("Update")]
        public async Task<IHttpActionResult> Put(RegisterUserData users)
        {
            await Initilization;
            var response = await _repo.UpdateUserAsync(users);
            return Ok(response.Resource);
        }

        /// <summary>
        /// Delete a collection by ID
        /// </summary>
        /// <param name="id">Specify collection ID</param>
        /// <returns>Status code</returns>
        // Delete: api/User
        [Route("Delete")]
        public async Task<IHttpActionResult> Delete(string id)
        {
            await Initilization;
            var response = await _repo.DeleteUserAsync(id);
            return Ok();
        }
    }
}