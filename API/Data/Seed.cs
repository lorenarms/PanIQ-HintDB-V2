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

			await context.Rooms.AddRangeAsync(rooms);
			await context.SaveChangesAsync();

			var wizard = context.Rooms.Single(r => r.Name == "Wizard");

			var puzzles = new List<Puzzle>
			{
				new Puzzle()
				{
					RoomId = wizard.Id,
					Order = 1,
					Name = "Knocking Chest",
					Description = "Player must repeat the knock from the bookshelf on the chest"
				},

				new Puzzle()
				{
					RoomId = wizard.Id,
					Order = 2,
					Name = "Sit on Chair",
					Description = "Player sits on the Wizard chair and activates the book on the desk"
				},
				new Puzzle()
				{
					RoomId = wizard.Id,
					Order = 3,
					Name = "Spirits Board",
					Description = "Players must place the planchette on the board on the desk"
				},

				new Puzzle()
				{
					RoomId = wizard.Id,
					Order = 4,
					Name = "Code Panel",
					Description = "Using the symbols revealed by the planchette, players enter the code"
				},

				new Puzzle()
				{
					RoomId = wizard.Id,
					Order = 5,
					Name = "Spell Chart",
					Description = "Select the correct spells as revealed by the potions"
				}
			};

			await context.Puzzles.AddRangeAsync(puzzles);
			await context.SaveChangesAsync();
			
			var knockingChest = context.Puzzles.Single(p => p.Name == "Knocking Chest");
			
			var hints = new List<Hint>
			{
				new Hint()
				{
					PuzzleId = knockingChest.Id,
					Order = 1,
					Description = "I REALLY SHOULDN’T GIVE YOU TOO MUCH GUIDANCE – THIS IS A TEST, AFTER ALL – BUT I SUGGEST YOU BEGIN BY EXAMINING THE CHEST. AS I RECALL, IT CAME WITH AN INSTRUCTION MANUAL; I’M SURE IT’S ON THESE SHELVES SOMEWHERE…"
				},

				new Hint()
				{
					PuzzleId = knockingChest.Id,
					Order = 2,
					Description = "THE SPIRIT THAT HOLDS THE CHEST CLOSED EXPECTS YOU TO USE THE SECRET KNOCK."
				},

				new Hint()
				{
					PuzzleId = knockingChest.Id,
					Order = 3,
					Description = "LOCATE THE MANUAL ON THE SHELF – IT BEARS A LABEL THAT IS SIMILAR TO THE SYMBOL FOUND ON THE CHEST."
				},

				new Hint()
				{
					PuzzleId = knockingChest.Id,
					Order = 4,
					Description = "THE MANUAL CAN BE TRIGGERED BY PRESSING THE SPINE INWARD – THE CHEST WILL RESPOND BY DEMONSTRATING THE RHYTHM OF THE SECRET KNOCK."
				},

				new Hint()
				{
					PuzzleId = knockingChest.Id,
					Order = 5,
					Description = "THE RHYTHM WILL BE BEST HEARD IF YOU KNOCK DIRECTLY ON THE SYMBOL."
				},

				new Hint()
				{
					PuzzleId = knockingChest.Id,
					Order = 6,
					Description = "THE RHYTHM WILL BE BEST HEARD IF YOU RAP DIRECTLY ON THE SYMBOL."
				},

				new Hint()
				{
					PuzzleId = knockingChest.Id,
					Order = 8,
					Description = "NO NEED TO BE CAREFUL WITH THE OLD CHEST - RAP FIRMLY."
				},

				new Hint()
				{
					PuzzleId = knockingChest.Id,
					Order = 7,
					Description = "NO NEED TO BE CAREFUL WITH THE OLD CHEST - RAP FIRMLY, DIRECTLY ON THE SYMBOL."
				},
				new Hint()
				{
					PuzzleId = knockingChest.Id,
					Order = 9,
					Description = "IMAGE OF THE CHEST."
				},

				new Hint()
				{
					PuzzleId = knockingChest.Id,
					Order = 10,
					Description = "IMAGE OF THE SYMBOL."
				},

				new Hint()
				{
					PuzzleId = knockingChest.Id,
					Order = 11,
					Description = "IMAGE OF THE BOOK"
				},

				new Hint()
				{
					PuzzleId = knockingChest.Id,
					Order = 12,
					Description = "IMAGE OF THE SYMBOL + BOOK"
				},
			};

			
			await context.Hints.AddRangeAsync(hints);

			await context.SaveChangesAsync();
		}
	}
}
