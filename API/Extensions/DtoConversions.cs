using API.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Models.DTOs;

namespace API.Extensions
{
	public static class DtoConversions
	{
		public static IEnumerable<HintDto> ConvertToDto(this IEnumerable<Hint> hints, IEnumerable<Puzzle> puzzles, IEnumerable<Room> rooms)
		{
			return (from hint in hints
					join puzzle in puzzles on hint.PuzzleId equals puzzle.Id
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

		public static IEnumerable<PuzzleDto> ConvertToDto(this IEnumerable<Puzzle> puzzles, int roomId)
		{
			return (from puzzle in puzzles
					select new PuzzleDto()
					{
						Id = puzzle.Id,
						RoomId = roomId,
						RoomName = puzzle.Room.Name,
						Name = puzzle.Name,
						Description = puzzle.Description,
						Order = puzzle.Order

					}).ToList();
		}

		public static IEnumerable<PuzzleDto> ConvertToDto(this IEnumerable<Puzzle> puzzles)
		{
			return (from puzzle in puzzles
				select new PuzzleDto()
				{
					Id = puzzle.Id,
					RoomId = puzzle.Room.Id,
					RoomName = puzzle.Room.Name,
					Name = puzzle.Name,
					Description = puzzle.Description,
					Order = puzzle.Order

				}).ToList();
		}

		public static IEnumerable<HintDto> ConvertToDto(this IEnumerable<Hint> hints)
		{
			List<HintDto> result = new List<HintDto>();
			foreach (var hint in hints)
			{
				var hintDto = new HintDto()
				{
					Id = hint.Id,
					PuzzleId = hint.PuzzleId,
					PuzzleName = hint.Puzzle.Name,
					RoomId = hint.Puzzle.RoomId,
					RoomName = hint.Puzzle.Room.Name,
					Description = hint.Description,
					Order = hint.Order,
					Image = null
				};
				result.Add(hintDto);
			}

			return result;
		}

		public static Puzzle ConvertToPuzzle(this PuzzleDto puzzleDto)
		{
			var puzzle = new Puzzle()
			{
				RoomId = puzzleDto.RoomId,
				Name = puzzleDto.Name,
				Description = puzzleDto.Description,
				Order = puzzleDto.Order
			};
			return puzzle;
		}

		public static PuzzleDto ConvertToPuzzleDto(this Puzzle puzzle)
		{
			var puzzleDto = new PuzzleDto()
			{
				Id = puzzle.Id,
				Name = puzzle.Name,
				Description = puzzle.Description,
				Order = puzzle.Order,
				RoomId = puzzle.RoomId,
				RoomName = puzzle.Room.Name
			};
			return puzzleDto;
		}
	}
}
