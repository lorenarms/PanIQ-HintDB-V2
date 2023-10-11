using API.Entities;

namespace API.Repositories.Contracts
{
	public interface IHintRepository
	{
		Task<IEnumerable<Hint>> GetHints();
		Task<Hint> GetHintById(int id);
		Task<IEnumerable<Puzzle>> GetPuzzles();
		Task<Puzzle> GetPuzzlesById(int id);
		Task<IEnumerable<Room>> GetRooms();
		Task<Room> GetRoomsById(int id);

	}
}
