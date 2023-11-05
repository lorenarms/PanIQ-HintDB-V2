using Models.DTOs;

namespace Client.Services.Contracts
{
	public interface IPuzzleService
	{
		Task<IEnumerable<PuzzleDto>> GetPuzzles();
		Task<IEnumerable<PuzzleDto>> GetPuzzlesByRoom(int roomId);
		Task<PuzzleDto> GetPuzzleById(int id);
		Task<PuzzleDto> AddNewPuzzleToRoom(PuzzleDto puzzleDto, int roomId);
	}
}
