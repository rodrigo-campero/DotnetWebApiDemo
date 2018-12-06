using DotnetWebApiDemo.Domain.Entities;
using DotnetWebApiDemo.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;

namespace DotnetWebApiDemo.Service.WebAPI.Controllers
{
    [RoutePrefix("client")]
    public class ClientController : ApiController
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        /// <summary>
        /// Get all clients
        /// </summary>
        /// <remarks>Get all clients registered on application</remarks>
        /// <response code="200">Ok</response>
        [Route("")]
        [HttpGet]
        [ResponseType(typeof(IEnumerable<Client>))]
        public OkNegotiatedContentResult<IEnumerable<Client>> Get(string search = "")
        {
            return Ok(_clientService.Search(x => string.Concat(x.FirstName, " ", x.LastName).Contains(search)));
        }

        /// <summary>
        /// Get client
        /// </summary>
        /// <param name="id">Client id</param>
        /// <remarks>Get client by id registered on application</remarks>
        /// <response code="200">Ok</response>
        [Route("{id:int:min(1)}")]
        [HttpGet]
        [ResponseType(typeof(Client))]
        public OkNegotiatedContentResult<Client> Get(int id)
        {
            return Ok(_clientService.GetById(id));
        }

        /// <summary>
        /// Register a new client on application
        /// </summary>
        /// <param name="client">New client to register</param>
        /// <remarks>Adds new client to application</remarks>
        /// <response code="200">Ok</response>
        /// <response code="400">Bad Request</response>
        [Route("")]
        [HttpPost]
        [ResponseType(typeof(Client))]
        public IHttpActionResult Post([FromBody]Client client)
        {
            if (ModelState.IsValid)
            {
                return Ok(_clientService.Add(client));
            }

            return BadRequest();
        }

        /// <summary>
        /// Edit application client
        /// </summary>
        /// <param name="id">Client id</param>
        /// <param name="client">Client to edit</param>
        /// <remarks>Update client</remarks>
        /// <response code="200">Ok</response>
        /// <response code="400">Bad Request</response>
        [Route("{id:int:min(1)}")]
        [HttpPut]
        [ResponseType(typeof(Client))]
        public IHttpActionResult Put([FromUri]int id, [FromBody]Client client)
        {
            if (ModelState.IsValid)
            {
                client.ClientId = id;
                return Ok(_clientService.Update(client));
            }

            return BadRequest();
        }

        /// <summary>
        /// Delete application client
        /// </summary>
        /// <param name="id">Client id</param>
        /// <remarks>Delete client</remarks>
        /// <response code="200">Ok</response>
        /// <response code="400">Bad Request</response>
        [Route("{id:int:min(1)}")]
        [HttpDelete]
        [ResponseType(typeof(Client))]
        public IHttpActionResult Delete([FromUri]int id)
        {
            if (ModelState.IsValid)
            {
                _clientService.Remove(id);
                return Ok("Success");
            }

            return BadRequest();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _clientService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
