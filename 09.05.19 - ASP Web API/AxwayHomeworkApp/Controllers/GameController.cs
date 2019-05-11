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

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
