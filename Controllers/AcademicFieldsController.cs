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
    [Route("api/v1/academicfields")]
    public class AcademicFieldsController : ControllerBase
    {
        private readonly MinistersOfSwedenContext _context;

        public AcademicFieldsController(MinistersOfSwedenContext context)
        {
            _context = context;
        }


       [HttpGet()]
        public async Task<IActionResult>ListAll(){

            var result = await _context.AcademicFields.ToListAsync();

            //Returnerar 200 resultat, json style (standard)
            return Ok(result);

        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _context.AcademicFields.FindAsync(id);

            return Ok(result);
        }

        //krävs extra url segment för att undivka ambigious match med ovanstående get
         [HttpGet("name/{name}")]
        public async Task<IActionResult> GetByBorn(string name)
        {
            var result = await _context.AcademicFields.SingleOrDefaultAsync(c => c.Name == name);

            return Ok(result);
        }
        [HttpGet("{name}/ministers")]
        public async Task<IActionResult> GetMinistersByAcademicField(string name)
        {
        var result = await _context.AcademicFields
        .Where(c => c.Name.ToUpper().StartsWith(name.ToUpper()))
        .Select(a => new {
            AcademicArea = a.Name,
            Minister = a.Ministers.Select(m => new{

                    Name = m.Name,
                    MinisterType = m.Type,
                    Sex = m.Sex
            }
            ).ToList()
        })
        .ToListAsync();

        return Ok(result);
        }
    
    }
}