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
							Description = hint.Description

						}).ToList();
		}
	}
}
