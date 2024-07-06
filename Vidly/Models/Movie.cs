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

		[Display(Name = "Release Date")]
		public DateTime? ReleaseDate { get; set; }

		public DateTime? DateAdded { get; set; }

		public Genre Genre { get; set; }

		[Display(Name = "Genres")]
		public byte GenreId { get; set; }

		[Display(Name = "Number In Stock")]
		public int Stock { get; set; }

		public Movie()
		{
		}
	}
}

