using API.Data;
using API.Entities;
using API.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using Models.DTOs;

namespace API.Repositories
{
	public class RoomRepository : IRoomRepository
	{
		private readonly HintdbContext _context;

		public RoomRepository(HintdbContext context)
		{
			_context = context;
		}
		public async Task<IEnumerable<Room>> GetAllRooms()
		{
			var rooms = await _context.Rooms.ToListAsync();
			return rooms;
		}

		public async Task<Room> GetRoomById(int roomId)
		{
			var room = await _context.Rooms.FirstOrDefaultAsync(x => x.Id == roomId);
			return room;
		}
	}
}
