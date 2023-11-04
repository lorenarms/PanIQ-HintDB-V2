using System.Reflection;
using Models.DTOs;

namespace Client.Services.Contracts
{
	public interface IHintService
	{
		Task<IEnumerable<HintDto>> GetHints(int puzzleId);
		Task<IEnumerable<RoomDto>> GetRooms();
		Task<IEnumerable<PuzzleDto>> GetPuzzles();
		Task<IEnumerable<PuzzleDto>> GetPuzzlesByRoomId(int roomId);
		Task<PuzzleDto> GetPuzzleById(int puzzleId);
		Task<PuzzleDto> AddNewPuzzleToRoom(PuzzleDto puzzle);
		Task<MultiPuzzleDto> AddMultipleNewPuzzlesToRoom(MultiPuzzleDto puzzles);
	}
}
