using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Data.DTOs
{
    public class UpdateTheaterDTO
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
    }
}
