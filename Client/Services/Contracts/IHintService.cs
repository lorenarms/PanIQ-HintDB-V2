using Models.DTOs;

namespace Client.Services.Contracts
{
	public interface IHintService
	{
		Task<IEnumerable<HintDto>> GetItems();
		Task<IEnumerable<RoomDto>> GetRooms();
	}
}
