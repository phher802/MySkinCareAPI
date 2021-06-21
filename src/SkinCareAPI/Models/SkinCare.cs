using System.ComponentModel.DataAnnotations;

namespace SkinCareAPI.Models
{
    public class SkinCare
    {
        [Key]
        [Required]
        public int Id {get; set;}

        [Required]
        public string IngredientName {get; set;}

        public string Contain {get; set;}

        [Required]
        [MaxLength(250)]
        public string ReasonWhyItsBad {get; set;}

        public string Source {get; set;}
    }

}