//namespace MoviesAPI.Data.DTOs
using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Data.DTOs
{
    public class CreateMovieDTO
    {
        
        [Required(ErrorMessage = "Movie title required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Movie genre required")]
        [MaxLength(20, ErrorMessage = "Movie Genre lenght cannot exceed 20 characters")]
        public string Genre { get; set; }
        [Required(ErrorMessage = "Movie duration required")]
        [Range(60, 600, ErrorMessage = "Movie duration must be between 60 and 600 minutes")]
        public int Duration { get; set; }

    }
}
