using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
	public class Movie
	{
        public int Id { get; set; }

		[Required]
		[Display(Name= "Name")]
        public string Title { get; set; }

		[Required]
		[Display(Name = "Release Date")]
		public DateTime? ReleaseDate { get; set; }

		public DateTime? DateAdded { get; set; }

        public Genre Genre { get; set; }

        [Required(ErrorMessage = "The Genre field is required")]
        [Display(Name = "Genres")]
		public byte GenreId { get; set; }

        [Required(ErrorMessage = "The Number In Stock field is required")]
        [Range(1,20, ErrorMessage = "The field Number in Stock must be between 1 and 20")]
		[Display(Name = "Number In Stock")]
		public int Stock { get; set; }

		public Movie()
		{
		}
	}
}

