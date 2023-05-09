using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Data.DTOs
{
    public class CreateTheaterDTO
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        public int AddressId { get; set; }
    }
}
