using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie.Data;
using Movie.Models;

namespace Movie.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class MovieAppController : ControllerBase
    {
        private readonly ApiContext _context;

        public MovieAppController(ApiContext context)
        {
            _context = context;
        }

        // Create Movie
        [HttpPost]
        public JsonResult Create(MovieApp movie)
        {
            _context.Movies.Add(movie);

            // save changes
            _context.SaveChanges();

            return new JsonResult(Ok(movie));
        }
        // list all movies
        [HttpGet("/all")]
        public JsonResult GetAll()
        {
            var result = _context.Movies.ToList();
            return new JsonResult(Ok(result));
        }
        // list one movie
        [HttpGet]
        public JsonResult Get(int id)
        {
            var result = _context.Movies.Find(id);

            if (result == null)
                return new JsonResult(NotFound());

            return new JsonResult(Ok(result));
        }
        // edit movie
        [HttpPut]
        public JsonResult Edit(MovieApp movie)
        {
            var movieInDb = _context.Movies.Find(movie.Id);

            if (movieInDb == null)
                return new JsonResult(NotFound());

            movieInDb.MovieType = movie.MovieType;
            movieInDb.MovieName = movie.MovieName;

            // save changes
            _context.SaveChanges();

            return new JsonResult(Ok(movie));
        }
        // delete movie
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            var result = _context.Movies.Find(id);

            if (result == null)
                return new JsonResult(NotFound());

            // delete movie
            _context.Movies.Remove(result);

            // save changes
            _context.SaveChanges();

            return new JsonResult(Ok(result)); 
        }
    }
}
