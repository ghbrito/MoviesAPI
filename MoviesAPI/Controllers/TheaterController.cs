using AutoMapper;
using MoviesAPI.Data.DTOs;
using MoviesAPI.Data;
using MoviesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class TheaterController : ControllerBase
    {
        private MovieContext _context;
        private IMapper _mapper;

        public TheaterController(MovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpPost]
        public IActionResult AddTheater([FromBody] CreateTheaterDTO theaterDTO)
        {
            Theater theater = _mapper.Map<Theater>(theaterDTO);
            _context.Theaters.Add(theater);
            _context.SaveChanges();
            return CreatedAtAction(nameof(FindTheater), new { Id = theater.Id }, theaterDTO);
        }

        [HttpGet]
        public IEnumerable<ReadTheaterDTO> ReadTheaterList([FromQuery] int? addressId = null)
        {

            //var listTheathers = _mapper.Map<List<ReadTheaterDTO>>(_context.Theaters.ToList());
            //return listTheathers;
            if(addressId == null)
            {
                return _mapper.Map<List<ReadTheaterDTO>>(_context.Theaters.ToList());
            }
            return _mapper.Map<List<ReadTheaterDTO>>(_context.Theaters.FromSqlRaw($"SELECT Id, Name, AddressId FROM theaters where theaters.AddressId = {addressId}").ToList());

        }

        [HttpGet("{id}")]
        public IActionResult FindTheater(int id)
        {
            Theater theater = _context.Theaters.FirstOrDefault(theater => theater.Id == id);
            if (theater != null)
            {
                ReadTheaterDTO theaterDTO = _mapper.Map<ReadTheaterDTO>(theater);
                return Ok(theaterDTO);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTheater(int id, [FromBody] UpdateTheaterDTO theaterDTO)
        {
            Theater theater = _context.Theaters.FirstOrDefault(theater => theater.Id == id);
            if (theater == null)
            {
                return NotFound();
            }
            _mapper.Map(theaterDTO, theater);
            _context.SaveChanges();
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteTheater(int id)
        {
            Theater theater = _context.Theaters.FirstOrDefault(theater => theater.Id == id);
            if (theater == null)
            {
                return NotFound();
            }
            _context.Remove(theater);
            _context.SaveChanges();
            return NoContent();
        }

    }
}