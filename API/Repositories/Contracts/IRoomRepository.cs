using API.Entities;

namespace API.Repositories.Contracts
{
	public interface IRoomRepository
	{
		Task<IEnumerable<Room>> GetAllRooms();
		Task<Room> GetRoomById(int id);

	}
}
