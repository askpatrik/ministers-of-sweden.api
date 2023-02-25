using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ministers_of_sweden.api.ViewModels
{
    public class MinisterBaseViewModel
    {
        
    
         [Required(ErrorMessage = "Type must be specificed.")]
        public string Type{ get; set; }
        [Required(ErrorMessage = "BirthYear must be specificed.")]
        public int Born {get; set;}
        [Required(ErrorMessage = "Sex must be specificed.")]
        public string Sex { get; set; }
        public bool HasAcademicDegree { get; set; } = false;
         [Required(ErrorMessage = "Party must be specificed.")]
        public string Party {get; set;}
         [Required(ErrorMessage = "Department must be specificed.")]
        public string Department {get; set;}
         [Required(ErrorMessage = "Academic Field must be specificed.")]
        public string AcademicField {get; set;} 
        public string ImgUrl { get; set; }
    }
}