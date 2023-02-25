using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ministers_of_sweden.api.ViewModels
{
    public class MinisterPostViewModel: MinisterBaseViewModel
    {
        //Dekorera require för att kontrollera indatan. 

        [Required(ErrorMessage = "Name must be specificed.")]
        public string Name {get; set;}
      

    }
}