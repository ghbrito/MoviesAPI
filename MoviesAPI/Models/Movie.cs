//using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Models
{
    public class Movie
    {
        //[Required(ErrorMessage = "Movie ID required")]
        [Key]
        [Required]
        public int ID { get; set; }
        [Required(ErrorMessage = "Movie title required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Movie genre required")]
        [StringLength(20, ErrorMessage = "Movie Genre lenght cannot exceed 20 characters")]
        public string Genre { get; set; }
        [Required(ErrorMessage = "Movie duration required")]
        [Range(60, 600, ErrorMessage = "Movie duration must be between 60 and 600 minutes")]
        public int Duration { get; set; }
        public virtual ICollection<Session> Sessions { get; set; }

    }
}