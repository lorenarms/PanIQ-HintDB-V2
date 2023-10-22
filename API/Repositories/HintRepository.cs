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

		public async Task<IEnumerable<Puzzle>> GetPuzzles()
		{
			var puzzles = await _context.Puzzles.ToListAsync();
			return puzzles;
		}

		public async Task<IEnumerable<Puzzle>> GetPuzzlesById(int roomId)
		{
			var puzzles = await _context.Puzzles.Where(x => x.RoomId == roomId).ToListAsync();
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
