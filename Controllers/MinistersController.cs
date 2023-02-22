using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ministers_of_sweden.api.Data;

namespace ministers_of_sweden.api.Controllers
{
    //Basendpoint
    [ApiController]
    [Route("api/v1/ministers")]
    public class MinistersController : ControllerBase
    {
       
        private readonly MinistersOfSwedenContext _context;

        public MinistersController(MinistersOfSwedenContext context)
        {
            _context = context;
        }

        [HttpGet()]
        public async Task<IActionResult>ListAll(){

            var result = await _context.Ministers.ToListAsync();

            //Returnerar 200 resultat, json style (standard)
            return Ok(result);

        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _context.Ministers.FindAsync(id);

            return Ok(result);
        }

        //krävs extra url segment för att undivka ambigious match med ovanstående get
         [HttpGet("partyid/{partyid}")]
        public async Task<IActionResult> GetByBorn(int partyid)
        {
            var result = await _context.Ministers.SingleOrDefaultAsync(c => c.PartyId == partyid);

            return Ok(result);
        }
    }
}