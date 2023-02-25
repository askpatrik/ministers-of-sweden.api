using System.ComponentModel.DataAnnotations;

namespace ministers_of_sweden.api.ViewModels
{
    public class MinisterUpdateModel: MinisterBaseViewModel
    {
      
        [Required(ErrorMessage = "Name must be specificed.")]
        public int Id {get; set;}
       
}}