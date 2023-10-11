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

		public Task<IEnumerable<Puzzle>> GetPuzzles()
		{
			throw new NotImplementedException();
		}

		public Task<Puzzle> GetPuzzlesById(int id)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<Room>> GetRooms()
		{
			throw new NotImplementedException();
		}

		public Task<Room> GetRoomsById(int id)
		{
			throw new NotImplementedException();
		}
	}
}
