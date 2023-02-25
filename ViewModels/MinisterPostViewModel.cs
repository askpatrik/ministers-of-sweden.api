using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ministers_of_sweden.api.ViewModels
{
    public class MinisterPostViewModel
    {
        //Dekorera require för att kontrollera indatan. 

        [Required(ErrorMessage = "Name must be specificed.")]
        public string Name {get; set;}
        public string Type{ get; set; }
        public int Born {get; set;}
        public string Sex { get; set; }
        public bool HasAcademicDegree { get; set; }
        public string Party {get; set;}
        public string Department {get; set;}
        public string AcademicField {get; set;} 
    }
}