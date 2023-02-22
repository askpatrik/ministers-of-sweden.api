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

            //Returnerar 200 resultat, json style
            return Ok(result);

        }
    }
}