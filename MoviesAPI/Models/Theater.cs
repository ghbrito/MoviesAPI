using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Models
{
    public class Theater
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        public int AddressId { get; set; }
        public virtual Address Address { get; set; }
        public virtual ICollection<Session> Sessions { get; set; }
    }
}
