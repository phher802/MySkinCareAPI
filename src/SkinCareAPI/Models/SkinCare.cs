using System.ComponentModel.DataAnnotations;

namespace SkinCareAPI.Models
{
    public class SkinCare
    {
        [Key]
        [Required]
        public int Id {get; set;}

        [Required]
        public string Ingredient {get; set;}

        [Required]
        public string Purpose {get; set;}

        [Required]
        public string Contain {get; set;}

        public string Source {get; set;}
    }

}