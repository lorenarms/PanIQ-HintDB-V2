using API.Data;
using API.Entities;
using API.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class PuzzleRepository : IPuzzleRepository
    {
	    private readonly HintdbContext _context;

	    public PuzzleRepository(HintdbContext context)
	    {
		    _context = context;
	    }
	    public async Task<IEnumerable<Puzzle>> GetAllPuzzles()
	    {
			var puzzles = await _context.Puzzles
				.Include(r => r.Room)
				.ToListAsync();
			return puzzles;
		}

	    public async Task<IEnumerable<Puzzle>> GetPuzzlesByRoomId(int roomId)
	    {
			var puzzles = await _context.Puzzles
				.Where(x => x.RoomId == roomId)
				.Include(p => p.Room)
				.ToListAsync();
			return puzzles;
		}

	    public async Task<Puzzle> GetPuzzleById(int id)
	    {
			var puzzle = await _context.Puzzles
				.Include(r => r.Room)
				.SingleOrDefaultAsync(p => p.Id == id);
			return puzzle;
		}

	    public async Task<Puzzle> AddNewPuzzle(Puzzle newPuzzle)
	    {
		    _context.Puzzles.Add(newPuzzle);
			await _context.SaveChangesAsync();
			return newPuzzle;
	    }
    }
}
