using Models.DTOs;

namespace Client.Services.Contracts
{
	public interface IRoomService
	{
		Task<IEnumerable<RoomDto>> GetRooms();
		Task<RoomDto> GetRoom(int roomId);
	}
}
