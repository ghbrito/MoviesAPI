namespace MoviesAPI.Data.DTOs
{
    public class ReadTheaterDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ReadAddressDto Address { get; set; }
        public ICollection<ReadSessionDto> Sessions { get; set; }
    }
}
