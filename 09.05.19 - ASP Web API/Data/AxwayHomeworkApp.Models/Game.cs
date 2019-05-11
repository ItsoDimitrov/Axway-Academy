using System;
using System.ComponentModel.DataAnnotations;

namespace AxwayHomeworkApp.Models
{
    public class Game
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string Genre { get; set; }

    }
}
