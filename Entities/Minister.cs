using System.ComponentModel.DataAnnotations.Schema;

namespace ministers_of_sweden.api.Entities
{
    public class Minister: BaseEntity
    {
        public string Type { get; set; }
        public int Born {get; set;}
        public string Sex { get; set; }
        public string ImgUrl { get; set; }
        public bool HasAcademicDegree { get; set; }
       

        public int DepartmentId {get; set;}
        [ForeignKey("DepartmentId")]
        public Department department {get; set;}

        public int AcademicFieldId {get; set;}
        [ForeignKey("AcademicFieldId")]
        public AcademicField academicField {get; set;}

        public int PartyId {get; set;}
        [ForeignKey("PartyId")]
        public Party party {get; set;}


    }
}