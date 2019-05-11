using System;
using System.ComponentModel.DataAnnotations;
using AxwayHomeworkApp.Models.Enums;

namespace AxwayHomeworkApp.Models
{
    public class Game
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public Genre Genre { get; set; }

    }
}
