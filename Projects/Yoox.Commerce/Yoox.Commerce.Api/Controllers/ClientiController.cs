using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Yoox.Commerce.Dal.TeamA.DTOs;
using Yoox.Commerce.Dal.TeamA.Repositories;

namespace Yoox.Commerce.Api.Controllers
{
    public class ClientiController : ApiController
    {
        protected ClienteRepository rp = new ClienteRepository();
        public IHttpActionResult Get(int id)
        {
            var cliente = rp.Get(id);

            if(cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }

        public IHttpActionResult Post(ClienteDTOAdd cliente)
        {
            if (ModelState.IsValid)
            {
                var id = rp.Add(cliente);
                return Created("/api/Clienti/" + id, cliente);
            }

            return BadRequest(ModelState);
        }
    }
}
