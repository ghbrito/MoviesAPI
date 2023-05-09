using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
using MoviesAPI.Data.DTOs;
using MoviesAPI.Models;

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {

        //private static List<Movie> movies = new List<Movie>();
        //private static int ID = 0;

        private MovieContext _context;
        private IMapper _mapper;

        public MovieController(MovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Adds a movie to the database
        /// </summary>
        /// <param name="movieDTO">Object containing the fields required to create a new movie</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">If movie insertion is succeeded</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult AddMovie([FromBody] CreateMovieDTO movieDTO)
        {

            //movie.ID = ID++;
            //movies.Add(movie);

            Movie movie = _mapper.Map<Movie>(movieDTO);

            _context.Movies.Add(movie);
            _context.SaveChanges();
            return CreatedAtAction(nameof(FindMovie), new { id = movie.ID }, movie);

            //Console.WriteLine(movie.Title);
            //Console.WriteLine(movie.Duration);

        }

        //[HttpGet]
        //public IEnumerable<Movie> ReadMovieList()
        //{
        //    return movies;
        //    //return movies.Skip(10).Take(2);
        //}

        [HttpGet]
        public IEnumerable<ReadMovieDTO> ReadMovieList([FromQuery] int skip = 0, [FromQuery] int take = 50,
            [FromQuery] string? nameTheater = null)
        {
            //return movies.Skip(skip).Take(take);
            //return _context.Movies.Skip(skip).Take(take);
            if(nameTheater == null)
            {
                return _mapper.Map<List<ReadMovieDTO>>(_context.Movies.Skip(skip).Take(take).ToList());
            }
            return _mapper.Map<List<ReadMovieDTO>>(_context.Movies.Skip(skip).Take(take).ToList()
                .Where(movie => movie.Sessions.Any(session => session.Theater.Name == nameTheater)).ToList());
        }

        [HttpGet("{id}")]
        public IActionResult FindMovie(int id)
        {
            //var movie = movies.FirstOrDefault(movie => movie.ID == id);
            var movie = _context.Movies.FirstOrDefault(movie => movie.ID == id);
            if (movie == null) return NotFound();
            var movieDTO = _mapper.Map<ReadMovieDTO>(movie);
            return Ok(movieDTO);

        }
        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, [FromBody] UpdateMovieDTO movieDTO)
        {
            var movie = _context.Movies.FirstOrDefault(movie => movie.ID == id);
            if (movie == null) return NotFound();
            _mapper.Map(movieDTO, movie);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateMoviePatch(int id, JsonPatchDocument<UpdateMovieDTO> patch)
        {
            var movie = _context.Movies.FirstOrDefault(movie => movie.ID == id);
            if (movie == null) return NotFound();

            var movieToBePatched = _mapper.Map<UpdateMovieDTO>(movie);

            patch.ApplyTo(movieToBePatched, ModelState);

            if (!TryValidateModel(movieToBePatched))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(movieToBePatched, movie);
            _context.SaveChanges();
            return NoContent();

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            var movie = _context.Movies.FirstOrDefault(
                movie => movie.ID == id);
            if (movie == null) return NotFound();
            _context.Remove(movie);
            _context.SaveChanges();
            return NoContent();
        }

    }

}