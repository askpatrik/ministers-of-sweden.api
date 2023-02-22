using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ministers_of_sweden.api.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public string Name {get ; set;}
    }
}