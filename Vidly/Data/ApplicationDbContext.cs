using System;
using Vidly.Models;
using Microsoft.EntityFrameworkCore;

namespace Vidly.Data
{
	public class ApplicationDbContext : DbContext
	{

        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Movie> Movies { get; set; } = null!;
        public DbSet<MemberShipType> MemberShipType { get; set; } = null!;
        public DbSet<Genre> Genre { get; set; } = null!;

        public ApplicationDbContext()
		{
		}

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Host=localhost; Port=5432; Database=Vidly; Username=postgres; Password=oladapo; Include Error Detail=True;");
        }


    }
}

