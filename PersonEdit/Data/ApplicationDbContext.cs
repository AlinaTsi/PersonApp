using Microsoft.EntityFrameworkCore;
using PersonEdit.Models;

namespace PersonEdit.Data
{
	public class ApplicationDbContext:DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}

		public DbSet<Person> Persons { get; set; }
	}
}
