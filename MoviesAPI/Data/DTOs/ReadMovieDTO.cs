namespace MoviesAPI.Data.DTOs
{
    public class ReadMovieDTO
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Duration { get; set; }
        public DateTime LastRead { get; set; } = DateTime.Now;
        public ICollection<ReadSessionDto> Sessions { get; set; }

    }
}
