namespace SkinCareAPI.Dtos
{
    public class SkinCareReadDto
    {
        public int Id {get; set;}
        public string IngredientName {get; set;}

        public string Contain {get; set;}

        public string ReasonWhyItsBad {get; set;}

        public string Source {get; set;}
    }

}