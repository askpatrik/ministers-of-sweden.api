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
    [Route("api/v1/departments")]
    
    public class DepartmentsController : ControllerBase
    {
        
         private readonly MinistersOfSwedenContext _context;

        public DepartmentsController(MinistersOfSwedenContext context)
        {
            _context = context;
        }


       [HttpGet()]
        public async Task<IActionResult>ListAll(){

            var result = await _context.Departments.ToListAsync();

            //Returnerar 200 resultat, json style (standard)
            return Ok(result);

        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _context.Departments.FindAsync(id);

            return Ok(result);
        }

        //krävs extra url segment för att undivka ambigious match med ovanstående get
         [HttpGet("name/{name}")]
        public async Task<IActionResult> GetByBorn(string name)
        {
            var result = await _context.Departments.SingleOrDefaultAsync(c => c.Name == name);

            return Ok(result);
        }


    }
}