﻿using APIfajoliatm_csharp.Entities;
using APIfajoliatm_csharp.Persistance;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIfajoliatm_csharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly DBContext _context;

        public ClientController(DBContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            //Retornar todos os usuários da base
            var clients = _context.Clients.ToList();
            return Ok(clients);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            var client = _context.Clients.SingleOrDefault(u => u.Id == id);
            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Post(Client client)
        {
            _context.Clients.Add(client);
            return CreatedAtAction("GetById", new { id = client.Id }, client);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Put(int id, string name)
        {
            var clientReturned = _context.Clients.SingleOrDefault(c => c.Id == id);

            if (clientReturned == null)
            {
                return NotFound();
            }

            clientReturned.Update(name);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Delete(int id)
        {
            var clientReturned = _context.Clients.SingleOrDefault(a => a.Id == id);

            if (clientReturned == null)
            {
                return NotFound();
            }

            _context.Clients.Remove(clientReturned);
            return NoContent();
        }
    }
}
