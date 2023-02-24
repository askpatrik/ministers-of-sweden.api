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
        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetByName (string name)
        {
            var result = await _context.Parties.SingleOrDefaultAsync(c => c.Name == name);
            return Ok(result);
        }
        // http://localhost:3000/api/v1/parties/M/ministers
        [HttpGet("{name}/ministers")]
        public async Task<IActionResult> ListMinistersByParty(string name)
        {
            var result = await _context.Parties
            .Where(c => c.Name.ToUpper().StartsWith(name.ToUpper()))
            .Select(p => new 
            {
                Party = p.Name,
                Minister = p.Ministers.Select(m => new 
                    {
                        Name = m.Name,
                        PoliticalPost = m.Type
                    }).ToList()
            }).ToListAsync();
          
            
            return Ok(result);

        }
    }
}