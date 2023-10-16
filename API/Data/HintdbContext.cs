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

			// ROOMS

			modelBuilder.Entity<Room>().HasData(new Room
			{
				Id = 1,
				Name = "Time Machine",
				NameGraphic = "https://paniqescaperoom.com/img/paniq/room-name-the-time-machine-2.png",
				Image = "https://paniqescaperoom.com/img/paniq/room-bg-the-time-machine-card-2.webp"
			});

			modelBuilder.Entity<Room>().HasData(new Room
			{
				Id = 2,
				Name = "Atlantis",
				NameGraphic = "https://paniqescaperoom.com/img/paniq/room-name-atlantis-rising-2.png",
				Image = "https://paniqescaperoom.com/img/paniq/room-bg-atlantis-rising-card-2.webp",
			});

			modelBuilder.Entity<Room>().HasData(new Room
			{
				Id = 3,
				Name = "Haunted",
				NameGraphic = "https://paniqescaperoom.com/img/paniq/room-name-haunted-manor-2.png",
				Image = "https://paniqescaperoom.com/img/paniq/room-bg-haunted-manor-card-2.webp"
			});

			modelBuilder.Entity<Room>().HasData(new Room
			{
				Id = 4,
				Name = "Wizard",
				NameGraphic = "https://paniqescaperoom.com/img/paniq/room-name-wizard-trials-2.png",
				Image = "https://paniqescaperoom.com/img/paniq/room-bg-wizard-trials-card-2.webp"
			});

			modelBuilder.Entity<Room>().HasData(new Room
			{
				Id = 5,
				Name = "Zombie",
				NameGraphic = "https://paniqescaperoom.com/img/paniq/room-name-zombie-outbreak-2.png",
				Image = "https://paniqescaperoom.com/img/paniq/room-bg-zombie-outbreak-card-2.webp"
			});
			
			modelBuilder.Entity<Room>().HasData(new Room
			{
				Id = 6,
				Name = "Casino",
				NameGraphic = "https://paniqescaperoom.com/img/paniq/room-name-casino-heist-2.png",
				Image = "https://paniqescaperoom.com/img/paniq/room-bg-casino-heist-card-2.webp"
			});

			modelBuilder.Entity<Room>().HasData(new Room
			{
				Id = 7,
				Name = "Morning After",
				NameGraphic = "https://paniqescaperoom.com/img/paniq/room-name-the-morning-after-2.png",
				Image = "https://paniqescaperoom.com/img/paniq/room-bg-the-morning-after-card-2.webp"
			});

			// PUZZLES

			modelBuilder.Entity<Puzzle>().HasData(new Puzzle
			{
				Id = 1,
				RoomId = 4,
				Order = 1,
				Name = "Sit on Chair",
				Description = "Player must sit on the wizard's chair"
			});

			modelBuilder.Entity<Hint>().HasData(new Hint
			{
				Id = 1,
				PuzzleId = 1,
				Order = 1,
				Description = "Sit on the chair!"
			});
		}

		
	}
}
