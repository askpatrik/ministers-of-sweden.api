using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ministers_of_sweden.api.Data;

namespace ministers_of_sweden.api.Controllers
{
    [ApiController]
    [Route("api/v1/parties")]
    public class PartiesController : ControllerBase
    {
        private readonly MinistersOfSwedenContext _context;

        public PartiesController(MinistersOfSwedenContext context)
        {
            _context = context;
        }
        
        [HttpGet()]
        public async Task<IActionResult> ListAll()
        {
            var result = await _context.Parties.ToListAsync();

            return Ok(result);
            
        }
         [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _context.Parties.FindAsync(id);

            return Ok(result);
            
        }
    }
}