using API.Entities;
using Models.DTOs;

namespace API.Extensions
{
	public static class DtoConversions
	{
		public static IEnumerable<HintDto> ConvertToDto(this IEnumerable<Hint> hints, IEnumerable<Puzzle> puzzles, IEnumerable<Room> rooms)
		{
			return (from hint in hints
					join puzzle in puzzles
					on hint.PuzzleId equals puzzle.Id
					join room in rooms on puzzle.RoomId equals room.Id
					select new HintDto
					{
						Id = hint.Id,
						PuzzleId = puzzle.Id,
						PuzzleName = puzzle.Name,
						RoomId = room.Id,
						RoomName = room.Name,
						Order = hint.Order,
						Description = hint.Description,
						Image = room.Image,

					}).ToList();
		}

		public static IEnumerable<RoomDto> ConvertToDto(this IEnumerable<Room> rooms)
		{
			return (from room in rooms
				select new RoomDto
				{
					Id = room.Id,
					Image = room.Image,
					Name = room.Name,
					NameGraphic = room.NameGraphic
				}).ToList();
		}
	}
}
