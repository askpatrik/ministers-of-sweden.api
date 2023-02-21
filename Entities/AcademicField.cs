using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ministers_of_sweden.api.Entities
{
    public class AcademicField: BaseEntity
    {   
     public ICollection<Minister> Ministers {get; set;}

    }
}