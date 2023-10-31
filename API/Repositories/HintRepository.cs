using API.Data;
using API.Entities;
using API.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
	public class HintRepository : IHintRepository
	{
		private HintdbContext _context;
		public HintRepository(HintdbContext context)
		{
			_context = context;
		}
		public async Task<IEnumerable<Hint>> GetHints()
		{
			var hints = await _context.Hints.ToListAsync();
			return hints;
		}

		public Task<Hint> GetHintById(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<Hint> AddNewHintToPuzzle(Hint hint)
		{
			_context.Hints.Add(hint);
			await _context.SaveChangesAsync();
			return hint;
		}

		public async Task<IEnumerable<Hint>> GetPuzzleHintsById(int id)
		{
			var hints = await _context.Hints.Where(x => x.PuzzleId == id)
				.Include(p => p.Puzzle)
				.ThenInclude(r => r.Room).ToListAsync();
			
			return hints;
		}

		public async Task<IEnumerable<Puzzle>> GetPuzzles()
		{
			var puzzles = await _context.Puzzles.ToListAsync();
			return puzzles;
		}

		public async Task<Puzzle> AddNewPuzzleToRoom(Puzzle puzzle)
		{
			_context.Puzzles.Add(puzzle);
			await _context.SaveChangesAsync();
			return puzzle;
		}

		public async Task<IEnumerable<Puzzle>> GetPuzzlesById(int roomId)
		{
			var puzzles = await _context.Puzzles.Where(x => x.RoomId == roomId)
				.Include(p => p.Room).ToListAsync();
			return puzzles;
		}

		public async Task<IEnumerable<Room>> GetRooms()
		{
			var rooms = await _context.Rooms.ToListAsync();
			return rooms;
		}

		public async Task<Room> GetRoomsById(int id)
		{
			var room = await _context.Rooms.FirstOrDefaultAsync(x => x.Id == id);
			return room;
		}
	}
}
