using API.Entities;

namespace API.Repositories.Contracts
{
	public interface IPuzzleRepository
	{
		Task<IEnumerable<Puzzle>> GetAllPuzzles();
		Task<IEnumerable<Puzzle>> GetPuzzlesByRoomId(int id);
		Task<Puzzle> GetPuzzleById(int id);
		
	}
}
