using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AxwayHomeworkApp.Data;
using AxwayHomeworkApp.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AxwayHomeworkApp.Controllers
{
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        private readonly AxwayHomeworkAppContext _context;
        public GameController(AxwayHomeworkAppContext context)
        {
            this._context = context;
        }
        // GET: api/<controller>/id
        [HttpGet("{id}")]
        public ActionResult<Game> GetById(int id)
        {
            var gameById = _context.Games.FirstOrDefault(g => g.Id == id);
            if (gameById == null)
            {
                return NotFound();
            }

            return gameById;
        }
        // GET: api/<controller>/name
        [HttpGet("byname/{name}")]
        public ActionResult<Game> GetByName(string name)
        {
            var gameByName = this._context.Games.FirstOrDefault(g => g.Name == name);
            if (gameByName == null)
            {
                return StatusCode(404);
            }
            return gameByName;
        }
        // GET: api/<controller>/all
        [HttpGet("all")]
        public List<Game> AllGames(string name)
        {
            var allGames = this._context.Games.ToList();
            
            return allGames;
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult<Game> CreateGame([FromBody] Game game)
        {
            var isExist = this._context.Games.Any(g => g.Name == game.Name);
            if (!isExist)
            {
                this._context.Add(game);
                this._context.SaveChanges();
                return CreatedAtAction(nameof(AllGames), new { id = game.Id }, game);

            }

            return StatusCode(400);
        }

        // PUT api/<controller>/id
        [HttpPut("{id}")]
        public ActionResult<Game> Modify(int id, [FromBody]Game game) // Modify
        {
            var isExist = this._context.Games.Any(g => g.Id == id);
            if (!isExist)
            {
                return StatusCode(404);

            }

            var gameToModify = this._context.Games.FirstOrDefault(g => g.Id == id);
            gameToModify.Name = game.Name;
            gameToModify.Genre = game.Genre;
            gameToModify.ReleaseDate = game.ReleaseDate;
            _context.SaveChanges();
            return NoContent();


        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public ActionResult<Game> DeleteGame(int id)
        {
            var gameToDelete = this._context.Games.FirstOrDefault(g => g.Id == id);
            if (gameToDelete == null)
            {
                return StatusCode(404);
            }

            this._context.Games.Remove(gameToDelete);
            this._context.SaveChanges();
            return NoContent();
        }
    }
}
