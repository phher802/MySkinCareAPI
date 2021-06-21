using System.ComponentModel.DataAnnotations;

namespace SkinCareAPI.Dtos
{
    public class SkinCareCreateDto
    {
        [Required]
        public string IngredientName {get; set;}

        public string Contain {get; set;}

        [Required]
         [MaxLength(250)]
        public string ReasonWhyItsBad {get; set;}

        public string Source {get; set;}
    }
}