using API.Data;
using API.Entities;
using API.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
	public class HintRepository : IHintRepository
	{
		//TODO: move each entity thing to it's own repository

		private readonly HintdbContext _context;
		public HintRepository(HintdbContext context)
		{
			_context = context;
		}
		public async Task<IEnumerable<Hint>> GetAllHints()
		{
			var hints = await _context.Hints.ToListAsync();
			return hints;
		}

		public Task<Hint> GetHintById(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<Hint>> GetHintsByPuzzleId(int id)
		{
			var hints = await _context.Hints.Where(x => x.PuzzleId == id)
				.Include(p => p.Puzzle)
				.ThenInclude(r => r.Room).ToListAsync();
			
			return hints;
		}

		public async Task<Hint> AddNewHintToPuzzle(Hint hint)
		{
			_context.Hints.Add(hint);
			await _context.SaveChangesAsync();
			return hint;
		}



		// PUZZLE REPOSITORY FUNCTION


		public async Task<Puzzle> AddNewPuzzleToRoom(Puzzle puzzle)
		{
			_context.Puzzles.Add(puzzle);
			await _context.SaveChangesAsync();
			return puzzle;
		}








	}
}
