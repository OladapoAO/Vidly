using System;
using Vidly.Models;
namespace Vidly.ViewModel
{
	public class MovieFormViewModel
	{
        public IEnumerable<Genre> Genres { get; set; }
		public Movie Movie { get; set; }

	}
}

