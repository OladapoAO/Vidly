using System;
using Vidly.Models;
namespace Vidly.ViewModel
{
	public class RandomViewModel
	{
		public List<Movie> Movies { get; set; }
		public List<Customer> Customers { get; set; }

		public RandomViewModel()
		{
		}
	}
}

