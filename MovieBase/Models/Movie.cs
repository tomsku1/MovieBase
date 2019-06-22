using System;
using System.ComponentModel.DataAnnotations;

namespace MovieBase.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The movie name cannot be blank")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Please enter a movie name between 1 and 50 characters in length")]
        public string Name { get; set; }
        public string Description { get; set; }
        public int? CategoryID { get; set; }
        [Required(ErrorMessage = "Please insert date when you watched the movie")]
        public DateTime WhenWatched { get; set; }
        [Required(ErrorMessage = "Please insert your rate")]
        public int MyRate { get; set; }
        public virtual Category Category { get; set; }
    }

   
}