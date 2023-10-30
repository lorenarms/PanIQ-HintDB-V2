using Models.DTOs;

namespace Client.Services.Contracts
{
	public interface IHintService
	{
		Task<IEnumerable<HintDto>> GetHints(int puzzleId);
		Task<IEnumerable<RoomDto>> GetRooms();
		Task<IEnumerable<PuzzleDto>> GetPuzzlesByRoomId(int roomId);
	}
}
