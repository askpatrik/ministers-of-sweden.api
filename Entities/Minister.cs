using System.ComponentModel.DataAnnotations.Schema;

namespace ministers_of_sweden.api.Entities
{
    public class Minister
    {
        public int Id { get; set; }
        public string Post { get; set; }
        public string Name { get; set; }
        public int Born {get; set;}
        public string Sex { get; set; }
        public string ImgUrl { get; set; }
        public string YearsInPolitics{get; set;}


        public int DepartmentId {get; set;}
        [ForeignKey("DepartmentId")]
        public Department department {get; set;}

         public int EducationId {get; set;}
        [ForeignKey("DepartmentId")]
        public Education education {get; set;}


    }
}