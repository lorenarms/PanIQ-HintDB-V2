using System.Runtime.Serialization;
using API.Entities;

namespace API.Data
{
	public class Seed
	{
		public static async Task SeedData(HintdbContext context)
		{
			if (context.Rooms.Any() || context.Puzzles.Any() || context.Hints.Any()) return;

			var rooms = new List<Room>
			{
				new Room
				{
					//Id = 1,
					Name = "Time Machine",
					NameGraphic = "https://paniqescaperoom.com/img/paniq/room-name-the-time-machine-2.png",
					Image = "https://paniqescaperoom.com/img/paniq/room-bg-the-time-machine-card-2.webp"
				},
				new Room
				{
					//Id = 2,
					Name = "Atlantis",
					NameGraphic = "https://paniqescaperoom.com/img/paniq/room-name-atlantis-rising-2.png",
					Image = "https://paniqescaperoom.com/img/paniq/room-bg-atlantis-rising-card-2.webp",
				},
				new Room
				{
					//Id = 3,
					Name = "Haunted",
					NameGraphic = "https://paniqescaperoom.com/img/paniq/room-name-haunted-manor-2.png",
					Image = "https://paniqescaperoom.com/img/paniq/room-bg-haunted-manor-card-2.webp"
				},
				new Room()
				{
					//Id = 4,
					Name = "Wizard",
					NameGraphic = "https://paniqescaperoom.com/img/paniq/room-name-wizard-trials-2.png",
					Image = "https://paniqescaperoom.com/img/paniq/room-bg-wizard-trials-card-2.webp"
				},
				new Room()
				{
					//Id = 5,
					Name = "Zombie",
					NameGraphic = "https://paniqescaperoom.com/img/paniq/room-name-zombie-outbreak-2.png",
					Image = "https://paniqescaperoom.com/img/paniq/room-bg-zombie-outbreak-card-2.webp"
				},
				new Room()
				{
					//Id = 6,
					Name = "Casino",
					NameGraphic = "https://paniqescaperoom.com/img/paniq/room-name-casino-heist-2.png",
					Image = "https://paniqescaperoom.com/img/paniq/room-bg-casino-heist-card-2.webp"
				},
				new Room()
				{
					//Id = 7,
					Name = "Morning After",
					NameGraphic = "https://paniqescaperoom.com/img/paniq/room-name-the-morning-after-2.png",
					Image = "https://paniqescaperoom.com/img/paniq/room-bg-the-morning-after-card-2.webp"
				}
			};

			var puzzles = new List<Puzzle>
			{
				new Puzzle()
				{
					//Id = 1,
					RoomId = 4,
					Order = 1,
					Name = "Sit on Chair",
					Description = "Player must sit on the wizard's chair"
				}
			};

			var hints = new List<Hint>
			{
				new Hint()
				{
					//Id = 1,
					PuzzleId = 1,
					Order = 1,
					Description = "Sit on the chair!"
				}
			};

			await context.Rooms.AddRangeAsync(rooms);
			await context.Puzzles.AddRangeAsync(puzzles);
			await context.Hints.AddRangeAsync(hints);

			await context.SaveChangesAsync();
		}
	}
}
