using Microsoft.EntityFrameworkCore;
using task1.Models;

namespace task1.Data
{
	public class ApplicationDbContext : DbContext
	{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
            
        }

        public DbSet<Categories> Categories { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder) 
		{
			modelBuilder.Entity<Categories>().HasData(
				new Categories { Id = 1, Name = "Electronics" },
				new Categories { Id = 2, Name = "Clothing" },
				new Categories { Id = 3, Name = "Books" }
			);

		}


	}
}
