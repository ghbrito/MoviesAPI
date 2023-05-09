using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Models
{
    public class Session
    {
        
        public int? MovieId { get; set; }
        public virtual Movie Movie { get; set; }
        public int? TheaterId { get; set; }
        public virtual Theater Theater { get; set; }
    }
}
