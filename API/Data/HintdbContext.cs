using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
	public class HintdbContext : DbContext
	{
		public HintdbContext(DbContextOptions<HintdbContext> options) : base(options)
		{

			
		}


		public DbSet<Room> Rooms { get; set; }
		public DbSet<Puzzle> Puzzles { get; set; }
		public DbSet<Hint> Hints { get; set; }
		
		
	}
}
