using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ministers_of_sweden.api.Data;
using ministers_of_sweden.api.Entities;
using ministers_of_sweden.api.ViewModels;

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

        [HttpPost()]

        public async Task<IActionResult> Add(MinisterPostViewModel minister)
        {
            if (!ModelState.IsValid) return ValidationProblem();

            //Kolla om ministern redan har lagts till i systemet. I API returnerar vi då ett korrekt statuskod. 
            //If-satsen säger att om c.Name är model.Name, lägg till den i C. DÅ är den inte null. 
            if (await _context.Ministers.SingleOrDefaultAsync(c => c.Name == minister.Name) is not null)         
                return BadRequest($"Minister med namnet {minister.Name} finns redan i systemet");
            

            //Hämta department, party och academic field om det stämmer överens med indatan.
            var politicalDepartment = await _context.Departments.SingleOrDefaultAsync(c => c.Name.ToUpper() == minister.Department.ToUpper());
            if (politicalDepartment is null) return NotFound($"Could not find department named {minister.Department}");
                

            var politicalParty = await _context.Parties.SingleOrDefaultAsync(c => c.Name.ToUpper() == minister.Party.ToUpper());
            if (politicalParty is null) return NotFound($"Could not find party named {minister.Party}");

            var academics = await _context.AcademicFields.SingleOrDefaultAsync(c => c.Name.ToUpper() == minister.AcademicField.ToUpper());
            if (academics is null) return NotFound($"Could not find academic field named {minister.AcademicField}");


            var ministerToAdd = new Minister{
                Name = minister.Name,
                Type = minister.Type,
                Born = minister.Born,
                Sex = minister.Sex,
                HasAcademicDegree = minister.HasAcademicDegree,
                academicField = academics,
                party = politicalParty,
                department = politicalDepartment
            };
            //Try catch för databasanrops-delen

            try
            {
            await _context.Ministers.AddAsync(ministerToAdd);
            if (await _context.SaveChangesAsync() > 0) 
            
            return CreatedAtAction(nameof(GetById), new{id = ministerToAdd.Id}, 
            new {
                Id = ministerToAdd.Id,
                Name = ministerToAdd.Name,
             
            });
            //Nånting fel med EF core
            return StatusCode(500, "Internal Server Error");
            }

            //Ej visa servererrors till klient!
            catch (Exception ex)
            {
                //Loggning till db som hanterar debug info
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
         
        }
    }
    
}