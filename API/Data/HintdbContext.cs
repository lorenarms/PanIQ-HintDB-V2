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

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Room>().HasData(new Room
			{
				Id = 1,
				Name = "Wizard"
			});

			modelBuilder.Entity<Puzzle>().HasData(new Puzzle
			{
				Id = 1,
				Name = "Sit on Chair",
				Order = 1,
				RoomId = 1
			});

			modelBuilder.Entity<Hint>().HasData(new Hint
			{
				Id = 1,
				Order = 1,
				Description = "Sit on the chair!",
				PuzzleId = 1
			});
		}

		
	}
}
