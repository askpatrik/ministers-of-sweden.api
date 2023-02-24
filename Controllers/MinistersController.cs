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
        //Enkel listning av ministrar
        //Kan $"{v.department.Name} {v.party.Name}"
        public async Task<IActionResult>ListAll(){

            var result = await _context.Ministers
            .Select(v => new {
                Identitet = v.Id,
                Minister = v.Type,
                Name = v.Name,
                Born = v.Born,    
                Department = v.department.Name,       
                Party = v.party.Name,         
                ImageUrl = v.ImgUrl
            })
           
            .ToListAsync();

            //Returnerar 200 resultat, json style (standard)
            return Ok(result);

        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _context.Ministers
            .Select(v => new 
            {
                ID = v.Id,
                PoliticalPost = v.Type,
                Name = v.Name,
                Born = v.Born,    
                Sex = v.Sex,
                HasAcademicDegree = v.HasAcademicDegree,
                Department = v.department.Name,       
                Party = v.party.Name,         
                ImageUrl = v.ImgUrl
            })
            .SingleOrDefaultAsync(c => c.ID == id);

            return Ok(result);
        }

        //krävs extra url segment för att undivka ambigious match med ovanstående get
         [HttpGet("type/{type}")]
        public async Task<IActionResult> GetByPoliticalPost(string type)
        {
            var result = await _context.Ministers.Select(v => new 
            {
                ID = v.Id,
                PoliticalPost = v.Type,
                Name = v.Name,
                Born = v.Born,    
                Sex = v.Sex,
                HasAcademicDegree = v.HasAcademicDegree,
                Department = v.department.Name,       
                Party = v.party.Name,         
                ImageUrl = v.ImgUrl
            })
            .SingleOrDefaultAsync(c => c.PoliticalPost == type);

            return Ok(result);
        }
    }
}