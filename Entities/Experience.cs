using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ministers_of_sweden.api.Entities
{
    public class Experience
    {
        public int Id { get; set; }
        public string Description {get; set; }
        public int YearsInPolitics {get; set;}
        
    }
}