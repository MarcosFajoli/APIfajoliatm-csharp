using APIfajoliatm_csharp.Entities;
using APIfajoliatm_csharp.Persistance;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIfajoliatm_csharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly DBContext _context;

        public AccountController(DBContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            //Retornar todos os usuários da base
            var accounts = _context.Accounts.ToList();
            return Ok(accounts);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            var account = _context.Accounts.SingleOrDefault(a => a.Id == id);
            if (account == null)
            {
                return NotFound();
            }
            return Ok(account);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Post(Account account)
        {
            var client = _context.Clients.SingleOrDefault(c => c.Id == account.ClientId);
            if (client == null)
            {
                return NotFound();
            }
            else
            {
                _context.Accounts.Add(account);
                return CreatedAtAction("GetById", new { id = account.Id }, account);
            }
        }
    }
}
