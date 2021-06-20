using System.ComponentModel.DataAnnotations;

namespace SkinCareAPI.Dtos
{
    public class SkinCareUpdateDto
    {
        [Required]
        public string IngredientName {get; set;}
        public string Contain {get; set;}

        [Required]
        public string ReasonWhyItsBad {get; set;}
        public string Source {get; set;}
    }
}